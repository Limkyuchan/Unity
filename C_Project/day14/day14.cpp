#include <stdio.h>
#include <conio.h>
#include "Util.h"

#define MAP_WIDTH		19
#define MAP_HEIGHT		17

#define HEAD			0		// 뱀의 머리

#define LEFT	       75
#define RIGHT	       77
#define UP		       72
#define DOWN	       80
#define EXIT           27

int snakeX[255];
int snakeY[255];
int foodX, foodY;
int snakeLength;
int dir;							// 뱀의 진행방향
int speed;						// 뱀의 속도
int isStart;

void Initialize();
void KeyProcess();
void SnakeControl();
void GameProcess();
void MakeFood();

int main()
{
	// 2024/03/04 : 스네이크 게임 만들기, 파일 분할

	SetCursorType(NO_CURSOR);
	Initialize();

	while (true)
	{
		KeyProcess();
		if (!isStart)		// 키 입력 시 게임 시작
			continue;
		GameProcess();
		SnakeControl();
		Sleep(speed);
	}
}

void Initialize()
{
	isStart = false;
	system("cls");
	snakeLength = 4;
	dir = RIGHT;							// 뱀의 진행방향
	speed = 300;							// 뱀의 속도

	// 맵 그리기 
	/*
	for (int i = 0; i < MAP_HEIGHT; i++)
	{
		for (int j = 0; j < MAP_WIDTH; j++)
		{
			if (i == 0 || i == MAP_HEIGHT - 1)
			{
				printf("■");
			}
			else
			{
				if (j == 0 || j == MAP_WIDTH - 1)
				{
					printf("■");
				}
				else
				{
					printf("  ");
				}
			}
		}
		printf("\n");
	}	*/

	// 맵 그리기 
	for (int i = 0; i < MAP_WIDTH; i++)			// 맨 위, 아래 가로줄 그리기
	{
		GotoXY(i, 0);
		printf("■");
		GotoXY(i, MAP_HEIGHT - 1);
		printf("■");
	}
	for (int i = 1; i < MAP_HEIGHT - 1; i++)	// 세로줄 그리기
	{
		GotoXY(0, i);
		printf("■");
		GotoXY(MAP_WIDTH - 1, i);
		printf("■");
	}

	// 스네이크 그리기
	snakeX[HEAD] = MAP_WIDTH / 2 - 4;		// x축 : 맵의 중앙에서 왼쪽으로 4칸
	snakeY[HEAD] = MAP_HEIGHT / 2;			// y축 : 맵의 중앙
	GotoXY(snakeX[HEAD], snakeY[HEAD]);
	printf("◈");							// 뱀의 머리 그리기
	for (int i = 1; i < snakeLength; i++)	// 뱀의 몸통 그리기
	{
		snakeX[i] = snakeX[HEAD] - i;		// 머리를 기준으로 몸통이 한 칸씩 떨어져있다
		snakeY[i] = snakeY[HEAD];
		GotoXY(snakeX[i], snakeY[i]);
		printf("◎");
	}

	// 먹이 그리기
	foodX = MAP_WIDTH / 2 + 4;
	foodY = MAP_HEIGHT / 2;
	GotoXY(foodX, foodY);
	printf("♥");
}

void KeyProcess()
{
	int key = 0;		// 입력받는 키
	// 키 처리하기
	if (_kbhit())
	{
		key = _getch();
		if (key == 224)
		{
			key = _getch();
			if (key == LEFT && dir != RIGHT ||		// 진행방향과 반대방향으로는 움직이지 않게 설정
				key == RIGHT && dir != LEFT ||
				key == UP && dir != DOWN ||
				key == DOWN && dir != UP)
				dir = key;
			isStart = true;
		}
	}
}

void SnakeControl()
{
	// 스네이크 움직이기
	GotoXY(snakeX[HEAD], snakeY[HEAD]);								// 머리는 몸통으로 바뀌고
	printf("◎");
	GotoXY(snakeX[snakeLength - 1], snakeY[snakeLength - 1]);		// 꼬리는 지워지고
	printf("  ");

	for (int i = snakeLength - 1; i > 0; i--)						// 몸통은 그 전의 값을 전달받아 현재값으로
	{
		snakeX[i] = snakeX[i - 1];
		snakeY[i] = snakeY[i - 1];
	}

	switch (dir)													// 뱀의 이동방향
	{
	case LEFT:
		snakeX[HEAD]--;
		break;
	case RIGHT:
		snakeX[HEAD]++;
		break;
	case UP:
		snakeY[HEAD]--;
		break;
	case DOWN:
		snakeY[HEAD]++;
		break;
	}
	GotoXY(snakeX[HEAD], snakeY[HEAD]);
	printf("◈");
}

void GameProcess()
{
	// 게임 룰 처리
	// 먹이를 먹었을 때
	if (foodX == snakeX[HEAD] && foodY == snakeY[HEAD])
	{
		snakeLength++;
		snakeX[snakeLength - 1] = snakeX[snakeLength - 2];		// 새 꼬리 = 이전 꼬리
		snakeY[snakeLength - 1] = snakeY[snakeLength - 2];		// --> 이전 꼬리의 값을 새 꼬리의 값으로 전달

		speed -= 5;			// 먹이 먹을때마다 속도 빠르게
		if (speed < 20)		// 최대속도 20으로 고정
		{
			speed = 20;
		}
		MakeFood();
	}

	// 벽에 닿았을 때 게임오버
	if (snakeX[HEAD] <= 0 || snakeX[HEAD] >= MAP_WIDTH - 1 || snakeY[HEAD] <= 0 || snakeY[HEAD] >= MAP_HEIGHT - 1)
	{
		Initialize();		// 게임오버 시 재시작 == exit(0);
	}

	// 몸통에 닿아을 때 게임오버
	for (int i = 1; i < snakeLength; i++)
	{
		if (snakeX[HEAD] == snakeX[i] && snakeY[HEAD] == snakeY[i])
		{
			Initialize();
			break;
		}
	}
}

void MakeFood()
{
	int isTry = false;
	// 먹이 랜덤 생성
	do
	{
		isTry = false;
		foodX = rand() % (MAP_WIDTH - 2) + 1;
		foodY = rand() % (MAP_HEIGHT - 2) + 1;

		for (int i = 0; i < snakeLength; i++)
		{
			if (foodX == snakeX[i] && foodY == snakeY[i])		// 먹이와 뱀의 몸통과 겹치면
			{													// 계속 반복
				isTry = true;
				break;
			}
		}
	} while (isTry);

	GotoXY(foodX, foodY);
	printf("♥");
}