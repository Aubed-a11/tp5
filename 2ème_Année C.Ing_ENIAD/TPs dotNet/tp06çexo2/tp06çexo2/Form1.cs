using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tp06çexo2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.AddRange(new string[] { "Janvier", "Février", "Mars", "Avril" });
            checkedListBox.Items.AddRange(new string[] { "Mai", "Juin", "Juillet", "Août" });
            comboBox1.Items.AddRange(new string[] { "Septembre", "Octobre", "Novembre", "Décembre" });

            UpdateCheckedCount();
            UpdateSummary();

            listBox1.SelectedIndexChanged += AnyList_SelectionChanged;
            checkedListBox.ItemCheck += CheckedListBoxMonths_ItemCheck;
            comboBox1.SelectedIndexChanged += AnyList_SelectionChanged;
            checkBoxMultiSelect.CheckedChanged += CheckBoxMultiSelect_CheckedChanged;
        }
        private void CheckBoxMultiSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMultiSelect.Checked)
                listBox1.SelectionMode = SelectionMode.MultiExtended;
            else
                listBox1.SelectionMode = SelectionMode.One;

            listBoxMonths.ClearSelected();
            UpdateSummary();
        }

        private void AnyList_SelectionChanged(object sender, EventArgs e)
        {
            UpdateSummary();
        }

        private void CheckedListBoxMonths_ItemCheck(object sender, ItemCheckEventArgs e)
        {
           
            this.BeginInvoke((Action)(() =>
            {
                UpdateCheckedCount();
                UpdateSummary();
            }));
        }

        // 🔹 Met à jour le nombre d’éléments cochés
        private void UpdateCheckedCount()
        {
            labelCheckedCount.Text = $"Éléments cochés : {checkedListBoxMonths.CheckedItems.Count}";
        }

        // 🔹 Met à jour le récapitulatif des mois sélectionnés
        private void UpdateSummary()
        {
            var listBoxSelection = listBoxMonths.SelectedItems.Cast<string>();
            var checkedListSelection = checkedListBoxMonths.CheckedItems.Cast<string>();
            var comboBoxSelection = comboBoxMonths.SelectedItem != null ? new string[] { comboBoxMonths.SelectedItem.ToString() } : new string[] { };

            var allSelected = listBoxSelection.Concat(checkedListSelection).Concat(comboBoxSelection);
            labelSummary.Text = "Mois sélectionnés : " + string.Join(", ", allSelected);
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void checkedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
