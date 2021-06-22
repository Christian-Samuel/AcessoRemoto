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

namespace AcessoRemotoInterface.Conexao
{
    static class GerarComando
    {
        static private Point posicaoAnterior;
        static public void EnviarCliqueMouse(int clique)
        {
            ControlerToDB.EnviarComando($"MC {(clique == 1 ? 'E':'D')}");
        }

        static public void EnviarMovimentoMouse(Point movimento)
        {
            if (movimento.X != posicaoAnterior.X || movimento.Y != posicaoAnterior.Y)
            {
                posicaoAnterior = movimento;

                int direcaoX;
                int direcaoY;

                direcaoX = movimento.X >= 0 ? movimento.X : 0;
                direcaoY = movimento.Y >= 0 ? movimento.Y : 0;

                ControlerToDB.EnviarComando($"MM {direcaoX} {direcaoY}");
            }
        }
    }
}
