namespace VocabManager
{
    partial class StudyMethod2DialogFrm
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
            this.Btn_NextMeaning = new System.Windows.Forms.Button();
            this.Btn_Show = new System.Windows.Forms.Button();
            this.Grb_Hint = new System.Windows.Forms.GroupBox();
            this.Lbl_WordType = new System.Windows.Forms.Label();
            this.LLbl_WordType = new System.Windows.Forms.LinkLabel();
            this.Lbl_LastTwoLettersResult = new System.Windows.Forms.Label();
            this.Lbl_FirstTwoLettersResult = new System.Windows.Forms.Label();
            this.Lbl_LastLetterResult = new System.Windows.Forms.Label();
            this.Lbl_FirstLetterResult = new System.Windows.Forms.Label();
            this.Lbl_LetterCountResult = new System.Windows.Forms.Label();
            this.Llbl_Synonym = new System.Windows.Forms.LinkLabel();
            this.LLbl_LastTwoLetters = new System.Windows.Forms.LinkLabel();
            this.LLbl_LastLetter = new System.Windows.Forms.LinkLabel();
            this.LLbl_FirstTwoLetters = new System.Windows.Forms.LinkLabel();
            this.LLbl_LetterCount = new System.Windows.Forms.LinkLabel();
            this.LLbl_FirstLetter = new System.Windows.Forms.LinkLabel();
            this.Rtb_Definition = new System.Windows.Forms.RichTextBox();
            this.Tb_Word = new System.Windows.Forms.TextBox();
            this.Lbl_Result = new System.Windows.Forms.Label();
            this.Lbl_Synonym = new System.Windows.Forms.Label();
            this.Lbl_PageCount = new System.Windows.Forms.Label();
            this.Lbl_Pronunciation_US = new System.Windows.Forms.Label();
            this.Llbl_Pronunciation = new System.Windows.Forms.LinkLabel();
            this.Grb_Hint.SuspendLayout();
            this.SuspendLayout();
            // 
            // Btn_NextMeaning
            // 
            this.Btn_NextMeaning.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_NextMeaning.Location = new System.Drawing.Point(162, 139);
            this.Btn_NextMeaning.Name = "Btn_NextMeaning";
            this.Btn_NextMeaning.Size = new System.Drawing.Size(131, 31);
            this.Btn_NextMeaning.TabIndex = 20;
            this.Btn_NextMeaning.Text = "Next";
            this.Btn_NextMeaning.UseVisualStyleBackColor = true;
            this.Btn_NextMeaning.Click += new System.EventHandler(this.Btn_NextMeaning_Click);
            // 
            // Btn_Show
            // 
            this.Btn_Show.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Show.Location = new System.Drawing.Point(32, 139);
            this.Btn_Show.Name = "Btn_Show";
            this.Btn_Show.Size = new System.Drawing.Size(114, 31);
            this.Btn_Show.TabIndex = 19;
            this.Btn_Show.Text = "Show";
            this.Btn_Show.UseVisualStyleBackColor = true;
            this.Btn_Show.Click += new System.EventHandler(this.Btn_Show_Click);
            // 
            // Grb_Hint
            // 
            this.Grb_Hint.Controls.Add(this.Llbl_Pronunciation);
            this.Grb_Hint.Controls.Add(this.Lbl_WordType);
            this.Grb_Hint.Controls.Add(this.LLbl_WordType);
            this.Grb_Hint.Controls.Add(this.Lbl_LastTwoLettersResult);
            this.Grb_Hint.Controls.Add(this.Lbl_FirstTwoLettersResult);
            this.Grb_Hint.Controls.Add(this.Lbl_LastLetterResult);
            this.Grb_Hint.Controls.Add(this.Lbl_FirstLetterResult);
            this.Grb_Hint.Controls.Add(this.Lbl_LetterCountResult);
            this.Grb_Hint.Controls.Add(this.Llbl_Synonym);
            this.Grb_Hint.Controls.Add(this.LLbl_LastTwoLetters);
            this.Grb_Hint.Controls.Add(this.LLbl_LastLetter);
            this.Grb_Hint.Controls.Add(this.LLbl_FirstTwoLetters);
            this.Grb_Hint.Controls.Add(this.LLbl_LetterCount);
            this.Grb_Hint.Controls.Add(this.LLbl_FirstLetter);
            this.Grb_Hint.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grb_Hint.Location = new System.Drawing.Point(32, 203);
            this.Grb_Hint.Name = "Grb_Hint";
            this.Grb_Hint.Size = new System.Drawing.Size(312, 317);
            this.Grb_Hint.TabIndex = 18;
            this.Grb_Hint.TabStop = false;
            this.Grb_Hint.Text = "Hints";
            // 
            // Lbl_WordType
            // 
            this.Lbl_WordType.AutoSize = true;
            this.Lbl_WordType.Location = new System.Drawing.Point(236, 31);
            this.Lbl_WordType.Name = "Lbl_WordType";
            this.Lbl_WordType.Size = new System.Drawing.Size(25, 23);
            this.Lbl_WordType.TabIndex = 14;
            this.Lbl_WordType.Text = "...";
            // 
            // LLbl_WordType
            // 
            this.LLbl_WordType.AutoSize = true;
            this.LLbl_WordType.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LLbl_WordType.Location = new System.Drawing.Point(20, 31);
            this.LLbl_WordType.Name = "LLbl_WordType";
            this.LLbl_WordType.Size = new System.Drawing.Size(91, 23);
            this.LLbl_WordType.TabIndex = 13;
            this.LLbl_WordType.TabStop = true;
            this.LLbl_WordType.Text = "Word type";
            // 
            // Lbl_LastTwoLettersResult
            // 
            this.Lbl_LastTwoLettersResult.AutoSize = true;
            this.Lbl_LastTwoLettersResult.Location = new System.Drawing.Point(236, 206);
            this.Lbl_LastTwoLettersResult.Name = "Lbl_LastTwoLettersResult";
            this.Lbl_LastTwoLettersResult.Size = new System.Drawing.Size(25, 23);
            this.Lbl_LastTwoLettersResult.TabIndex = 12;
            this.Lbl_LastTwoLettersResult.Text = "...";
            // 
            // Lbl_FirstTwoLettersResult
            // 
            this.Lbl_FirstTwoLettersResult.AutoSize = true;
            this.Lbl_FirstTwoLettersResult.Location = new System.Drawing.Point(236, 172);
            this.Lbl_FirstTwoLettersResult.Name = "Lbl_FirstTwoLettersResult";
            this.Lbl_FirstTwoLettersResult.Size = new System.Drawing.Size(25, 23);
            this.Lbl_FirstTwoLettersResult.TabIndex = 11;
            this.Lbl_FirstTwoLettersResult.Text = "...";
            // 
            // Lbl_LastLetterResult
            // 
            this.Lbl_LastLetterResult.AutoSize = true;
            this.Lbl_LastLetterResult.Location = new System.Drawing.Point(236, 135);
            this.Lbl_LastLetterResult.Name = "Lbl_LastLetterResult";
            this.Lbl_LastLetterResult.Size = new System.Drawing.Size(25, 23);
            this.Lbl_LastLetterResult.TabIndex = 10;
            this.Lbl_LastLetterResult.Text = "...";
            // 
            // Lbl_FirstLetterResult
            // 
            this.Lbl_FirstLetterResult.AutoSize = true;
            this.Lbl_FirstLetterResult.Location = new System.Drawing.Point(236, 100);
            this.Lbl_FirstLetterResult.Name = "Lbl_FirstLetterResult";
            this.Lbl_FirstLetterResult.Size = new System.Drawing.Size(25, 23);
            this.Lbl_FirstLetterResult.TabIndex = 9;
            this.Lbl_FirstLetterResult.Text = "...";
            // 
            // Lbl_LetterCountResult
            // 
            this.Lbl_LetterCountResult.AutoSize = true;
            this.Lbl_LetterCountResult.Location = new System.Drawing.Point(236, 65);
            this.Lbl_LetterCountResult.Name = "Lbl_LetterCountResult";
            this.Lbl_LetterCountResult.Size = new System.Drawing.Size(25, 23);
            this.Lbl_LetterCountResult.TabIndex = 8;
            this.Lbl_LetterCountResult.Text = "...";
            // 
            // Llbl_Synonym
            // 
            this.Llbl_Synonym.AutoSize = true;
            this.Llbl_Synonym.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Llbl_Synonym.Location = new System.Drawing.Point(20, 274);
            this.Llbl_Synonym.Name = "Llbl_Synonym";
            this.Llbl_Synonym.Size = new System.Drawing.Size(102, 23);
            this.Llbl_Synonym.TabIndex = 6;
            this.Llbl_Synonym.TabStop = true;
            this.Llbl_Synonym.Text = "Synonym(s)";
            this.Llbl_Synonym.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Llbl_Synonym_LinkClicked);
            // 
            // LLbl_LastTwoLetters
            // 
            this.LLbl_LastTwoLetters.AutoSize = true;
            this.LLbl_LastTwoLetters.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LLbl_LastTwoLetters.Location = new System.Drawing.Point(20, 206);
            this.LLbl_LastTwoLetters.Name = "LLbl_LastTwoLetters";
            this.LLbl_LastTwoLetters.Size = new System.Drawing.Size(128, 23);
            this.LLbl_LastTwoLetters.TabIndex = 5;
            this.LLbl_LastTwoLetters.TabStop = true;
            this.LLbl_LastTwoLetters.Text = "Last two letters";
            this.LLbl_LastTwoLetters.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LLbl_LastTwoLetters_LinkClicked);
            // 
            // LLbl_LastLetter
            // 
            this.LLbl_LastLetter.AutoSize = true;
            this.LLbl_LastLetter.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LLbl_LastLetter.Location = new System.Drawing.Point(20, 135);
            this.LLbl_LastLetter.Name = "LLbl_LastLetter";
            this.LLbl_LastLetter.Size = new System.Drawing.Size(86, 23);
            this.LLbl_LastLetter.TabIndex = 4;
            this.LLbl_LastLetter.TabStop = true;
            this.LLbl_LastLetter.Text = "Last letter";
            this.LLbl_LastLetter.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LLbl_LastLetter_LinkClicked);
            // 
            // LLbl_FirstTwoLetters
            // 
            this.LLbl_FirstTwoLetters.AutoSize = true;
            this.LLbl_FirstTwoLetters.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LLbl_FirstTwoLetters.Location = new System.Drawing.Point(20, 172);
            this.LLbl_FirstTwoLetters.Name = "LLbl_FirstTwoLetters";
            this.LLbl_FirstTwoLetters.Size = new System.Drawing.Size(131, 23);
            this.LLbl_FirstTwoLetters.TabIndex = 3;
            this.LLbl_FirstTwoLetters.TabStop = true;
            this.LLbl_FirstTwoLetters.Text = "First two letters";
            this.LLbl_FirstTwoLetters.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LLbl_FirstTwoLetters_LinkClicked);
            // 
            // LLbl_LetterCount
            // 
            this.LLbl_LetterCount.AutoSize = true;
            this.LLbl_LetterCount.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LLbl_LetterCount.Location = new System.Drawing.Point(20, 65);
            this.LLbl_LetterCount.Name = "LLbl_LetterCount";
            this.LLbl_LetterCount.Size = new System.Drawing.Size(103, 23);
            this.LLbl_LetterCount.TabIndex = 2;
            this.LLbl_LetterCount.TabStop = true;
            this.LLbl_LetterCount.Text = "Letter count";
            this.LLbl_LetterCount.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LLbl_LetterCount_LinkClicked);
            // 
            // LLbl_FirstLetter
            // 
            this.LLbl_FirstLetter.AutoSize = true;
            this.LLbl_FirstLetter.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LLbl_FirstLetter.Location = new System.Drawing.Point(20, 100);
            this.LLbl_FirstLetter.Name = "LLbl_FirstLetter";
            this.LLbl_FirstLetter.Size = new System.Drawing.Size(89, 23);
            this.LLbl_FirstLetter.TabIndex = 0;
            this.LLbl_FirstLetter.TabStop = true;
            this.LLbl_FirstLetter.Text = "First letter";
            this.LLbl_FirstLetter.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LLbl_FirstLetter_LinkClicked);
            // 
            // Rtb_Definition
            // 
            this.Rtb_Definition.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rtb_Definition.Location = new System.Drawing.Point(32, 22);
            this.Rtb_Definition.Name = "Rtb_Definition";
            this.Rtb_Definition.Size = new System.Drawing.Size(494, 98);
            this.Rtb_Definition.TabIndex = 21;
            this.Rtb_Definition.Text = "";
            // 
            // Tb_Word
            // 
            this.Tb_Word.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Tb_Word.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.Tb_Word.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Tb_Word.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tb_Word.Location = new System.Drawing.Point(320, 139);
            this.Tb_Word.Name = "Tb_Word";
            this.Tb_Word.Size = new System.Drawing.Size(206, 33);
            this.Tb_Word.TabIndex = 22;
            this.Tb_Word.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Tb_Word_KeyUp);
            // 
            // Lbl_Result
            // 
            this.Lbl_Result.AutoSize = true;
            this.Lbl_Result.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Result.Location = new System.Drawing.Point(532, 145);
            this.Lbl_Result.Name = "Lbl_Result";
            this.Lbl_Result.Size = new System.Drawing.Size(21, 20);
            this.Lbl_Result.TabIndex = 23;
            this.Lbl_Result.Text = "...";
            this.Lbl_Result.Visible = false;
            // 
            // Lbl_Synonym
            // 
            this.Lbl_Synonym.AutoSize = true;
            this.Lbl_Synonym.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Synonym.Location = new System.Drawing.Point(366, 214);
            this.Lbl_Synonym.Name = "Lbl_Synonym";
            this.Lbl_Synonym.Size = new System.Drawing.Size(21, 19);
            this.Lbl_Synonym.TabIndex = 24;
            this.Lbl_Synonym.Text = "...";
            // 
            // Lbl_PageCount
            // 
            this.Lbl_PageCount.AutoSize = true;
            this.Lbl_PageCount.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_PageCount.Location = new System.Drawing.Point(258, 535);
            this.Lbl_PageCount.Name = "Lbl_PageCount";
            this.Lbl_PageCount.Size = new System.Drawing.Size(47, 19);
            this.Lbl_PageCount.TabIndex = 25;
            this.Lbl_PageCount.Text = "... / ...";
            // 
            // Lbl_Pronunciation_US
            // 
            this.Lbl_Pronunciation_US.AutoSize = true;
            this.Lbl_Pronunciation_US.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Pronunciation_US.Location = new System.Drawing.Point(316, 178);
            this.Lbl_Pronunciation_US.Name = "Lbl_Pronunciation_US";
            this.Lbl_Pronunciation_US.Size = new System.Drawing.Size(50, 21);
            this.Lbl_Pronunciation_US.TabIndex = 26;
            this.Lbl_Pronunciation_US.Text = "US: ...";
            // 
            // Llbl_Pronunciation
            // 
            this.Llbl_Pronunciation.AutoSize = true;
            this.Llbl_Pronunciation.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Llbl_Pronunciation.Location = new System.Drawing.Point(20, 241);
            this.Llbl_Pronunciation.Name = "Llbl_Pronunciation";
            this.Llbl_Pronunciation.Size = new System.Drawing.Size(119, 23);
            this.Llbl_Pronunciation.TabIndex = 15;
            this.Llbl_Pronunciation.TabStop = true;
            this.Llbl_Pronunciation.Text = "Pronunciation";
            this.Llbl_Pronunciation.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Llbl_Pronunciation_LinkClicked);
            // 
            // StudyMethod2DialogFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 565);
            this.Controls.Add(this.Lbl_Pronunciation_US);
            this.Controls.Add(this.Lbl_PageCount);
            this.Controls.Add(this.Lbl_Synonym);
            this.Controls.Add(this.Lbl_Result);
            this.Controls.Add(this.Tb_Word);
            this.Controls.Add(this.Rtb_Definition);
            this.Controls.Add(this.Btn_NextMeaning);
            this.Controls.Add(this.Btn_Show);
            this.Controls.Add(this.Grb_Hint);
            this.Name = "StudyMethod2DialogFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Study";
            this.Grb_Hint.ResumeLayout(false);
            this.Grb_Hint.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Btn_NextMeaning;
        private System.Windows.Forms.Button Btn_Show;
        private System.Windows.Forms.GroupBox Grb_Hint;
        private System.Windows.Forms.LinkLabel LLbl_LetterCount;
        private System.Windows.Forms.LinkLabel LLbl_FirstLetter;
        private System.Windows.Forms.LinkLabel LLbl_FirstTwoLetters;
        private System.Windows.Forms.LinkLabel LLbl_LastTwoLetters;
        private System.Windows.Forms.LinkLabel LLbl_LastLetter;
        private System.Windows.Forms.RichTextBox Rtb_Definition;
        private System.Windows.Forms.TextBox Tb_Word;
        private System.Windows.Forms.Label Lbl_Result;
        private System.Windows.Forms.LinkLabel Llbl_Synonym;
        private System.Windows.Forms.Label Lbl_LastTwoLettersResult;
        private System.Windows.Forms.Label Lbl_FirstTwoLettersResult;
        private System.Windows.Forms.Label Lbl_LastLetterResult;
        private System.Windows.Forms.Label Lbl_FirstLetterResult;
        private System.Windows.Forms.Label Lbl_LetterCountResult;
        private System.Windows.Forms.LinkLabel LLbl_WordType;
        private System.Windows.Forms.Label Lbl_WordType;
        private System.Windows.Forms.Label Lbl_Synonym;
        private System.Windows.Forms.Label Lbl_PageCount;
        private System.Windows.Forms.Label Lbl_Pronunciation_US;
        private System.Windows.Forms.LinkLabel Llbl_Pronunciation;
    }
}