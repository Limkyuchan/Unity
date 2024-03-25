#include <stdio.h>
#include <string.h>

int main()
{
	// Q1. 회원가입 구현하기
	char name[20];
	char email[30];
	char password[10];
	char password2[10];

	printf("회원 가입을 시작합니다.\n");
	while (true)
	{
		while (true)	// 이름 입력받기
		{
			printf("가입하실 이름을 입력해주세요(한글 5, 영문 10글자 이내)\n");
			scanf("%s", name);

			if (strlen(name) < 3)
			{
				printf("이름이 너무 짧습니다.\n");
			}
			else if (strlen(name) > 10)
			{
				printf("이름이 너무 깁니다.\n");
			}
			else
			{
				break;
			}
		}

		while (true)	// 아이디 입력받기
		{
			printf("가입하실 아이디를 email 주소를 입력해주세요\n");
			scanf("%s", email);

			// 이메일 형식 확인하기
			if (strchr(email, '@') == NULL)
			{
				printf("이메일 형식을 확인하세요\n");
			}
			else
			{
				break;
			}
		}

		while (true)	// 비밀번호 입력받기
		{
			printf("비밀번호를 입력해주세요 (6글자 이상 8글자 이내)\n");
			scanf("%s", password);

			if (strlen(password) < 6)
			{
				printf("비밀번호가 너무 짧습니다.\n");
			}
			else if (strlen(password) > 8)
			{
				printf("비밀번호가 너무 깁니다.\n");
			}
			else
			{
				// 비밀번호 확인하기
				while (true)
				{
					printf("비밀번호를 다시 입력해주세요 (6글자 이상 8글자 이내)\n");
					scanf("%s", password2);

					if (strcmp(password, password2) != 0)
					{
						printf("비밀번호가 다릅니다.\n");
					}
					else
					{
						break;
					}
				}
				break;
			}
		}
		printf("\n=======================\n");
		printf("이름: %s\n", name);
		printf("아이디: %s\n", email);
		printf("비밀번호: %s\n", password);
		printf("회원가입 완료되었습니다.\n");
		printf("=======================\n");
		break;
	}
}