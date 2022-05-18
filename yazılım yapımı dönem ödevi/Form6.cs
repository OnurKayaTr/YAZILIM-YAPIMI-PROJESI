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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-HVCUDKM;Initial Catalog=yazılım yapım;Integrated Security=True");
        private void Form6_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            string sql = "select * From sorular";
            SqlDataAdapter adtp = new SqlDataAdapter(sql,baglanti);
            DataTable dt = new DataTable();
            adtp.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sorular onaylandı");
        }
    }
}
