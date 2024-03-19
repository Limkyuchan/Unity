#include <stdio.h>
#include <stdlib.h>
#include <malloc.h>
#include <string.h>

/*
// 2024/03/12 : 동적 할당(문자열 관리, 확장성), 구조체

// C 언어 문자열 초기화 방법
// strcpy(메모리 공간(주소), 입력할 문자열)
// strcpy를 활용해 문자열을 메모리에 복사해서 넣을 수 있다.

// ☆ C 언어 포인터 사용 시 주의법
// ☆ 비어있는 포인터는 절대 사용하면 안된다.
// ☆ 항상 NULL인지 아닌지를 확인하고 포인터를 사용해야 한다.

// 동적 할당 memset
// 동적 할당을 받을 경우 보통 초기화가 되어있지 않다.
// 그렇기 때문에 Heap 메모리 초기화할 때 memset을 사용한다.
// memset(ptr, 0, sizeof(int) * size) => 시작주소(메모리 시작위치)부터, 0으로 초기화, 배열 전체크기만큼

// C 언어 구조체 (struct)
// 구조체 = 구조형 자료형
// .을 찍으면 멤버 변수에 접근할 수 있다.

// C 언어 구조체 (typedef struct)
// 원하는대로 형을 정의해서 사용할 수 있다.
//
// 원형:
// typedef struct tagMonster
// {
//   int hp;
// } Monster;   (별칭)

*/


// 동적 할당 예제 4)
#define SMALL   4
#define BIG     8

// 구조체 예제)
struct PERSON
{
    char name[10];
    int age;
    float weight;
};

// 구조체 예제 2)
typedef struct tagPERSON
{
    char name[10];
    int age;
    float weight;
}PERSON;


int main()
{
    // 2024/03/12 : 동적 할당(문자열 관리, 확장성), 구조체

    
    // 동적 할당 예제 1)
    int length = 0;
    int* pList = NULL;      // NULL : 내가 가르키는 공간이 비어있다를 의미.

    printf("배열의 길이를 입력하세요: ");
    scanf("%d", &length);

    pList = (int*)malloc(sizeof(int) * length);
    for (int i = 0; i < length; i++)
    {
        pList[i] = i + 1;
        printf("pList[%d] : %3d\n", i, pList[i]);
    }
    printf("\n");
    free(pList);


    // 동적 할당 예제 2) 문자열 관리
    char name[13];                      // 문자열 초기화 방법.
    strcpy(name, "Lim Kyu Chan");       // strcpy(메모리 공간(주소), 입력할 문자열)
    printf("%s\n\n", name);             // strcpy를 활용해 문자열을 메모리에 복사해서 넣을 수 있다.


    // 동적 할당 예제 2-1) 문자열 관리(strlen, strcpy)
    char* str1 = (char*)malloc(strlen("공유는") + 1);          // malloc을 통해 문자열 받을 공간을 할당
    char* str2 = (char*)malloc(strlen("TVN 드라마") + 1);
    char* str3 = (char*)malloc(strlen("도깨비에서 남자 주인공이다.") + 1);

    strcpy(str1, "공유는");            // strcpy(메모리 공간(주소), 입력할 문자열)
    strcpy(str2, "TVN 드라마");        // strcpy를 활용해 입력할 문자열을 메모리에 복사해서 넣을 수 있다.
    strcpy(str3, "도깨비에서 남자 주인공이다.");
    printf("%s %s %s\n\n", str1, str2, str3);
    free(str1);
    free(str2);
    free(str3);


    // 동적 할당 예제 3) memset
    int* ptr = NULL;
    int size = 10;

    ptr = (int*)malloc(sizeof(int) * size);
    if (ptr != NULL)                            // ☆비어있는 포인터를 사용하지 않기 위해 확인.
    {
        memset(ptr, 0, sizeof(int) * size);     // memset(ptr, 0, sizeof(int) * size)
        for (int i = 0; i < size; i++)          // => 시작주소(ptr) 부터 배열 전체크기만큼(sizeof) 0으로 초기화(0)
        {
            printf("%d : %d \n", i, *ptr++);    // *ptr++ => *ptr = *ptr + 1   (주소가 시작지점에서 한칸씩 이동한다.)
        }
        // Error : ptr이 처음 주소의 위치가 아닌 10만큼 이동하여 주소를 가르키고 있음.
        free(ptr);
    }


    // 동적 할당 예제 4) 동적할당 부족할 때 방법(확장성)
    int* ptr = NULL;
    ptr = (int*)malloc(sizeof(int) * SMALL);        // ptr에 4개의 공간 할당
    for (int i = 0; i < SMALL; i++)
    {
        ptr[i] = i + 1;
    }

    int* temp = (int*)malloc(sizeof(int) * BIG);    // temp에 8개의 공간 할당
    memset(temp, 0, sizeof(int) * BIG);             // temp 모든 값 0으로 초기화
    for (int i = 0; i < SMALL; i++)                 // 기존의 ptr값을 temp로 전달
    {
        temp[i] = ptr[i];
    }
    free(ptr);                                      // 4개의 공간 참조하는 ptr 해제

    ptr = temp;                                     // ptr이 temp가 바라보는 주소를 같이 참조
    for (int i = 0; i < BIG; i++)
    {
        printf("ptr[%d] = %d\n", i, *(ptr + i));
    }
    free(ptr);                                      // 8개의 공간 참조하는 ptr 해제


    // 동적 할당 예제 5) 성적 관리 프로그램(확장성)
    int student = 0, input = 0, sum = 0;
    int* score;

    printf("학생의 수는? : ");
    scanf("%d", &student);
    score = (int*)malloc(sizeof(int) * student);

    for (int i = 0; i < student; i++)
    {
        printf("학생 %d의 점수 : ", i);
        scanf("%d", &input);
        score[i] = input;
    }
    for (int i = 0; i < student; i++)
    {
        sum += score[i];
    }
    printf("전체 학생 평균 점수 : %d \n", sum / student);
    free(score);
    


    // 구조체 예제 )
    struct PERSON person = { "임규찬", 29, 73.0f };         // PERSON(구조체 자료형) person(구조체 변수) = { 이름, 나이, 체중 };
                                                                                                  // 선언 순서에 맞게 초기화 가능
    printf("이름: %s\n", person.name);
    printf("나이: %d\n", person.age);
    printf("체중: %.2f\n", person.weight);


    // 구조체 예제 2)
    PERSON person = { "임규찬", 29, 73.0f };

    printf("이름: %s\n", person.name);
    printf("나이: %d\n", person.age);
    printf("체중: %.2f\n", person.weight);

}
