#include <stdio.h>
#include <conio.h>		// console input output : 콘솔창의 입/출력을 담당
#include <stdlib.h>
#include <Windows.h>
#include <time.h>

/* 2024/02/28 : 보석찾기게임 커서제어 및 함수처리, 버블 정렬
*
// C 언어 커서 제어
// GotoXY() : 커서의 위치를 특정 좌표로 이동시키는 함수이다. 특정 위치에 텍스트나 그래픽을 출력하기 위해 사용된다.
// COORD : WINDOW API에서 사용되는 구조체로 일반적으로 2차원 평면에서의 좌표(X, Y)를 나타내가 위해 사용된다.
// SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE), pos); : 콘솔 화면의 커서를 pos 변수가 나타내는 위치로 이동 시키겠다!
*/


// 1. 보석 찾기 게임 함수화 시키기
/*
#define MAP_WIDTH     10
#define MAP_HEIGHT    10

#define ROAD           0
#define WALL           1
#define GEM            2

#define LEFT	       75
#define RIGHT	       77
#define UP		       72
#define DOWN	       80
#define EXIT           27

enum CURSOR_TYPE    // 커서 타입 enum
{
    NO_CURSOR,
    SOLID_CURSOR,
    NORMAL_CURSOR
};

int choose;
int map[MAP_HEIGHT][MAP_WIDTH] = {
        {0, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        {1, 1, 1, 1, 1, 1, 1, 0, 0, 1},
        {1, 0, 0, 0, 0, 0, 1, 1, 0, 1},
        {1, 0, 0, 0, 2, 0, 1, 1, 0, 1},
        {1, 1, 1, 1, 1, 0, 1, 1, 0, 1},
        {1, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        {1, 1, 1, 1, 1, 1, 1, 0, 0, 1},
        {1, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        {1, 1, 1, 1, 1, 1, 1, 1, 1, 1}
};
int playerX;
int playerY;


void SetCursorType(CURSOR_TYPE type);
void ClearGame();
void KeyProcess();
void GameProcess();
void DrawGame();
*/

void GotoXY(int x, int y);

// 2. 버블 정렬
#define MAX_NUM 50000
int num[MAX_NUM];
void BubbleSort();

int main()
{
    // 2024/02/28 : 보석찾기게임 커서제어 및 함수처리, 버블 정렬

    // 1. 보석 찾기 게임 함수화 시키기
    /*
    SetCursorType(NO_CURSOR);   // 커서 형태를 결정
    while (true)
    {
        KeyProcess();
        GameProcess();
        DrawGame();
    }
    */


    /*
    // 2. 버블 정렬
    srand((unsigned int)time(NULL));
    printf("버블소트 전\n");
    for (int i = 0; i < MAX_NUM; i++)
    {
        num[i] = rand() % 100;
        printf("%4d", num[i]);
        if (i > 0 && (i + 1) % 5 == 0) printf("\n");
    }
    BubbleSort();
    printf("버블소트 후\n");
    for (int i = 0; i < MAX_NUM; i++)
    {
        printf("%4d", num[i]);
        if (i > 0 && (i + 1) % 5 == 0) printf("\n");
    }
    printf("\n");   */

    // 2-1. 버블 정렬 소요되는 시간 보기
    //clock_t start, end;                     // clock_t : 시간 값을 정수(초)로 저장
    //srand((unsigned int)time(NULL));
    //for (int i = 0; i < MAX_NUM; i++)
    //    num[i] = rand() % MAX_NUM + 1;      // 1 ~ 50000사이 랜덤 수

    //start = clock();                        // 시간을 재기 시작한 시간
    //printf("버블정렬을 시작합니다.\n");
    //BubbleSort();
    //end = clock();                          // 끝난 시간
    //printf("버블정렬에 걸린 시간: %.2lf초\n", (end - start) / (double)CLOCKS_PER_SEC);


    // 게임에서 시, 분, 초를 띄우는 방법
    clock_t start = clock();
    clock_t now;
    int secPermsec = 1000;                  // 초를 msec으로 전환
    int minPermsec = secPermsec * 60;       // 분을 msec으로 전환
    int hourPermsec = minPermsec * 60;      // 시간을 msec으로 전환
    int dayPermsec = hourPermsec * 24;      // 일을 msec으로 전환
    int day = 0, hour = 0, min = 0, sec = 0;

    while (true)
    {
        now = clock() - start;          // 현재 시간

        day = now / dayPermsec;
        if (day > 0)    // 하루 이상이 지났을 때
        {
            now -= day * dayPermsec;
        }

        hour = now / hourPermsec;
        if (hour > 0)
        {
            now -= hour * hourPermsec;
        }

        min = now / minPermsec;
        if (min > 0)
        {
            now -= min * minPermsec;
        }

        sec = now / secPermsec;

        GotoXY(0, 0);
        printf("%.2dday %.2dhour %.2dmin %.2dsec", day, hour, min, sec);
    }

}

