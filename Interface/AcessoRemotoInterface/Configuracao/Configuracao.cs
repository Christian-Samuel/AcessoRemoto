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

namespace AcessoRemotoInterface.Configuracao
{
    static class Configuracao
    {

       static public void SalvarConfiguracaoConexao(Queue<string> confs,int tipo)
       {
            var ArquivoConf = new StreamWriter(tipo == 0 ? Constantes.pathArquivoConfiguracaoControlador : Constantes.pathArquivoConfiguracaoCliente);
            
            while(confs.Any())
            {
                ArquivoConf.WriteLine(confs.Dequeue());
            }

            ArquivoConf.Close();
       }

        static public Queue<string> CarregarConfiguracaoConexao(int tipo)
        {
            var ArquivoConf = new StreamReader(tipo == 0 ? Constantes.pathArquivoConfiguracaoControlador : Constantes.pathArquivoConfiguracaoCliente);
            var confs = new Queue<string>();

            while(!ArquivoConf.EndOfStream)
            {
                confs.Enqueue(ArquivoConf.ReadLine());
            }

            return confs;
        }
    }
}
