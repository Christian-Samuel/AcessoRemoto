using AcessoRemotoInterface.Conexao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using System.Windows.Forms;
using System.IO;
using AcessoRemotoInterface.Utils;


namespace AcessoRemotoInterface
{
    public partial class ControladorForm : Form
    {
        public ControladorForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ControlerToDB.GetEstado() == ConnectionState.Closed || ControlerToDB.GetEstado() == ConnectionState.Broken)
            {
                ControlerToDB.Conectar();
                lblStatus.Text = "Conectado";
                lblStatus.ForeColor = Color.Green;
                timerReceberCaptura.Enabled = true;
                posicaoMouse.Enabled = true;
            }
            else
            {
                ControlerToDB.Desconectar();
                btnConectar.Text = "Conectar";
                lblStatus.Text = "Desconectado";
                lblStatus.ForeColor = Color.Red;
                timerReceberCaptura.Enabled = false;
                posicaoMouse.Enabled = false;
            }
        }

        private void ClickE_Click(object sender, EventArgs e)
        {
            Button clique = sender as Button;

            GerarComando.EnviarCliqueMouse(clique.Text.Equals("E") ? 1 : 2);
        }


        private void timerReceberCaptura_Tick(object sender, EventArgs e)
        {
           pictureBox1.Image.Dispose();
           pictureBox1.Image = null;
           pictureBox1.Image = Image.FromStream( CapturaDeTela.ConverterBytesToStream());
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void posicaoMouse_Tick(object sender, EventArgs e)
        {
            Point posicaoMouse = pictureBox1.PointToClient(Cursor.Position);
            GerarComando.EnviarMovimentoMouse(posicaoMouse);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
                GerarComando.EnviarCliqueMouse(2);

            if (e.Button == MouseButtons.Left)
                GerarComando.EnviarCliqueMouse(1);
        }
    }
}
