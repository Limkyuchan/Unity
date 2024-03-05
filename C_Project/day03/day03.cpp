#include <stdio.h>

/* 2024/02/15 : 연산자, 제어문
*
// C 언어 논리 연산자       true(참) : 1, false(거짓) : 0
// && : AND (논리곱) - 둘 다 참이여야 참
// || :  OR (논리합) - 둘 중 하나만 참이면 참
//  ! : NOT (부정) - 참이면 거짓, 거짓이면 참

// C 언어 비트 연산자
// & : 비트 단위 AND
// | : 비트 단위  OR
// ^ : 비트 단위 XOR - 두 비트가 같으면 0, 다르면 1
// ~ : 1의 보수 - 1을 만들기 위해 보충을 해야하는 수 (부호가 반전, 더하면 1이 되도록 한다)
// << : 왼쪽 쉬프트 - 2의 n승을 곱한 값
// >> : 오른쪽 쉬프트 - 2의 n승을 나눈 값

// 시작 중괄호를 통해 종료 중괄호 찾는 단축키 : 시작 중괄호 드래그 이후 "ctrl + 중괄호"
*/

int main()
{
    // 2024/02/15 : 연산자, 제어문(if)
    
    // Q1. 세 개의 정수를 입력받아 큰 순서대로 나열하는 문제
    int num1 = 0;
    int num2 = 0;
    int num3 = 0;

    printf("세 개의 정수를 입력하세요 : ");
    scanf("%d%d%d", &num1, &num2, &num3);

    if (num1 > num2 && num1 > num3)
    {
        if (num2 > num3)
        {
            printf("num1: %d > num2: %d > num3: %d", num1, num2, num3);
        }
        else
        {
            printf("num1: %d > num3: %d > num2: %d", num1, num3, num2);
        }
    }
    else
    {
        if (num2 > num1 && num2 > num3)
        {
            if (num1 > num3)
            {
                printf("num2: %d > num1: %d > num3: %d", num2, num1, num3);
            }
            else
            {
                printf("num2: %d > num3: %d > num1: %d", num2, num3, num1);
            }
        }
        else
        {
            if (num1 > num2)
            {
                printf("num3: %d > num1: %d > num2: %d", num3, num1, num2);
            }
            else
            {
                printf("num3: %d > num2: %d > num1: %d", num3, num2, num1);
            }
        }
    }
    
}
