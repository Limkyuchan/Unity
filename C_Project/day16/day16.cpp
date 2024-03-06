#include <stdio.h>

/*
// 2024/03/06 : 포인터와 배열의 관계

// C 언어 포인터
// 포인터는 자료형에 상관없이 모두 크기가 동일하다 (32bit컴 : 4byte, 64bit컴 : 8byte)

// 포인터와 배열의 관계
// 배열은 포인터 상수와 같은 의미.
// 배열은 선언과 동시에 공간을 할당받고, 그 배열을 가르키는 포인터(본인 변수)는 다른 배열을 가르키게 바꾸면 안된다.
// 포인터를 통해서는 배열의 크기를 알 수 없다. (포인터의 크기는 모두 동일)
// 포인터는 상수영역의 주소(상수의 주소)를 가리킨다.
// 포인터는 상수의 메모리를 접근한 것이기 때문에 변경이 불가능하다.
// => 배열은 수정이 가능하지만, 포인터는 수정이 불가능하다.
// ☆ 상수선언 : const

*/

// 포인터 예제 3) call by reference
void swap(int* a, int* b);

int main()
{
    // 2024/03/06 : 포인터와 배열의 관계

    /*
    // 포인터 예제) 값, 구조, 크기 출력하기
    int a = 10;
    char b = 'A';
    double c = 1234.56f;
    int* ptr1 = &a;
    char* ptr2 = &b;
    double* ptr3 = &c;

    printf("int형 a의 값 %d, 주소 %d, 크기 %dbyte\n", a, &a, sizeof(a));
    printf("char형 b의 값 %c, 주소 %d, 크기 %dbyte\n", b, &b, sizeof(b));
    printf("double형 c의 값 %f, 주소 %d, 크기 %dbyte\n", c, &c, sizeof(c));
    printf("int형 포인터 ptr1의 값 %d, 주소 %d, 크기 %dbyte\n", ptr1, &ptr1, sizeof(ptr1));
    printf("char형 포인터 ptr2의 값 %d, 주소 %d, 크기 %dbyte\n", ptr2, &ptr2, sizeof(ptr2));
    printf("double형 포인터 ptr3의 값 %d, 주소 %d, 크기 %dbyte\n\n", ptr3, &ptr3, sizeof(ptr3));


    // 포인터 예제 2)
    int nData = 10;
    int* pnData = &nData;

    printf("%d, %d\n", nData, *pnData);
    printf("%d, %d\n", &nData, pnData);
    *pnData += 20;
    printf("%d\n", nData);


    // 포인터 예제 3) 포인터를 활용해 값 바꾸기 (call by reference)
    int a = 3;
    int b = 2;
    swap(&a, &b);
    printf("3.함수호출 후 a: %d, b: %d\n", a, b);


    // 포인터 예제 4) void 포인터 생성 후, 사용 시 각 형에 맞게 캐스팅(변환).
    void* ptr = NULL;
    int nData = 10;
    float fData = 1.234;

    ptr = &nData;
    printf("포인터의 값: %d\n", (int*)ptr);      // void형 포인터를 int형으로 캐스팅

    ptr = &fData;
    printf("포인터의 값: %d\n", (float*)ptr);    // void형 포인터를 float형으로 캐스팅


    // 포인터 예제 5) 포인터와 배열의 관계
    int arr[3] = { 10, 20, 30 };
    int* ptr = &arr[0];                             // 둘이 같은 주소(arr[0])를 가리킨다.

    printf("%d %3d\n", ptr[0], arr[0]);
    printf("%d %3d\n", ptr[1], arr[1]);
    printf("%d %3d\n", ptr[2], arr[2]);
    printf("%d %3d\n", *ptr, *arr);                 // ptr과 arr이 가리키는 arr[3]의 첫 시작 주소의 값 == arr[0]
    printf("%d %3d\n", *(ptr + 0), *(arr + 0));     // *(arr + 0) : 자기 자료형 크기만큼 더해라. (1004 + 0)
    printf("%d %3d\n", *(ptr + 1), *(arr + 1));     // *(arr + 1) : 자기 자료형 크기만큼 더해라. int형 4byte씩 증가 (1004 + 4)
    printf("%d %3d\n", *(ptr + 2), *(arr + 2));     // *(arr + 2) : 자기 자료형 크기만큼 더해라. int형 4byte씩 증가 (1008 + 4)


    // 포인터 예제 6) 포인터와 배열의 크기 비교
    int arr[5];
    int* pArr = arr;

    printf("배열 크기: %dbyte\n", sizeof(arr));
    printf("포인터 크기: %dbyte\n", sizeof(pArr));
    */

    // 포인터 예제 7) 포인터와 배열의 비교
    char str1[5] = "abcd";
    const char* str2 = "ABCD";      // 포인터는 상수이기 때문에 const 를 함께 작성해준다.

    printf("%s  \n", str1);
    printf("%s  \n", str2);

    str1[0] = 'x';
    //str2[0] = 'X';                // 에러

    printf("%s  \n", str1);
    printf("%s  \n", str2);
}


// 포인터 예제 3) call by reference
void swap(int* a, int* b)
{
    int temp = 0;
    printf("1.변경 전 a: %d, b: %d\n", *a, *b);
    temp = *a;
    *a = *b;
    *b = temp;
    printf("2.변경 후 a: %d, b: %d\n", *a, *b);

}