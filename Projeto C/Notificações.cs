﻿using System;
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
            button7.Hide();
            listBox2.Hide();
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
            //O form, ao dar load, carrega todas as salas para a listbox1
            string salas = @"salas.txt";
            if (File.Exists(salas))
            {
                StreamReader sr = File.OpenText(salas);
                string linhaS;
                while ((linhaS = sr.ReadLine()) != null)
                {
                    listBox2.Items.Add(linhaS);
                }
                sr.Close();
            }
            //ao iniciar o form carrega os assuntos todos para a listbox1
            string assuntos = @"assuntos.txt";
            if (File.Exists(assuntos))
            {
                StreamReader sr = File.OpenText(assuntos);
                string linhaA;
                while ((linhaA = sr.ReadLine()) != null)
                {
                    listBox1.Items.Add(linhaA);
                }
                sr.Close();
            }
            //mudança de estado para admin e serviços inf./docentes                        
            if ((textBox1.Text == "admin") || (textBox1.Text == "serviçosinf"))
            {
                button5.Hide();//botao enviar notificaçao
                button6.Show();//botao submeter comentario
                richTextBox1.ReadOnly = true;//texto da resposta aos comentarios
                richTextBox2.ReadOnly = false;//texto do comentarios
                button4.Show();//botao de mudar o estado
                textBox3.ReadOnly = true;//botao do assunto para a não poder ser editado
                button1.Hide();
                button8.Hide();
            }
            else
            {
                button5.Show();
                button6.Hide();
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

        private void button6_Click(object sender, EventArgs e)
        {

        }

        //botao enviar notificaçao
        private void button5_Click(object sender, EventArgs e)
        {
            string ficheiro = @"notificaçoes.txt";
            if (File.Exists(ficheiro))
            {
                if ((maskedTextBox1.Text==""))//se nao for escolhida a sala
                {
                    MessageBox.Show("Escolha a sala pretendida");
                }
                else if (textBox3.Text=="")//se nao for escolhido o assunto
                {
                    MessageBox.Show("Escolha ou digite um assunto.");
                }
                else if (richTextBox1.Text=="")//se nao for feito comentário
                {
                    MessageBox.Show("Insira um comentário.");
                }
                else
                {
                    string docente = textBox1.Text;//string do docente para o ficheiro de texto
                    string sala = maskedTextBox1.Text;//string sala para o ficheiro de texto
                    string assunto = textBox3.Text;//string do assunto para o ficheiro de texto
                    string comentario = richTextBox1.Text;//string do comentario para o ficheiro de texto
                    string data = textBox4.Text;//string da data para o ficheiro de texto
                    string hora = textBox5.Text;//string da hora para o ficheiro de texto
                    string estado = textBox2.Text;//string do estado para o ficheiro de texto

                    StreamWriter sw = File.AppendText(ficheiro);
                    sw.WriteLine(docente + "; " + sala + "; " + assunto + "; " + comentario + "; " + data + "; " + hora + "; " + estado + "; ");
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            listBox1.Hide();
            button2.Hide();
            listBox2.Show();
            button7.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button7.Hide();
            listBox2.Hide();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selecionado = listBox2.SelectedItem.ToString();
            maskedTextBox1.Text = selecionado;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
