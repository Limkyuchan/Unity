#include <stdio.h>
#include <conio.h>		// console input output : 콘솔창의 입/출력을 담당
#include <stdlib.h>
#include <Windows.h>

/* 2024/02/27 : 콘솔 입/출력, 보석 찾기 게임, enum, 커서 제어
* 
// C 언어 콘솔 입/출력
// window용 콘솔창 (window에서만 사용이 가능하다)
// #include <conio.h> 을 사용하면 kbhit(), getch()를 사용할 수 있다. (이 둘을 함께 사용하여 키 입력되는 것을 알 수 있다.)
// kbhit() : keyboard hit (키보드 키가 눌리면 1, 안 눌리면 0)
//
// getch(); : Enter를 치지 않아도 키보드가 눌리면 문자 한 개를 얻어온다. (1 byte)
// getch(); == 224 : 224번은 확장키 구분자로, 224가 들어오면 확장키로 인식. 
// 1byte만 보내면 225개만 사용 가능. -> 아스키코드로 인식
// 224번을 확장키의 구본자로 전송해서, 그 이후에 입력되는 키를 아스키코드가 아닌 확장키로 인식하도록 (2 byte 전송)

// C 언어 enum
// enum(열거형) : 열거만 해놓으면 자동적으로 번호가 부여된다.
// 값이 여러개이고, 번호가 순서대로 나열된다면 #define 보다 enum이 더 편리하다.
// enum 내부의 개수를 파악하기 용이하다. (중간에 추가 및 삭제가 되더라도 개수를 파악하기 쉽다)

// C 언어 커서 제어
// GotoXY() : 커서의 위치를 특정 좌표로 이동시키는 함수이다. 특정 위치에 텍스트나 그래픽을 출력하기 위해 사용된다.
// COORD : WINDOW API에서 사용되는 구조체로 일반적으로 2차원 평면에서의 좌표(X, Y)를 나타내가 위해 사용된다.
*/

/*
// 확장키 <conio.h>
#define LEFT	75
#define RIGHT	77
#define UP		72
#define DOWN	80
#define SPACE	32	// 일반키
#define ESC		27  // 일반키      */

/*
// 보석찾기 게임
#define MAP_WIDTH     10
#define MAP_HEIGHT    10

#define ROAD           0
#define WALL           1
#define GEM            2

#define LEFT	       75
#define RIGHT	       77
#define UP		       72
#define DOWN	       80
#define EXIT           27       */

/*
// enum 예시
enum ITEM
{
    NONE = -1,      // 아무것도 소지하고 있지 않음을 표시하기 위해 -1을 사용한다.
    SWORD,
    SPEAR,
    BOW,
    AXE,
    GUN,
    MAX,            // 총 갯수를 파악하기 위해 주로 MAX를 사용한다.
};  */

/*
// enum 아이템 등급 구분 예시
enum ITEM
{
    NORMAL_SWORD = 1,
    NORMAL_AXE,
    NORMAL_BOW,
    MAGIC_SWORD = 1000,
    MAGIC_AXE,
    MAGIC_BOW,
    RARE_SWORD = 2000,
    RARE_AXE,
    RARE_BOW,
    EPIC_SWORD = 10000,
    EPIC_AXE,
    EPIC_BOW,
    LEGENDARY_SWORD = 100000,
    LEGENDARY_AXE,
    LEGENDARY_BOW,
};  */

// C 언어 커서 제어
void GotoXY(int x, int y)
{
    COORD pos = { x * 2, y };           // WINDOW API에서 사용되는 구조체로 일반적으로 2차원 평면에서의 좌표(X, Y)를 나타내가 위해 사용된다.
    SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE), pos);     // 콘솔 화면의 커서를 pos 변수가 나타내는 위치로 이동 시키겠다!
}

