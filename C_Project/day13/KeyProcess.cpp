#include "KeyProcess.h"         // 자기 자신의 헤더를 include

int choose;

void KeyProcess()
{
    // 키보드 입력
    choose = -1;    // 음수 : 값이 없음을 의미 (입력된 키 값 초기화 (reset))
    if (_kbhit())
    {
        choose = _getch();
        if (choose == 224)
            choose = _getch();
    }
}