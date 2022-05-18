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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-HVCUDKM;Initial Catalog=yazılım yapım;Integrated Security=True");

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                string sql = "select * From ogrencigiris where ad=@adi AND sifre=@sifresi";
                SqlParameter prm1 = new SqlParameter("adi",textBox1.Text.Trim());
                SqlParameter prm2 = new SqlParameter("sifresi", textBox2.Text.Trim());
                SqlCommand komut = new SqlCommand(sql, baglanti);
                komut.Parameters.Add(prm1);
                komut.Parameters.Add(prm2);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(komut);
                da.Fill(dt);
                
                if (dt.Rows.Count > 0)
                {
                    Form2 fr = new Form2();
                    fr.Show();

                }
                    


            }
            catch (Exception)
            {
                MessageBox.Show("HATALI GİRİŞ");
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 fr = new Form5();
            fr.Show();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 frtt = new Form6();
            frtt.Show();
        }
    }
}
