using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VocabManager
{
    public partial class StudyMethodChoosingDialogFrm : Form
    {
        public MainFrm Parent { get; set; }
        private List<string> _words;

        public StudyMethodChoosingDialogFrm(MainFrm parent, List<string> words)
        {
            InitializeComponent();

            Parent = parent;
            _words = words;

            Rbtn_StudyMethod1.Checked = false;
            Rbtn_StudyMethod2.Checked = false;
            Btn_StartStudy.Enabled = false;
        }

        private void Btn_StartStudy_Click(object sender, EventArgs e)
        {
            if (Rbtn_StudyMethod1.Checked)
            {
                var studyDialog = new StudyMethod1DialogFrm(this, _words);
                studyDialog.Show();
            }
            else
            {
                var studyDialog = new StudyMethod2DialogFrm(this, _words);
                studyDialog.Show();
            }
        }

        private void Rbtn_StudyMethod1_CheckedChanged(object sender, EventArgs e)
        {
            Btn_StartStudy.Enabled = true;
        }

        private void Rbtn_StudyMethod2_CheckedChanged(object sender, EventArgs e)
        {
            Btn_StartStudy.Enabled = true;
        }
    }
}
