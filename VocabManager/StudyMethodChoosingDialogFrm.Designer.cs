namespace VocabManager
{
    partial class StudyMethodChoosingDialogFrm
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
            this.Btn_StartStudy = new System.Windows.Forms.Button();
            this.Rbtn_StudyMethod1 = new System.Windows.Forms.RadioButton();
            this.Rbtn_StudyMethod2 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // Btn_StartStudy
            // 
            this.Btn_StartStudy.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_StartStudy.Location = new System.Drawing.Point(43, 144);
            this.Btn_StartStudy.Name = "Btn_StartStudy";
            this.Btn_StartStudy.Size = new System.Drawing.Size(89, 44);
            this.Btn_StartStudy.TabIndex = 0;
            this.Btn_StartStudy.Text = "Start";
            this.Btn_StartStudy.UseVisualStyleBackColor = true;
            this.Btn_StartStudy.Click += new System.EventHandler(this.Btn_StartStudy_Click);
            // 
            // Rbtn_StudyMethod1
            // 
            this.Rbtn_StudyMethod1.AutoSize = true;
            this.Rbtn_StudyMethod1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rbtn_StudyMethod1.Location = new System.Drawing.Point(43, 45);
            this.Rbtn_StudyMethod1.Name = "Rbtn_StudyMethod1";
            this.Rbtn_StudyMethod1.Size = new System.Drawing.Size(172, 27);
            this.Rbtn_StudyMethod1.TabIndex = 1;
            this.Rbtn_StudyMethod1.TabStop = true;
            this.Rbtn_StudyMethod1.Text = "Word → Definition";
            this.Rbtn_StudyMethod1.UseVisualStyleBackColor = true;
            this.Rbtn_StudyMethod1.CheckedChanged += new System.EventHandler(this.Rbtn_StudyMethod1_CheckedChanged);
            // 
            // Rbtn_StudyMethod2
            // 
            this.Rbtn_StudyMethod2.AutoSize = true;
            this.Rbtn_StudyMethod2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rbtn_StudyMethod2.Location = new System.Drawing.Point(43, 88);
            this.Rbtn_StudyMethod2.Name = "Rbtn_StudyMethod2";
            this.Rbtn_StudyMethod2.Size = new System.Drawing.Size(172, 27);
            this.Rbtn_StudyMethod2.TabIndex = 2;
            this.Rbtn_StudyMethod2.TabStop = true;
            this.Rbtn_StudyMethod2.Text = "Definition → Word";
            this.Rbtn_StudyMethod2.UseVisualStyleBackColor = true;
            this.Rbtn_StudyMethod2.CheckedChanged += new System.EventHandler(this.Rbtn_StudyMethod2_CheckedChanged);
            // 
            // StudyMethodChoosingDialogFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 215);
            this.Controls.Add(this.Rbtn_StudyMethod2);
            this.Controls.Add(this.Rbtn_StudyMethod1);
            this.Controls.Add(this.Btn_StartStudy);
            this.Name = "StudyMethodChoosingDialogFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Study Method";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_StartStudy;
        private System.Windows.Forms.RadioButton Rbtn_StudyMethod1;
        private System.Windows.Forms.RadioButton Rbtn_StudyMethod2;
    }
}