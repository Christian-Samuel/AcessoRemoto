#include <conio.h>
#include <stdio.h>
#include <iostream>
#include <windows.h>

using namespace std;

void MovimentarMouse(int x, int y)
{
    POINT ponto;

    GetCursorPos(&ponto);
    SetCursorPos(x,y);
}

void ClickEsquerdoMouse()
{
    INPUT inputs[2];
    ZeroMemory(inputs, sizeof(inputs));

    inputs[0].type = INPUT_MOUSE;
    inputs[0].mi.dwFlags = MOUSEEVENTF_LEFTDOWN;

    inputs[1].type = INPUT_MOUSE;
    inputs[1].mi.dwFlags = MOUSEEVENTF_LEFTUP;

    SendInput(2,inputs,sizeof(INPUT));
}

void ClickDireitoMouse()
{
    INPUT inputs[2];
    ZeroMemory(inputs, sizeof(inputs));

    inputs[0].type = INPUT_MOUSE;
    inputs[0].mi.dwFlags = MOUSEEVENTF_RIGHTDOWN;

    inputs[1].type = INPUT_MOUSE;
    inputs[1].mi.dwFlags = MOUSEEVENTF_RIGHTUP;

    SendInput(2,inputs,sizeof(INPUT));
}
