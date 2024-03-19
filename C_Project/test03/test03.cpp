#include <stdio.h>
#include <stdlib.h>
#include <string.h>


struct USER
{
    char* id;
    char* name;
    int age;
};

// 유저 삭제 함수
void removeUser(const char* id)
{
    int foundIndex = -1;
    for (int i = 0; i < user_count; i++)
    {
        if (strcmp(users[i].id, id) == 0)
        {
            foundIndex = i;
            break;
        }
    }

    if (foundIndex != -1)
    {
        // 유저 삭제
        for (int j = foundIndex; j < user_count - 1; j++)
        {
            users[j] = users[j + 1];
        }
        user_count--;

        // 유저 배열 크기를 줄임
        users = (USER*)realloc(users, user_count * sizeof(USER));
        printf("유저가 삭제되었습니다.\n");
    }
    else
    {
        printf("해당하는 ID의 유저를 찾을 수 없습니다.\n");
    }
}

void addUser(char* id, char* name, int age);
void showUsers();

USER* users = NULL;
int user_count = 0;

int main()
{
    int choice, isTrue;
    char id[20];
    char name[20];
    int age;

    while (true)
    {
        printf("==================== MENU ====================\n");
        printf("1. User 정보 추가\n");
        printf("2. User 정보 삭제\n");
        printf("3. User 정보 출력\n");
        printf("0. 종료\n");

        printf("\n메뉴를 선택하세요: ");
        scanf("%d", &choice);

        if (choice == 0)
        {
            printf("프로그램을 종료합니다.\n");
            free(users);
            break;
        }
        else
        {
            switch (choice)
            {
                case 1:
                    do {
                        isTrue = false;
                        printf("ID를 입력하세요: ");
                        scanf("%s", id);

                        for (int i = 0; i < user_count; i++)
                        {
                            if (strcmp(users[i].id, id) == 0)
                            {
                                printf("이미 존재하는 ID입니다.\n");
                                isTrue = true;
                                break;
                            }
                        }
                    } while (isTrue);
                    
                    printf("이름을 입력하세요: ");
                    scanf("%s", name);

                    printf("나이를 입력하세요: ");
                    scanf("%d", &age);

                    addUser(id, name, age);
                    break;
                case 2:
                    printf("삭제할 ID를 입력하세요: ");
                    scanf("%s", id);

                    removeUser(id);
                    break;
                case 3:
                    showUsers();
                    break;
                default:
                    printf("올바른 메뉴를 선택해주세요\n");
                    break;
            }
        }
    }
}


void addUser(char* id, char* name, int age)
{

    // String* str = (String*)malloc(sizeof(String));   // 구조체의 크기만큼 동적할당 받고
    // str->texts = (char*)malloc(6);                   // texts는 몇글자를 받을지 모르기때문에 알려줘야 한다. -> char 자료형 6개만큼
    // strcpy(str->texts, "hello");                     // hello 단어를 strcpy를 통해 문자열 복사


    // 새로운 유저 정보를 저장할 새로운 배열 할당
    USER* newUser = (USER*)malloc(sizeof(USER) * (user_count + 1));

    // 기존 유저 정보를 새로운 배열로 복사
    for (int i = 0; i < user_count; i++)
    {
        newUser[i] = users[i];
    }

    // 새로운 유저 정보 추가
    strcpy(newUser[user_count].id, id);
    strcpy(newUser[user_count].name, name);
    newUser[user_count].age = age;

    // 기존 유저 배열의 메모리 해제
    free(users);

    // 새로운 유저 배열을 기존 유저 배열로 대체
    users = newUser;
    user_count++;
}

void showUsers()
{
    if (user_count == 0)
    {
        printf("유저 정보가 없습니다.\n");
        return;
    }

    printf("=============== 유저 정보 ===============\n");
    for (int i = 0; i < user_count; i++)
    {
        printf("ID: %s, 이름: %s, 나이: %d\n", users[i].id, users[i].name, users[i].age);
    }
    printf("\n========================================\n\n");
}

