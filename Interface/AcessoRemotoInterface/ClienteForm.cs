using AcessoRemotoInterface.Conexao;
using AcessoRemotoInterface.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcessoRemotoInterface
{
    public partial class ClienteForm : Form
    {
        public ClienteForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ClienteToDB.GetEstado() == ConnectionState.Closed || ClienteToDB.GetEstado() == ConnectionState.Broken)
            {
                ClienteToDB.Conectar();
                btnConectar.Text = "Desconectar";
                lblStatus.Text = "Conectado";
                lblStatus.ForeColor = Color.Green;

                Process.Start("AcessoRemoto.exe");

                this.Visible = false;
                notifyIcon1.Visible = true;

                timer1.Enabled = true;
                timerCapTela.Enabled = true;
            }
            else
            {
                ClienteToDB.Desconectar();
                btnConectar.Text = "Conectar";
                lblStatus.Text = "Desconectado";
                lblStatus.ForeColor = Color.Red;


                timer1.Enabled = false;
                timerCapTela.Enabled = false;


                foreach (Process process in Process.GetProcessesByName("AcessoRemoto"))
                {
                    process.Kill();
                    process.WaitForExit();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ClienteToDB.GetEstado() != ConnectionState.Closed && ClienteToDB.GetEstado() != ConnectionState.Broken)
            {
                var comandos = ClienteToDB.ReceberComando();
                SalvarComandos.SalvarComandosEmArquivo(comandos);
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!this.Visible)
                this.Visible = true;

            this.WindowState = FormWindowState.Maximized;
            notifyIcon1.Visible = false;
        }

        private void timerCapTela_Tick(object sender, EventArgs e)
        {
            CapturaDeTela.CapturarTela();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }
}
