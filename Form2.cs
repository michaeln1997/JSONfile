using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ReadJsonApp
{
    public partial class Form2 : Form
    {
        private static string myText; // a string to hold new text

        public Form2() // creating the form - window
        {
            InitializeComponent();
        }

        private void textPreview_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textPreview.Text = myText; // loading text for preview on the form 2 when it is created
        }

        public static void addText(string text) // method for sending text from other forms to this form
        {
            myText = text;
        }
    }
}
