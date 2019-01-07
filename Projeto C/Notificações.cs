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
    public partial class Notificações : Form
    {
        public Notificações(string nomeUtilizador)
        {
            InitializeComponent();
            //nome aparece logo no docente 
            textBox1.Text = nomeUtilizador;
            //classe para a hora e data
            Software software = new Software();
            software.hora = DateTime.Now.ToString("HH:mm");
            software.data = DateTime.Today.ToString("dd/MM/yyyy");
            textBox4.Text = software.data;
            textBox5.Text = software.hora;            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Show();
            listBox1.Show();            
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Notificações_Load(object sender, EventArgs e)
        {
            //texto do estado
            textBox2.Text = "Pendente";
            //ao iniciar o form carrega os assuntos todos para a listbox1
            string assuntos = @"assuntos.txt";
            if (File.Exists(assuntos))
            {
                StreamReader sr = File.OpenText(assuntos);
                string linha;
                while ((linha = sr.ReadLine()) != null)
                {
                    listBox1.Items.Add(linha);
                }
                sr.Close();
            }
            //mudança de estado para admin e serviços inf./docentes                        
            if ((textBox1.Text == "admin") || (textBox1.Text == "serviçosinf"))
            {
                richTextBox1.ReadOnly = true;
                richTextBox2.ReadOnly = false;
                button4.Show();
            }
            else
            {
                richTextBox1.ReadOnly = false;
                richTextBox2.ReadOnly = true;
                button4.Hide();
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selecionado = listBox1.SelectedItem.ToString();
            int pos = selecionado.IndexOf(";");
            string assuntonum = selecionado.Substring(0, pos);
            textBox3.Text = assuntonum;            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Hide();
            listBox1.Hide();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "Pendente")
            {
                textBox2.Text = "Concluído";
            }
            else if (textBox2.Text == "Concluído")
            {
                textBox2.Text = "Pendente";
            }
        }
    }
}
