#include "GameProcess.h"        // 자기 자신의 헤더를 include

int playerX;
int playerY;

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
