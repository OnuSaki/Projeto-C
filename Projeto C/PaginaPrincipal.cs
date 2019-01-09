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
        public PaginaPrincipal()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label3.Text = pessoas.nomeut;
            if ((label3.Text != "admin") && (label3.Text != "serviçosinf"))//botao sem permissoes
            {
                button4.Text = "Sem Permissões";
                button4.Enabled = false;
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
            this.Hide();
        }

        //BOTAO GESTÃO DE SOFTWARE
        private void button1_Click(object sender, EventArgs e)
        {
            Form software = new Gestao_de_Software();                        
            software.Show();//abre gestao de software
            this.Hide();
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
            this.Hide();
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
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
