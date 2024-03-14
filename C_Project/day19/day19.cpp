#include <stdio.h>

/*
// 2024/03/13 : 구조체, 구조체 포인터, 파일 입출력

// C 언어 구조체 포인터
// 구조체 포인터 표현방식
// 1) (*me.name).first
// 2) me.name->first

// 구조체 패딩 바이트
// 구조체안의 가장 큰 자료형을 기준으로 패딩 바이트(버려지는 바이트)가 결정된다.
//  ex) char, int 자료형 2개가 들어오면 총 8Byte ==> 3Byte가 버려진다.
// 패딩 바이트가 있을 경우 그 안에 들어가는 자료형이 있다면 채워지기도 한다.
//  ex) 위의 상황에서 char 또는 short가 들어오는 경우
// 구조체에 자료형이 들어오는 순서에 따라 구조체의 전체 크기가 달리지기도 한다.

// C 언어 파일 입출력
// 컴퓨터는 파일을 텍스트 파일 or 2진수(바이너리) 두 가지로 구분한다.
// 파일의 정보를 읽고 메모리 주소를 받아옴 => 파일 포인터(void형) 이용.
// 파일을 열었다면(fopen) 반드시 닫아줘야 한다(fclose).
// 파일 액세스 모드
// - "r" : 파일 읽기모드, 파일 없으면 에러
// - "w" : 파일 쓰기모드, 파일 없으면 생성, 파일 있으면 지우고 생성
// - "a" : 파일 추가모드, 파일 없으면 생성, 파일 있으면 이어서 작성
// - "t" : 텍스트 파일 모드로 열기
// - "b" : 바이너리 파일 모드로 열기
//  ex) "rt", "rb", "wt", "wb"...

*/

/*
// 구조체 문제)
struct STUDENT
{
   char name[10];
   int kor;
   int eng;
   int math;
};
*/

// 구조체 예제 1), 1-1)
struct NAME
{
    char first[10];
    char last[10];
};
struct STUDENT
{
    int num;
    int cls;
    NAME name;
    NAME* ptrName;      // Name 포인터는 Name 구조체 변수의 주소를 기억
};

// 구조체 예제 2)
struct VALUE
{
    char a;
    char b;
    int c;            // 8Byte
};
struct VALUE2
{
    char a;
    int b;
    char c;            // 12Byte
};


int main()
{
    // 2024/03/13 : 구조체, 구조체 포인터, 파일 입출력

    /*
    // 구조체 문제) 학생의 이름, 국어, 영어, 수학을 멤버로 갖는 구조체를 선언하고 5명의 성적을 입력 받는 프로그램 작성
    STUDENT student[5];

    for (int i = 0; i < 5; i++)
    {
       printf("%d번째 학생 이름은? ", i + 1);
       scanf("%s", student[i].name);         // . 활용해 멤버 변수에 접근

       printf("국어 점수를 입력하세요: ");
       scanf("%d", &student[i].kor);         // 정수형 변수이기 때문에 주소지정자(&)를 사용

       printf("영어 점수를 입력하세요: ");
       scanf("%d", &student[i].eng);

       printf("수학 점수를 입력하세요: ");
       scanf("%d", &student[i].math);

       printf("\n");
    }
    for (int i = 0; i < 5; i++)
    {
       printf("%s 학생 성적\n", student[i].name);
       printf("국어 [%.3d] 영어 [%.3d] 수학 [%.3d]\n", student[i].kor, student[i].eng, student[i].math);
    }


    // 구조체 예제 1)
    STUDENT me = { 1, 2, "길동", "홍" };
    printf("번호: %d, 반: %d, 이름: %s, 성: %s\n", me.num, me.cls, me.name.first, me.name.last);

    // 구조체 예제 1-1) 구조체 포인터
    NAME ptrName = { "순신", "이" };      // NAME(자료형) ptrName(변수명) -> stack 메모리에 할당
    STUDENT me2 = { 2, 3 };
    me2.ptrName = &ptrName;
    printf("번호: %d, 반: %d, 이름: %s, 성: %s\n", me2.num, me2.cls, (*me2.ptrName).first, me2.ptrName->last);


    // 구조체 예제 2)
    VALUE val;
    VALUE2 val2;
    printf("구조체  VALUE 크기: %dByte\n", sizeof(val));
    printf("구조체 VALUE2 크기: %dByte\n", sizeof(val2));


    // 텍스트 파일 입출력 예제)
    FILE* fp;                     // 파일의 정보를 얻기 위해 파일의 메모리 주소를 가져온다.
    fp = fopen("test.txt", "r");      // 현재 test.txt의 위치: 현재 소스코드가 있는 곳의 경로
    if (fp == NULL)   printf("파일 열기 실패!\n");
    fclose(fp);
    */

    // 텍스트 파일 입출력 예제 2)
    FILE* fp;
    int num1 = 0, num2 = 0, result = 0;
    char ch1, ch2;

    fp = fopen("multiple_table.txt", "wt");
    if (fp == NULL)
    {
        printf("파일을 여는데 실패하였습니다.");
        return 0;
    }
    for (int i = 1; i < 10; i++)
        fprintf(fp, "2 x %d = %d\n", i, 2 * i);
    fclose(fp);

    fp = fopen("multiple_table.txt", "rt");
    if (fp == NULL)
    {
        printf("파일을 여는데 실패하였습니다.");
        return 0;
    }
    for (int i = 1; i < 10; i++)
    {
        fscanf(fp, "%d %c %d %c %d", &num1, &ch1, &num2, &ch2, &result);
        printf("%d %c %d %c %d\n", num1, ch1, num2, ch2, result);
    }
    fclose(fp);

}
