﻿using System;
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
    public partial class BransDetay : Form
    {
        public BransDetay()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void btnekle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into tblbrans(bransAd)values(@p1)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtbransad.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kaydınız Gerçekleştirilmiştir","Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void BransDetay_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tblbrans",bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource= dt;
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            SqlCommand komut1 = new SqlCommand("delete from tblbrans where bransAd=@b1", bgl.baglanti());
            komut1.Parameters.AddWithValue("@b1",txtbransad.Text);
            komut1.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kaydınız Silinmiştir");
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update tblbrans set bransAd=@p1 where bransAd=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtbransad.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kaydınız Güncellendi");
        }
    }
}
