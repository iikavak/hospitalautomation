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
    public partial class DoktorBilgiDuzenle : Form
    {
        public DoktorBilgiDuzenle()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        private void btnguncel_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("update tbldoktor set doktorAd=@d1, doktorSoyad=@d2,doktorTC=@d3,doktorTelefon=@d4,doktorBrans=@d5,doktorSifre=@d6 where doktorTC'" + txttc.Text + "'", bgl.baglanti());
            komut2.Parameters.AddWithValue("@d1", txtad.Text);
            komut2.Parameters.AddWithValue("@d2", txtsoyad.Text);
            komut2.Parameters.AddWithValue("@d3", txttc.Text);
            komut2.Parameters.AddWithValue("@d4", txttel.Text);
            komut2.Parameters.AddWithValue("@d5", cmbbrans.Text);
            komut2.Parameters.AddWithValue("@d6", txtsifre.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kaydınız Güncellenmiştir", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
