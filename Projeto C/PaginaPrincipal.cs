using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_C
{
    public partial class PaginaPrincipal : System.Windows.Forms.Form
    {
        public PaginaPrincipal(string nomeUtilizador)
        {
            InitializeComponent();
            label3.Text = nomeUtilizador;//UTILIZADOR ATIVO
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            if((label3.Text!="admin")&&(label3.Text!="serviçosinf"))
            {
                button4.Hide();//esconde o botao gestao salas
                //button5.Location=new Point(116, 240);//relocalizar botao consultas
                //button6.Location = new Point(304, 240);//relocalizar botao assuntos
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
            f4.Show();
        }

        //BOTAO GESTÃO DE SOFTWARE
        private void button1_Click(object sender, EventArgs e)
        {
            Form software = new Gestao_de_Software();
            software.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form login = new Login();
            login.Show();
            this.Close();
        }

        //BOTAO ASSUNTOS
        private void button6_Click(object sender, EventArgs e)
        {
            Form assuntos = new Assuntos();
            assuntos.Show();
        }

        //BOTAO ALERTAS
        private void button2_Click(object sender, EventArgs e)
        {

        }

        //BOTAO NOTIFICAÇOES
        private void button3_Click(object sender, EventArgs e)
        {
            Form notificaçoes = new Notificações(label3.Text);
            notificaçoes.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
