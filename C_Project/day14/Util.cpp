#include "Util.h"

void GotoXY(int x, int y)
{
    COORD pos = { x * 2, y };           // WINDOW API���� ���Ǵ� ����ü�� �Ϲ������� 2���� ��鿡���� ��ǥ(X, Y)�� ��Ÿ���� ���� ���ȴ�.
    SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE), pos);     // �ܼ� ȭ���� Ŀ���� pos ������ ��Ÿ���� ��ġ�� �̵� ��Ű�ڴ�!
}

void SetCursorType(CURSOR_TYPE type)
{
    CONSOLE_CURSOR_INFO cursorInfo;

    switch (type)
    {
    case NO_CURSOR:
        cursorInfo.dwSize = 1;          // dwSize : Ŀ�� ������
        cursorInfo.bVisible = FALSE;    // bVsible : Ŀ���� ���̰� ����, ������ �ʰ� ����
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