using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VocabManager
{
    public partial class WordDefinitionDialogFrm : Form
    {
        private MainFrm _parent;
        private string _word;
        private string _wordImagePath;
        private DbManager _dbManager = DbManager.GetInstance();
        private DictionaryApi _dicApi = new DictionaryApi();

        public WordDefinitionDialogFrm(MainFrm parent, string word)
        {
            InitializeComponent();

            _parent = parent;
            _word = word;

            // Adjust image to fit the Picture Box
            Ptb_WordImage.SizeMode = PictureBoxSizeMode.Zoom;
        }

        public void Display()
        {
            Word w = _dbManager.Select_Word(_word);
            if (w == null)
            {
                MessageBox.Show("Cannot find the word", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Lbl_Word.Text = _word;

            // Display Pronunciation
            Lbl_Pronunciation_US.Text = w.pronunciation_us;
            Lbl_Pronunciation_UK.Text = w.pronunciation_uk;

            // Display Image
            var images = _dbManager.Select_Images(_word);
            for (int i = 0; i < images.Count; i++)
            {
                string imagePath = images[i].image;
                if (File.Exists(imagePath))
                {
                    Ptb_WordImage.Image = new Bitmap(imagePath);
                    _wordImagePath = imagePath;
                }
            }

            // Display word definition
            _parent.DisplayWordDefinitionInRichTextBox(ref Rtb_WordDefinition, w);

            // Temporary way: Pre-load the next word to prevent lagging
            PreLoadPronunciation(_word);
        }

        private void Btn_PlayPronunciation_US_Click(object sender, EventArgs e)
        {
            PlayPronunciation(Lbl_Word.Text, PRONUNCIATION_COUNTRY_2.US);
        }

        private void Btn_PlayPronunciation_UK_Click(object sender, EventArgs e)
        {
            PlayPronunciation(Lbl_Word.Text, PRONUNCIATION_COUNTRY_2.UK);
        }

        void PreLoadPronunciation(string word)
        {
            PreLoadPronunciation_InNewThread(word);
        }

        async void PreLoadPronunciation_InNewThread(string word)
        {
            await Task.Run(() => { _dicApi.PreLoadPronunciation(word, PRONUNCIATION_COUNTRY_2.US); });
            await Task.Run(() => { _dicApi.PreLoadPronunciation(word, PRONUNCIATION_COUNTRY_2.UK); });
        }

        void PlayPronunciation(string text, string country)
        {
            PlayPronunciation_InNewThread(text, country);
        }

        async void PlayPronunciation_InNewThread(string text, string country)
        {
            await Task.Run(() => { _dicApi.PlayPronunciation_2(text, country); });
        }

        private void Ptb_WordImage_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(_wordImagePath) && File.Exists(_wordImagePath))
            {
                Process.Start(Directory.GetCurrentDirectory() + @"/" + _wordImagePath);
            }
        }
    }
}
