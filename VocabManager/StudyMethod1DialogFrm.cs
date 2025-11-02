using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VocabManager
{
    public partial class StudyMethod1DialogFrm : Form
    {
        public StudyMethodChoosingDialogFrm Parent { get; set; }
        private List<string> _words;
        private List<Meaning> _meaningsOfCurrentWord;

        private int _currentWordIdx = 0;
        private string _currentWord = string.Empty;
        private Word _currentWordObj;
        private StudyPlan _studyPlanOfCurrentWord;
        private DbManager _dbManager = DbManager.GetInstance();

        private DictionaryApi _dicApi { get; set; }

        public StudyMethod1DialogFrm(StudyMethodChoosingDialogFrm parent, List<string> words)
        {
            InitializeComponent();
            InitFrm();

            Parent = parent;

            // Randomly shuffle selected words
            _words = Utils.Shuffle(words);

            _currentWord = _words[_currentWordIdx];
            _currentWordObj = _dbManager.Select_Word(_currentWord);
            _studyPlanOfCurrentWord = _dbManager.Select_StudyPlans(_currentWord);
            _meaningsOfCurrentWord = _dbManager.Select_Meanings(_currentWord);
            _dicApi = new DictionaryApi();

            // Play pronunciation
            PlayPronunciation(_currentWord);

            // Temporary way: Pre-load the next word to prevent lagging
            //if (_words.Count > _currentWordIdx + 1)
            //{
            //    PreLoadPronunciation(_words[_currentWordIdx + 1]);
            //}

            UpdateUi();
        }

        void PreLoadPronunciation(string word)
        {
            PreLoadPronunciation_InNewThread(word);
        }

        async void PreLoadPronunciation_InNewThread(string word)
        {
            await Task.Run(() => { _dicApi.PreLoadPronunciation(word, PRONUNCIATION_COUNTRY_2.US); });
        }

        void PlayPronunciation(string text)
        {
            PlayPronunciation_InNewThread(text);
        }

        async void PlayPronunciation_InNewThread(string text)
        {
            await Task.Run(() => { _dicApi.PlayPronunciation_2(text, PRONUNCIATION_COUNTRY_2.US); });
        }

        private void InitFrm()
        {
            //////////////////// Color Mark Combobox /////////////////
            var items = new List<string>();
            items.Add(COLOR_MARK.WHITE);
            items.Add(COLOR_MARK.YELLOW);
            items.Add(COLOR_MARK.GREEN);
            items.Add(COLOR_MARK.RED);
            Cbb_ColorMark.Items.AddRange(items.ToArray());
        }

        private bool ChangeToNextWord()
        {
            // Go to the next word
            _currentWordIdx++;
            if (_currentWordIdx >= _words.Count)
            {
                MessageBox.Show("Finished!", "", MessageBoxButtons.OK);
                return false;
            }
            _currentWord = _words[_currentWordIdx];
            _currentWordObj = _dbManager.Select_Word(_currentWord);
            _studyPlanOfCurrentWord = _dbManager.Select_StudyPlans(_currentWord);
            _meaningsOfCurrentWord = _dbManager.Select_Meanings(_currentWord);

            // Update UI for the next word
            UpdateUi();

            // Play pronunciation
            PlayPronunciation(_currentWord);

            // Temporary way: Pre-load the next word to prevent lagging
            //if (_words.Count > _currentWordIdx + 1)
            //{
            //    PreLoadPronunciation(_words[_currentWordIdx + 1]);
            //}

            return true;
        }

        private void UpdateUi()
        {
            Lbl_Word.Text = _currentWord;

            if (!String.IsNullOrEmpty(_currentWordObj.note) && !String.IsNullOrWhiteSpace(_currentWordObj.note))
            {
                Lbl_Note.Text = _currentWordObj.note;
                Lbl_Note.Visible = true;
            }
            else
            {
                Lbl_Note.Visible = false;
            }

            Cbb_ColorMark.SelectedItem = _studyPlanOfCurrentWord.color;
            Lbl_StudiedCountValue.Text = _studyPlanOfCurrentWord.studiedCount.ToString();

            Lbl_WordTypeResult.Text = String.Empty;

            // Show or hide examples
            for (int i = 0; i < _meaningsOfCurrentWord.Count; i++)
            {
                var meaning = _meaningsOfCurrentWord[i];
                if (String.IsNullOrEmpty(meaning.example))
                {
                    LLbl_Example.Visible = false;
                    Btn_Example_PlayPronunciation_US.Visible = false;
                }
                else
                {
                    LLbl_Example.Visible = true;
                    Btn_Example_PlayPronunciation_US.Visible = true;
                    break;
                }
            }

            // Display current page count
            Lbl_PageCount.Text = String.Format("{0}/{1}", _currentWordIdx + 1, _words.Count);
        }

        private void Btn_NextWord_Click(object sender, EventArgs e)
        {
            // Update DB of the just-studied word
            UpdateDb();

            // Go to the next word
            if (!ChangeToNextWord())
            {
                return;
            }
        }

        private void UpdateDb()
        {
            string lastStudiedTime = DateTime.Now.ToString(Constants.DATETIME_FORMAT);  // current time
            string nextStudiedTime = string.Empty;                                      // FIXME

            int studiedCount = _studyPlanOfCurrentWord.studiedCount + 1;
            string note1 = _studyPlanOfCurrentWord.note1;
            string note2 = _studyPlanOfCurrentWord.note2;

            _dbManager.Update_InTable_StudyPlan(_currentWord,
                                                Cbb_ColorMark.SelectedItem.ToString(),
                                                lastStudiedTime,
                                                nextStudiedTime,
                                                studiedCount,
                                                note1,
                                                note2);
        }

        private void Btn_Show_Click(object sender, EventArgs e)
        {
            var wordDefinitionDialog = new WordDefinitionDialogFrm(Parent.Parent, _currentWord);
            wordDefinitionDialog.Display();
            wordDefinitionDialog.Show();
        }

        private string GetCurrentWordTypes()
        {
            string types = String.Empty;

            for (int i = 0; i < _meaningsOfCurrentWord.Count; i++)
            {
                var meaning = _meaningsOfCurrentWord[i];
                types += (i < _meaningsOfCurrentWord.Count - 1) ? meaning.wordType + ", " : meaning.wordType;
            }

            return types;
        }

        private void LLbl_WordType_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Lbl_WordTypeResult.Text = GetCurrentWordTypes();
        }

        private void LLbl_Topic_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string hint = String.Empty;

            for (int i = 0; i < _meaningsOfCurrentWord.Count; i++)
            {
                var meaning = _meaningsOfCurrentWord[i];
                hint += String.Format("{0}. {1}\n", i+1, meaning.topic);
            }

            MessageBox.Show(hint, "", MessageBoxButtons.OK);
        }

        private void LLbl_Example_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string hint = String.Empty;

            for (int i = 0; i < _meaningsOfCurrentWord.Count; i++)
            {
                var meaning = _meaningsOfCurrentWord[i];
                hint += String.Format("{0}.\n{1}\n\n", i+1, meaning.example);
            }

            MessageBox.Show(hint, "", MessageBoxButtons.OK);
        }

        private void Btn_Example_PlayPronunciation_US_Click(object sender, EventArgs e)
        {
            string hint = String.Empty;

            for (int i = 0; i < _meaningsOfCurrentWord.Count; i++)
            {
                var meaning = _meaningsOfCurrentWord[i];
                hint += String.Format("{0}.\n{1}\n\n", i + 1, meaning.example);
            }

            // Play examples
            PlayPronunciation(hint);

            MessageBox.Show(hint, "", MessageBoxButtons.OK);
        }
    }
}
