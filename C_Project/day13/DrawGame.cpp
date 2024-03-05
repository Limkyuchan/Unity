#include "DrawGame.h"           // �ڱ� �ڽ��� ����� include

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
    // �� �׸� �׸��� �ڵ�
    for (int y = 0; y < MAP_HEIGHT; y++)
    {
        for (int x = 0; x < MAP_WIDTH; x++)
        {
            GotoXY(x, y);        // �ش� ��ġ�� Ŀ���� �̵��ϰ�, �׸��� �׸��� �ȴ�.
            if (map[y][x] == ROAD)
            {
                if (playerX == x && playerY == y)
                {
                    printf("��");
                }
                else
                {
                    printf("��");
                }
            }
            else if (map[y][x] == WALL)
            {
                printf("��");
            }
            else if (map[y][x] == GEM)
            {
                printf("��");
            }
        }
    }
}