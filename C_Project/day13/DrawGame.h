#ifndef _DRAW_GAME_H_
#define _DRAW_GAME_H_

#include <stdio.h>
#include "GameProcess.h"
#include "Util.h"

#define MAP_WIDTH     10		// define은 모두 헤더파일로
#define MAP_HEIGHT    10

#define ROAD           0
#define WALL           1
#define GEM            2

extern int map[MAP_HEIGHT][MAP_WIDTH];
void DrawGame();

#endif // !
