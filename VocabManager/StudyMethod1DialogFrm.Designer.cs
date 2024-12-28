namespace VocabManager
{
    partial class StudyMethod1DialogFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Lbl_Word = new System.Windows.Forms.Label();
            this.Grb_Hint = new System.Windows.Forms.GroupBox();
            this.Lbl_WordTypeResult = new System.Windows.Forms.Label();
            this.Btn_Example_PlayPronunciation_US = new System.Windows.Forms.Button();
            this.LLbl_Example = new System.Windows.Forms.LinkLabel();
            this.LLbl_Topic = new System.Windows.Forms.LinkLabel();
            this.LLbl_WordType = new System.Windows.Forms.LinkLabel();
            this.Btn_Show = new System.Windows.Forms.Button();
            this.Btn_NextWord = new System.Windows.Forms.Button();
            this.Cbb_ColorMark = new System.Windows.Forms.ComboBox();
            this.Lbl_StudiedCount = new System.Windows.Forms.Label();
            this.Lbl_StudiedCountValue = new System.Windows.Forms.Label();
            this.Lbl_ColorMark = new System.Windows.Forms.Label();
            this.Lbl_Note = new System.Windows.Forms.Label();
            this.Lbl_PageCount = new System.Windows.Forms.Label();
            this.Grb_Hint.SuspendLayout();
            this.SuspendLayout();
            // 
            // Lbl_Word
            // 
            this.Lbl_Word.AutoSize = true;
            this.Lbl_Word.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Word.Location = new System.Drawing.Point(23, 14);
            this.Lbl_Word.Name = "Lbl_Word";
            this.Lbl_Word.Size = new System.Drawing.Size(36, 33);
            this.Lbl_Word.TabIndex = 0;
            this.Lbl_Word.Text = "...";
            // 
            // Grb_Hint
            // 
            this.Grb_Hint.Controls.Add(this.Lbl_WordTypeResult);
            this.Grb_Hint.Controls.Add(this.Btn_Example_PlayPronunciation_US);
            this.Grb_Hint.Controls.Add(this.LLbl_Example);
            this.Grb_Hint.Controls.Add(this.LLbl_Topic);
            this.Grb_Hint.Controls.Add(this.LLbl_WordType);
            this.Grb_Hint.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grb_Hint.Location = new System.Drawing.Point(29, 148);
            this.Grb_Hint.Name = "Grb_Hint";
            this.Grb_Hint.Size = new System.Drawing.Size(298, 177);
            this.Grb_Hint.TabIndex = 1;
            this.Grb_Hint.TabStop = false;
            this.Grb_Hint.Text = "Hints";
            // 
            // Lbl_WordTypeResult
            // 
            this.Lbl_WordTypeResult.AutoSize = true;
            this.Lbl_WordTypeResult.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_WordTypeResult.Location = new System.Drawing.Point(184, 47);
            this.Lbl_WordTypeResult.Name = "Lbl_WordTypeResult";
            this.Lbl_WordTypeResult.Size = new System.Drawing.Size(21, 19);
            this.Lbl_WordTypeResult.TabIndex = 12;
            this.Lbl_WordTypeResult.Text = "...";
            // 
            // Btn_Example_PlayPronunciation_US
            // 
            this.Btn_Example_PlayPronunciation_US.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Example_PlayPronunciation_US.Location = new System.Drawing.Point(108, 115);
            this.Btn_Example_PlayPronunciation_US.Name = "Btn_Example_PlayPronunciation_US";
            this.Btn_Example_PlayPronunciation_US.Size = new System.Drawing.Size(53, 27);
            this.Btn_Example_PlayPronunciation_US.TabIndex = 11;
            this.Btn_Example_PlayPronunciation_US.Text = "🔊 (US)";
            this.Btn_Example_PlayPronunciation_US.UseVisualStyleBackColor = true;
            this.Btn_Example_PlayPronunciation_US.Click += new System.EventHandler(this.Btn_Example_PlayPronunciation_US_Click);
            // 
            // LLbl_Example
            // 
            this.LLbl_Example.AutoSize = true;
            this.LLbl_Example.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LLbl_Example.Location = new System.Drawing.Point(17, 116);
            this.LLbl_Example.Name = "LLbl_Example";
            this.LLbl_Example.Size = new System.Drawing.Size(94, 23);
            this.LLbl_Example.TabIndex = 2;
            this.LLbl_Example.TabStop = true;
            this.LLbl_Example.Text = "Example(s)";
            this.LLbl_Example.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LLbl_Example_LinkClicked);
            // 
            // LLbl_Topic
            // 
            this.LLbl_Topic.AutoSize = true;
            this.LLbl_Topic.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LLbl_Topic.Location = new System.Drawing.Point(17, 79);
            this.LLbl_Topic.Name = "LLbl_Topic";
            this.LLbl_Topic.Size = new System.Drawing.Size(69, 23);
            this.LLbl_Topic.TabIndex = 1;
            this.LLbl_Topic.TabStop = true;
            this.LLbl_Topic.Text = "Topic(s)";
            this.LLbl_Topic.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LLbl_Topic_LinkClicked);
            // 
            // LLbl_WordType
            // 
            this.LLbl_WordType.AutoSize = true;
            this.LLbl_WordType.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LLbl_WordType.Location = new System.Drawing.Point(17, 43);
            this.LLbl_WordType.Name = "LLbl_WordType";
            this.LLbl_WordType.Size = new System.Drawing.Size(111, 23);
            this.LLbl_WordType.TabIndex = 0;
            this.LLbl_WordType.TabStop = true;
            this.LLbl_WordType.Text = "Word type(s)";
            this.LLbl_WordType.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LLbl_WordType_LinkClicked);
            // 
            // Btn_Show
            // 
            this.Btn_Show.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Show.Location = new System.Drawing.Point(29, 84);
            this.Btn_Show.Name = "Btn_Show";
            this.Btn_Show.Size = new System.Drawing.Size(114, 31);
            this.Btn_Show.TabIndex = 2;
            this.Btn_Show.Text = "Show";
            this.Btn_Show.UseVisualStyleBackColor = true;
            this.Btn_Show.Click += new System.EventHandler(this.Btn_Show_Click);
            // 
            // Btn_NextWord
            // 
            this.Btn_NextWord.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_NextWord.Location = new System.Drawing.Point(196, 84);
            this.Btn_NextWord.Name = "Btn_NextWord";
            this.Btn_NextWord.Size = new System.Drawing.Size(131, 31);
            this.Btn_NextWord.TabIndex = 3;
            this.Btn_NextWord.Text = "Next";
            this.Btn_NextWord.UseVisualStyleBackColor = true;
            this.Btn_NextWord.Click += new System.EventHandler(this.Btn_NextWord_Click);
            // 
            // Cbb_ColorMark
            // 
            this.Cbb_ColorMark.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Cbb_ColorMark.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.Cbb_ColorMark.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.Cbb_ColorMark.FormattingEnabled = true;
            this.Cbb_ColorMark.Location = new System.Drawing.Point(158, 353);
            this.Cbb_ColorMark.Name = "Cbb_ColorMark";
            this.Cbb_ColorMark.Size = new System.Drawing.Size(131, 31);
            this.Cbb_ColorMark.TabIndex = 13;
            // 
            // Lbl_StudiedCount
            // 
            this.Lbl_StudiedCount.AutoSize = true;
            this.Lbl_StudiedCount.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_StudiedCount.Location = new System.Drawing.Point(25, 397);
            this.Lbl_StudiedCount.Name = "Lbl_StudiedCount";
            this.Lbl_StudiedCount.Size = new System.Drawing.Size(123, 23);
            this.Lbl_StudiedCount.TabIndex = 14;
            this.Lbl_StudiedCount.Text = "Studied Count:";
            // 
            // Lbl_StudiedCountValue
            // 
            this.Lbl_StudiedCountValue.AutoSize = true;
            this.Lbl_StudiedCountValue.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_StudiedCountValue.Location = new System.Drawing.Point(154, 397);
            this.Lbl_StudiedCountValue.Name = "Lbl_StudiedCountValue";
            this.Lbl_StudiedCountValue.Size = new System.Drawing.Size(25, 23);
            this.Lbl_StudiedCountValue.TabIndex = 15;
            this.Lbl_StudiedCountValue.Text = "...";
            // 
            // Lbl_ColorMark
            // 
            this.Lbl_ColorMark.AutoSize = true;
            this.Lbl_ColorMark.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_ColorMark.Location = new System.Drawing.Point(25, 356);
            this.Lbl_ColorMark.Name = "Lbl_ColorMark";
            this.Lbl_ColorMark.Size = new System.Drawing.Size(101, 23);
            this.Lbl_ColorMark.TabIndex = 16;
            this.Lbl_ColorMark.Text = "Color Mark:";
            // 
            // Lbl_Note
            // 
            this.Lbl_Note.AutoSize = true;
            this.Lbl_Note.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Note.Location = new System.Drawing.Point(25, 50);
            this.Lbl_Note.Name = "Lbl_Note";
            this.Lbl_Note.Size = new System.Drawing.Size(21, 19);
            this.Lbl_Note.TabIndex = 17;
            this.Lbl_Note.Text = "...";
            // 
            // Lbl_PageCount
            // 
            this.Lbl_PageCount.AutoSize = true;
            this.Lbl_PageCount.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_PageCount.Location = new System.Drawing.Point(164, 448);
            this.Lbl_PageCount.Name = "Lbl_PageCount";
            this.Lbl_PageCount.Size = new System.Drawing.Size(47, 19);
            this.Lbl_PageCount.TabIndex = 18;
            this.Lbl_PageCount.Text = "... / ...";
            // 
            // StudyMethod1DialogFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 476);
            this.Controls.Add(this.Lbl_PageCount);
            this.Controls.Add(this.Lbl_Note);
            this.Controls.Add(this.Lbl_ColorMark);
            this.Controls.Add(this.Lbl_StudiedCountValue);
            this.Controls.Add(this.Lbl_StudiedCount);
            this.Controls.Add(this.Cbb_ColorMark);
            this.Controls.Add(this.Btn_NextWord);
            this.Controls.Add(this.Btn_Show);
            this.Controls.Add(this.Grb_Hint);
            this.Controls.Add(this.Lbl_Word);
            this.Name = "StudyMethod1DialogFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Study";
            this.Grb_Hint.ResumeLayout(false);
            this.Grb_Hint.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbl_Word;
        private System.Windows.Forms.GroupBox Grb_Hint;
        private System.Windows.Forms.Button Btn_Show;
        private System.Windows.Forms.Button Btn_NextWord;
        private System.Windows.Forms.LinkLabel LLbl_Example;
        private System.Windows.Forms.LinkLabel LLbl_Topic;
        private System.Windows.Forms.LinkLabel LLbl_WordType;
        public System.Windows.Forms.ComboBox Cbb_ColorMark;
        private System.Windows.Forms.Label Lbl_StudiedCount;
        private System.Windows.Forms.Label Lbl_StudiedCountValue;
        private System.Windows.Forms.Label Lbl_ColorMark;
        private System.Windows.Forms.Button Btn_Example_PlayPronunciation_US;
        private System.Windows.Forms.Label Lbl_WordTypeResult;
        private System.Windows.Forms.Label Lbl_Note;
        private System.Windows.Forms.Label Lbl_PageCount;
    }
}