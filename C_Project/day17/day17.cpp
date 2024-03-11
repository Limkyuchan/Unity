#include <stdio.h>
#include <stdlib.h>
#include <malloc.h>

/*
// 2024/03/11 : 포인터와 배열의 관계, 2차원 포인터, 동적 할당

// C 언어 포인터 배열
// 포인터 배열은 순서대로 선언되고 주소를 값으로 가진다.
// 예제3)에서 애초의 값들은 배열이 아니였지만, 포인터 배열을 사용해 그 값들을 순서대로 정렬할 수 있다.
// 즉, 떨어진 메모리를 하나로 모아서 관리할 수 있다는 장점이 있음

// C 언어 포인터와 배열의 관계
// 포인터를 배열처럼 사용 ==> 배열을 매개변수로 사용할 때는 포인터를 사용해서 응용

// C 언어 동적 할당
// ☆무조건 연속된 메모리 공간으로 할당된다. (Heap 영역)
// ☆연속된 공간이 없다면 절대로 할당되지 않는다.
// ☆할당 받은 동적 할당은 반드시 해제해줘야 한다. => free();

*/

// 포인터 예제 2) call by value, call by reference 차이 비교
int Min(int num1, int num2);
int Max(int num1, int num2);
void Compare(int num1, int num2, int* min, int* max);

// 포인터 예제 6)
int ArrayAdd(int* pArr, int size);   // == (int pArr[], int size)

// 포인터 연습
int ArrayMax(int arr[], int size);

// 2차원 포인터 예제 7)
void Swap(const char** pstr1, const char** pstr2);


int main()
{
    // 2024/03/11 : 포인터와 배열의 관계, 2차원 포인터, 동적 할당

    /*
    // 포인터 예제 1)
    int array[3] = { 0, 1, 2 };
    printf("array의 값 :\t%d\n", array);         // 884276280
    printf("array의 주소 :\t%d\n", &array);      // 884276280   포인터 상수이기도 하고, 참조형식(call by address 및 reference)이여서 위의 값과 동일
    printf("array + 1 :\t%d\n", array + 1);     // 884276284
    printf("&array + 1 :\t%d\n", &array + 1);   // 884276292   &array : 개별적인 변수. 배열이 모두 끝나고 난뒤 그 이후의 값(+1)이 출력(88 뒤인 92 출력)
    for (int i = 0; i < 3; i++)
    {
       printf("%d\n", array + i);               // 884276280 884276284 884276288
    }


    // 포인터 예제 2) call by value, call by reference 차이 비교
    int num1 = 2, num2 = 3, min = 0, max = 0;

    // 1. call by value (값을 전달해 주면서 받는 형태)
    //min = Min(num1, num2);
    //max = Max(num1, num2);
    // 2. call by reference (주소를 받아서 값을 전달해주는 형태)
    Compare(num1, num2, &min, &max);
    printf("%d, %d 중 큰 수는 %d이고, 작은 수는 %d입니다.", num1, num2, max, min);


    // 포인터 예제 3) 포인터 배열
    int a = 10, b = 20, c = 30;         // 변수 선언 : 순서대로 되지 않을 가능성 있음
    int* pArr[3] = { &a, &b, &c };      // 배열 선언 : 순서대로 나열

    printf("%d %10d, %3d \n", &a, pArr[0], *pArr[0]);
    printf("%d %10d, %3d \n", &b, pArr[1], *pArr[1]);
    printf("%d %10d, %3d \n", &c, pArr[2], *pArr[2]);


    // 포인트 예제 4)
    const char* pArr[3];      // == const char* pArr[3] = { "C 언어", "C++ 언어", "C# 언어" };
    pArr[0] = "C 언어";
    pArr[1] = "C++ 언어";
    pArr[2] = "C# 언어";
    for (int i = 0; i < 3; i++)
    {
       printf("%s\n", pArr[i]);
    }


    // 포인터 예제 5) 서로 다른 세개의 배열을 2차원 배열로 활용하기
    int arr1[4] = { 1, 2, 3, 4 };             // pArr[0][0], pArr[0][1] ...
    int arr2[4] = { 5, 6, 7, 8 };
    int arr3[4] = { 9, 10, 11, 12 };
    int* pArr[3] = { arr1, arr2, arr3 };      // 각 배열의 시작 주소를 포인터 배열이 받는다 == pArr[0], pArr[1], pArr[2]

    for (int i = 0; i < 3; i++)
    {
       for (int j = 0; j < 4; j++)
       {
          printf("%4d", pArr[i][j]);
       }
       printf("\n");
    }


    // 포인터 예제 6)
    int arr[5] = { 3, 6, 9, 12, 15 };
    int size = (sizeof(arr) / sizeof(int));      // 배열의 크기 구하기
    printf("배열의 총 합은 %d 입니다.\n", ArrayAdd(arr, size));
    */

    // 포인터 연습) 랜덤 10개 뽑고 제일 큰 값 출력하기
    int arr[10];
    int size = (sizeof(arr) / sizeof(int));     // 배열의 크기 구하기

    printf("랜덤한 숫자 10개 : ");
    for (int i = 0; i < 10; i++)
    {
       arr[i] = rand() % 100;
       printf("%d ", arr[i]);
    }
    printf("\n배열 중 가장 큰 수는 %d입니다.\n", ArrayMax(arr, size));


    // 2차원 포인터 예제 7)
    const char* pstr1 = "Bear";
    const char* pstr2 = "Rabbit";
    printf("1. 바꾸기 전 pstr1 = %s, pstr2 = %s\n", pstr1, pstr2);
    Swap(&pstr1, &pstr2);
    printf("2. 바꾸기 후 pstr1 = %s, pstr2 = %s\n", pstr1, pstr2);
    

    // 동적 할당 예제 8)
    int* pBuffer = (int*)malloc(sizeof(int) * 100);
        
    printf("버퍼에 할당된 메모리 크기: %2dByte\n", sizeof(pBuffer));   // 8Byte
    printf("버퍼에 할당된 메모리 크기: %2dByte\n", _msize(pBuffer));   // 400Byte

    free(pBuffer);

}


// 포인터 예제 2) call by value, call by reference 차이 비교
int Min(int num1, int num2)
{
    return num1 < num2 ? num1 : num2;
}
int Max(int num1, int num2)
{
    return num1 > num2 ? num1 : num2;
}
void Compare(int num1, int num2, int* min, int* max)
{
    *min = num1 < num2 ? num1 : num2;
    *max = num1 > num2 ? num1 : num2;
}


// 포인터 예제 6)
int ArrayAdd(int* pArr, int size)   // 배열을 매개변수로 사용할 때는 포인터를 사용해서 응용
{                                   // == (int pArr[], int size) : 외형적으로 알아보기 쉽게 배열로 표현해도 가능.
    int sum = 0;
    for (int i = 0; i < size; i++)
    {
        sum += pArr[i];
    }
    return sum;
}


// 포인터 연습
int ArrayMax(int arr[], int size)               
{
    int max = 0;
    for (int i = 1; i < size; i++)
    {
        if (arr[max] < arr[i])
        {
            max = i;
        }
    }
    return arr[max];
}


// 2차원 포인터 예제 7)
void Swap(const char** pstr1, const char** pstr2)
{
    const char* str;
    str = *pstr1;
    *pstr1 = *pstr2;
    *pstr2 = str;
}