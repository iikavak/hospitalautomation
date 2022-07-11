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
            SqlCommand komut = new SqlCommand("insert into tbldoktor (doktorAd,doktorSoyad,doktorTC,doktorTelefon,doktorBrans,doktorSifre) values(@p1,@p2,@p3,@p4,@p5,@p6)", bgl.baglanti());
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

        private void btngucel_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("update tbldoktor set doktorAd=@d1, doktorSoyad=@d2,doktorTC=@d3,doktorTelefon=@d4,doktorBrans=@d5,doktorSifre=@d6 where doktorTC'"+txttc.Text+"'", bgl.baglanti());
            komut2.Parameters.AddWithValue("@d1", txtad.Text);
            komut2.Parameters.AddWithValue("@d2", txtsoyad.Text);
            komut2.Parameters.AddWithValue("@d3", txttc.Text);
            komut2.Parameters.AddWithValue("@d4", txttelefon.Text);
            komut2.Parameters.AddWithValue("@d5", cmbbrans.Text);
            komut2.Parameters.AddWithValue("@d6", txtsifre.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kaydınız Güncellenmiştir","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            SqlCommand komut3 = new SqlCommand("delete from tbldoktor where doktorTC=@d1",bgl.baglanti());
            komut3.Parameters.AddWithValue("@d1", txttc.Text);
            komut3.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kaydınız Silinmiştir");
        }

        private void DoktorPaneli_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tbldoktor", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString(); 
            txtsoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString(); 
            txttc.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString(); 
            txttelefon.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString(); 
            cmbbrans.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString(); 
            txtsifre.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString(); 
            
        }
    }
}
