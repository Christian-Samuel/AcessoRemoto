#include <string>
using namespace std;

class CONSTANTES{

public:
    CONSTANTES(){}


        string comandos_txt = "C:\\chrYstYan\\AcessoRemoto\\comandos.txt";

        char cliqueMouseEsquerdo = 'E';
        char cliqueMouseDireito = 'D';
        string movimentarMouse = "MM";
        string clicarMouse = "MC";


        float resolucaoX = GetSystemMetrics(SM_CXSCREEN);
        float resolucaoY = GetSystemMetrics(SM_CYSCREEN);

        float taxaDePosicaoX = 1305 / resolucaoX;
        float taxaDePosicaoY = 615 / resolucaoY;
};
