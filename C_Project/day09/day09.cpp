#include <stdio.h>
#include <stdlib.h>
#include <time.h>

/* 2024/02/23 : 로또 번호, 가위바위보 게임, 변수 선언, 함수
*
// C 언어 변수 선언
// 지역 변수
// 선언한 해당 지역의 {} 안에서만 사용, {} 을 벗어나면 소멸

// 전역 변수
// 함수 외부에서 선언한 변수. 프로그램 종료 시 소멸
// 같은 파일 내에서는 어디서든 참조 가능
// 초기화를 하지 않아도 0으로 초기화

// 정적 변수
// 전역과 지역변수의 혼합형태
// 지역변수처럼 사용되지만 프로그램이 종료되어야만 소멸된다.
// ex) static int hp;

// C 언어 함수
// 함수명은 반드시 대문자로 시작해야 된다. (변수는 소문자)
// 함수 원형 : 반환값의자료형 함수이름 (매개변수, 매개변수)    // 함수 사용 시 필요한 값을 전달받는 매개변수
//            {
//                return 0;                               // 반환되는 값
//            }                                           // return이 나오면 값을 반환하고 무조건 함수를 탈출한다.
// 반환할 값이 없을 경우 void 를 작성하면 된다.
// void는 값을 전달하지 않아도 되니 주로 출력하는 형태의 경우 사용한다.
*/

#define SCISSOR 0
#define ROCK    1
#define PAPER   2
int main()
{
    // 2024/02/23 : 로또 번호, 가위바위보 게임, 변수 선언, 함수
     
    // 로또번호 7개 추출하기 풀이
    int input = 0;
    int num[7] = { 0 };
    int checkNum[45] = { 0 };
    srand((int)time(NULL));
    int value = 0;

    while (true)
    {
        printf("로또 번호 생성기 입니다.\n");
        printf("1. 번호생성 2. 종료하기\n");
        scanf("%d", &input);

        if (input == 1)
        {
            for (int i = 0; i < 7; i++)
            {
                do {
                    value = rand() % 45;
                } while (checkNum[value]);
                checkNum[value] == 1;
                num[i] = value;
            }

            for (int i = 0; i < 6; i++)
            {
                printf("%3d", num[i] + 1);
            }
            printf("\t보너스 %3d", num[6] + 1);
            printf("\n");
        }
        else
        {
            printf("종료합니다.");
            break;
        }
        system("pause");    // 키를 눌러야 다음으로 진행
        system("cls");      // 화면 깨끗하게 비워줌
    }

     
    // 가위바위보 게임
    int win = 0, draw = 0, lose = 0, choose, computer, cnt = 0;
    srand((int)time(NULL));

    while (true)
    {
        printf("가위바위보 게임입니다.\n");
        printf("가위(0) 바위(1) 보(2) 중 하나를 입력하세요 (종료시 9) : ");
        scanf("%d", &choose);

        if (choose == 9)
        {
            printf("게임을 종료합니다.\n");
            printf("플레이어 총 %d판 %d승 %d무 %d패\n", cnt, win, draw, lose);
            break;
        }
        else if (choose == 0 || choose == 1 || choose == 2)
        {
            computer = rand() % 3;
            cnt += 1;
            printf("컴퓨터가 나온 숫자 : %d\n", computer);

            if (computer == SCISSOR)
            {
                if (choose == SCISSOR)
                {
                    draw += 1;
                    printf("플레이어: 가위, 컴퓨터: 가위\n");
                    printf("비겼습니다.\n");
                }
                else if (choose == ROCK)
                {
                    win += 1;
                    printf("플레이어: 바위, 컴퓨터: 가위\n");
                    printf("플레이어가 이겼습니다.\n");
                }
                else if (choose == PAPER)
                {
                    lose += 1;
                    printf("플레이어: 보, 컴퓨터: 가위\n");
                    printf("컴퓨터가 이겼습니다.\n");
                }
            }
            else if (computer == ROCK)
            {
                if (choose == SCISSOR)
                {
                    lose += 1;
                    printf("플레이어: 가위, 컴퓨터: 바위\n");
                    printf("컴퓨터가 이겼습니다.\n");
                }
                else if (choose == ROCK)
                {
                    draw += 1;
                    printf("플레이어: 바위, 컴퓨터: 바위\n");
                    printf("비겼습니다.\n");
                }
                else if (choose == PAPER)
                {
                    win += 1;
                    printf("플레이어: 보, 컴퓨터: 바위\n");
                    printf("플레이어가 이겼습니다.\n");
                }
            }
            else if (computer == PAPER)
            {
                if (choose == SCISSOR)
                {
                    win += 1;
                    printf("플레이어: 가위, 컴퓨터: 보\n");
                    printf("플레이어가 이겼습니다.\n");
                }
                else if (choose == ROCK)
                {
                    lose += 1;
                    printf("플레이어: 바위, 컴퓨터: 보\n");
                    printf("컴퓨터가 이겼습니다.\n");
                }
                else if (choose == PAPER)
                {
                    draw += 1;
                    printf("플레이어: 보, 컴퓨터: 보\n");
                    printf("비겼습니다.\n");
                }
            }
        }
        else
        {
            printf("0, 1, 2 세 숫자 중 하나를 입력해주세요.\n");
        }
        printf("\n\n");
    }
}

