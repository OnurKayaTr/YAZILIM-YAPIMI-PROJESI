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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-HVCUDKM;Initial Catalog=yazılım yapım;Integrated Security=True");
        string soruyazisi;
        int sorusayaci = 0;
        int saniye = 60;
        int dakika = 10;
        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Start();
            
            //private void sorucek()
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("SELECT top 1 *FROM sorular ORDER BY NEWID()", baglanti);
                SqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    label1.Text = soruyazisi = Convert.ToString(oku[1]); // soru
                    label2.Text = soruyazisi = Convert.ToString(oku[2]); // cevap a
                    label3.Text = soruyazisi = Convert.ToString(oku[3]); // cevap b
                    label4.Text = soruyazisi = Convert.ToString(oku[4]); // cevap c
                    label5.Text = soruyazisi = Convert.ToString(oku[5]); // cevap d
                }
                baglanti.Close();
                //MessageBox.Show(soruyazisi);
            }
        }
        
        
        private void button1_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            if (sorusayaci<10)
            {
                sorusayaci++;
                //private void sorucek()
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("SELECT top 1 *FROM sorular ORDER BY NEWID()", baglanti);
                    SqlDataReader oku = komut.ExecuteReader();
                    while (oku.Read())
                    {
                        label1.Text = soruyazisi = Convert.ToString(oku[1]); // soru
                        label2.Text = soruyazisi = Convert.ToString(oku[2]); // cevap a
                        label3.Text = soruyazisi = Convert.ToString(oku[3]); // cevap b
                        label4.Text = soruyazisi = Convert.ToString(oku[4]); // cevap c
                        label5.Text = soruyazisi = Convert.ToString(oku[5]); // cevap d
                    }
                    baglanti.Close();
                    //MessageBox.Show(soruyazisi);
                }
            }
            else
            {
                MessageBox.Show("Sınav bitmiştir.");
                this.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            saniye = saniye - 1;
            label8.Text = saniye.ToString();
            label7.Text = (dakika - 1).ToString();
            if (saniye == 0)
            {
                dakika = dakika - 1;
                label7.Text = dakika.ToString();
                saniye = 60;
            }
        }
    }
}
