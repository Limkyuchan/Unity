#include <stdio.h>

// 2024/02/21 : 반복문, 배열, 보석 찾기 게임
#define MAP_WIDTH     10
#define MAP_HEIGHT    10

#define ROAD           0
#define WALL           1
#define GEM            2

#define LEFT           1
#define RIGHT          2
#define UP             3
#define DOWN           4
#define EXIT           0

int main()
{
    // 2024/02/21 : 반복문, 배열, 보석 찾기 게임
    
    // 배열 예제) 동전 교환 프로그램
    int coins[] = { 500, 100, 50, 10 };
    int money = 0;

    while (true)
    {
        printf("교환하려는 금액을 입력해주세요 (종료시 0): ");
        scanf("%d", &money);
        if (money == 0)
        {
            printf("프로그램을 종료합니다.");
            break;
        }

        for (int i = 0; i < 4; i++)
        {
            int cnt = 0;
            while (money / coins[i] > 0)
            {
                cnt++;
                money -= coins[i];
            }
            printf("%d 원 : %d 개\n", coins[i], cnt);
        }
        printf("\n");
    }


    // 보석 찾기 게임
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
        printf("\n");
        printf("1.왼쪽 2.오른쪽 3.위 4.아래 (0.종료)\n");
        scanf("%d", &choose);

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
        printf("\n");
        printf("\n");
    }
    
}


