using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using MyForm;
using Microsoft.Web.WebView2.Core;
using System.IO;
using System.Diagnostics;

namespace VocabManager
{
    public partial class MainFrm : Form
    {
        private List<MeaningFrm> _meaningFrms = new List<MeaningFrm>();
        private List<RichTextBox> _collocationRichTextboxes = new List<RichTextBox>();
        private List<RichTextBox> _collocationDefRichTextboxes = new List<RichTextBox>();
        private List<RichTextBox> _collocationExRichTextboxes = new List<RichTextBox>();
        private List<RichTextBox> _idiomRichTextboxes = new List<RichTextBox>();
        private List<RichTextBox> _idiomDefRichTextboxes = new List<RichTextBox>();
        private List<RichTextBox> _idiomExRichTextboxes = new List<RichTextBox>();

        private List<string> _urls = new List<string>();
        private bool _isWebBrowserBackBtnOrNextBtn_Clicked;
        private bool isWebview_InitCompleted;
        private string _selectedWord = String.Empty;

        private TabPage _previousTab;

        public DbManager DbManager { get; set; }
        public DbManager_Data DbManagerData { get; set; }
        public DictionaryApi DicApi { get; set; }

        public MainFrm()
        {
            DicApi = new DictionaryApi();
            DbManager = DbManager.GetInstance();

            InitDb();

            InitializeComponent();

            InitFrm();
        }

        private void InitDb()
        {
            DbManager.Open();

            DbManager.CreateTable_Word_IfNotExists();
            DbManager.CreateTable_Meaning_IfNotExists();
            DbManager.CreateTable_Collocation_IfNotExists();
            DbManager.CreateTable_Idiom_IfNotExists();
            DbManager.CreateTable_Image_IfNotExists();
            DbManager.CreateTable_StudyPlan_IfNotExists();

            DbManagerData = DbManager_Data.GetInstance();
        }

