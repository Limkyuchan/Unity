
// 헤더를 한 번만 참조할 수 있도록 설정하는 방법(#ifndef, #define, #endif)
#ifndef _SUM_H_		// 정의가 되어있지 않다면 코드 실행. (다른 곳에서 코드를 포함하지 못함)
#define _SUM_H_		// 정의를 진행하고 실행

int Sum();			// 함수 원형을 헤더파일(.h)에 작성해준다.

extern int x;		// 외부에서의 접근을 허용하도록 extern 작성. 단, 값을 초기화 하면 안된다(다른 값으로 인식). 오직 선언만 가능!
extern int y;		// Sum.cpp에 작성된 변수를 외부에서도 접근하도록 선언

#endif