int main()
{
    // 2024/02/27 : 콘솔 입/출력, 보석 찾기 게임, enum, 커서 제어

    /*
    int key = 0;
    while (true)
    {
        if (_kbhit())
        {
            key = _getch();
            if (key == 224)     // 확장키
            {
                key = _getch();
                switch (key)
                {
                case UP:
                    printf("UP 눌림\n");
                    break;
                case DOWN:
                    printf("DOWN 눌림\n");
                    break;
                case RIGHT:
                    printf("RIGHT 눌림\n");
                    break;
                case LEFT:
                    printf("LEFT 눌림\n");
                    break;
                default:
                    break;
                }
            }
            else                // 일반키 (space, esc)
            {
                if (key == SPACE)
                    printf("SPACE 눌림\n");
                else if (key == ESC)
                    printf("ESC 눌림\n");
            }
        }
    }   */

    /*
    // 보석 찾기 게임 (흐름: 입력 - 처리 - 결과)
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
    int playerX = 0;
    int playerY = 0;
    int choose = 0;

    while (true)
    {
        // 키보드 입력
        choose = -1;    // 음수 : 값이 없음을 의미 (입력된 키 값 초기화 (reset))
        if (_kbhit())
        {
            choose = _getch();
            if (choose == 224)
                choose = _getch();
        }

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
                    printf("축하합니다. 보석을 찾았습니다.\n");
                    playerX = 0;
                    playerY = 0;
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
                    printf("축하합니다. 보석을 찾았습니다.\n");
                    playerX = 0;
                    playerY = 0;
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
                    printf("축하합니다. 보석을 찾았습니다.\n");
                    playerX = 0;
                    playerY = 0;
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
                    printf("축하합니다. 보석을 찾았습니다.\n");
                    playerX = 0;
                    playerY = 0;
                }
            }
            break;
        default:
            if (choose == EXIT)
            {
                return 0;       // main() 을 빠져나가는 의미
            }
            break;
        }

        // 맵 그림 그리는 코드
        for (int y = 0; y < MAP_HEIGHT; y++)
        {
            for (int x = 0; x < MAP_WIDTH; x++)
            {
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
            printf("\n");
        }
        Sleep(200);        // 화면을 정지해주는 역할 (0.2초)
        system("cls");      // 화면 지워주는 역할
    }   */

    /*
    // enum 예시
    ITEM myItem = NONE;     // 아이템이 없는 상태를 표시

    if (myItem == SWORD)
    {

    }
    else if (myItem == SPEAR)
    {

    }   */

    /*
    // enum 예시) enum을 활용해 직업을 선택받으세요
    enum JOBS
    {
        NONE = -1,
        WARRIOR,        // 0
        MAGE,           // 1
        HUNTER,         // 2
        THIEF           // 3
    };

    JOBS myJob = NONE;
    printf("< 직업을 선택해주세요 >\n");
    printf(" 1. 전사\n");
    printf(" 2. 마법사\n");
    printf(" 3. 사냥꾼\n");
    printf(" 4. 도적\n");
    printf("*********************\n");
    scanf("%d", &myJob);

    switch (myJob - 1)
    {
    case WARRIOR:
        printf("전사를 선택하셨습니다.\n");
        break;
    case MAGE:
        printf("마법사를 선택하셨습니다.\n");
        break;
    case HUNTER:
        printf("사냥꾼을 선택하셨습니다.\n");
        break;
    case THIEF:
        printf("도적을 선택하셨습니다.\n");
        break;
    default:
        printf("잘못 선택하셨습니다.\n");
        break;
    }
    */

    // C 언어 커서 제어   
    //GotoXY(10, 10);           // 커서를 10, 10 위치로 이동해서 별을 찍음
    //printf("☆");

    for (int i = 0; i < 20; i++)
    {
        for (int j = 0; j < 30; j++)
        {
            GotoXY(rand() % 30, rand() % 20);
            printf("☆");
            Sleep(200);
            system("cls");
        }
    }
}

