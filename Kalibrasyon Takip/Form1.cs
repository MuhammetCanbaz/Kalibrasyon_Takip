using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Kalibrasyon_Takip
{
    public partial class MainPage : Form
    {
        OleDbConnection baglanti;
        OleDbDataAdapter da;
        OleDbCommand cmd;
        DataSet ds;

        public MainPage()
        {
            InitializeComponent();
        }
        void griddoldur()
        {
            baglanti = new OleDbConnection("Provider=Microsoft.Ace.OLEDB.12.0;Data Source=cihaz takip.accdb;");
            da = new OleDbDataAdapter("Select * from main", baglanti);
            ds = new DataSet();
            baglanti.Open();
            da.Fill(ds, "main");
            dataGridView1.DataSource = ds.Tables["main"];
            baglanti.Close();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            griddoldur();
        }

        private void button2_Click(object sender, EventArgs e) //KAYDETME
        {
            cmd = new OleDbCommand();
            baglanti.Open();
            cmd.Connection = baglanti;
            cmd.CommandText = "insert into main (cihaz_no,cihaz_seri_no,cihaz_turu,cihaz_adi,kalibrasyon_tarihi) values ('" + textBox1.Text + "','" + textBox3.Text + "','" +comboBox1.Text + "','" + textBox2.Text + "','"  + dateTimePicker1.Value + "')";
            cmd.ExecuteNonQuery();
            baglanti.Close();
            griddoldur();
        }

        private void button3_Click(object sender, EventArgs e) //GÜNCELLEME
        {
            cmd = new OleDbCommand();
            baglanti.Open();
            cmd.Connection = baglanti;
            cmd.CommandText = "update main set cihaz_turu='" + comboBox1.Text + "',cihaz_adi='" + textBox2.Text + "',cihaz_seri_no='" + textBox3.Text + "',kalibrasyon_tarihi='" + dateTimePicker1.Value + "' where cihaz_no=" + textBox1.Text + "";
            cmd.ExecuteNonQuery();
            baglanti.Close();
            griddoldur();
        }

        private void button4_Click(object sender, EventArgs e) //SİLME
        {
            cmd = new OleDbCommand();
            baglanti.Open();
            cmd.Connection = baglanti;
            cmd.CommandText = "delete from main where cihaz_no=" + textBox1.Text + "";
            cmd.ExecuteNonQuery();
            baglanti.Close();
            griddoldur();
        }
        
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            comboBox1.Text = "";
            textBox2.Clear();
            textBox3.Clear();
            textBox3.Clear();
        }
    }
    
}

