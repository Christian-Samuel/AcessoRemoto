using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcessoRemotoInterface
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var controladorForm = new ControladorForm();
            controladorForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var configuracaoform = new ConfiguracaoForm();
            configuracaoform.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var clienteForm = new ClienteForm();
            clienteForm.Show();
            this.Hide();
        }
    }
}
