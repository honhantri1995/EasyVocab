namespace MyForm
{
    partial class MeaningFrm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Rtb_Definition = new System.Windows.Forms.RichTextBox();
            this.Lbl_Definition = new System.Windows.Forms.Label();
            this.Rtb_Example = new System.Windows.Forms.RichTextBox();
            this.Example = new System.Windows.Forms.Label();
            this.Rtb_Synonym = new System.Windows.Forms.RichTextBox();
            this.Rtb_Antonym = new System.Windows.Forms.RichTextBox();
            this.Lb_Synonym = new System.Windows.Forms.Label();
            this.Lb_Antonym = new System.Windows.Forms.Label();
            this.Cbb_Topic = new System.Windows.Forms.ComboBox();
            this.Lb_Topic = new System.Windows.Forms.Label();
            this.Lbl_Type = new System.Windows.Forms.Label();
            this.Cbb_Type = new System.Windows.Forms.ComboBox();
            this.Grb_Meaning = new System.Windows.Forms.GroupBox();
            this.Grb_Meaning.SuspendLayout();
            this.SuspendLayout();
            // 
            // Rtb_Definition
            // 
            this.Rtb_Definition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Rtb_Definition.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.Rtb_Definition.Location = new System.Drawing.Point(80, 17);
            this.Rtb_Definition.Name = "Rtb_Definition";
            this.Rtb_Definition.Size = new System.Drawing.Size(331, 31);
            this.Rtb_Definition.TabIndex = 0;
            this.Rtb_Definition.Text = "";
            // 
            // Lbl_Definition
            // 
            this.Lbl_Definition.AutoSize = true;
            this.Lbl_Definition.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.Lbl_Definition.Location = new System.Drawing.Point(9, 14);
            this.Lbl_Definition.Name = "Lbl_Definition";
            this.Lbl_Definition.Size = new System.Drawing.Size(86, 23);
            this.Lbl_Definition.TabIndex = 2;
            this.Lbl_Definition.Text = "Definition";
            // 
            // Rtb_Example
            // 
            this.Rtb_Example.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Rtb_Example.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.Rtb_Example.Location = new System.Drawing.Point(80, 55);
            this.Rtb_Example.Name = "Rtb_Example";
            this.Rtb_Example.Size = new System.Drawing.Size(331, 44);
            this.Rtb_Example.TabIndex = 3;
            this.Rtb_Example.Text = "";
            // 
            // Example
            // 
            this.Example.AutoSize = true;
            this.Example.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.Example.Location = new System.Drawing.Point(9, 52);
            this.Example.Name = "Example";
            this.Example.Size = new System.Drawing.Size(74, 23);
            this.Example.TabIndex = 4;
            this.Example.Text = "Example";
            // 
            // Rtb_Synonym
            // 
            this.Rtb_Synonym.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Rtb_Synonym.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.Rtb_Synonym.Location = new System.Drawing.Point(625, 12);
            this.Rtb_Synonym.Name = "Rtb_Synonym";
            this.Rtb_Synonym.Size = new System.Drawing.Size(106, 34);
            this.Rtb_Synonym.TabIndex = 5;
            this.Rtb_Synonym.Text = "";
            // 
            // Rtb_Antonym
            // 
            this.Rtb_Antonym.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Rtb_Antonym.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.Rtb_Antonym.Location = new System.Drawing.Point(625, 52);
            this.Rtb_Antonym.Name = "Rtb_Antonym";
            this.Rtb_Antonym.Size = new System.Drawing.Size(106, 40);
            this.Rtb_Antonym.TabIndex = 6;
            this.Rtb_Antonym.Text = "";
            // 
            // Lb_Synonym
            // 
            this.Lb_Synonym.AutoSize = true;
            this.Lb_Synonym.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.Lb_Synonym.Location = new System.Drawing.Point(573, 14);
            this.Lb_Synonym.Name = "Lb_Synonym";
            this.Lb_Synonym.Size = new System.Drawing.Size(82, 23);
            this.Lb_Synonym.TabIndex = 9;
            this.Lb_Synonym.Text = "Synonym";
            // 
            // Lb_Antonym
            // 
            this.Lb_Antonym.AutoSize = true;
            this.Lb_Antonym.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.Lb_Antonym.Location = new System.Drawing.Point(574, 52);
            this.Lb_Antonym.Name = "Lb_Antonym";
            this.Lb_Antonym.Size = new System.Drawing.Size(81, 23);
            this.Lb_Antonym.TabIndex = 10;
            this.Lb_Antonym.Text = "Antonym";
            // 
            // Cbb_Topic
            // 
            this.Cbb_Topic.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Cbb_Topic.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.Cbb_Topic.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.Cbb_Topic.FormattingEnabled = true;
            this.Cbb_Topic.Location = new System.Drawing.Point(459, 54);
            this.Cbb_Topic.Name = "Cbb_Topic";
            this.Cbb_Topic.Size = new System.Drawing.Size(108, 31);
            this.Cbb_Topic.TabIndex = 11;
            // 
            // Lb_Topic
            // 
            this.Lb_Topic.AutoSize = true;
            this.Lb_Topic.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.Lb_Topic.Location = new System.Drawing.Point(414, 57);
            this.Lb_Topic.Name = "Lb_Topic";
            this.Lb_Topic.Size = new System.Drawing.Size(49, 23);
            this.Lb_Topic.TabIndex = 12;
            this.Lb_Topic.Text = "Topic";
            // 
            // Lbl_Type
            // 
            this.Lbl_Type.AutoSize = true;
            this.Lbl_Type.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.Lbl_Type.Location = new System.Drawing.Point(414, 14);
            this.Lbl_Type.Name = "Lbl_Type";
            this.Lbl_Type.Size = new System.Drawing.Size(46, 23);
            this.Lbl_Type.TabIndex = 8;
            this.Lbl_Type.Text = "Type";
            // 
            // Cbb_Type
            // 
            this.Cbb_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbb_Type.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.Cbb_Type.FormattingEnabled = true;
            this.Cbb_Type.Location = new System.Drawing.Point(459, 14);
            this.Cbb_Type.Name = "Cbb_Type";
            this.Cbb_Type.Size = new System.Drawing.Size(108, 31);
            this.Cbb_Type.TabIndex = 15;
            this.Cbb_Type.SelectedIndexChanged += new System.EventHandler(this.Cbb_Type_SelectedIndexChanged);
            // 
            // Grb_Meaning
            // 
            this.Grb_Meaning.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Grb_Meaning.Controls.Add(this.Cbb_Type);
            this.Grb_Meaning.Controls.Add(this.Lbl_Type);
            this.Grb_Meaning.Controls.Add(this.Lb_Topic);
            this.Grb_Meaning.Controls.Add(this.Cbb_Topic);
            this.Grb_Meaning.Controls.Add(this.Lb_Antonym);
            this.Grb_Meaning.Controls.Add(this.Lb_Synonym);
            this.Grb_Meaning.Controls.Add(this.Rtb_Antonym);
            this.Grb_Meaning.Controls.Add(this.Rtb_Synonym);
            this.Grb_Meaning.Controls.Add(this.Example);
            this.Grb_Meaning.Controls.Add(this.Rtb_Example);
            this.Grb_Meaning.Controls.Add(this.Lbl_Definition);
            this.Grb_Meaning.Controls.Add(this.Rtb_Definition);
            this.Grb_Meaning.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.Grb_Meaning.Location = new System.Drawing.Point(0, 0);
            this.Grb_Meaning.Margin = new System.Windows.Forms.Padding(0);
            this.Grb_Meaning.Name = "Grb_Meaning";
            this.Grb_Meaning.Padding = new System.Windows.Forms.Padding(0);
            this.Grb_Meaning.Size = new System.Drawing.Size(739, 106);
            this.Grb_Meaning.TabIndex = 5;
            this.Grb_Meaning.TabStop = false;
            // 
            // MeaningFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Grb_Meaning);
            this.Name = "MeaningFrm";
            this.Size = new System.Drawing.Size(1091, 109);
            this.Grb_Meaning.ResumeLayout(false);
            this.Grb_Meaning.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.RichTextBox Rtb_Definition;
        public System.Windows.Forms.Label Lbl_Definition;
        public System.Windows.Forms.RichTextBox Rtb_Example;
        public System.Windows.Forms.Label Example;
        public System.Windows.Forms.RichTextBox Rtb_Synonym;
        public System.Windows.Forms.RichTextBox Rtb_Antonym;
        public System.Windows.Forms.Label Lb_Synonym;
        public System.Windows.Forms.Label Lb_Antonym;
        public System.Windows.Forms.ComboBox Cbb_Topic;
        public System.Windows.Forms.Label Lb_Topic;
        public System.Windows.Forms.Label Lbl_Type;
        public System.Windows.Forms.ComboBox Cbb_Type;
        public System.Windows.Forms.GroupBox Grb_Meaning;
    }
}
