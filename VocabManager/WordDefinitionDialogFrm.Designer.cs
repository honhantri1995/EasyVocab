namespace VocabManager
{
    partial class WordDefinitionDialogFrm
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
            this.Ptb_WordImage = new System.Windows.Forms.PictureBox();
            this.Lbl_Pronunciation_UK = new System.Windows.Forms.Label();
            this.Lbl_Pronunciation_US = new System.Windows.Forms.Label();
            this.Rtb_WordDefinition = new System.Windows.Forms.RichTextBox();
            this.Lbl_Word = new System.Windows.Forms.Label();
            this.Btn_PlayPronunciation_UK = new System.Windows.Forms.Button();
            this.Btn_PlayPronunciation_US = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Ptb_WordImage)).BeginInit();
            this.SuspendLayout();
            // 
            // Ptb_WordImage
            // 
            this.Ptb_WordImage.Location = new System.Drawing.Point(657, 8);
            this.Ptb_WordImage.Name = "Ptb_WordImage";
            this.Ptb_WordImage.Size = new System.Drawing.Size(214, 130);
            this.Ptb_WordImage.TabIndex = 13;
            this.Ptb_WordImage.TabStop = false;
            this.Ptb_WordImage.Click += new System.EventHandler(this.Ptb_WordImage_Click);
            // 
            // Lbl_Pronunciation_UK
            // 
            this.Lbl_Pronunciation_UK.AutoSize = true;
            this.Lbl_Pronunciation_UK.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.Lbl_Pronunciation_UK.Location = new System.Drawing.Point(377, 67);
            this.Lbl_Pronunciation_UK.Name = "Lbl_Pronunciation_UK";
            this.Lbl_Pronunciation_UK.Size = new System.Drawing.Size(26, 23);
            this.Lbl_Pronunciation_UK.TabIndex = 12;
            this.Lbl_Pronunciation_UK.Text = "[ ]";
            // 
            // Lbl_Pronunciation_US
            // 
            this.Lbl_Pronunciation_US.AutoSize = true;
            this.Lbl_Pronunciation_US.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.Lbl_Pronunciation_US.Location = new System.Drawing.Point(377, 24);
            this.Lbl_Pronunciation_US.Name = "Lbl_Pronunciation_US";
            this.Lbl_Pronunciation_US.Size = new System.Drawing.Size(26, 23);
            this.Lbl_Pronunciation_US.TabIndex = 11;
            this.Lbl_Pronunciation_US.Text = "[ ]";
            // 
            // Rtb_WordDefinition
            // 
            this.Rtb_WordDefinition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Rtb_WordDefinition.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rtb_WordDefinition.Location = new System.Drawing.Point(13, 144);
            this.Rtb_WordDefinition.Name = "Rtb_WordDefinition";
            this.Rtb_WordDefinition.ReadOnly = true;
            this.Rtb_WordDefinition.Size = new System.Drawing.Size(1388, 586);
            this.Rtb_WordDefinition.TabIndex = 10;
            this.Rtb_WordDefinition.Text = "";
            // 
            // Lbl_Word
            // 
            this.Lbl_Word.AutoSize = true;
            this.Lbl_Word.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Word.Location = new System.Drawing.Point(13, 16);
            this.Lbl_Word.Name = "Lbl_Word";
            this.Lbl_Word.Size = new System.Drawing.Size(36, 33);
            this.Lbl_Word.TabIndex = 14;
            this.Lbl_Word.Text = "...";
            // 
            // Btn_PlayPronunciation_UK
            // 
            this.Btn_PlayPronunciation_UK.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_PlayPronunciation_UK.Location = new System.Drawing.Point(302, 64);
            this.Btn_PlayPronunciation_UK.Name = "Btn_PlayPronunciation_UK";
            this.Btn_PlayPronunciation_UK.Size = new System.Drawing.Size(69, 33);
            this.Btn_PlayPronunciation_UK.TabIndex = 16;
            this.Btn_PlayPronunciation_UK.Text = "🔊 (UK)";
            this.Btn_PlayPronunciation_UK.UseVisualStyleBackColor = true;
            this.Btn_PlayPronunciation_UK.Click += new System.EventHandler(this.Btn_PlayPronunciation_UK_Click);
            // 
            // Btn_PlayPronunciation_US
            // 
            this.Btn_PlayPronunciation_US.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_PlayPronunciation_US.Location = new System.Drawing.Point(302, 20);
            this.Btn_PlayPronunciation_US.Name = "Btn_PlayPronunciation_US";
            this.Btn_PlayPronunciation_US.Size = new System.Drawing.Size(69, 33);
            this.Btn_PlayPronunciation_US.TabIndex = 15;
            this.Btn_PlayPronunciation_US.Text = "🔊 (US)";
            this.Btn_PlayPronunciation_US.UseVisualStyleBackColor = true;
            this.Btn_PlayPronunciation_US.Click += new System.EventHandler(this.Btn_PlayPronunciation_US_Click);
            // 
            // WordDefinitionDialogFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1421, 742);
            this.Controls.Add(this.Btn_PlayPronunciation_UK);
            this.Controls.Add(this.Btn_PlayPronunciation_US);
            this.Controls.Add(this.Lbl_Word);
            this.Controls.Add(this.Ptb_WordImage);
            this.Controls.Add(this.Lbl_Pronunciation_UK);
            this.Controls.Add(this.Lbl_Pronunciation_US);
            this.Controls.Add(this.Rtb_WordDefinition);
            this.Name = "WordDefinitionDialogFrm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Word Definition";
            ((System.ComponentModel.ISupportInitialize)(this.Ptb_WordImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Ptb_WordImage;
        private System.Windows.Forms.Label Lbl_Pronunciation_UK;
        private System.Windows.Forms.Label Lbl_Pronunciation_US;
        public System.Windows.Forms.RichTextBox Rtb_WordDefinition;
        private System.Windows.Forms.Label Lbl_Word;
        private System.Windows.Forms.Button Btn_PlayPronunciation_UK;
        private System.Windows.Forms.Button Btn_PlayPronunciation_US;
    }
}