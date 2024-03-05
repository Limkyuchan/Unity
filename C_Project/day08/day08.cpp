#include <stdio.h>      // 표준 입출력
#include <stdlib.h>     // rand() 함수를 사용하기 위함
#include <time.h>       // time

/* 2024/02/22 : 반복문, 배열, 테트리스 게임
*
// rand() : 랜덤한 정수를 출력
// srand() : random의 시드값(기준값)을 변경 -> 랜덤 돌릴 때 처음 기준이 된 값을 기준으로 연산을 돌려서 매번 똑같게 나옴.
//  ex) srand(20); : 20으로 시드값을 고정
// time(NULL) : 시간을 반환해주는 함수 (정수값인 '초'로 반환)
//
// srand() : 32bit 값 / time() : 64bit 값
// 64비트의 값을 32비트로 넣는 과정에서 값 손실을 없애기 위해 int형으로 변환
//
// 랜덤된 수를 가져오기 위해 시드값을 시간을 이용해서 변경
// srand((int)time(NULL)); : time()을 int형으로 변환. 시간을 시드값으로 랜덤된 수 출력
//
// 형 변환
// float pi = 3.14f;
// int num = (int)pi;   // int형으로 변환
*/

int main()
{
    // 2024/02/22 : 반복문, 배열, 테트리스 게임
    
    // 테트리스 게임
    char block[7][4][4] = {
        {
            {0,0,0,0},
            {0,1,1,0},
            {0,1,1,0},
            {0,0,0,0},
        },
        {
            {1,0,0,0},
            {1,0,0,0},
            {1,0,0,0},
            {1,0,0,0},
        },
        {
            {0,0,0,0},
            {1,1,0,0},
            {0,1,1,0},
            {0,0,0,0},
        },
        {
            {0,0,0,0},
            {0,1,1,0},
            {1,1,0,0},
            {0,0,0,0},
        },
        {
            {0,0,0,0},
            {0,0,1,0},
            {1,1,1,0},
            {0,0,0,0},
        },
        {
            {0,0,0,0},
            {1,0,0,0},
            {1,1,1,0},
            {0,0,0,0},
        },
        {
            {0,0,0,0},
            {0,1,0,0},
            {1,1,1,0},
            {0,0,0,0},
        },
    };

    int type = 0;
    int key = 0;
    while (true)
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (block[type][i][j] == 1)
                    printf("■");
                else
                    printf("  ");
            }
            printf("\n");
        }
        printf("\n");
        printf("명령을 입력하세요. 1.바꾸기 2.종료 \n");
        key = getchar();
        while (getchar() != '\n');  // newline 제거용도.

        if (key == '1')
        {
            type = rand() % 7;      // rand() : 랜덤한 정수를 가져옴
        }
        else if (key == '2')
        {
            exit(0);
        }
    }

    // 예제) 숫자 7개 무작위 추출하기
    int num[7] = { 0, };
    srand((int)time(NULL));

    for (int i = 0; i < 7; i++)
    {
        num[i] = rand() % 100;
        printf("num[%d] : %d\n", i, num[i]);
    }

    //// 풀이 1) 중복되지 않는 숫자 7개 출력하기
    //int num[7] = { 0, };
    //srand((int)time(NULL));

    //for (int i = 0; i < 7; i++)
    //{
    //    num[i] = rand() % 7;

    //    for (int j = 0; j < i; j++)
    //    {
    //        if (num[i] == num[j])
    //        {
    //            num[i] = rand() % 7;
    //            j = -1;
    //        }
    //    }
    //    printf("num[%d] : %d\n", i, num[i]);
    //}

    //// 풀이 2) 중복되지 않는 숫자 7개 출력하기
    //int num[7] = { 0, };
    //srand((int)time(NULL));

    //for (int i = 0; i < 7; i++)
    //{
    //    num[i] = rand() % 7;

    //    for (int j = 0; j < i; j++)
    //    {
    //        if (num[i] == num[j])
    //        {
    //            i--;
    //            break;
    //        }
    //    }
    //}

    //for (int i = 0; i < 7; i++)
    //{
    //    printf("num[%d] : %d\n", i, num[i]);
    //}

    //// 풀이 3) 중복되지 않는 숫자 7개 출력하기
    //int num[7] = { 0, };
    //int duplicate;
    //srand((int)time(NULL));

    //for (int i = 0; i < 7; i++)
    //{
    //    do {
    //        num[i] = rand() % 7;
    //        duplicate = 0;

    //        for (int j = 0; j < i; j++)
    //        {
    //            if (num[i] == num[j])
    //            {
    //                num[i] = rand() % 7;
    //                duplicate = 1;
    //            }
    //        }
    //    } while (duplicate);

    //    printf("num[%d] : %d\n", i, num[i]);
    //}
    
}