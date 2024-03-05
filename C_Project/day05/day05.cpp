#include <stdio.h>
#include <string.h>

/* 2024/02/19 : 반복문(for, while)
*
// C 언어 반복문
// 1. for문
// for (초기값; 조건식; 증감식)
//  { 실행문 }
// 초기값: 최초 실행할 때 한 번만 실행된다.

// 2. while문
// 초기값
// while (조건식)
// {
//  실행문
//  증감식
// }
// 반복 횟수를 가늠하기 힘들다. (횟수가 부정확할 때 사용)

// 문자열 길이 세기
// #include <string.h> 를 작성해야 사용할 수 있음
// strlen("문자열") : 문자열의 byte길이를 반환
*/

int main()
{
    // 2024/02/19 : 반복문(for, while)
    
    // for문 예제 1) 1부터 입력한 수까지의 총 합을 구하시오
    int num = 0;
    int sum = 0;
    printf("정수를 입력해주세요: ");
    scanf("%d", &num);

    for (int i = 0; i <= num; i++)
    {
        sum += i;
    }
    printf("1부터 %d까지의 총 합은 %d입니다.\n", num, sum);


    // for문 예제 2) 문자를 한 글자씩 출력해보기
    char name[] = "welcome to SBS Games Academy";
    for (int i = 0; i < strlen(name); i++)
    {
        printf("%2d번째 문자 : %c\n", i+1, name[i]);
    }


    // 별 찍기 연습 (for)
    // 1)
    int line = 0;
    printf("출력할 라인 수를 입력하세요 : ");
    scanf("%d", &line);

    for (int i = 0; i < line; i++)
    {
        for (int j = 0; j < line; j++)
        {
            printf("*");        // putchar('문자') : 1byte 짜리 한 글자만 출력해줌. (특수문자는 안됨 x)
        }
        printf("\n");
    }

    // 2)
    for (int i = 0; i < 5; i++)
    {
        for (int j = 0; j < 5 - i; j++)
        {
            printf(" ");
        }
        for (int j = 0; j < (i * 2) + 1; j++)
        {
            printf("*");
        }
        printf("\n");
    }
    for (int i = 0; i < 4; i++)
    {
        for (int j = 0; j < i + 2; j++)
        {
            printf(" ");
        }
        for (int j = 0; j < 7 - (i * 2); j++)
        {
            printf("*");
        }
        printf("\n");
    }


    // while문 예제 1) 1부터 입력한 수까지의 총 합을 구하시오
    int num2 = 0;
    int sum2 = 0;
    int i = 0;
    printf("정수를 입력해주세요 : ");
    scanf("%d", &num2);

    while (i <= num2)
    {
        sum2 += i;
        i++;
    }
    printf("1부터 %d까지의 총 합은 %d입니다.\n", num2, sum2);


    // while문 예제 2) 아스키코드 65 ~ 122 까지 출력해보시오
    int i2 = 65;
    while (i2 <= 122)
    {
        printf("%5d : %c\t", i2, i2);
        i2++;
    }
    printf("\n\n");


    // while문 예제 3) 구구단
    int step = 0;
    int num3 = 1;
    printf("구구단 프로그램입니다. 출력할 단을 입력하세요 : ");
    scanf("%d", &step);

    while (num3 <= 9)
    {
        printf("%d x %d = %d\n", step, num3, step * num3);
        num3++;
    }


    // while, for문 예제) 구구단
    int step1 = 0;
    while (true)
    {
        printf("구구단 프로그램입니다.\n");
        printf("출력할 단을 입력하세요. (종료시 0): ");
        scanf("%d", &step1);

        if (step1 == 0)  break;
        for (int i = 1; i < 10; i++)
        {
            printf("%d x %d = %d\n", step1, i , step1*i);
        }
        printf("\n");
    }
    
}

