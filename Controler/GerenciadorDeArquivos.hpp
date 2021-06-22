#include <conio.h>
#include <stdio.h>
#include <iostream>
#include <fstream>
#include <queue>
#include <windows.h>

using namespace std;

class GERENCIADORDEARQUIVOS
{

private:
    ifstream Arquivo;

    CONSTANTES* Constantes = new CONSTANTES();


public:
    GERENCIADORDEARQUIVOS(){}


queue<string> LerArquivo()
{
    queue<string> fila;
    string linhaTemporaria;

    Arquivo.open(Constantes->comandos_txt);
    if (Arquivo.is_open())
    {
        while (!Arquivo.eof())
        {
            getline(Arquivo, linhaTemporaria);
            if(linhaTemporaria.length()>2)
                fila.push(linhaTemporaria);
        }

        Arquivo.close();
        ApagarArquivo();
    }
    return fila;
}

void ApagarArquivo()
{
    remove(Constantes->comandos_txt.c_str());
}





};
