#include "KeyProcess.h"         // �ڱ� �ڽ��� ����� include

int choose;

void KeyProcess()
{
    // Ű���� �Է�
    choose = -1;    // ���� : ���� ������ �ǹ� (�Էµ� Ű �� �ʱ�ȭ (reset))
    if (_kbhit())
    {
        choose = _getch();
        if (choose == 224)
            choose = _getch();
    }
}