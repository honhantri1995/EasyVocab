using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VocabManager;

namespace MyForm
{
    public partial class MeaningFrm : UserControl
    {
        private DictionaryApi _dictApi = new DictionaryApi();
        private DictionaryApi_Data _dictData = DictionaryApi_Data.GetInstance();

        public MeaningFrm()
        {
            InitializeComponent();

            InitForm();
        }

        public void InitForm()
        {
            //////////////////// Word Type Combobox in Add/Edit Tab /////////////////
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
            Cbb_Type.Items.AddRange(items.ToArray());

            //////////////////// Topic Combobox /////////////////
            var items2 = new List<string>();
            UpdateTopicCombobox(items2);
        }

        public void UpdateTopicCombobox(List<string> items)
        {
            Cbb_Topic.Items.Clear();
            Cbb_Topic.Items.AddRange(items.ToArray());
        }

        public void UpdateAutoCompleteSource_For_TopicCombobox(List<string> items)
        {
            var source = new AutoCompleteStringCollection();
            foreach (string topic in items)
            {
                source.Add(topic);
            }
            Cbb_Topic.AutoCompleteCustomSource = source;
        }

        public void UpdateDefinitionTextbox()
        {
            if (Cbb_Type.SelectedItem == null)
            {
                return;
            }

            if (String.IsNullOrEmpty(Rtb_Definition.Text))
            {
                Rtb_Definition.Text = _dictApi.GetDefinition(Cbb_Type.SelectedItem.ToString(), _dictData.Word);
            }
        }

        private void Cbb_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cbb_Type.SelectedItem = e.ToString();

            if (Cbb_Type.SelectedItem == null)
            {
                return;
            }

            // Display definition (if there is currently no definition)
            if (String.IsNullOrEmpty(Rtb_Definition.Text))
            {
                Rtb_Definition.Text = _dictApi.GetDefinition(Cbb_Type.SelectedItem.ToString(), _dictData.Word);
            }
        }

        public void ClearUi()
        {
            Cbb_Type.SelectedItem = null;
            Rtb_Definition.Text = String.Empty;
            Cbb_Topic.Text = String.Empty;
            Rtb_Example.Text = String.Empty;
            Rtb_Synonym.Text = String.Empty;
            Rtb_Antonym.Text = String.Empty;
        }
    }
}
