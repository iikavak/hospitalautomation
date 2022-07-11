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
    public partial class SekreterDetay : Form
    {
        public SekreterDetay()
        {
            InitializeComponent();
        }
        public string TCnumara;
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void SekreterDetay_Load(object sender, EventArgs e)
        {
            lblkimlik.Text = TCnumara;

            SqlCommand komut1= new SqlCommand(" select sekreterAdSoyad from tblsekreter where sekreterTC =@p1", bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1",lblkimlik.Text);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                lbladsoyad.Text = dr1[0].ToString();
            }
            bgl.baglanti().Close();



            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tblbrans", bgl.baglanti());
            da.Fill(dt1);
            dataGridView1.DataSource= dt1;


            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select (doktorAd+' '+doktorSoyad)as'Doktorlar', doktorBrans from tbldoktor", bgl.baglanti());
            da2.Fill(dt2);
            dataGridView2.DataSource= dt2;

            SqlCommand komut2 = new SqlCommand("select bransAd from tblbrans", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmbbrans.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();

        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komutkaydet = new SqlCommand("insert into tblrandevu(randevuTarih, randevuSaat,randevuBrans,randevuDoktor) values(@r1,@r2,@r3,@r4)", bgl.baglanti());
            komutkaydet.Parameters.AddWithValue("@r1",txttarih.Text);
            komutkaydet.Parameters.AddWithValue("@r2",txtsaat.Text);
            komutkaydet.Parameters.AddWithValue("@r3",cmbbrans.Text);
            komutkaydet.Parameters.AddWithValue("@r4",cmbdoktor.Text);
            komutkaydet.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu Oluşturuldu");
        }

        private void cmbbrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbdoktor.Items.Clear();

            SqlCommand komut = new SqlCommand("select doktorAd doktorSoyad from tbldoktor where doktorBrans=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", cmbbrans.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbdoktor.Items.Add(dr[0] + " " + dr[1]);

            }
            bgl.baglanti().Close();  
        }

        private void btndoktor_Click(object sender, EventArgs e)
        {
            DoktorPaneli dp = new DoktorPaneli();
            dp.Show();
        }

        private void btnbrans_Click(object sender, EventArgs e)
        {
            BransDetay bd = new BransDetay();
            bd.Show();
        }

        private void btnrandevul_Click(object sender, EventArgs e)
        {
            RandevuListele rl = new RandevuListele();
            rl.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into tblduyuru (duyuru) values(@d1)",bgl.baglanti());
            komut.Parameters.AddWithValue("@d1",rtxtduy.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Duyuru Oluşturuldu");
        }
    }
}