// 1. 보석 찾기 게임 함수화 시키기
/*
void GotoXY(int x, int y)
{
    COORD pos = { x * 2, y };           // WINDOW API에서 사용되는 구조체로 일반적으로 2차원 평면에서의 좌표(X, Y)를 나타내가 위해 사용된다.
    SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE), pos);     // 콘솔 화면의 커서를 pos 변수가 나타내는 위치로 이동 시키겠다!
}

void SetCursorType(CURSOR_TYPE type)
{
    CONSOLE_CURSOR_INFO cursorInfo;

    switch (type)
    {
    case NO_CURSOR:
        cursorInfo.dwSize = 1;          // dwSize : 커서 사이즈
        cursorInfo.bVisible = FALSE;    // bVsible : 커서를 보이게 할지, 보이지 않게 할지
        break;
    case SOLID_CURSOR:
        cursorInfo.dwSize = 100;
        cursorInfo.bVisible = TRUE;
        break;
    case NORMAL_CURSOR:
        cursorInfo.dwSize = 20;
        cursorInfo.bVisible = TRUE;
        break;
    }
    SetConsoleCursorInfo(GetStdHandle(STD_OUTPUT_HANDLE), &cursorInfo);
}

void ClearGame()
{
    GotoXY(0, MAP_HEIGHT);
    printf("축하합니다. 보석을 찾았습니다.\n");
    DrawGame();                     // 보석 위치에 플레이어 그리기
    GotoXY(playerX, playerY);       // 보석 위치에 플레이어 그리기
    printf("♀");                    // 보석 위치에 플레이어 그리기
    Sleep(500);
    GotoXY(0, MAP_HEIGHT);
    printf("                                           \n");    // 글자 초기화
    playerX = 0;
    playerY = 0;
}

void KeyProcess()
{
    // 키보드 입력
    choose = -1;    // 음수 : 값이 없음을 의미 (입력된 키 값 초기화 (reset))
    if (_kbhit())
    {
        choose = _getch();
        if (choose == 224)
            choose = _getch();
    }
}

void GameProcess()
{
    // 플레이어 이동 계산
    switch (choose)
    {
    case LEFT:
        if (playerX - 1 >= 0)
        {
            if (map[playerY][playerX - 1] == ROAD)
                playerX--;
            else if (map[playerY][playerX - 1] == GEM)
            {
                playerX--;
                ClearGame();
            }
        }
        break;
    case RIGHT:
        if (playerX + 1 < MAP_WIDTH)
        {
            if (map[playerY][playerX + 1] == ROAD)
                playerX++;
            else if (map[playerY][playerX + 1] == GEM)
            {
                playerX++;
                ClearGame();
            }
        }
        break;
    case UP:
        if (playerY - 1 >= 0)
        {
            if (map[playerY - 1][playerX] == ROAD)
                playerY--;
            else if (map[playerY - 1][playerX] == GEM)
            {
                playerY--;
                ClearGame();
            }
        }
        break;
    case DOWN:
        if (playerY + 1 < MAP_HEIGHT)
        {
            if (map[playerY + 1][playerX] == ROAD)
                playerY++;
            else if (map[playerY + 1][playerX] == GEM)
            {
                playerY++;
                ClearGame();
            }
        }
        break;
    default:
        if (choose == EXIT)
        {
            return;       // main() 을 빠져나가는 의미
        }
        break;
    }
}

void DrawGame()
{
    // 맵 그림 그리는 코드
    for (int y = 0; y < MAP_HEIGHT; y++)
    {
        for (int x = 0; x < MAP_WIDTH; x++)
        {
            GotoXY(x, y);        // 해당 위치로 커서가 이동하고, 그림을 그리게 된다.
            if (map[y][x] == ROAD)
            {
                if (playerX == x && playerY == y)
                {
                    printf("♀");
                }
                else
                {
                    printf("■");
                }
            }
            else if (map[y][x] == WALL)
            {
                printf("▧");
            }
            else if (map[y][x] == GEM)
            {
                printf("◈");
            }
        }
    }
}
*/

// 2. 버블 정렬 함수
void BubbleSort()
{
    int temp = 0;
    for (int i = 0; i < MAX_NUM - 1; i++)
    {
        for (int j = 0; j < MAX_NUM - i - 1; j++)
        {
            if (num[j] > num[j + 1])
            {
                temp = num[j];
                num[j] = num[j + 1];
                num[j + 1] = temp;
            }
        }
    }
}
