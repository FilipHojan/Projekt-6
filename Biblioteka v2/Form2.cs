using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteka_v2
{
    public partial class Form2 : Form
    {
        System.Windows.Forms.Form f1 = System.Windows.Forms.Application.OpenForms["Form1"];
        int id = 1;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var f1 = new Form1();
            f1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((textBox2.Text != "") && (textBox1.Text != ""))
            {
                ((Form1)f1).dataGridView1.DataSource = null;
                ((Form1)f1).lista.Add(new Class2{ ID = id, tytul = textBox1.Text, autor = textBox2.Text, wydawnictwo = textBox3.Text, rok = textBox4.Text });
                ((Form1)f1).dataGridView1.DataSource = ((Form1)f1).lista;
                id += 1;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
