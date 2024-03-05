#include "Util.h"

void GotoXY(int x, int y)
{
    COORD pos = { x * 2, y };           // WINDOW API에서 사용되는 구조체로 일반적으로 2차원 평면에서의 좌표(X, Y)를 나타내가 위해 사용된다.
    SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE), pos);     // 콘솔 화면의 커서를 pos 변수가 나타내는 위치로 이동 시키겠다!
}

void SetCursorType(CURSOR_TYPE type)
{
    CONSOLE_CURSOR_INFO cursorInfo;

    switch (type)
    {
    case NO_CURSOR:
        cursorInfo.dwSize = 1;          // dwSize : 커서 사이즈
        cursorInfo.bVisible = FALSE;    // bVsible : 커서를 보이게 할지, 보이지 않게 할지
        break;
    case SOLID_CURSOR:
        cursorInfo.dwSize = 100;
        cursorInfo.bVisible = TRUE;
        break;
    case NORMAL_CURSOR:
        cursorInfo.dwSize = 20;
        cursorInfo.bVisible = TRUE;
        break;
    }
    SetConsoleCursorInfo(GetStdHandle(STD_OUTPUT_HANDLE), &cursorInfo);
}