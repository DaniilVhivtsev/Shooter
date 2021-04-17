using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Shooter
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form1 newForm = new Form1(this);
            newForm.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
