using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace yazılım_yapımı_dönem_ödevi
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-HVCUDKM;Initial Catalog=yazılım yapım;Integrated Security=True");

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            char dogruCevap = ' ';
            if (radioButton1.Checked)
            {
                dogruCevap = 'A';
               // MessageBox.Show("a");
            }
            if (radioButton2.Checked)
            {
                dogruCevap = 'B';
              //  MessageBox.Show("b");
            }
            if (radioButton3.Checked)
            {
                dogruCevap = 'C';
              //  MessageBox.Show("c");
            }
            if (radioButton4.Checked)
            {
                dogruCevap = 'D';
              //  MessageBox.Show("d");
            }
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into sorular(soruyazisi,cevapA,cevapB,cevapC,cevapD,dogruCevap) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + dogruCevap + "')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt eklendi","Kayıt");
                for (int i = 0; i < Controls.Count; i++)
                {
                if (Controls[i] is TextBox)
                {
                    Controls[i].Text = ""; 
                }
                }
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;


        }
    }
}
