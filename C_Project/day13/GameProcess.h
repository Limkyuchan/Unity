#ifndef _GAME_PROCESS_H_
#define _GAME_PROCESS_H_

#include <stdio.h>
#include "Util.h"
#include "DrawGame.h"
#include "KeyProcess.h"

extern int playerX;			// 초기화는 절대 하면 안된다.
extern int playerY;

void ClearGame();
void GameProcess();

#endif // !_GAME_PROCESS_H_