        private void InitFrm()
        {
            _meaningFrms.Add(Frm_Meaning);

            _collocationRichTextboxes.Add(Rtb_TabAddEdit_Collocation_1);
            _collocationRichTextboxes.Add(Rtb_TabAddEdit_Collocation_2);
            _collocationRichTextboxes.Add(Rtb_TabAddEdit_Collocation_3);

            _collocationDefRichTextboxes.Add(Rtb_TabAddEdit_Collocation_Def_1);
            _collocationDefRichTextboxes.Add(Rtb_TabAddEdit_Collocation_Def_2);
            _collocationDefRichTextboxes.Add(Rtb_TabAddEdit_Collocation_Def_3);

            _collocationExRichTextboxes.Add(Rtb_TabAddEdit_Collocation_Ex_1);
            _collocationExRichTextboxes.Add(Rtb_TabAddEdit_Collocation_Ex_2);
            _collocationExRichTextboxes.Add(Rtb_TabAddEdit_Collocation_Ex_3);

            _idiomRichTextboxes.Add(Rtb_TabAddEdit_Idiom_1);
            _idiomRichTextboxes.Add(Rtb_TabAddEdit_Idiom_2);
            _idiomRichTextboxes.Add(Rtb_TabAddEdit_Idiom_3);

            _idiomDefRichTextboxes.Add(Rtb_TabAddEdit_Idiom_Def_1);
            _idiomDefRichTextboxes.Add(Rtb_TabAddEdit_Idiom_Def_2);
            _idiomDefRichTextboxes.Add(Rtb_TabAddEdit_Idiom_Def_3);

            _idiomExRichTextboxes.Add(Rtb_TabAddEdit_Idiom_Ex_1);
            _idiomExRichTextboxes.Add(Rtb_TabAddEdit_Idiom_Ex_2);
            _idiomExRichTextboxes.Add(Rtb_TabAddEdit_Idiom_Ex_3);

            UpdateAutoCompleteSource_For_WordTextbox();

            foreach (var meaningFrm in _meaningFrms)
            {
                meaningFrm.UpdateAutoCompleteSource_For_TopicCombobox(DbManagerData.Topics);
            }

            UpdateAutoCompleteSource_For_WordTextbox();

            UpdateTopicComboboxes();

            InitColorMarkCombobox();

            InitWordTypeCombobox();

            Init_WebBrowserWebsiteCombobox();

            WebView_TabWebBrowser_Dictionary.EnsureCoreWebView2Async();

            // Adjust image to fit the Picture Box
            Ptb_TabAddEdit_WordImage.SizeMode = PictureBoxSizeMode.Zoom;
            Ptb_TabFind_WordImage.SizeMode = PictureBoxSizeMode.Zoom;

            // Hide Delete-Image button
            Btn_TabAddEdit_DeleteWordImage.Visible = false;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Ask user to confirm if really want to exit
            var response = MessageBox.Show("Are you sure you want to exit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (response == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }

            DbManager.Close();
        }


        ////////////////////////////////// Common ////////////////////////////////////
        private void GetWordDictionaryFromWeb(string word)
        {
            DicApi.GetWord(word);

            // Display pronunciation
            Invoke(new Action(() => UpdatePronunciationTextbox()));

            // Display definition
            Invoke(new Action(() => UpdateDefinitionTextboxes()));
        }

        private void UpdatePronunciationTextbox()
        {
            //string word = Tb_TabAddEdit_Word.Text;

            //if (!String.IsNullOrEmpty(word) && !DbManagerData.Words.Contains(word))
            if (!IsPronunciationExist())
            {
                Tb_TabAddEdit_Pronunciation_US.Text = DicApi.GetPronunciation(PRONUNCIATION_COUNTRY_1.US);
                Tb_TabAddEdit_Pronunciation_UK.Text = DicApi.GetPronunciation(PRONUNCIATION_COUNTRY_1.UK);
            }
        }

        private bool IsPronunciationExist()
        {
            return (!string.IsNullOrEmpty(Tb_TabAddEdit_Pronunciation_US.Text) || !string.IsNullOrEmpty(Tb_TabAddEdit_Pronunciation_UK.Text));
        }

        private bool IsMeaningExist()
        {
            return _meaningFrms.Count > 0 && !string.IsNullOrEmpty(_meaningFrms[0].Rtb_Definition.Text);
        }

        private void UpdateDefinitionTextboxes()
        {
            foreach (var meaningFrm in _meaningFrms)
            {
                meaningFrm.UpdateDefinitionTextbox();
            }
        }

        private void UpdateTopicComboboxes()
        {
            var items = DbManager.Select_AllTopics();

            foreach (var meaningFrm in _meaningFrms)
            {
                meaningFrm.UpdateTopicCombobox(items);
                meaningFrm.UpdateAutoCompleteSource_For_TopicCombobox(items);
            }
        }

        private void Clear_TabAddEdit_Ui()
        {
            Tb_TabAddEdit_Word.Text = String.Empty;
            Tb_TabAddEdit_Pronunciation_US.Text = String.Empty;
            Tb_TabAddEdit_Pronunciation_UK.Text = String.Empty;
            Tb_TabAddEdit_Note.Text = String.Empty;

            while (_meaningFrms.Count > 1)
            {
                Btn_TabAddEdit_RemoveMeaning_Click(new object(), null);       // Trash params
            }

            foreach (var meaningFrm in _meaningFrms)
            {
                meaningFrm.ClearUi();
            }

            for (int i = 0; i < _collocationRichTextboxes.Count; i++)
            {
                _collocationRichTextboxes[i].Text = String.Empty;
                _collocationDefRichTextboxes[i].Text = String.Empty;
                _collocationExRichTextboxes[i].Text = String.Empty;
            }

            for (int i = 0; i < _idiomRichTextboxes.Count; i++)
            {
                _idiomRichTextboxes[i].Text = String.Empty;
                _idiomDefRichTextboxes[i].Text = String.Empty;
                _idiomExRichTextboxes[i].Text = String.Empty;
            }

            if (Ptb_TabAddEdit_WordImage.Image != null)
            {
                Ptb_TabAddEdit_WordImage.Image.Dispose();
                Ptb_TabAddEdit_WordImage.Image = null;
            }
            Lbl_TabAddEdit_ImagePath.Text = String.Empty;

            // Hide Delete-Image button
            Btn_TabAddEdit_DeleteWordImage.Visible = false;

            // Set Color Mark to default value
            Cbb_TabAddEdit_ColorMark.SelectedItem = COLOR_MARK.WHITE;
        }

        private void UpdateDb()
        {
            DbManagerData.Words = DbManager.Select_AllWords();
            DbManagerData.Topics = DbManager.Select_AllTopics();
            DbManagerData.Definitions = DbManager.Select_AllDefinitions();
        }

        private void Update_TabAddEdit_Ui()
        {
            UpdateAutoCompleteSource_For_WordTextbox();

            foreach (var meaningFrm in _meaningFrms)
            {
                meaningFrm.UpdateAutoCompleteSource_For_TopicCombobox(DbManagerData.Topics);
            }
        }

        void PreLoadPronunciation(string word)
        {
            PreLoadPronunciation_InNewThread(word);
        }

        async void PreLoadPronunciation_InNewThread(string word)
        {
            await Task.Run(() => { DicApi.PreLoadPronunciation(word, PRONUNCIATION_COUNTRY_2.US); });
            await Task.Run(() => { DicApi.PreLoadPronunciation(word, PRONUNCIATION_COUNTRY_2.UK); });
        }

        void PlayPronunciation(string text, string country)
        {
            PlayPronunciation_InNewThread(text, country);

            // Bug: Main thread has to wait for subthread
            // Thread thread = new Thread(() => DicApi.PlayPronunciation_2(text, PRONUNCIATION_COUNTRY_2.US));
            // thread.Start(); thread.Join();
        }

        async void PlayPronunciation_InNewThread(string text, string country)
        {
            await Task.Run(() => { DicApi.PlayPronunciation_2(text, country); });
        }


        ////////////////////////////// Tab Add/Edit /////////////////////////////////////
        private void InitColorMarkCombobox()
        {
            var items = new List<string>();
            items.Add(COLOR_MARK.WHITE);
            items.Add(COLOR_MARK.YELLOW);
            items.Add(COLOR_MARK.GREEN);
            items.Add(COLOR_MARK.RED);
            Cbb_TabAddEdit_ColorMark.Items.AddRange(items.ToArray());
        }

        private void Tb_TabAddEdit_Word_LostFocus(object sender, EventArgs e)
        {
            string wordStr = Tb_TabAddEdit_Word.Text;

            if (String.IsNullOrEmpty(wordStr))
            {
                return;
            }

            // if (!IsPronunciationExist())
            if (!IsMeaningExist())
            {
                Word word = DbManager.Select_Word(wordStr);
                if (word != null)
                {
                    AutoFill_AddEditTab(word);
                }
                else
                {
                    Task.Factory.StartNew(() => GetWordDictionaryFromWeb(wordStr));
                }
            }
        }

        private void Tb_TabAddEdit_Word_KeyUp(object sender, KeyEventArgs e)
        {
            // ENTER or Click
            if (e.KeyValue == 13)
            {
                Word word = DbManager.Select_Word(Tb_TabAddEdit_Word.Text);
                if (word != null)
                {
                    AutoFill_AddEditTab(word);

                    // Temporary way: Pre-load the next word to prevent lagging
                    PreLoadPronunciation(word.word);
                }
            }
        }

        private void AutoFill_AddEditTab(Word word)
        {
            if (word == null)
            {
                return;
            }

            Clear_TabAddEdit_Ui();
            Tb_TabAddEdit_Word.Text = word.word;

            // Display pronunciation
            Tb_TabAddEdit_Pronunciation_US.Text = word.pronunciation_us;
            Tb_TabAddEdit_Pronunciation_UK.Text = word.pronunciation_uk;

            // Display note
            Tb_TabAddEdit_Note.Text = word.note;

            // Get all items of Meaning from DB and display to Meaning Form
            var meanings = DbManager.Select_Meanings(word.word);
            for (int i = 0; i < meanings.Count; i++)
            {
                var meaning = meanings[i];

                if (_meaningFrms.Count < i + 1)
                {
                    Btn_TabAddEdit_AddMeaning_Click(new object(), null);       // Trash params
                }

                var frm_meaning = _meaningFrms[i];
                frm_meaning.Rtb_Definition.Text = meaning.definition;
                frm_meaning.Cbb_Type.SelectedItem = Utils.ConvertShorthandWordTypeToFullWordType(meaning.wordType);
                frm_meaning.Cbb_Topic.Text = meaning.topic;
                frm_meaning.Rtb_Example.Text = meaning.example;
                frm_meaning.Rtb_Synonym.Text = meaning.synonym;
                frm_meaning.Rtb_Antonym.Text = meaning.antonym;
            }

            // Get all items of Collocation from DB and display to Collocation RichTextBoxes
            var collocations = DbManager.Select_Collocations(word.word);
            for (int i = 0; i < collocations.Count; i++)
            {
                var collocation = collocations[i];
                _collocationRichTextboxes[i].Text = collocation.collocation;
                _collocationDefRichTextboxes[i].Text = collocation.definition;
                _collocationExRichTextboxes[i].Text = collocation.example;
            }

            // Get all items of Idiom from DB and display to Idiom RichTextBoxes
            var idioms = DbManager.Select_Idioms(word.word);
            for (int i = 0; i < idioms.Count; i++)
            {
                var idiom = idioms[i];
                _idiomRichTextboxes[i].Text = idiom.idiom;
                _idiomDefRichTextboxes[i].Text = idiom.definition;
                _idiomExRichTextboxes[i].Text = idiom.example;
            }

            // Display image to Picture Box
            var images = DbManager.Select_Images(word.word);
            for (int i = 0; i < images.Count; i++)
            {
                string imagePath = images[i].image;
                if (File.Exists(imagePath))
                {
                    Ptb_TabAddEdit_WordImage.Image = new Bitmap(imagePath);
                    Lbl_TabAddEdit_ImagePath.Text = imagePath;

                    // Show Delete-Image button
                    Btn_TabAddEdit_DeleteWordImage.Visible = true;
                }
            }

            // Display Color Mark
            Cbb_TabAddEdit_ColorMark.SelectedItem = DbManager.Select_StudyPlans(word.word).color;
        }

        private void UpdateAutoCompleteSource_For_WordTextbox()
        {
            var source = new AutoCompleteStringCollection();
            foreach (string word in DbManagerData.Words)
            {
                source.Add(word);
            }
            Tb_TabAddEdit_Word.AutoCompleteCustomSource = source;
            Tb_TabFind_Word.AutoCompleteCustomSource = source;
            Tb_TabStudyPlan_SearchKeyword.AutoCompleteCustomSource = source;
        }

        private void Btn_TabAddEdit_SaveWord_Click(object sender, EventArgs e)
        {
            string word = Tb_TabAddEdit_Word.Text.Trim();

            // Validate inputs
            if (!ValidateInputsBeforeSave(word))
            {
                return;
            }

            // Existing word -> EDIT mode
            // New word -> ADD mode
            bool isEditMode = DbManagerData.Words.Contains(word);

            if (isEditMode)
            {
                DbManager.Delete_FromTable_Meaning(word);
                DbManager.Delete_FromTable_Collocation(word);
                DbManager.Delete_FromTable_Idiom(word);
                DbManager.Delete_FromTable_Image(word);
                // DbManager.Delete_FromTable_StudyPlan(word);

                string editedTime = DateTime.Now.ToString(Constants.DATETIME_FORMAT);
                DbManager.Update_InTable_Word(word, Tb_TabAddEdit_Pronunciation_US.Text, Tb_TabAddEdit_Pronunciation_UK.Text, editedTime, Tb_TabAddEdit_Note.Text);
            }
            else
            {
                string addedTime = DateTime.Now.ToString(Constants.DATETIME_FORMAT);
                string editedTime = addedTime;
                DbManager.Insert_ToTable_Word(word, Tb_TabAddEdit_Pronunciation_US.Text, Tb_TabAddEdit_Pronunciation_UK.Text, addedTime, editedTime, Tb_TabAddEdit_Note.Text);
            }

            // Save all meaning
            foreach (var meaningFrm in _meaningFrms)
            {
                DbManager.Insert_ToTable_Meaning(word,
                                                 Utils.ConvertFullWordTypeToShorthandWordType(meaningFrm.Cbb_Type.SelectedItem.ToString()),
                                                 meaningFrm.Rtb_Definition.Text.TrimEnd('\r', '\n'),
                                                 meaningFrm.Cbb_Topic.Text,
                                                 meaningFrm.Rtb_Example.Text.TrimEnd('\r', '\n'),
                                                 meaningFrm.Rtb_Synonym.Text.TrimEnd('\r', '\n'),
                                                 meaningFrm.Rtb_Antonym.Text.TrimEnd('\r', '\n'));
            }

            // Save all collocation
            for (int i = 0; i < _collocationRichTextboxes.Count; i++)
            {
                if (!String.IsNullOrEmpty(_collocationRichTextboxes[i].Text))
                {
                    DbManager.Insert_ToTable_Collocation(word,
                                                         _collocationRichTextboxes[i].Text.TrimEnd('\r', '\n'),
                                                         _collocationDefRichTextboxes[i].Text.TrimEnd('\r', '\n'),
                                                         _collocationExRichTextboxes[i].Text.TrimEnd('\r', '\n'));
                }
            }

            // Save all idiom
            for (int i = 0; i < _idiomRichTextboxes.Count; i++)
            {
                if (!String.IsNullOrEmpty(_idiomRichTextboxes[i].Text))
                {
                    DbManager.Insert_ToTable_Idiom(word,
                                                   _idiomRichTextboxes[i].Text.TrimEnd('\r', '\n'),
                                                   _idiomDefRichTextboxes[i].Text.TrimEnd('\r', '\n'),
                                                   _idiomExRichTextboxes[i].Text.TrimEnd('\r', '\n'));
                }
            }

            // Save image
            string imageRelativePath = Lbl_TabAddEdit_ImagePath.Text;
            if (!String.IsNullOrEmpty(imageRelativePath) && !String.IsNullOrWhiteSpace(imageRelativePath))
            {
                try
                {
                    // FIXME: Cause Exception. How to fix: https://stackoverflow.com/a/7105595/14835442
                    DbManager.Insert_ToTable_Image(word, imageRelativePath);    // Insert to DB
                    Ptb_TabAddEdit_WordImage.Image.Save(imageRelativePath);     // Save image to disk
                }
                catch (Exception)
                {
                }
            }

            // Study Plan
            if (!isEditMode)
            {
                DbManager.Insert_ToTable_StudyPlan(word, Cbb_TabAddEdit_ColorMark.SelectedItem.ToString(), "", "", 0, "", "");
            }
            else
            {
                DbManager.Update_ColorMark_InTable_StudyPlan(word, Cbb_TabAddEdit_ColorMark.SelectedItem.ToString());
            }

            // Update member
            UpdateDb();
            Update_TabAddEdit_Ui();

            // Clear UI
            Clear_TabAddEdit_Ui();
        }

        private bool ValidateInputsBeforeSave(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                MessageBox.Show("Please enter any word!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            foreach (var meaningFrm in _meaningFrms)
            {
                if (String.IsNullOrEmpty(meaningFrm.Rtb_Definition.Text))
                {
                    MessageBox.Show("Please enter a definition for word!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (meaningFrm.Cbb_Type.SelectedItem == null)
                {
                    MessageBox.Show("Please enter a type for word!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (String.IsNullOrEmpty(meaningFrm.Cbb_Topic.Text))
                {
                    MessageBox.Show("Please enter a topic for word!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        private void Btn_TabAddEdit_DeleteWord_Click(object sender, EventArgs e)
        {
            // Ask user to confirm if really want to delete word
            var rsp = MessageBox.Show("Are you sure you want to delete word?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rsp == DialogResult.No)
            {
                return;
            }

            string word = Tb_TabAddEdit_Word.Text;
            string imageRelativePath = Lbl_TabAddEdit_ImagePath.Text;

            // Validate inputs
            if (!ValidateInputsBeforeDelete(word))
            {
                return;
            }

            // Delete word from DB
            DbManager.Delete_FromTable_Word(word);
            DbManager.Delete_FromTable_Meaning(word);
            DbManager.Delete_FromTable_Collocation(word);
            DbManager.Delete_FromTable_Idiom(word);
            DbManager.Delete_FromTable_Image(word);
            DbManager.Delete_FromTable_StudyPlan(word);

            // Update member
            UpdateDb();
            Update_TabAddEdit_Ui();

            // Clear UI
            Clear_TabAddEdit_Ui();

            // Delete image
            if (File.Exists(imageRelativePath))
            {
                File.Delete(imageRelativePath);
            }
        }

        private bool ValidateInputsBeforeDelete(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                MessageBox.Show("Cannot delete because there is no word to delete!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Not existing word
            if (!DbManagerData.Words.Contains(word))
            {
                MessageBox.Show("Cannot delete because the inputed word doesn't exist", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void Btn_TabAddEdit_PlayPronunciation_US_Click(object sender, EventArgs e)
        {
            PlayPronunciation(Tb_TabAddEdit_Word.Text, PRONUNCIATION_COUNTRY_2.US);
        }

        private void Btn_TabAddEdit_PlayPronunciation_UK_Click(object sender, EventArgs e)
        {
            PlayPronunciation(Tb_TabAddEdit_Word.Text, PRONUNCIATION_COUNTRY_2.UK);
        }

        private void Btn_TabAddEdit_AddMeaning_Click(object sender, EventArgs e)
        {
            MeaningFrm prevMeaningFrm = _meaningFrms[_meaningFrms.Count - 1];

            MeaningFrm meaningFrm = new MeaningFrm();
            meaningFrm.Name = "Frm_Meaning";
            meaningFrm.Location = new Point(prevMeaningFrm.Location.X, prevMeaningFrm.Location.Y + prevMeaningFrm.Size.Height + 10);
            meaningFrm.Size = prevMeaningFrm.Size;

            // Add new Meaning form
            Tab_Add_Edit.Controls.Add(meaningFrm);

            // NOTE: Lack of the below line will cause unexpected offset in Location (don't know why ??)
            Tab_Add_Edit.Controls[Tab_Add_Edit.Controls.Count-1].Location = new Point(prevMeaningFrm.Location.X, prevMeaningFrm.Location.Y + prevMeaningFrm.Size.Height + 10);
            // NOTE: Lack of the below line will cause unexpected offset in Size (don't know why ??)
            Tab_Add_Edit.Controls[Tab_Add_Edit.Controls.Count - 1].Size = prevMeaningFrm.Size;

            // Change location of Add Meaning button and Remove Meaning button
            Btn_TabAddEdit_AddMeaning.Location = new Point(Btn_TabAddEdit_AddMeaning.Location.X, Btn_TabAddEdit_AddMeaning.Location.Y + prevMeaningFrm.Size.Height + 10);
            Btn_TabAddEdit_RemoveMeaning.Location = new Point(Btn_TabAddEdit_RemoveMeaning.Location.X, Btn_TabAddEdit_RemoveMeaning.Location.Y + prevMeaningFrm.Size.Height + 10);

            // Append to Meaning Form list
            meaningFrm.UpdateAutoCompleteSource_For_TopicCombobox(DbManagerData.Topics);
            _meaningFrms.Add(meaningFrm);
        }

        private void Btn_TabAddEdit_RemoveMeaning_Click(object sender, EventArgs e)
        {
            if (_meaningFrms.Count <= 1)
            {
                MessageBox.Show("Cannot remove!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MeaningFrm prevMeaningFrm = _meaningFrms[_meaningFrms.Count - 1];

            // Change location of Add Meaning button and Remove Meaning button
            Btn_TabAddEdit_AddMeaning.Location = new Point(Btn_TabAddEdit_AddMeaning.Location.X, Btn_TabAddEdit_AddMeaning.Location.Y - prevMeaningFrm.Size.Height - 10);
            Btn_TabAddEdit_RemoveMeaning.Location = new Point(Btn_TabAddEdit_RemoveMeaning.Location.X, Btn_TabAddEdit_RemoveMeaning.Location.Y - prevMeaningFrm.Size.Height - 10);

            // Remove existing Meaning form
            Tab_Add_Edit.Controls.RemoveAt(Tab_Add_Edit.Controls.Count - 1);

            // Remove from Meaning Form list
            _meaningFrms.RemoveAt(_meaningFrms.Count - 1);
        }

        private void Btn_TabAddEdit_BrowseWordImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif; *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // Display image in Picture Box
                Ptb_TabAddEdit_WordImage.Image = new Bitmap(dialog.FileName);

                string imageRelativePath = Constants.PATH_IMAGE_DIR + Path.GetFileName(dialog.FileName);

                // Display image path to Label
                Lbl_TabAddEdit_ImagePath.Text = imageRelativePath;

                // Show Delete-Image button
                Btn_TabAddEdit_DeleteWordImage.Visible = true;
            }
        }

        private void Ptb_TabAddEdit_WordImage_Click(object sender, EventArgs e)
        {
            string imagePath = Lbl_TabAddEdit_ImagePath.Text;
            OpenImageInWindowPhoto(imagePath);
        }

        private void OpenImageInWindowPhoto(string path)
        {
            if (!String.IsNullOrEmpty(path) && File.Exists(path))
            {
                Process.Start(Directory.GetCurrentDirectory() + @"/" + path);
            }
        }

        private void Btn_TabAddEdit_ClearWord_Click(object sender, EventArgs e)
        {
            Clear_TabAddEdit_Ui();
        }

        private void Btn_TabAddEdit_DeleteWordImage_Click(object sender, EventArgs e)
        {
            if (Ptb_TabAddEdit_WordImage.Image != null)
            {
                Ptb_TabAddEdit_WordImage.Image.Dispose();
                Ptb_TabAddEdit_WordImage.Image = null;
            }
            Lbl_TabAddEdit_ImagePath.Text = String.Empty;

            // Hide Delete-Image butotn
            Btn_TabAddEdit_DeleteWordImage.Visible = false;
        }

        /////////////////////////////////// Tab FIND //////////////////////////////////
        private void Tb_TabFind_Word_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)   // ENTER or Click
            {
                FindWord(Tb_TabFind_Word.Text.Trim());
            }
        }

        private void FindWord(string word)
        {
            if (String.IsNullOrEmpty(word) || String.IsNullOrWhiteSpace(word))
            {
                return;
            }

            Word w = DbManager.Select_Word(word);
            if (w == null)
            {
                MessageBox.Show("Cannot find the word", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Clear_TabFind_Ui();
            Tb_TabFind_Word.Text = word;

            // Display Pronunciation
            Lbl_TabFind_Pronunciation_US.Text = w.pronunciation_us;
            Lbl_TabFind_Pronunciation_UK.Text = w.pronunciation_uk;

            // Display Image
            var images = DbManager.Select_Images(word);
            for (int i = 0; i < images.Count; i++)
            {
                string imagePath = images[i].image;
                if (File.Exists(imagePath))
                {
                    Ptb_TabFind_WordImage.Image = new Bitmap(imagePath);
                }
            }

            // Display word definition ...
            DisplayWordDefinitionInRichTextBox(ref Rtb_TabFind_WordDefinition, w);

            // Temporary way: Pre-load the next word to prevent lagging
            PreLoadPronunciation(word);
        }

        public void DisplayWordDefinitionInRichTextBox(ref RichTextBox rtb, Word wordObj)
        {
            string word = wordObj.word;

            // Display Word
            AppendTextToRichTextBox(ref rtb, FontStyle.Bold | FontStyle.Underline, 17, word + "\n");

            // Display Note
            if (!String.IsNullOrEmpty(wordObj.note) && !String.IsNullOrWhiteSpace(wordObj.note))
            {
                AppendTextToRichTextBox(ref rtb, FontStyle.Regular, 14, "\n" + wordObj.note + "\n");
            }

            // Display Meanings
            var meanings = DbManager.Select_Meanings(word);
            for (int i = 0; i < meanings.Count; i++)
            {
                var meaning = meanings[i];

                AppendTextToRichTextBox(ref rtb, FontStyle.Bold, 15, "\n" + Utils.ConvertShorthandWordTypeToFullWordType(meaning.wordType) + "\n");

                AppendTextToRichTextBox(ref rtb, FontStyle.Regular, 14, meaning.definition + "\n\n");

                AppendTextToRichTextBox(ref rtb, FontStyle.Bold, 14, "  • " + WORD_DETAILS.TOPIC + ": ");
                AppendTextToRichTextBox(ref rtb, FontStyle.Regular, 14, meaning.topic + "\n");

                if (!String.IsNullOrEmpty(meaning.example) && !String.IsNullOrWhiteSpace(meaning.example))
                {
                    AppendTextToRichTextBox(ref rtb, FontStyle.Bold, 14, "  • " + WORD_DETAILS.EXAMPLE + ": \n");

                    // Add spaces to every line of example text
                    string[] exampleLines = meaning.example.Split(new string[] { "\n" }, StringSplitOptions.None);
                    string example = String.Empty;
                    foreach (var line in exampleLines)
                    {
                        example += String.Format("     {0}\n", line);
                    }
                    AppendTextToRichTextBox(ref rtb, FontStyle.Italic, 14, example);
                }

                if (!String.IsNullOrEmpty(meaning.synonym) && !String.IsNullOrWhiteSpace(meaning.synonym))
                {
                    AppendTextToRichTextBox(ref rtb, FontStyle.Bold, 14, "  • " + WORD_DETAILS.SYNONYM + ": ");
                    AppendTextToRichTextBox(ref rtb, FontStyle.Italic, 14, meaning.synonym + "\n");
                }

                if (!String.IsNullOrEmpty(meaning.antonym))
                {
                    AppendTextToRichTextBox(ref rtb, FontStyle.Bold, 14, "  • " + WORD_DETAILS.ANTONYM + ": ");
                    AppendTextToRichTextBox(ref rtb, FontStyle.Italic, 14, meaning.antonym + "\n");
                }
            }

            var collocations = DbManager.Select_Collocations(word);
            AppendTextToRichTextBox(ref rtb, FontStyle.Bold, 15, "\n" + WORD_DETAILS.COLLOCATION + "\n");
            for (int i = 0; i < collocations.Count; i++)
            {
                var collocation = collocations[i];
                if (!String.IsNullOrEmpty(collocation.collocation) && !String.IsNullOrWhiteSpace(collocation.collocation))
                {
                    AppendTextToRichTextBox(ref rtb, FontStyle.Bold, 14, "  • " + collocation.collocation);

                    if (!String.IsNullOrEmpty(collocation.definition) && !String.IsNullOrWhiteSpace(collocation.definition))
                    {
                        AppendTextToRichTextBox(ref rtb, FontStyle.Regular, 14, ": " + collocation.definition + "\n");
                    }

                    // Add spaces to every line of example text
                    if (!String.IsNullOrEmpty(collocation.example) && !String.IsNullOrWhiteSpace(collocation.example))
                    {
                        string[] exampleLines = collocation.example.Split(new string[] { "\n" }, StringSplitOptions.None);
                        string example = String.Empty;
                        foreach (var line in exampleLines)
                        {
                            example += String.Format("         {0}\n", line);
                        }
                        AppendTextToRichTextBox(ref rtb, FontStyle.Italic, 14, example);
                    }
                }
            }

            var idioms = DbManager.Select_Idioms(word);
            AppendTextToRichTextBox(ref rtb, FontStyle.Bold, 15, "\n\n" + WORD_DETAILS.IDIOM + "\n");
            for (int i = 0; i < idioms.Count; i++)
            {
                var idiom = idioms[i];
                if (!String.IsNullOrEmpty(idiom.idiom) && !String.IsNullOrWhiteSpace(idiom.idiom))
                {
                    AppendTextToRichTextBox(ref rtb, FontStyle.Bold, 14, "  • " + idiom.idiom);

                    if (!String.IsNullOrEmpty(idiom.definition) && !String.IsNullOrWhiteSpace(idiom.definition))
                    {
                        AppendTextToRichTextBox(ref rtb, FontStyle.Regular, 14, ": " + idiom.definition + "\n");
                    }

                    // Add spaces to every line of example text
                    if (!String.IsNullOrEmpty(idiom.example) && !String.IsNullOrWhiteSpace(idiom.example))
                    {
                        string[] exampleLines = idiom.example.Split(new string[] { "\n" }, StringSplitOptions.None);
                        string example = String.Empty;
                        foreach (var line in exampleLines)
                        {
                            example += String.Format("         {0}\n", line);
                        }
                        AppendTextToRichTextBox(ref rtb, FontStyle.Italic, 14, example);
                    }
                }
            }
        }

        private void AppendTextToRichTextBox(ref RichTextBox rtb, FontStyle fontStyle, int fontSize, string text)
        {
            // Default font color and style
            Color color = rtb.ForeColor;
            Font font = new Font("Calibri", fontSize, fontStyle);

            // Append formatted text to Rich Text Box
            // https://stackoverflow.com/a/15532593/14835442
            rtb.SelectionStart = rtb.TextLength;
            rtb.SelectionLength = 0;

            rtb.SelectionColor = color;
            rtb.SelectionFont = font;

            rtb.AppendText(text);

            rtb.SelectionColor = rtb.ForeColor;
        }

        private void Clear_TabFind_Ui()
        {
            Tb_TabFind_Word.Text = String.Empty;
            Lbl_TabFind_Pronunciation_US.Text = String.Empty;
            Lbl_TabFind_Pronunciation_UK.Text = String.Empty;
            Rtb_TabFind_WordDefinition.Text = String.Empty;

            if (Ptb_TabFind_WordImage.Image != null)
            {
                Ptb_TabFind_WordImage.Image.Dispose();
                Ptb_TabFind_WordImage.Image = null;
            }
        }

        private void Btn_TabFind_PlayPronunciation_US_Click(object sender, EventArgs e)
        {
            PlayPronunciation(Tb_TabFind_Word.Text, PRONUNCIATION_COUNTRY_2.US);
        }

        private void Btn_TabFind_PlayPronunciation_UK_Click(object sender, EventArgs e)
        {
            PlayPronunciation(Tb_TabFind_Word.Text, PRONUNCIATION_COUNTRY_2.UK);
        }

        private void Ptb_TabFind_WordImage_Click(object sender, EventArgs e)
        {
            string word = Tb_TabFind_Word.Text;
            var images = DbManager.Select_Images(word);
            for (int i = 0; i < images.Count; i++)
            {
                string imagePath = images[i].image;
                OpenImageInWindowPhoto(imagePath);
            }
        }

        ///////////////////////////////// Tab FILTER /////////////////////////////////
        private void InitWordTypeCombobox()
        {
            //////////////////// Word Type Combobox in Filter Tab /////////////////
            var items = new List<string>();
            items.Add(WORD_TYPE.N);
            items.Add(WORD_TYPE.V);
            items.Add(WORD_TYPE.ADJ);
            items.Add(WORD_TYPE.PN);
            items.Add(WORD_TYPE.ADV);
            items.Add(WORD_TYPE.PP);
            items.Add(WORD_TYPE.C);
            items.Add(WORD_TYPE.I);
            items.Add(WORD_TYPE.PRF);
            items.Add(WORD_TYPE.POF);
            items.Add(WORD_TYPE.ID);
            items.Add(WORD_TYPE.PHRASE);
            Cbb_TabFilter_WordType.Items.AddRange(items.ToArray());
        }

        private void Btn_TabFilter_Filter_Click(object sender, EventArgs e)
        {
            Dgv_TabFilter_Filter.Rows.Clear();

            TabFilter_Filter();
        }

        private void Tb_TabFilter_LastNWords_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TabFilter_Filter();
            }
        }

        private void TabFilter_Filter()
        {
            string topic = Cbb_TabFilter_Topic.Text;
            string definition = Cbb_TabFilter_Definition.Text;
            string wordType = Utils.ConvertFullWordTypeToShorthandWordType(Cbb_TabFilter_WordType.Text);
            bool isFollowingCreatedDate = Rbt_TabFilter_Created.Checked;
            bool isWholeWord = Cb_WholeWord.Checked;

            int lastNWord_limit;
            if (String.IsNullOrEmpty(Tb_TabFilter_LastNWords.Text) || String.IsNullOrWhiteSpace(Tb_TabFilter_LastNWords.Text))
            {
                lastNWord_limit = -1;
            }
            else
            {
                lastNWord_limit = int.Parse(Tb_TabFilter_LastNWords.Text);
            }

            var word_n_meaning_s = DbManager.Select_Word_n_Meaning_WithFilter(topic, definition, wordType, lastNWord_limit, isFollowingCreatedDate, isWholeWord);

            // Display to DataGridView
            TabFilter_DisplayWords(word_n_meaning_s);
        }

        private void TabFilter_DisplayWords(List<Word_n_Meaning> word_n_meaning_s)
        {
            try
            {
                Dgv_TabFilter_Filter.Rows.Clear();

                // Get last DGV positions and sorts
                Dgv_TabFilter_Filter.SuspendLayout();
                Status status = DataGridView_Utils.GetStatus(ref Dgv_TabFilter_Filter);

                var rows = new List<DataGridViewRow>();
                int index = 0;

                string word = String.Empty;
                string prev_word = String.Empty;

                for (int i = 0; i < word_n_meaning_s.Count; i++)
                {
                    var word_n_meaning = word_n_meaning_s[i];

                    if (word_n_meaning == null)
                    {
                        continue;
                    }

                    word = word_n_meaning.word;
                    prev_word = (index > 0) ? word_n_meaning_s[i-1].word : String.Empty;
                    if (word != prev_word)
                    {
                        index++;
                    }

                    var cells = new List<object>();
                    cells.Add(index);
                    cells.Add(word_n_meaning.word);
                    cells.Add(word_n_meaning.pronunciation_uk);
                    cells.Add(word_n_meaning.pronunciation_us);
                    cells.Add(word_n_meaning.type);
                    cells.Add(word_n_meaning.topic);
                    cells.Add(word_n_meaning.definition);
                    cells.Add(word_n_meaning.example);
                    cells.Add(word_n_meaning.synonym);
                    cells.Add(word_n_meaning.antonym);
                    cells.Add("");      // FIXME: collocation
                    cells.Add("");      // FIXME: idiom
                    cells.Add(word_n_meaning.addedTime);
                    cells.Add(word_n_meaning.editedTime);
                    cells.Add(new DataGridViewButtonCell());

                    rows.Add(new DataGridViewRow());
                    rows[rows.Count - 1].CreateCells(Dgv_TabFilter_Filter, cells.ToArray());
                }
                Dgv_TabFilter_Filter.Rows.AddRange(rows.ToArray());

                // Add a divider between two adjacent rows, except if these rows are of the same pair
                // Dgv_Trades_AddDividerHeightBetweenPositions();

                // Restore last DGV positions and sorts
                DataGridView_Utils.SetStatus(ref Dgv_TabFilter_Filter, status);
                Dgv_TabFilter_Filter.ResumeLayout();

                // Prevent slow rendering of DataGridView when scrolling
                DataGridView_Utils.SetDoubleBufferForDgv(ref Dgv_TabFilter_Filter, true);
            }
            catch (Exception ex)
            {
                String log = String.Format("Failed to display words to DataGridView. Exception: {0}", ex.ToString());
                MessageBox.Show(log, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void Dgv_Trades_AddDividerHeightBetweenPositions()
        //{
        //    try
        //    {
        //        var word_ColumnIndex = Dgv_Filter.Columns["Dgv_Filter_Column_Word"].Index;

        //        for (int rowIdx = 0; rowIdx < Dgv_Filter.Rows.Count; rowIdx++)
        //        {
        //            if (rowIdx == 0)
        //            {
        //                continue;
        //            }

        //            var word = Dgv_Filter.Rows[rowIdx].Cells[word_ColumnIndex].Value.ToString();
        //            var prev_word = Dgv_Filter.Rows[rowIdx - 1].Cells[word_ColumnIndex].Value.ToString();

        //            // Add a divider between meanings of different word.
        //            // Note: Color of the divider is based on Dgv_Filter.GridColor in MainFrm.Designer.cs
        //            if (word != prev_word)
        //            {
        //                Dgv_Filter.Rows[rowIdx - 1].DividerHeight = 2;
        //                continue;
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //    }
        //}

        private void Dgv_TabFilter_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Ignore if Header row
            if (e.RowIndex == -1)
            {
                return;
            }

            if ( (e.ColumnIndex == Dgv_TabFilter_Filter.Columns["Dgv_Filter_Column_Index"].Index)
                || (e.ColumnIndex == Dgv_TabFilter_Filter.Columns["Dgv_Filter_Column_Word"].Index)
                || (e.ColumnIndex == Dgv_TabFilter_Filter.Columns["Dgv_Filter_Column_Pronunciation_US"].Index)
                && e.Value != null)
            {
                // Don't erase bottom border of the last row
                if (e.RowIndex != Dgv_TabFilter_Filter.Rows.Count - 1)
                {
                    e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
                }

                if (DataGridView_Utils.IsSameCellValue(ref Dgv_TabFilter_Filter, e.ColumnIndex, e.RowIndex))
                {
                    e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
                }
                else
                {
                    e.AdvancedBorderStyle.Top = Dgv_TabFilter_Filter.AdvancedCellBorderStyle.Bottom;
                }
            }
        }

        private void Dgv_TabFilter_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Ignore if Header row
            if (e.RowIndex == -1)
            {
                return;
            }

            if ( (e.ColumnIndex == Dgv_TabFilter_Filter.Columns["Dgv_Filter_Column_Index"].Index)
                 || (e.ColumnIndex == Dgv_TabFilter_Filter.Columns["Dgv_Filter_Column_Word"].Index) 
                 || (e.ColumnIndex == Dgv_TabFilter_Filter.Columns["Dgv_Filter_Column_Pronunciation_US"].Index)
                  && e.Value != null)
            {
                if (DataGridView_Utils.IsSameCellValue(ref Dgv_TabFilter_Filter, e.ColumnIndex, e.RowIndex))
                {
                    e.Value = "";
                    //e.FormattingApplied = true;
                }
            }
        }

        private void Dgv_TabFilter_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Ignore if Header row
            if (e.RowIndex == -1)
            {
                return;
            }

            if ((e.ColumnIndex == Dgv_TabFilter_Filter.Columns["Dgv_Filter_Column_Word"].Index))
            {
                _selectedWord = Dgv_TabFilter_Filter.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                if (e.Button == MouseButtons.Right && e.Clicks == 1)
                {
                    // Create ToolStripMenu
                    var cms = new ContextMenuStrip();
                    var sort = new ToolStripMenuItem("Edit", null, On_TabFilter_MenuItem_EditClick);
                    cms.Items.Add(sort);

                    ((DataGridView)sender).ContextMenuStrip = cms;
                    cms.Show(Dgv_TabFilter_Filter, e.Location);
                }
            }
        }

        private void Dgv_TabFilter_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore if Header row
            if (e.RowIndex == -1)
            {
                return;
            }

            if ((e.ColumnIndex == Dgv_TabFilter_Filter.Columns["Dgv_Filter_Column_Word"].Index))
            {
                _selectedWord = Dgv_TabFilter_Filter.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                FindWord(_selectedWord);
                TabControl_VocabManager.SelectedTab = Tab_Find;
            }
        }

        private void On_TabFilter_MenuItem_EditClick(object sender, EventArgs e)
        {
            Word word = DbManager.Select_Word(_selectedWord);
            if (word != null)
            {
                AutoFill_AddEditTab(word);
            }

            TabControl_VocabManager.SelectedTab = Tab_Add_Edit;
        }

        public void Update_FilterTab_TopicCombobox(List<string> items)
        {
            Cbb_TabFilter_Topic.Items.Clear();
            Cbb_TabFilter_Topic.Items.AddRange(items.ToArray());
        }

        public void UpdateAutoCompleteSource_For_TabFilter_TopicCombobox(List<string> items)
        {
            var source = new AutoCompleteStringCollection();
            foreach (string topic in items)
            {
                source.Add(topic);
            }
            Cbb_TabFilter_Topic.AutoCompleteCustomSource = source;
        }

        private void Update_TabFilter_DefinitionCombobox(List<string> items)
        {
            Cbb_TabFilter_Definition.Items.Clear();
            Cbb_TabFilter_Definition.Items.AddRange(items.ToArray());
        }

        public void UpdateAutoCompleteSource_For_TabFilter_DefinitionCombobox(List<string> items)
        {
            var source = new AutoCompleteStringCollection();
            foreach (string topic in items)
            {
                source.Add(topic);
            }
            Cbb_TabFilter_Definition.AutoCompleteCustomSource = source;
        }

        ///////////////////////////////// Tab WEB BROWSER /////////////////////////////////
        private void Tb_TabWebBrowser_NavigationBar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _isWebBrowserBackBtnOrNextBtn_Clicked = false;
                Navigate(Tb_TabWebBrowser_NavigationBar.Text);
            }
        }

        private void WebView_TabWebBrowser_Dictionary_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            isWebview_InitCompleted = true;
        }

        private void WebView_TabWebBrowser_Dictionary_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            Tb_TabWebBrowser_NavigationBar.Text = WebView_TabWebBrowser_Dictionary.Source.ToString();   // URL

            // If the event is NOT triggered by Back button or Next button, and the new URL is different from the latest URL,
            // save URL to list
            if (!_isWebBrowserBackBtnOrNextBtn_Clicked)
            {
                if (_urls.Count == 0 ||
                    (_urls.Count > 0 && (Tb_TabWebBrowser_NavigationBar.Text != _urls[_urls.Count - 1])))
                {
                    _urls.Add(Tb_TabWebBrowser_NavigationBar.Text);
                }
            }
            else
            {
                _isWebBrowserBackBtnOrNextBtn_Clicked = false;
            }
        }

        private void Navigate(string url)
        {
            try
            {
                if (String.IsNullOrEmpty(url)) return;
                if (url.Equals("about:blank")) return;

                if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                {
                    url = "https://" + url;
                }

                if (isWebview_InitCompleted)
                {
                    WebView_TabWebBrowser_Dictionary.CoreWebView2.Navigate(url);   // Triger event "WebBro_Dictionary_Navigated"
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private void Btn_TabWebBrowser_WebBrowser_Back_Click(object sender, EventArgs e)
        {
            // Find index of URL (started from the end of list)
            int index = _urls.LastIndexOf(WebView_TabWebBrowser_Dictionary.Source.ToString());

            if (index > 0)
            {
                _isWebBrowserBackBtnOrNextBtn_Clicked = true;
                // Navigate to the URL right before the current URL
                Navigate(_urls[index - 1]);
            }
        }

        private void Btn_TabWebBrowser_WebBrowser_Next_Click(object sender, EventArgs e)
        {
            // Find index of URL (started from the end of list)
            int index = _urls.LastIndexOf(WebView_TabWebBrowser_Dictionary.Source.ToString());

            if (_urls.Count > index + 1)
            {
                _isWebBrowserBackBtnOrNextBtn_Clicked = true;
                // Navigate to the URL right after the current URL
                Navigate(_urls[index + 1]);
            }
        }

        private void AutoNavigateWhenWordExist()
        {
            string word = String.Empty;

            if (!String.IsNullOrEmpty(Tb_TabAddEdit_Word.Text))
            {
                word = Tb_TabAddEdit_Word.Text;
            }
            else
            {
                if (!String.IsNullOrEmpty(Tb_TabFind_Word.Text))
                {
                    word = Tb_TabFind_Word.Text;
                }
            }

            if (String.IsNullOrEmpty(word))
            {
                return;
            }

            // If same word, don't need to reload the page
            // FIXME: Cause redundant reload of page if word is a phrase (e.g.: first aid)
            if (_urls.Count > 0 && (_urls[_urls.Count - 1].ToLower().Contains(word.ToLower())))
            {
                return;
            }

            string url = GetWordUrl(word);

            Navigate(url);
        }

        private void AutoNavigateWhenChangingWebsite()
        {
            string word = String.Empty;

            if (!String.IsNullOrEmpty(Tb_TabAddEdit_Word.Text))
            {
                word = Tb_TabAddEdit_Word.Text;
            }
            else
            {
                if (!String.IsNullOrEmpty(Tb_TabFind_Word.Text))
                {
                    word = Tb_TabFind_Word.Text;
                }
            }

            if (String.IsNullOrEmpty(word))
            {
                return;
            }

            string url = GetWordUrl(word);

            Navigate(url);
        }

        private void Cbb_TabWebBrowser_Website_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cbb_TabWebBrowser_Website.SelectedItem = e.ToString();

            AutoNavigateWhenChangingWebsite();
        }

        private void Init_WebBrowserWebsiteCombobox()
        {
            //////////////////// Website Combobox /////////////////
            var items = new List<string>();
            items.Add(WEBSITE.OXFORD);
            items.Add(WEBSITE.CAMBRIDGE);
            items.Add(WEBSITE.COLLINS);
            items.Add(WEBSITE.OZDIC);
            items.Add(WEBSITE.GOOGLE);
            items.Add(WEBSITE.THEFREEDICT);
            items.Add(WEBSITE.COVIET);
            items.Add(WEBSITE.LUGWID);
            items.Add(WEBSITE.THESAURUS);
            items.Add(WEBSITE.SENTENCE);
            items.Add(WEBSITE.FREEPICTURE);
            Cbb_TabWebBrowser_Website.Items.AddRange(items.ToArray());
            Cbb_TabWebBrowser_Website.SelectedItem = items[0];
        }

        private string GetWordUrl(string word)
        {
            string url;

            switch (Cbb_TabWebBrowser_Website.SelectedItem.ToString())
            {
                case WEBSITE.CAMBRIDGE:
                    url = String.Format("https://dictionary.cambridge.org/dictionary/english/{0}", word);
                    break;
                case WEBSITE.OXFORD:
                    url = String.Format("https://www.oxfordlearnersdictionaries.com/us/definition/english/{0}", word);
                    break;
                case WEBSITE.COLLINS:
                    url = String.Format("https://www.collinsdictionary.com/us/dictionary/english/{0}", word);
                    break;
                case WEBSITE.GOOGLE:
                    // url = String.Format("https://www.google.com/search?q=dictionary#dobs={0}", word);
                    url = String.Format("https://www.google.com/search?q={0}", word);
                    break;
                case WEBSITE.THEFREEDICT:
                    url = String.Format("https://www.thefreedictionary.com/{0}", word);
                    break;
                case WEBSITE.OZDIC:
                    url = String.Format("https://ozdic.com/collocation/{0}", word);
                    break;
                case WEBSITE.COVIET:
                    url = String.Format("http://tratu.coviet.vn/hoc-tieng-anh/tu-dien/lac-viet/A-V/{0}.html", word);
                    break;
                case WEBSITE.LUGWID:
                    url = String.Format("https://app.ludwig.guru/s/{0}", word);
                    break;
                case WEBSITE.THESAURUS:
                    url = String.Format("https://thesaurus.yourdictionary.com/{0}", word);
                    break;
                case WEBSITE.SENTENCE:
                    url = String.Format("https://sentence.yourdictionary.com/{0}", word);
                    break;
                case WEBSITE.FREEPICTURE:
                    url = String.Format("https://www.freepik.com/search?format=search&query={0}", word);
                    break;
                default:
                    return "";
            }
            return url;
        }


        ////////////////////////////// Swith between Tabs ///////////////////////////////
        private void Tab_Selected(object sender, TabControlEventArgs e)
        {
            try
            {
                if (e.TabPage == Tab_WebBrowser)
                {
                    AutoNavigateWhenWordExist();
                }
                else if (e.TabPage == Tab_Filter)
                {
                    var topics = DbManagerData.Topics;
                    Update_FilterTab_TopicCombobox(topics);
                    UpdateAutoCompleteSource_For_TabFilter_TopicCombobox(topics);

                    var defs = DbManagerData.Definitions;
                    Update_TabFilter_DefinitionCombobox(defs);
                    UpdateAutoCompleteSource_For_TabFilter_DefinitionCombobox(defs);
                }

                if (_previousTab == Tab_StudyPlan)
                {
                    // TODO
                }

                _previousTab = e.TabPage;
            }
            catch (Exception)
            {
            }
        }


        ////////////////////////////// Tab Study Plan ///////////////////////////////
        private void Btn_TabStudyPlan_Filter_Click(object sender, EventArgs e)
        {
            Dgv_TabStudyPlan_Filter.Rows.Clear();

            TabStudyPlan_Filter();
        }

        private void TabStudyPlan_Filter()
        {
            List<string> colorMarks = new List<string>();
            foreach (string checkedItem in Cbl_TabStudyPlan_ColorMarkFilter.CheckedItems)
            {
                colorMarks.Add(checkedItem);
            }

            var word_n_studyplan_s = DbManager.Select_Word_n_StudyPlan_WithFilter(colorMarks);

            // Display to DataGridView
            TabStudyPlan_DisplayWords(word_n_studyplan_s);
        }

        private void TabStudyPlan_DisplayWords(List<Word_n_StudyPlan> word_n_studyplan_s)
        {
            try
            {
                Dgv_TabStudyPlan_Filter.Rows.Clear();

                // Get last DGV positions and sorts
                Dgv_TabStudyPlan_Filter.SuspendLayout();
                Status status = DataGridView_Utils.GetStatus(ref Dgv_TabStudyPlan_Filter);

                var rows = new List<DataGridViewRow>();
                int index = 0;

                foreach (var word_n_studyplan in word_n_studyplan_s)
                {
                    var cells = new List<object>();
                    cells.Add(++index);
                    cells.Add(word_n_studyplan.word);
                    cells.Add(word_n_studyplan.addedTime);
                    cells.Add(word_n_studyplan.editedTime);
                    cells.Add(word_n_studyplan.lastStudiedTime);
                    cells.Add(word_n_studyplan.studiedCount);
                    cells.Add(word_n_studyplan.nextStudiedTime);
                    cells.Add(word_n_studyplan.color);
                    cells.Add(word_n_studyplan.note1);

                    rows.Add(new DataGridViewRow());
                    rows[rows.Count - 1].CreateCells(Dgv_TabStudyPlan_Filter, cells.ToArray());
                }
                Dgv_TabStudyPlan_Filter.Rows.AddRange(rows.ToArray());

                // Restore last DGV positions and sorts
                DataGridView_Utils.SetStatus(ref Dgv_TabStudyPlan_Filter, status);
                Dgv_TabStudyPlan_Filter.ResumeLayout();

                // Prevent slow rendering of DataGridView when scrolling
                DataGridView_Utils.SetDoubleBufferForDgv(ref Dgv_TabStudyPlan_Filter, true);
            }
            catch (Exception ex)
            {
                String log = String.Format("Failed to display words to DataGridView. Exception: {0}", ex.ToString());
                MessageBox.Show(log, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Dgv_TabStudyPlan_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore if Header row
            if (e.RowIndex == -1)
            {
                return;
            }

            if ((e.ColumnIndex == Dgv_TabStudyPlan_Filter.Columns["Dgv_TabStudyPlan_Column_Word"].Index))
            {
                _selectedWord = Dgv_TabStudyPlan_Filter.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                FindWord(_selectedWord);
                TabControl_VocabManager.SelectedTab = Tab_Find;
            }
        }

        private void SaveStudyPlan()
        {
            foreach (DataGridViewRow row in Dgv_TabStudyPlan_Filter.Rows)
            {
                string word = String.Empty;
                string colorMark = String.Empty;
                string lastStudiedTime = String.Empty;
                string nextStudiedTime = String.Empty;
                int studiedCount = 0;
                string note1 = String.Empty;
                string note2 = String.Empty;    // TODO

                foreach (DataGridViewCell cell in row.Cells)
                {
                    switch (cell.OwningColumn.Name.ToString())
                    {
                        case "Dgv_TabStudyPlan_Column_Word":
                            word = cell.Value.ToString();
                            break;
                        case "Dgv_TabStudyPlan_Column_LastStudiedTime":
                            lastStudiedTime = cell.Value != null ? cell.Value.ToString() : String.Empty;
                            break;
                        case "Dgv_TabStudyPlan_Column_StudiedCount":
                            studiedCount = cell.Value != null ? Int32.Parse(cell.Value.ToString()) : 0;
                            break;
                        case "Dgv_TabStudyPlan_Column_NextStudiedTime":
                            nextStudiedTime = cell.Value != null ? cell.Value.ToString() : String.Empty;
                            break;
                        case "Dgv_TabStudyPlan_Column_ColorMark":
                            colorMark = cell.Value.ToString();
                            break;
                        case "Dgv_TabStudyPlan_Column_Note":
                            note1 = cell.Value != null ? cell.Value.ToString() : String.Empty;
                            break;
                    }
                }

                DbManager.Update_InTable_StudyPlan(word, colorMark, lastStudiedTime, nextStudiedTime, studiedCount, note1, note2);
            }
        }

        private void Btn_TabStudyPlan_Save_Click(object sender, EventArgs e)
        {
            Btn_Tab_StudyPlan_Save.Enabled = false;
            SaveStudyPlan();
            Btn_Tab_StudyPlan_Save.Enabled = true;
        }

        private void Btn_TabStudyPlan_Search_Click(object sender, EventArgs e)
        {
            SearchKeyword();
        }

        private void Tb_TabStudyPlan_SearchKeyword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)   // ENTER or Click
            {
                SearchKeyword();
            }
        }

        private void Dgv_TabStudyPlan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Ignore if Header row
            if (e.RowIndex == -1)
            {
                return;
            }

            if ((e.ColumnIndex == Dgv_TabStudyPlan_Filter.Columns["Dgv_TabStudyPlan_Column_ColorMark"].Index)
                  && e.Value != null)
            {
                DataGridViewCell cell = Dgv_TabStudyPlan_Filter.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (cell.Value.Equals(COLOR_MARK.RED))
                {
                    cell.Style = new DataGridViewCellStyle { ForeColor = Color.Red };
                }
                else if (cell.Value.Equals(COLOR_MARK.GREEN))
                {
                    cell.Style = new DataGridViewCellStyle { ForeColor = Color.DarkGreen };
                }
                else if (cell.Value.Equals(COLOR_MARK.YELLOW))
                {
                    cell.Style = new DataGridViewCellStyle { ForeColor = Color.DarkOrange };
                }
            }
        }

        private void SearchKeyword()
        {
            string searchString = Tb_TabStudyPlan_SearchKeyword.Text;
            DataGridViewRow lastSearchRow = null;

            Dgv_TabStudyPlan_Filter.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                foreach (DataGridViewRow row in Dgv_TabStudyPlan_Filter.Rows)
                {
                    if (row.Cells[1].Value.ToString().Equals(searchString))
                    {
                        // Clear highlight of previous search row
                        if (lastSearchRow != null) lastSearchRow.Selected = false;
                        lastSearchRow = row;

                        // Set highlight for curren search row
                        row.Selected = true;

                        // Jump cursor to selected row
                        Dgv_TabStudyPlan_Filter.CurrentCell = row.Cells[0];

                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Btn_TabFilter_Export_Click(object sender, EventArgs e)
        {
            try
            {
                if (Dgv_TabFilter_Filter.Rows.Count <= 0)
                {
                    MessageBox.Show("There is no word to export!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string filePath = String.Empty;

                // Choose file to save
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "Save text files";
                saveFileDialog.CheckFileExists = false;
                saveFileDialog.CheckPathExists = false;
                saveFileDialog.DefaultExt = "txt";
                saveFileDialog.Filter = "All files (*.*)|*.*|Text files (*.txt)|*.txt";
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.RestoreDirectory = true;
                if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                filePath = saveFileDialog.FileName;

                string lastWord = String.Empty;

                // Export each word to file
                Dgv_TabFilter_Filter.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                foreach (DataGridViewRow row in Dgv_TabFilter_Filter.Rows)
                {
                    string word = row.Cells[1].Value.ToString();

                    if (word == lastWord)
                    {
                        continue;
                    }

                    if (String.IsNullOrEmpty(word) || String.IsNullOrWhiteSpace(word))
                    {
                        continue;
                    }

                    string text = FormatText(word);
                    if (String.IsNullOrEmpty(text) || String.IsNullOrWhiteSpace(text))
                    {
                        continue;
                    }

                    /////////////// Write to text file in append mode ////////////////////
                    using (StreamWriter sw = new StreamWriter(filePath, true))
                    {
                        // write formatted text to the file
                        sw.Write(text);
                    }

                    lastWord = word;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string FormatText(string word)
        {
            Word w = DbManager.Select_Word(word);
            if (w == null)
            {
                MessageBox.Show("Cannot find the word", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }

            // Display Word
            // AppendTextToRichTextBox(FontStyle.Bold | FontStyle.Underline, 17, word + "\n");
            string text = "\n\n==============================\n" + word + "\n\n";

            // Display Pronunciation
            text += String.Format("US: {0}    ", w.pronunciation_us);
            text += String.Format("UK: {0}\n", w.pronunciation_uk);

            // Display Meanings
            var meanings = DbManager.Select_Meanings(word);
            for (int i = 0; i < meanings.Count; i++)
            {
                var meaning = meanings[i];

                text += String.Format("\n{0}\n", Utils.ConvertShorthandWordTypeToFullWordType(meaning.wordType));
                // AppendTextToRichTextBox(FontStyle.Bold, 15, "\n" + Utils.ConvertShorthandWordTypeToFullWordType(meaning.type) + "\n");

                text += String.Format("{0}\n\n", meaning.definition);
                // AppendTextToRichTextBox(FontStyle.Regular, 14, meaning.definition + "\n\n");

                text += "  • " + WORD_DETAILS.TOPIC + ": ";
                // AppendTextToRichTextBox(FontStyle.Bold, 14, "  • " + WORD_DETAILS.TOPIC + ": ");
                text += meaning.topic + "\n";
                // AppendTextToRichTextBox(FontStyle.Regular, 14, meaning.topic + "\n");

                if (!String.IsNullOrEmpty(meaning.example))
                {
                    text += "  • " + WORD_DETAILS.EXAMPLE + ": \n";
                    // AppendTextToRichTextBox(FontStyle.Bold, 14, "  • " + WORD_DETAILS.EXAMPLE + ": \n");

                    // Add spaces to every line of example text
                    string[] exampleLines = meaning.example.Split(new string[] { "\n" }, StringSplitOptions.None);
                    string example = String.Empty;
                    foreach (var line in exampleLines)
                    {
                        example += String.Format("     {0}\n", line);
                    }
                    text += example;
                    // AppendTextToRichTextBox(FontStyle.Italic, 14, example);
                }

                if (!String.IsNullOrEmpty(meaning.synonym))
                {
                    text += "  • " + WORD_DETAILS.SYNONYM + ": ";
                    // AppendTextToRichTextBox(FontStyle.Bold, 14, "  • " + WORD_DETAILS.SYNONYM + ": ");
                    text += meaning.synonym + "\n";
                    // AppendTextToRichTextBox(FontStyle.Italic, 14, meaning.synonym + "\n");
                }

                if (!String.IsNullOrEmpty(meaning.antonym))
                {
                    text += "  • " + WORD_DETAILS.ANTONYM + ": ";
                    // AppendTextToRichTextBox(FontStyle.Bold, 14, "  • " + WORD_DETAILS.ANTONYM + ": ");
                    text += meaning.antonym + "\n";
                    // AppendTextToRichTextBox(FontStyle.Italic, 14, meaning.antonym + "\n");
                }
            }

            var collocations = DbManager.Select_Collocations(word);
            text += "\n" + WORD_DETAILS.COLLOCATION + "\n";
            // AppendTextToRichTextBox(FontStyle.Bold, 15, "\n" + WORD_DETAILS.COLLOCATION + "\n");
            for (int i = 0; i < collocations.Count; i++)
            {
                var collocation = collocations[i];
                if (!String.IsNullOrEmpty(collocation.collocation))
                {
                    text += "  • " + collocation.collocation + ": ";
                    // AppendTextToRichTextBox(FontStyle.Bold, 14, "  • " + collocation.collocation + ": ");
                    text += collocation.definition + "\n";
                    // AppendTextToRichTextBox(FontStyle.Regular, 14, collocation.definition + "\n");

                    // Add spaces to every line of example text
                    string[] exampleLines = collocation.example.Split(new string[] { "\n" }, StringSplitOptions.None);
                    string example = String.Empty;
                    foreach (var line in exampleLines)
                    {
                        example += String.Format("         {0}\n", line);
                    }
                    text += example;
                    // AppendTextToRichTextBox(FontStyle.Italic, 14, example);
                }
            }

            var idioms = DbManager.Select_Idioms(word);
            text += "\n" + WORD_DETAILS.IDIOM + "\n";
            // AppendTextToRichTextBox(FontStyle.Bold, 15, "\n" + WORD_DETAILS.IDIOM + "\n");
            for (int i = 0; i < idioms.Count; i++)
            {
                var idiom = idioms[i];
                if (!String.IsNullOrEmpty(idiom.idiom))
                {
                    text += "  • " + idiom.idiom + ": ";
                    // AppendTextToRichTextBox(FontStyle.Bold, 14, "  • " + idiom.idiom + ": ");
                    text += idiom.definition + "\n";
                    // AppendTextToRichTextBox(FontStyle.Regular, 14, idiom.definition + "\n");

                    // Add spaces to every line of example text
                    string[] exampleLines = idiom.example.Split(new string[] { "\n" }, StringSplitOptions.None);
                    string example = String.Empty;
                    foreach (var line in exampleLines)
                    {
                        example += String.Format("         {0}\n", line);
                    }
                    text += example;
                    // AppendTextToRichTextBox(FontStyle.Italic, 14, example);
                }
            }

            return text;
        }

        private void Btn_Tab_StudyPlan_Study_Click(object sender, EventArgs e)
        {
            // Get selected words to study
            var selectedRows = Dgv_TabStudyPlan_Filter.SelectedCells;

            if (selectedRows.Count <= 0)
            {
                MessageBox.Show("There is no word to study", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedWords = new List<string>();

            foreach (DataGridViewCell row in selectedRows)
            {
                if (row.OwningColumn.Name.ToString() == "Dgv_TabStudyPlan_Column_Word")
                {
                    selectedWords.Add(row.Value.ToString());
                }
            }
            
            var studyMethodDialog = new StudyMethodChoosingDialogFrm(this, selectedWords);
            studyMethodDialog.Show();
        }
    }
}
