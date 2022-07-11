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



namespace hospitalauto
{
    public partial class HastaDetay : Form
    {
        public HastaDetay()
        {
            InitializeComponent();
        }
        public string tc;

        sqlbaglantisi bgl = new sqlbaglantisi();
        private void HastaDetay_Load(object sender, EventArgs e)
        {
            lbltcno.Text = tc;

            SqlCommand komut = new SqlCommand("select hastaAd, HastaSoyad from tblhasta where hastaTC =@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", lbltcno.Text);
            SqlDataReader dr =komut.ExecuteReader();
            while (dr.Read())
            {
                lblas.Text = dr[0]+" " + dr[1];
            }
            bgl.baglanti().Close();


            DataTable dt =new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tblrandevu where hastaTC=" + tc, bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource= dt;


            SqlCommand komut2 = new SqlCommand("select bransAd from tblbrans", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmbbrans.Items.Add(dr2[0]);


            }
            bgl.baglanti().Close();
        }

        private void cmbbrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand komut3 = new SqlCommand("select doktorAd, doktorSoyad from tbldoktor where doktorBrans=@p1", bgl.baglanti());
            komut3.Parameters.AddWithValue("@p1", cmbbrans.Text);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                cmbdoktor.Items.Add(dr3[0]+" " + dr3[1]);
            }
            bgl.baglanti().Close();
        }

        private void cmbdoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt =new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tblrandevu where= '" + cmbbrans.Text+"'", bgl.baglanti());
            da.Fill(dt);
            dataGridView2.DataSource= dt;
        }
    }
}
