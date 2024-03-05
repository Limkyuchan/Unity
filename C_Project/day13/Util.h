#ifndef _UTIL_H_		
#define _UTIL_H_	

#include <Windows.h>
enum CURSOR_TYPE    // 커서 타입 enum
{
    NO_CURSOR,
    SOLID_CURSOR,
    NORMAL_CURSOR
};

void GotoXY(int x, int y);              // 함수 원형을 헤더파일(.h)에 작성해준다.
void SetCursorType(CURSOR_TYPE type);

#endif // !_UTIL_H_