using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Projeto_C
{
    public partial class PaginaPrincipal : System.Windows.Forms.Form
    {
        public PaginaPrincipal(string nomeutilz)
        {
            InitializeComponent();            
            label3.Text = nomeutilz;//nome de utilizador
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {            
            if ((label3.Text != "admin") && (label3.Text != "serviçosinf"))//botao sem permissoes
            {
                button4.Text = "Sem Permissões";
                button4.Enabled = false;
            }
            string salas = @"salas.txt";
            if (File.Exists(salas))
            {

            }
            else
            {
                StreamWriter criar = File.CreateText(salas);
                criar.Close();
                using (StreamWriter sw = File.AppendText(salas))
                {
                    sw.WriteLine("B101");
                    sw.WriteLine("B102");
                    sw.WriteLine("B103");
                    sw.WriteLine("B104");
                    sw.WriteLine("B105");
                    sw.WriteLine("B106");
                    sw.WriteLine("B107");
                    sw.WriteLine("B108");
                    sw.WriteLine("B109");
                    sw.WriteLine("B110");
                    sw.WriteLine("B111");
                    sw.WriteLine("B201");
                    sw.WriteLine("B202");
                    sw.WriteLine("B203");
                    sw.WriteLine("B204");
                    sw.WriteLine("B205");
                    sw.WriteLine("B206");
                    sw.WriteLine("B207");
                    sw.WriteLine("B208");
                    sw.WriteLine("B209");
                    sw.WriteLine("B210");
                    sw.WriteLine("B211");
                    sw.Close();
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        //BOTAO CONSULTAS
        private void button5_Click(object sender, EventArgs e)
        {

        }
        
        //BOTAO GESTAO DE SALAS
        private void button4_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form f4 = new Form4();
            f4.Show();//abre gestao de salas            
        }

        //BOTAO GESTÃO DE SOFTWARE
        private void button1_Click(object sender, EventArgs e)
        {
            Form software = new Gestao_de_Software();                        
            software.Show();//abre gestao de software
        }

        //BOTAO LOGOUT
        private void button8_Click(object sender, EventArgs e)
        {
            Form login = new Login();
            login.Show();//da logout e volta ao login
            this.Close();
        }

        //BOTAO ASSUNTOS
        private void button6_Click(object sender, EventArgs e)
        {
            Form assuntos = new Assuntos();
            assuntos.Show();//abre os assuntos
        }

        //BOTAO ALERTAS
        private void button2_Click(object sender, EventArgs e)
        {

        }

        //BOTAO NOTIFICAÇOES
        private void button3_Click(object sender, EventArgs e)
        {
            Form notificaçoes = new Notificações(label3.Text);
            notificaçoes.Show();//abre as notificaçoes
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
