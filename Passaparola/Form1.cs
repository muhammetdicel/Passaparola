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

namespace Passaparola
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection bgl = new SqlConnection   ("Data Source=DESKTOP-TCEOMIL\\SQLEXPRESS;Initial Catalog=Passaparola;Integrated Security=True");
        

        int soruno = 0, dogru = 0, yanlıs = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            
         
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                

                if (label5.Text==textBox1.Text)
                {
                    
                    dogru++;
                    label2.Text = dogru.ToString();

                }
                else
                {
                    
                    yanlıs++;
                    label4.Text = yanlıs.ToString();
                    
                }
               
            }
            
        }

        private void BtnCevapla_Click(object sender, EventArgs e)
        {
            BtnCevapla.Text = "Sonraki";
            soruno++;
            this.Text = soruno.ToString();


            bgl.Open();
            SqlCommand komut = new SqlCommand("Select * From Sorular Where SoruId=@p1", bgl);
            komut.Parameters.AddWithValue("@p1", soruno);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                richTextBox1.Text = dr[1].ToString();
                label5.Text = dr[2].ToString();
            }
            bgl.Close();





           
        }
    }
}
