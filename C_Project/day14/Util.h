#ifndef _UTIL_H_		
#define _UTIL_H_	

#include <Windows.h>
enum CURSOR_TYPE    // Ŀ�� Ÿ�� enum
{
    NO_CURSOR,
    SOLID_CURSOR,
    NORMAL_CURSOR
};

void GotoXY(int x, int y);              // �Լ� ������ �������(.h)�� �ۼ����ش�.
void SetCursorType(CURSOR_TYPE type);

#endif // !_UTIL_H_