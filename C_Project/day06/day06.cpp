#include <stdio.h>

/* 2024/02/20 : 반복문(while, do ~ while), 배열
*
// C 언어 반복문
// 3. do ~ while문
// do {
//     실행문
//     증감식
// } while (조건식);
// 무조건 한 번은 실행하고, 그 후에 조건을 확인한다.

// while (getchar() != '\n');   --> newline이 아니면 반복, newline이면 끝

// C 언어 배열
// 배열은반드시 연속된 공간으로 메모리를 할당한다.
// - 배열의 선언
// int num[5]; : 20byte (int형 4byte가 5개)
// - 배열의 초기화
// int num[5] = {10, 20, 30, 40, 50};
// int num[5] = {10, 20};       // 나머지 값들은 모두 0으로 초기화 됨
// int num[5] = {0};
// - 2차원 배열의 선언
// int num[3][5];               // 3행 5열
// - 2차원 배열의 초기화
// int num[2][5] = {
//      {1, 2, 3, 4, 5},
//      {6, 7, 8, 9, 10}
//      };
*/

int main()
{
    // 2024/02/20 : 반복문(while, do ~ while), 배열

    // while문 예제) 구구단
    int step = 0;
    int num = 1;

    printf("구구단 프로그램입니다.\n");
    while (true)
    {
        printf("출력할 단을 입력하세요.(종료시 0) : ");
        scanf("%d", &step);

        if (step == 0)
        {
            printf("구구단을 종료합니다.");
            break;
        }
        while (num <= 9)
        {
            printf("%d x %d = %d", step, num, step * num);
            num++;
            printf("\n");
        }
        num = 1;
        printf("\n");
    }

    // do ~ while문 예제 1) 구구단
    int step1 = 0;
    while (true)
    {
        do {
            printf("출력할 단을 입력하세요(1 ~ 9단) : ");
            scanf("%d", &step1);
            printf("\n");
        } while (step1 <= 0 || step1 > 9);

        for (int i = 1; i < 10; i++)
        {
            printf("%d x %d = %d\n", step1, i, step1 * i);
        }
        printf("\n");
    }

    // do ~ while문 예제 2) 덧셈 계산기 프로그램
    int num1 = 0;
    int num2 = 0;
    char ch = 0;

    printf("덧셈 계산기 프로그램입니다.\n");
    do {
        printf("두 수를 입력해주세요 : ");
        scanf("%d %d", &num1, &num2);
        printf("%d + %d = %d 입니다.\n", num1, num2, num1 + num2);
        printf("계속 하시겠습니까? (y/n)");       // getchar() : 1byte 문자 한개를 얻어옴
        while (getchar() != '\n');              // newline이 아니면 반복, newline이면 끝
        scanf("%c", &ch);
        printf("\n");
    } while (ch == 'y' || ch == 'Y');


    //// 2차원 배열 예제 1)
    //int num[5][7] = {0};
    //int cnt = 1;

    //for (int i = 0; i < 5; i++)
    //{
    //    for (int j = 0; j < 7; j++)
    //    {
    //        num[i][j] = cnt;
    //        printf("%3d", num[i][j]);
    //        cnt++;
    //    }
    //    printf("\n");
    //}

    //// 2차원 배열 예제 1-1)
    //int num[5][7] = { 0 };

    //for (int i = 0; i < 5; i++)
    //{
    //    for (int j = 0; j < 7; j++)
    //    {
    //        num[i][j] = j + 1 + (i * 7);
    //        printf("%3d", num[i][j]);
    //    }
    //    printf("\n");
    //}

    //// 2차원 배열 예제 2)
    //int num[5][7] = {0};
    //int cnt = 1;

    //for (int i = 0; i < 5; i++)
    //{
    //    if (i % 2 == 0)
    //    {
    //        for (int j = 0; j < 7; j++)
    //        {
    //            num[i][j] = cnt;
    //            cnt++;
    //        }
    //    }
    //    else
    //    {
    //        for (int j = 6; j >=0 ; j--)
    //        {
    //            num[i][j] = cnt;
    //            cnt++;
    //        }
    //    }
    //}

    //for (int i = 0; i < 5; i++)
    //{
    //    for (int j = 0; j < 7; j++)
    //    {
    //        printf("%3d", num[i][j]);
    //    }
    //    printf("\n");
    //}

    //// 예제 2) 풀이 간단하게
    //for (int i = 0; i < 5; i++)
    //{
    //    for (int j = 0; j < 7; j++)
    //    {
    //        if (i % 2 == 0)
    //        {
    //            num[i][j] = cnt++;
    //        }
    //        else
    //        {
    //            num[i][6 - j] = cnt++;
    //        }
    //    }
    //}

}

