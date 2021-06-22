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
using AcessoRemotoInterface.Configuracao;

namespace AcessoRemotoInterface.Conexao
{
    static class SalvarComandos
    {

        static public void SalvarComandosEmArquivo(Queue<string> comandos)
        {

            while (comandos.Any())
            {
                try
                {
                    File.AppendAllLines(Constantes.pathArquivoComandos, comandos);
                    comandos.Clear();
                }
                catch (System.IO.IOException ex)
                {}
            }
        }
    }
}
