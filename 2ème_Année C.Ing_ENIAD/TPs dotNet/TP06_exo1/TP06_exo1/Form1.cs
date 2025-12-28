using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace TP06_exo1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listBox1.Items.Add("Janvier");
            listBox1.Items.Add("Février");
            listBox1.Items.Add("Mars");
            listBox1.Items.Add("Avril");
            listBox1.Items.Add("Mai");
            listBox1.Items.Add("Juin");
            listBox1.Items.Add("Juillet");
            listBox1.Items.Add("Aout");
            listBox1.Items.Add("Septembre");
            listBox1.Items.Add("Octobre");
            listBox1.Items.Add("Novembre");
            listBox1.Items.Add("Decembre");


            UpdateProperties();


            listBox1.SelectedIndexChanged += ListBox1_SelectedIndexChanged;
        }
        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateProperties();
        }
        private void UpdateProperties()
        {
           
            txtCount.Text = listBox1.Items.Count.ToString();

            txtSelectedIndex.Text = listBox1.SelectedIndex.ToString();
            
            txtTest.Text = listBox1.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
