#include <stdio.h>
#include <conio.h>
#include <stdlib.h>
#include <Windows.h>
#include <time.h>
#include "Util.h"
#include "GameProcess.h"
#include "KeyProcess.h"
#include "DrawGame.h"

/* 2024/02/29 : 전처리기, 파일 분할, 보석찾기게임 파일 분할
*
// C 언어 전처리기
// #define
// 한 줄 형태의 함수를 define으로 정의할 수 있다.(매크로 함수)
// 값을 작성하고 원하는 값으로 대체하여 정의한다.
// 매크로 함수 유의점 : 코드의 내용이 그대로 대치되기 때문에 계산 시 괄호사용에 유의해야 한다.

// 삼항연산자
// a < b ? a : b
// 참이면 a, 거짓이면 b

// #ifdef ~ #endif / #ifndef ~ #endif
// #define CAR : 뒤의 값이 없는 경우 값의 대체가 아닌 해당 변수가 정의가 됐는지 안됐는지의 여부를 확인한다.
// #ifdef CAR   = 만약에 CAR라는 내용으로 정의가 되어있다면 (정의가 됐는지 안됐는지가 조건)
// ~
// #endif       = #endif 가 나올때까지 #ifdef 의 공간으로 인식
// #ifndef BUS  = #ifndef : BUS가 정의 되어있지 않다면
// ~
// #endif
// 사용 이유: 코드에 이 내용을 포함할건지를 미리 결정하기 위해 #ifdef ~ #endif를 사용한다.
// 일반적인 if문으로 사용하면 골라서 선택을 하고 사용하지 않는 코드도 메모리에 올라간다.
// 미리 올려서 코드를 포함할건지 안할건지 미리 결정(실행도 안하고 컴파일도 하지 않는다)
// ex) 게임에서 키보드, 조이스틱, 터치 사용관련 코드에서 필요한 코드만 사용하도록.(필요없는 코드는 배제)

*/

// C 언어 전처리기
/*
// 전처리기와 함수 비교 예시 (동일한 내용)
#define MIN(a,b) a < b ? a : b      // 매크로 함수
int Min(int a, int b)
{
    return a < b ? a : b;
}

// 전처리기 예시 1
#define MAX(a,b) a > b ? a : b
#define MIN(a,b) a < b ? a : b
#define P printf

// 전처리기 예시 2
#define SQUARE1(a) a * a
#define SQUARE2(a) ((a) * (a))
#define P printf
int Square(int a)
{
    return a * a;
}

// 전처리기 예시 3
#define CAR         // 정의된 CAR
//#define BUS       // 정의되지 않은 BUS
#define P printf

// 전처리기 예시 4
#define IPHONE
#define ANDROID
#define P printf
*/


// C 언어 파일 분할 (.h, .cpp 파일 추가)
#include "Sum.h"        // 헤더를 참조 (Sum함수를 찾는다.)


int main()
{
    // 2024/02/29 : 전처리기, 파일 분할, 보석찾기게임 파일 분할

    // C 언어 전처리기
    /*
    // 전처리기와 함수 비교 예시
    Min(10, 20);
    MIN(20, 30);        // MIN(20, 30);  ==>  20 < 30 ? 20 : 30; (화살표 뒤의 값으로 바뀌어 들어온다.)

    // 전처리기 예시 1
    P("%d, %d 중 큰 값은 : %d\n", 30, 100, MAX(30, 100));
    P("%d, %d 중 작은 값은 : %d\n", 30, 100, MIN(30, 100));

    // 전처리기 예시 2
    P("SQUARE1(10) = %d\n", SQUARE1(10));   // 100
    P("SQUARE2(10) = %d\n", SQUARE2(10));   // 100
    P("Square(10) = %d\n", Square(10));     // 100
    P("\n");
    P("SQUARE1(3 + 7) = %d\n", SQUARE1(3 + 7));     // 31 => 3 + 7 * 3 + 7
    P("SQUARE2(3 + 7) = %d\n", SQUARE2(3 + 7));     // 100
    P("Square(3 + 7) = %d\n", Square(3 + 7));       // 100

    // 전처리기 예시 3
    P("\n");
    #ifdef CAR      // CAR가 정의되어 있다면
        P("나는 자동차로 출근합니다.\n");
    #endif
    #ifndef BUS     // 버스가 정의되어있지 않다면
        P("나는 버스로 출근하지 않습니다.\n");
    #endif

    // 전처리기 예시 4
    P("\n");
    #if ((defined IPHONE) || (defined ANDROID))                     // IPHONE과 ANDROID가 정의되어 있다면 실행하는 코드
            P("모바일 코드를 실행합니다.\n");
    #elif ((defined WIN7) || (defined WIN8) || (defined WIN10))     // WIN7, 8, 10 이 정의되어 있다면 실행되는 코드
            P("PC 코드를 실행합니다.\n");
    #endif
    #if((!defined WIN7) || (!defined WIN8) || (!defined WIN10))     // WIN7, 8, 10 이 정의되어 있지 않으면 실행되는 코드 (!:부정)
            P("PC버전이 활성화 되어있지 않습니다.");
    #endif
    */


    // C 언어 파일 분할 (헤더파일 Sum.h , Sum.cpp)
    /*
    x = 3;
    y = 5;
    printf("%d + %d = %d\n", x, y, Sum());
    */


    // 보석찾기게임 파일 분할
    SetCursorType(NO_CURSOR);   // 커서 형태를 결정
    while (true)
    {
        KeyProcess();
        GameProcess();
        DrawGame();
    }

}
