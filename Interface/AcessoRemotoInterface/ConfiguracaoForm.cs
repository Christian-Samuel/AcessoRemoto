using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AcessoRemotoInterface.Configuracao.Configuracao;


namespace AcessoRemotoInterface
{
    public partial class ConfiguracaoForm : Form
    {
        public ConfiguracaoForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var confs = new Queue<string>();
            
            confs.Enqueue(txtServidorControlador.Text);
            confs.Enqueue(txtPortaControlador.Text);
            confs.Enqueue(txtDbControlador.Text);
            confs.Enqueue(txtUsuarioControlador.Text);
            confs.Enqueue(txtSenhaControlador.Text);

            SalvarConfiguracaoConexao(confs, 0);
        }
    }
}
