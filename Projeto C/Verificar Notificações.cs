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
            if (pessoas.nomeut != "admin" && pessoas.nomeut != "serviçosinf")
            {
                label2.Visible = false;
                comboBox1.Visible = false;
                //botao submeter resposta
                button2.Visible = false;
                //texto da resposta
                textBox1.Visible = false;
                //label da resposta a notificaçao
                label1.Visible = false;
                //coluna 6 - estado passa a readonly para docentes
                Column6.ReadOnly = true;
            }
            if (pessoas.nomeut == "admin" && pessoas.nomeut == "serviçosinf")
            {
                //coluna 6 - estado passa a ter alteraçao possivel para o admin e serviços
                Column6.ReadOnly = false;
            }
            string notificacao = @"notificaçoes.txt";
            string linha = "";
            StreamReader sr;
            int i = 0;
            if (File.Exists(notificacao))
            {
                if (pessoas.nomeut == "admin" || pessoas.nomeut == "serviçosinf")
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
                        if (words[8] == "" && words[9] == "")
                        {
                            //data resposta
                            dataGridView1[8, i].Value = "";
                            //hora resposta
                            dataGridView1[9, i].Value = "";
                            i++;
                        }
                        else
                        {
                            //data resposta
                            dataGridView1[8, i].Value = words[8];
                            //hora resposta
                            dataGridView1[9, i].Value = words[9];
                            i++;
                        }
                    }
                    sr.Close();
                }
                else
                {
                    sr = File.OpenText(notificacao);
                    while ((linha = sr.ReadLine()) != null)
                    {
                        string[] words = linha.Split(';');
                        if (words[0] == pessoas.nomeut)
                        {
                            dataGridView1.Rows.Add(1);
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
                            //data resposta
                            dataGridView1[8, i].Value = words[8];
                            //hora resposta
                            dataGridView1[9, i].Value = words[9];
                            i++;
                        }
                    }
                    sr.Close();
                }
            }
            else
            {
                MessageBox.Show("Não há nenhuma notificação para verificar!");
                Form consultas = new Consultas();
                consultas.Show();
                this.Close();
            }
            //ESCOLHER UTILIZADOR-----------------------------
            string escolherUTIL = @"escolherUTIL.txt";
            string utilizadores = @"utilizadores.txt";
            StreamWriter create = File.CreateText(escolherUTIL);//cria ficheiro para escolher utilizador
            create.Close();
            if (File.Exists(escolherUTIL))//vai existir sempre
            {
                StreamReader sr1 = File.OpenText(utilizadores);//abre os utilizadores para leitura
                while ((linha = sr1.ReadLine()) != null)
                {
                    string[] words = linha.Split(';');//divide em ';'
                    if ((words[0] != "admin") && (words[0] != "serviçosinf"))//se nome de utilizador não for admin ou serviços, copia para o ficheiro
                    {
                        StreamWriter sw1 = File.AppendText(escolherUTIL);
                        sw1.WriteLine(words[0]);
                        sw1.Close();
                    }
                }
                sr1.Close();
            }
            StreamReader sr2 = File.OpenText(escolherUTIL);//abre a escolha de utilizadores para inserir na combobox
            while ((linha = sr2.ReadLine()) != null)
            {
                comboBox1.Items.Add(linha);
            }
            sr2.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form f = new Consultas();
            f.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Escrevr a resposta no ficheiro notificaçoes.txt
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                //Confirma se existe uma row selecionada
                if (dataGridView1.Rows[i].Selected == true)
                {
                    if (textBox1.Text != "")
                    {
                        if (dataGridView1[7, i].Value.ToString() == "")
                        {
                            dataGridView1[7, i].Value = textBox1.Text;
                            string notificacao = @"notificaçoes.txt";
                            if (File.Exists(notificacao))
                            {
                                //abre o ficheiro para verificar em q linha o espaços da datagridview se encontram
                                StreamReader sr = File.OpenText(notificacao);
                                string linha = "";
                                while ((linha = sr.ReadLine()) != null)
                                {
                                    string[] words = linha.Split(';');
                                    //confirmação
                                    if ((dataGridView1[0, i].Value.ToString() == words[0]) && (dataGridView1[1, i].Value.ToString() == words[1]) && (dataGridView1[2, i].Value.ToString() == words[2]) &&
                                        (dataGridView1[3, i].Value.ToString() == words[3]) && (dataGridView1[4, i].Value.ToString() == words[4]) && (dataGridView1[5, i].Value.ToString() == words[5]) &&
                                        (dataGridView1[6, i].Value.ToString() == words[6]) && (words[7] == ""))
                                    {
                                        dataGridView1[5, i].Value = "Concluído";
                                        dataGridView1[8, i].Value = DateTime.Now.ToString("HH:mm");
                                        dataGridView1[9, i].Value = DateTime.Today.ToString("dd/MM/yyyy");
                                        sr.Close();
                                        if (linha == words[0] + ";" + words[1] + ";" + words[2] + ";" + words[3] + ";" + words[4] + ";" + "Pendente" + ";" + words[6] + ";" + ";" + ";")
                                        {
                                            string linhareplace = words[0] + ";" + words[1] + ";" + words[2] + ";" + words[3] + ";" + words[4] + ";" + "Concluído" + ";" + words[6] + ";" + dataGridView1[7, i].Value.ToString() + ";" + dataGridView1[8, i].Value.ToString() + ";" + dataGridView1[9, i].Value.ToString();

                                            string remover = File.ReadAllText(notificacao);
                                            remover = remover.Replace(linha, linhareplace);
                                            File.WriteAllText(notificacao, remover);
                                        }
                                        MessageBox.Show("Resposta Enviada!");
                                        goto end;
                                    }
                                }
                                sr.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("A notificação que selecionou já tem resposta");
                            goto end;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Escreva uma resposta.");
                        goto end;
                    }
                }
            }
            //Caso não selecione nenhuma row
            MessageBox.Show("Selecione primeiro uma row.");
        end:;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = 0;
            string linha = "";
            string notificacao = @"notificaçoes.txt";            
            if ((comboBox1.Text == "Todos") || (comboBox1.Text == ""))
            {
                dataGridView1.Rows.Clear();
                //copia todas as notificações para a datagridview
                StreamReader sr = File.OpenText(notificacao);
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
                    if (words[8] == "" && words[9] == "")
                    {
                        //data resposta
                        dataGridView1[8, i].Value = "";
                        //hora resposta
                        dataGridView1[9, i].Value = "";
                        i++;
                    }
                    else
                    {
                        //data resposta
                        dataGridView1[8, i].Value = words[8];
                        //hora resposta
                        dataGridView1[9, i].Value = words[9];
                        i++;
                    }
                }
                sr.Close();
            }
        
            else
            {
                dataGridView1.Rows.Clear();
                if (File.Exists(notificacao))
                {
                    StreamReader srUTIL;
                    //copia todas as notificações para a datagridview
                    srUTIL = File.OpenText(notificacao);
                    while ((linha = srUTIL.ReadLine()) != null)
                    {
                        string[] words = linha.Split(';');
                        if (words[0] == comboBox1.Text)
                        {
                            dataGridView1.Rows.Add(1);                            
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
                            if (words[8] == "" && words[9] == "")
                            {
                                //data resposta
                                dataGridView1[8, i].Value = "";
                                //hora resposta
                                dataGridView1[9, i].Value = "";
                                i++;
                            }
                            else
                            {
                                //data resposta
                                dataGridView1[8, i].Value = words[8];
                                //hora resposta
                                dataGridView1[9, i].Value = words[9];
                                i++;
                            }
                        }
                    }
                }
            }
        }
    }
}
