#include <stdio.h>
#include <string.h>

struct PRODUCT
{
	char name[10];
	int price;
	float grade;
};

void showProduct(PRODUCT* product);
void sortName(PRODUCT* product);
void sortLowPrice(PRODUCT* product);
void sortHighPrice(PRODUCT* product);
void sortGrade(PRODUCT* product);

int main()
{
	// Q2. 상품 정렬 구현하기
	PRODUCT product[5] = { };
	product[0] = { "니콘", 1000000, 4.5f };
	product[1] = { "캐논", 1000354, 4.2f };
	product[2] = { "소니", 1234500, 3.8f };
	product[3] = { "라이카", 2134220, 4.0f };
	product[4] = { "삼성", 1347823, 5.0f };
	int choice = 0;

	// 상품 소개
	showProduct(product);
	printf("번호를 고르시면 상품이 순서대로 정렬됩니다.\n\n");

	// 상품 정렬하기
	while (true)
	{
		printf("[1] 이름순 [2] 낮은 가격순 [3] 높은 가격순 [4] 평점순 [9] 프로그램 종료\n");
		scanf("%d", &choice);
	
		if (choice == 9)
		{
			break;	// 프로그램 종료
		}
		else
		{
			switch (choice)		// 정렬 선택
			{
				case 1:
					printf("\n이름순\n");
					sortName(product);
					showProduct(product);
					break;
				case 2:
					printf("\n낮은 가격순\n");
					sortLowPrice(product);
					showProduct(product);
					break;
				case 3:
					printf("\n높은 가격순\n");
					sortHighPrice(product);
					showProduct(product);
					break;
				case 4:
					printf("\n평점순\n");
					sortGrade(product);
					showProduct(product);
					break;
				default:
					printf("\n1 ~ 4번 사이의 숫자를 선택해주세요\n");
					break;
			}
		}
	}
}


void showProduct(PRODUCT* product)
{
	printf("-------------------------------------------------\n");
	printf("번호\t   상품명\t   가격\t\t  평점\t\n");
	printf("-------------------------------------------------\n");
	for (int i = 0; i < 5; i++)
	{
		printf("[%2d]\t[%7s]\t[%d]\t[%.3f]\n", i + 1, product[i].name, product[i].price, product[i].grade);
	}
	printf("-------------------------------------------------\n\n");
}

void sortName(PRODUCT* product)
{
	PRODUCT temp;
	for (int i = 0; i < 5; i++)
	{
		for (int j = 0; j < i; j++)
		{
			// strcmp() : 첫 번째 문자열이 두 번째 문자열보다 앞에 위치하면 음수, 뒤에 위치하면 양수
			if (strcmp(product[i].name, product[j].name) == -1)	
			{
				temp = product[i];
				product[i] = product[j];
				product[j] = temp;
			}
		}
	}
}

void sortLowPrice(PRODUCT* product)
{
	PRODUCT temp;
	for (int i = 0; i < 5; i++)
	{
		for (int j = 0; j < i; j++)
		{
			if (product[i].price < product[j].price)
			{
				temp = product[i];
				product[i] = product[j];
				product[j] = temp;
			}
		}
	}
}

void sortHighPrice(PRODUCT* product)
{
	PRODUCT temp;
	for (int i = 0; i < 5; i++)
	{
		for (int j = 0; j < i; j++)
		{
			if (product[i].price > product[j].price)
			{
				temp = product[i];
				product[i] = product[j];
				product[j] = temp;
			}
		}
	}
}

void sortGrade(PRODUCT* product)
{
	PRODUCT temp;
	for (int i = 0; i < 5; i++)
	{
		for (int j = 0; j < i; j++)
		{
			if (product[i].grade > product[j].grade)
			{
				temp = product[i];
				product[i] = product[j];
				product[j] = temp;
			}
		}
	}
}