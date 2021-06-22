#include "Mouse.hpp"
#include "../Configuracao/Constantes.hpp"
#include "GerenciadorDeArquivos.hpp"
#include "ExecutarComandos.hpp"

#include <queue>

void AguradarComandos()
{
    queue<string> filaDeComandos;
    GERENCIADORDEARQUIVOS* GerenciadorDeArquivos = new GERENCIADORDEARQUIVOS();
    EXECUTARCOMANDOS* ExecutarComandos = new EXECUTARCOMANDOS();

    while(1)
    {
        filaDeComandos = GerenciadorDeArquivos->LerArquivo();
        while(!filaDeComandos.empty())
        {
            ExecutarComandos->StartComando(filaDeComandos.front());
            filaDeComandos.pop();
        }
        Sleep(10);
    }
}


int main()
{
    FreeConsole();
    AguradarComandos();
}
