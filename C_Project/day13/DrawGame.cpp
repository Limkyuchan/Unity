#include "DrawGame.h"           // 자기 자신의 헤더를 include

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