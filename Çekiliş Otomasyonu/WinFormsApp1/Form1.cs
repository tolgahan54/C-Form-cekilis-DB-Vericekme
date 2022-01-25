using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                listBox1.Items.Add(textBox1.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int sayi = Int32.Parse(textBox2.Text);
                Random Rnd = new Random();
                for (int i = 1; i <= sayi; i++)
                {
                    int tutulan = Rnd.Next(0, listBox1.Items.Count);
                    listBox2.Items.Add(listBox1.Items[tutulan]);
                    listBox1.Items.RemoveAt(tutulan);
                }
            }

            catch
            {
                {
                    MessageBox.Show("Bilgileri kontrol edin.");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int kisisayisi = listBox1.Items.Count;
            for (int i = 1; i <=kisisayisi; i++)
            {
                int tutulan = rnd.Next(0, listBox1.Items.Count);
                if (i % 2 == 1)
                {
                    listBox2.Items.Add(listBox1.Items[tutulan]);
                    listBox1.Items.RemoveAt(tutulan);
                }
                else
                {
                    listBox3.Items.Add(listBox1.Items[tutulan]);
                    listBox1.Items.RemoveAt(tutulan);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection("Data Source=TOLGA\\WINCCPLUSMIG2014;Initial Catalog=AdventureWorks2014;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select Name from HumanResources.Department",con);
                
            con.Open();
            
            var dr = cmd.ExecuteReader();
            ArrayList Isimler = new ArrayList();

            while (dr.Read())
            {
                Isimler.Add(dr["Name"]);
            }

            foreach (var item in Isimler)
            {
                listBox1.Items.Add(item);
            }

            dr.Close();
            con.Close();

            
        }

    }
}
