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
    public partial class Form1 : Form
    {

        public DataTable table = new DataTable("table");
        public List<Class1> lista = new List<Class1>();
        Class1 books = new Class1();

        XmlSerializer serializer = new XmlSerializer(typeof(List<Class1>));

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var f2 = new Form2();
            f2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string nazwaPliku = "Dane.csv";
            string savePath = "";

            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "CSV files (*.csv)|*.csv";
            sf.FileName = nazwaPliku;

            if (sf.ShowDialog() == DialogResult.OK)
            {
                savePath = Path.GetDirectoryName(sf.FileName);
            }
            string path = Path.Combine(savePath, nazwaPliku);

            StreamWriter writer = new StreamWriter(path, true);
            if (writer != null)
            {
                writer.WriteLine(@"ID;tytul;autor;wydawnictwo;rok");
                foreach (Class1 books in lista)
                {
                    writer.WriteLine(String.Format(@"{0};{1};", books.ID, books.tytul, books.autor, books.wydawnictwo, books.rok));
                }
                writer.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string plik = textBox1.Text;
            if (plik.Contains(".csv") == false)
            {
                var reader = new StreamReader(plik);
                lista = (List<Class1>)serializer.Deserialize(reader);
                reader.Close();
                dataGridView1.DataSource = lista;
            }
            else
            {
                MessageBox.Show("Wczytany plik ma rozszerzenie .csv");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }



    }
}
