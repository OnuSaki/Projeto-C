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
    public partial class Verificar_Notificações : Form
    {
        public Verificar_Notificações()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Verificar_Notificações_Load(object sender, EventArgs e)
        {
            string notificacao = @"notificaçoes.txt";
            string linha = "";
            StreamReader sr;
            int i = 0;
            if (File.Exists(notificacao))
            {
                //copia todas as notificações para a datagridview
                sr = File.OpenText(notificacao);
                while ((linha = sr.ReadLine()) != null)
                {
                    dataGridView1.Rows.Add(1);
                    string[] words = linha.Split(';');
                    //utilizador
                    dataGridView1[0, i].Value = words[0];
                    //sala
                    dataGridView1[1, i].Value = words[1];
                    //assunto
                    dataGridView1[2, i].Value = words[2];
                    //data
                    dataGridView1[3, i].Value = words[3];
                    //hora
                    dataGridView1[4, i].Value = words[4];
                    //estado
                    dataGridView1[5, i].Value = words[5];
                    //comentario
                    dataGridView1[6, i].Value = words[6];
                    //resposta
                    dataGridView1[7, i].Value = words[7];
                    i++;
                }
            }
            else
            {
                MessageBox.Show("Não há nenhuma notificação para verificar!");
                Form consultas = new Consultas();
                consultas.Show();
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form f = new Consultas();
            f.Show();
            this.Close();
        }
    }
}
