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
    public partial class DoktorPaneli : Form
    {
        public DoktorPaneli()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        private void btnekle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into tbldoktor (doktorAd,doktorSoyad,doktorTC,doktorTelefon,doktorBrans,doktorSifre) values(@p1,@p2,@p3,@p4,@p5,@p6", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", txttc.Text);
            komut.Parameters.AddWithValue("@p4", txttelefon.Text);
            komut.Parameters.AddWithValue("@p5", cmbbrans.Text);
            komut.Parameters.AddWithValue("@p6", txtsifre.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kaydınız Gerçekleştirilmiştir Şifreniz:" + txtsifre.Text , "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
           

        }
    }
}
