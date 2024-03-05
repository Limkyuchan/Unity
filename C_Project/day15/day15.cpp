#include <stdio.h>
#include <stdlib.h>

/*
// 2024/03/05 : 메모리 구조, 동적 할당, 포인터

// C 언어 메모리 구조
// Data 영역
// - Code Segment (코드 저장영역. 쓰기 금지)
// - Data Segment (상수, 전역, 정적변수. 쓰기 가능)
// Heap 영역 ☆ (동적으로 할당한 메모리 영역)
//  -> 사용자가 해제해야 한다. 하지 않을 시 메모리 누수 발생.
// Stack 영역 (지역변수, 매개변수 저장)

// C 언어 동적 할당 malloc
// 동적으로 Heap 메모리를 할당해주는 함수.
// ☆반드시 연속된 공간이 있어야 할당이 가능하다.
// 알려주는 주소의 형태는 void 형태. (주소는 알려주지만 무슨 형인지는 알 수 없어서 void)
// 동적으로 배열을 만드는 것과 비슷하다고 생각할 수 있다.

// C 언어 포인터
// NULL을 참조해서는 안된다.     ex) int* ptr = NULL;
// 반드시 주소값이 있는 것을 포인터 변수로 설정해줘야 한다.

*/

int global = 300;       // 전역변수 (Data 영역)

int main()
{
    // 2024/03/05 : 메모리 구조, 동적 할당, 포인터

    static int a = 20;      // 정적변수 (Data 영역)
    int b = 30;             // 지역변수 (Stack 영역)
    int* p = (int*)malloc(sizeof(int));     // int* p : int형 주소를 저장. (Heap 영역)      // (int*)malloc(sizeof(int));   int형 포인터로 사용하겠다.
    // malloc을 통해 주소가 넘어오니까, 주소를 저장할 수 있는 포인터를 사용한다.
    *p = 150;               // *p : 그 주소가 가리키고 있는 값 (값에 접근할 때 *p 사용)

    printf("전역변수 global=%3d, &global=%d\n", global, &global);
    printf("정적변수 a=%3d, \t&a=%d\n", a, &a);
    printf("지역변수 b=%3d, \t&b=%d\n", b, &b);
    printf("포인터\t *p=%3d, \tp=%d\n", *p, p);        // p : Heap 영역에 저장된 주소 값 
    printf("포인터\t *p=%3d, \t&p=%d\n", *p, &p);      // &p : p는 지역변수로 p의 주소는 Stack의 주소 값이 나온다.

}
