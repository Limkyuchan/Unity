#include "GameProcess.h"        // �ڱ� �ڽ��� ����� include

int playerX;
int playerY;

void ClearGame()
{
    GotoXY(0, MAP_HEIGHT);
    printf("�����մϴ�. ������ ã�ҽ��ϴ�.\n");
    DrawGame();                     // ���� ��ġ�� �÷��̾� �׸���
    GotoXY(playerX, playerY);       // ���� ��ġ�� �÷��̾� �׸���
    printf("��");                    // ���� ��ġ�� �÷��̾� �׸���
    Sleep(500);
    GotoXY(0, MAP_HEIGHT);
    printf("                                           \n");    // ���� �ʱ�ȭ
    playerX = 0;
    playerY = 0;
}


void GameProcess()
{
    // �÷��̾� �̵� ���
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
            return;       // main() �� ���������� �ǹ�
        }
        break;
    }
}
