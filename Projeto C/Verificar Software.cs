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
    public partial class Verificar_Software : Form
    {
        public Verificar_Software()
        {
            InitializeComponent();
        }

        private void Verificar_Software_Load(object sender, EventArgs e)
        {
            string salas = @"salas.txt";
            string linha = "";
            StreamReader sr = File.OpenText(salas);
            while((linha = sr.ReadLine())!= null)
            {
                listBox1.Items.Add(linha);
            }
            sr.Close();
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                StreamReader sala;
                string sala1 = @"" + listBox1.Items[i].ToString() + ".txt";
                if (File.Exists(sala1))
                {
                    sala = File.OpenText(sala1);
                    while ((linha = sala.ReadLine()) != null)
                    {
                        dataGridView1.Rows.Add(1);
                        string[] words = linha.Split(';');
                        dataGridView1[0, i].Value = listBox1.Items[i].ToString();
                        dataGridView1[1, i].Value = words[0];
                        dataGridView1[2, i].Value = words[1];
                        dataGridView1[3, i].Value = words[2];
                        dataGridView1[4, i].Value = words[3];
                    }
                }
                sr.Close();
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
