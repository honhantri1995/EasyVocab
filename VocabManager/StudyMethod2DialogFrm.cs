using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VocabManager
{
    public partial class StudyMethod2DialogFrm : Form
    {
        public StudyMethodChoosingDialogFrm Parent { get; set; }
        private List<string> _words;
        private List<Word> _wordObjs = new List<Word>();
        private List<Meaning> _meanings = new List<Meaning>();

        private int _currentMeaningIdx = 0;
        private Meaning _currentMeaning;
        private Word _currentWord;
        private DbManager _dbManager = DbManager.GetInstance();
        private bool _isPlayedWord = false;

        private DictionaryApi _dicApi { get; set; }

        public StudyMethod2DialogFrm(StudyMethodChoosingDialogFrm parent, List<string> words)
        {
            InitializeComponent();

            Parent = parent;
            _words = words;

            _dicApi = new DictionaryApi();

            GetWordsAndMeanings();

            if (_meanings.Count > 0)
            {
                _currentMeaning = _meanings[_currentMeaningIdx];

                _currentWord = GetWord(_currentMeaning.word);

                // Update UI for the first word
                UpdateUi();

                // Temporary way: Pre-load other words to prevent lagging
                PreLoadPronunciation(_currentMeaning.word);
            }
            else
            {
                MessageBox.Show("There is no meaning of word", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Word GetWord(string word)
        {
            foreach (var w in _wordObjs)
            {
                if (w.word == word)
                {
                    return w;
                }
            }
            return null;
        }

        private void GetWordsAndMeanings()
        {
            // Get all words and meanings from DB
            foreach (var word in _words)
            {
                // Get meanings of each word
                List<Meaning> meanings = _dbManager.Select_Meanings(word);

                // Add to word list
                _wordObjs.Add( _dbManager.Select_Word(word) );

                // Add meanings of each word to the list of all meanings of all words
                foreach (var meaning in meanings)
                {
                    _meanings.Add(meaning);
                }
            }

            // Shuffle all meanings in random order
            _meanings.Shuffle();
        }

        private bool ChangeToNextMeaning()
        {
            _isPlayedWord = false;

            // Go to the next meaning
            _currentMeaningIdx++;
            if (_currentMeaningIdx >= _meanings.Count)
            {
                MessageBox.Show("Finished!", "", MessageBoxButtons.OK);
                return false;
            }
            _currentMeaning = _meanings[_currentMeaningIdx];

            // Update UI for the next word
            UpdateUi();

            // Temporary way: Pre-load other words to prevent lagging
            PreLoadPronunciation(_currentMeaning.word);

            return true;
        }

        private void ChangeToNextWord()
        {
            _currentWord = GetWord(_currentMeaning.word);
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

        private void UpdateUi()
        {
            Rtb_Definition.Text = _currentMeaning.definition;
            Lbl_WordType.Text = _currentMeaning.wordType;

            Tb_Word.Text = String.Empty;
            Lbl_Result.Visible = false;
            Lbl_Result.Text = String.Empty;
            Lbl_LetterCountResult.Visible = false;
            Lbl_LetterCountResult.Text = String.Empty;
            Lbl_FirstLetterResult.Visible = false;
            Lbl_FirstLetterResult.Text = String.Empty;
            Lbl_FirstTwoLettersResult.Visible = false;
            Lbl_FirstTwoLettersResult.Text = String.Empty;
            Lbl_LastLetterResult.Visible = false;
            Lbl_LastLetterResult.Text = String.Empty;
            Lbl_LastTwoLettersResult.Visible = false;
            Lbl_LastTwoLettersResult.Text = String.Empty;
            Lbl_Synonym.Visible = false;
            Lbl_Synonym.Text = String.Empty;
            Lbl_Pronunciation_US.Visible = false;
            Lbl_Pronunciation_US.Text = String.Empty;

            Llbl_Synonym.Visible = String.IsNullOrEmpty(_currentMeaning.synonym) ? false : true;

            Llbl_Pronunciation.Visible = String.IsNullOrEmpty(_currentWord.pronunciation_us) ? false : true;

            // Display current page count
            Lbl_PageCount.Text = String.Format("{0}/{1}", _currentMeaningIdx + 1, _meanings.Count);

            // Set focus to Word textbox
            Tb_Word.Focus();
        }

        private void Btn_NextMeaning_Click(object sender, EventArgs e)
        {
            // Go to the next meaning
            if (!ChangeToNextMeaning())
            {
                return;
            }

            // Go to the next word
            ChangeToNextWord();
        }

        private void Btn_Show_Click(object sender, EventArgs e)
        {
            var wordDefinitionDialog = new WordDefinitionDialogFrm(Parent.Parent, _currentMeaning.word);
            wordDefinitionDialog.Display();
            wordDefinitionDialog.Show();
        }

        private void LLbl_LetterCount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string hint = String.Format("{0}", _currentMeaning.word.Length);
            Lbl_LetterCountResult.Text = hint;
            Lbl_LetterCountResult.Visible = true;
        }

        private void LLbl_FirstLetter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string hint = String.Format("{0}", _currentMeaning.word[0]);
            Lbl_FirstLetterResult.Text = hint;
            Lbl_FirstLetterResult.Visible = true;
        }

        private void LLbl_FirstTwoLetters_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string hint = String.Format("{0}{1}", _currentMeaning.word[0], _currentMeaning.word[1]);
            Lbl_FirstTwoLettersResult.Text = hint;
            Lbl_FirstTwoLettersResult.Visible = true;
        }

        private void LLbl_LastLetter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string hint = String.Format("{0}", _currentMeaning.word[_currentMeaning.word.Length - 1]);
            Lbl_LastLetterResult.Text = hint;
            Lbl_LastLetterResult.Visible = true;
        }

        private void LLbl_LastTwoLetters_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string hint = String.Format("{0}{1}", _currentMeaning.word[_currentMeaning.word.Length-2], _currentMeaning.word[_currentMeaning.word.Length - 1]);
            Lbl_LastTwoLettersResult.Text = hint;
            Lbl_LastTwoLettersResult.Visible = true;
        }

        private void Tb_Word_KeyUp(object sender, KeyEventArgs e)
        {
            if (_currentMeaning.word == Tb_Word.Text)
            {
                Lbl_Result.Text = "✔";
                Lbl_Result.ForeColor = Color.Green;
                Lbl_Result.Visible = true;

                // Play pronunciation
                if (_isPlayedWord == false)
                {
                    PlayPronunciation(_currentMeaning.word);
                    _isPlayedWord = true;
                }

                if (_currentWord != null)
                {
                    Lbl_Pronunciation_US.Text = _currentWord.pronunciation_us;
                    Lbl_Pronunciation_US.Visible = true;
                }

                DisplayAllSynonyms();

                // Set focus to Next button
                Btn_NextMeaning.Focus();
            }
            else
            {
                if (Tb_Word.Text.Length > 0)
                {
                    Lbl_Result.Text = "✖";
                    Lbl_Result.ForeColor = Color.Red;
                    Lbl_Result.Visible = true;

                    // If user enters synonym of that word, display all synonyms
                    CheckAndDisplaySynonym();
                }
                else
                {
                    Lbl_Result.Visible = false;
                }
            }
        }

        private void Llbl_Synonym_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DisplayAllSynonyms();
        }

        private void CheckAndDisplaySynonym()
        {
            if (!String.IsNullOrEmpty(_currentMeaning.synonym))
            {
                string[] syns = _currentMeaning.synonym.Split(',');
                foreach (var syn in syns)
                {
                    string s = syn.Trim();
                    if (s == Tb_Word.Text)
                    {
                        if (!Lbl_Synonym.Text.Contains(s))
                        {
                            Lbl_Synonym.Text += s + "\n";
                            Lbl_Synonym.Visible = true;
                        }
                        break;
                    }
                }
            }
        }

        private void DisplayAllSynonyms()
        {
            if (!String.IsNullOrEmpty(_currentMeaning.synonym))
            {
                string[] syns = _currentMeaning.synonym.Split(',');
                Lbl_Synonym.Text = String.Empty;
                foreach (var syn in syns)
                {
                    string s = syn.Trim();
                    Lbl_Synonym.Text += s + "\n";
                    Lbl_Synonym.Visible = true;
                }
            }
        }

        private void Llbl_Pronunciation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Lbl_Pronunciation_US.Text = _currentWord.pronunciation_us;
            Lbl_Pronunciation_US.Visible = true;
        }
    }
}