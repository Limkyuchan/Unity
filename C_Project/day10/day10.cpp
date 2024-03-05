#include <stdio.h>

/* 2024/02/26 : 함수, 재귀함수, 포인터 변수
*
// C 언어 함수
// 장점 : 기능들을 재사용할 수 있다.
// 재귀함수 : 자기 자신을 호출하는 함수

// C 언어 함수형태
// call by value (값을 전달하는 형태)
// call by reference (주소를 참조하는 형태)

// C 언어 포인터변수
// int* num1 : int형 포인터 변수 (int형의 주소를 가짐)
// 포인터 변수는 값을 절대 가질 수 없다. 값으로는 반드시 주소만 가질 수 있다.
// 포인터 변수는 메모리 주소를 가리킨다.
// 포인터 변수는 다른메모리에 접근할 수 있다.
*/


// ☆☆ main문 밑에 함수를 작성하려면 main문 위에 함수원형을 작성해줘야 한다.
int Sum(int a, int b);		// 1. 지역변수 예시
void Add();					// 2. 정적변수 예시
int factorial(int n);		// 재귀함수 팩토리얼 예시 

// 3. 전역변수 예시
int a, b;
int sum;
void Input1()
{
	printf("덧셈할 두 정수를 입력하세요 : ");
	scanf("%d %d", &a, &b);
}
void Sum1()				// 전역변수는 어디서든 사용가능하기 때문에 매개변수 필요없음
{
	sum = a + b;		// 전역변수는 어디서든 사용가능하기 때문에 반환값 필요없음
}
void OutPut1()
{
	printf("%d + %d = %d\n", a, b, a + b);
}

// 3-1. 전역변수를 사용하지 않고 반환값이 2개일 때 (포인터 변수)
void Input2(int* num1, int* num2)		// 여러 값을 전달하기 위해 값이 아닌 주소를 넣어준다. / call by reference (주소를 참조하는 형태)
{
	printf("덧셈할 두 정수를 입력하세요 : ");
	scanf("%d %d", num1, num2);			// 이미 가지고 있는 값이 주소이기 때문에 &를 붙일 필요가 없다.
}
int Sum2(int num1, int num2)
{
	int result = num1 + num2;
	return result;
}
void OutPut2(int num1, int num2, int result)
{
	printf("%d + %d = %d\n", num1, num2, result);
}


int main()
{
	// 2024/02/26 : 함수, 재귀함수, 포인터 변수
 
	// 1. 두 정수 입력받아 더하는 함수 만들기 (지역변수 사용)
	int a, b;
	printf("덧셈할 두 정수를 입력하세요: \n");
	scanf("%d %d", &a, &b);
	printf("%d + %d = %d\n", a, b, Sum(a,b));

	// 2. 반복되는 수를 누적해서 더하기 (정적변수 사용)
	for (int i = 0; i < 5; i++)
		Add();

	// 3. 입력, 계산, 출력 함수 만들기 (전역변수 사용)
	Input1();
	Sum1();
	OutPut1();

	// 3-1. 전역변수를 사용하지 않고 함수가 작동되도록 수정해보기
	int num1, num2, result;

	Input2(&num1, &num2);			// 지역변수 num1, num2의 주소를 넘겨줌
	result = Sum2(num1, num2);
	OutPut2(num1, num2, result);
	
	
	// 포인터 변수 예시
	int a = 10;
	int* ptr = &a;		// 포인터 변수 ptr은 a 값의 주소를 가리킨다.


	// 재귀함수 팩토리얼 예시
	int num = 0;
	printf("팩토리얼을 계산합니다. 숫자를 입력해주세요 : ");
	scanf("%d", &num);
	printf("\n%d 팩토리얼 : ", num);
	printf(" = %d\n", factorial(num));

}


// 1. 두 정수 입력받아 더하는 함수 만들기	/ call by value (값을 전달하는 형태)
int Sum(int a, int b)
{
	return a + b;
}

// 2. 반복되는 수를 누적해서 더하기
void Add()
{
	static int add = 0;		// 정적변수 사용 (지역변수같이 사용되면서 프로그램이 종료되어야 소멸되는 특징을 가짐 -> 값이 저장된다.)
	printf("현재 값: %d\n", ++add);
}

// 재귀함수 팩토리얼 예시
int factorial(int n)
{
	if (n == 1 || n == 0)
	{
		printf("%d", n);
		return 1;
	}
	else 
	{
		printf("%d*", n);
		return n * factorial(n - 1);
	}
}