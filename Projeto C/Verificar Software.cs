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
            //adiciona as salas todas à listbox para prevenir se houver alterações no ficheiro salas
            while((linha = sr.ReadLine())!= null)
            {
                listBox1.Items.Add(linha);
            }
            sr.Close();
            //Para cada sala, verifica se existe o ficheiro
            //se existir, passa todo o software dessa sala e avança para a próxima
            string num = listBox1.Items.Count.ToString();
            int num1 = Convert.ToInt16(num);
            for (int i = 0; i < num1; i++)
            {
                StreamReader sala;
                string sala1 = @"" + listBox1.Items[i].ToString() + ".txt";
                if (File.Exists(sala1))
                {
                    sala = File.OpenText(sala1);
                    while ((linha = sala.ReadLine()) != null)
                    {
                        string[] words = linha.Split(';');
                        dataGridView1.Rows.Add(listBox1.Items[i].ToString(), words[0], words[1], words[2], words[3]);

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
