using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Biblioteka_v2
{
    public partial class Form1 : Form
    {

        public DataTable table = new DataTable("table");
        public List<Class2> lista = new List<Class2>();
        Class2 books = new Class2();

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
            string[] text = System.IO.File.ReadAllLines("C:\\Users\\Filip\\Desktop\\dane.csv");
            string[] data_col = null;
            int x = 0;
            foreach (string line in text)
            {
                data_col = line.Split(',');
                if (x == 0)
                {
                    for (int i = 0; i <= data_col.Count() - 1; i++)
                    {
                        table.Columns.Add(data_col[i]);
                    }
                    x++;
                }
                else
                {
                    table.Rows.Add(data_col);
                }
            }
            dataGridView1.DataSource = table;
            this.Controls.Add(dataGridView1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StreamWriter writer = new StreamWriter("C:\\Users\\Filip\\Desktop\\dane.csv", true);
            if (writer != null)
            {
                writer.WriteLine(@"ID;tytul;autor;wydawnictwo;rok");
                foreach (Class2 books in lista)
                {
                    writer.WriteLine(String.Format(@"{0};{1};", books.ID, books.tytul, books.autor, books.wydawnictwo, books.rok));
                }
                writer.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var writer = new StreamWriter("C:\\Users\\Filip\\Desktop\\dane.xml");
            serializer.Serialize(writer, lista);
            writer.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var reader = new StreamReader("C:\\Users\\Filip\\Desktop\\dane.xml");
            lista = (List<Class2>)serializer.Deserialize(reader);
            reader.Close();
            dataGridView1.DataSource = lista;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
