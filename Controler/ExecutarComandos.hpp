using namespace std;
class EXECUTARCOMANDOS{
private:
    CONSTANTES* Constantes = new CONSTANTES();


public:
    EXECUTARCOMANDOS() {};

void StartComando(string comando)
{
    ConverterTxtParaComando(comando);

}

void ConverterTxtParaComando(string comando)
{
    string siglaComando;
    string parametroComando;

    siglaComando = SepararSiglaComando(comando);
    parametroComando = SepararParametroComando(comando);
   
    
    if (siglaComando == Constantes->clicarMouse)
    {
        if (parametroComando[0] == Constantes->cliqueMouseEsquerdo)
            ClickEsquerdoMouse();

        if (parametroComando[0] == Constantes->cliqueMouseDireito)
            ClickDireitoMouse ();
    }

    if (siglaComando == Constantes->movimentarMouse)
    {
        int* parametros = ConverterParametros(parametroComando);
        MovimentarMouse(parametros[0], parametros[1]);
        delete[] parametros;
    }
    

}

string SepararSiglaComando(string comando)
{
    return comando.substr(0,2);
}

string SepararParametroComando(string comando)
{
    return comando.substr(3,comando.length());
}

int* ConverterParametros(string parametro)
{
    int* parametros = new int[2];
    int posicaoDoEspaco;

    posicaoDoEspaco = parametro.find(" ");

    parametros[0] = atoi(parametro.substr(0,posicaoDoEspaco).c_str());
    parametros[1] = atoi(parametro.substr(posicaoDoEspaco+1,parametro.length()).c_str());

    return TransformarParametros(parametros);
}

int* TransformarParametros(int* parametros)
{
    parametros[0] = (int)(parametros[0] / Constantes->taxaDePosicaoX);
    parametros[1] = (int)(parametros[1] / Constantes->taxaDePosicaoY);

    return parametros;
}

};
