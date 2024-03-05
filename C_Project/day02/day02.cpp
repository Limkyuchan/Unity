#include <stdio.h>

/* 2024/02/14 : 입력(scanf), 배열 맛보기, 연산자
*
// 입력(scanf)
// scanf(); 를 사용할 때는 & 를 같이 적어야 한다.

// 배열 맛보기 (문자 입력받기)
// char name[10] : char 자료형인 name 변수명으로 10byte를 확보(연속적으로).
// 문자열의 경우 문자와는 다르게 인식한다.
// 문자열은 문자의 끝을 알려주는 NULL값 ('\0') 이 들어가야 한다.
//  ex) name[2] = '\0';
// 문자열의 길이를 모를 경우 []를 비워서 선언할 수 있다.
//  ex) char name[] = "abc...";
//
// 배열을 사용할 때는 scanf() 사용 시 주소 지정자(&)를 사용하지 않아도 된다.

// C 언어 산술 연산자
// / : 나눗셈 (몫)
// % : 나머지
// ++ : 1증가
// -- : 1감소

// C 언어 할당 연산자
// =, +=, -=, *=, /=, %=

// C 언어 관계 연산자
// >, >=, <, <=, == (같다), != (같지 않다)
*/

int main()
{
    // 2024/02/14 : 입력(scanf), 연산자
    
    // 예제) scanf()
    int a, b;

    scanf("%d", &a);                    // & : 주소 지정자 (메모리의 주소를 알려줌)
    printf("input 1 : %d\n", a);        // printf("%d", &a) --> a 값이 아닌 a의 주소 값이 찍힌다

    scanf("%d", &b);
    printf("input 2 : %d\n", b);

    printf("a + b = %d\n", a + b);


    // Q1. 나이, 키, 몸무게를 입력 받고 출력하시오.
    char name[11];
    int age = 0;
    float height = 0;
    float weight = 0;

    printf("이름을 입력해주세요(영문 10글자 한글 5글자 이내) : ");
    scanf("%s", name);
    printf("나이를 입력해주세요 : ");
    scanf("%d", &age);
    printf("신장을 입력해주세요 : ");
    scanf("%f", &height);
    printf("몸무게를 입력해주세요 : ");
    scanf("%f", &weight);

    printf("이름은 %s입니다. 나이는 %d이고 신장은 %.2fcm이며, 몸무게는 %.1fkg입니다.\n", name, age, height, weight);


    // 예제) 산술 연산자
    int c = 0;
    int d = 0;

    printf("%d\n", ++c);    // 전위증가 - 출력값 1 (최종값은 1)
    printf("%d\n", d++);    // 후위증가 - 출력값 0 (최종값은 1)
    
}

