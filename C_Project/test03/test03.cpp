#include <stdio.h>
#include <stdlib.h>
#include <string.h>

struct USER
{
    char* id;
    char* name;
    int age;
};

USER* users = NULL;
int user_count = 0;

void showUsers();
void addUser(char* id, char* name, int age);
void removeUser(char* id);

int main()
{
    // Q3. 유저 추가 삭제 구현하기
    int choice, isTrue;
    char id[20];
    char name[20];
    int age;

    while (true)
    {
        printf("\n======= MENU =======\n");
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
                    do {    // ID 중복 처리
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


void showUsers()
{
    if (user_count == 0)
    {
        printf("유저 정보가 없습니다.\n");
    }
    else
    {
        printf("\n|\t ID|\t  Name|\t      Age|\n");
        for (int i = 0; i < user_count; i++)
        {
            printf("|%10s|%10s|%10d|\n", users[i].id, users[i].name, users[i].age);
        }
    }
}

void addUser(char* id, char* name, int age)
{
    // 유저 추가 시 저장할 새로운 배열 할당
    USER* newUser = (USER*)malloc(sizeof(USER) * (user_count + 1));

    for (int i = 0; i < user_count; i++)
    {
        newUser[i] = users[i];
    }

    // 입력된 글자만큼 메모리 동적 할당
    newUser[user_count].id = (char*)malloc(sizeof(char) * (strlen(id) + 1));
    newUser[user_count].name = (char*)malloc(sizeof(char) * (strlen(name) + 1));
    newUser[user_count].age = age;

    strcpy(newUser[user_count].id, id);
    strcpy(newUser[user_count].name, name);


    // 기존 데이터 해제 및 대체
    free(users);
    users = newUser;
    user_count++;
}

void removeUser(char* id)
{
    // 삭제할 유저의 인덱스 찾기
    int userIndex = -1;
    for (int i = 0; i < user_count; i++)
    {
        if (strcmp(users[i].id, id) == 0)
        {
            userIndex = i;
            break;
        }
    }

    if (userIndex != -1)
    {   
        // 유저 삭제
        for (int i = userIndex; i < user_count - 1; i++)
        {
            users[i] = users[i + 1];
        }
        user_count--;
        
        // 유저 삭제 후 다시 할당
        USER* newUser = (USER*)malloc(sizeof(USER) * user_count);
        for (int i = 0; i < user_count; i++)
        {
            newUser[i] = users[i];
        }

        // 기존 데이터 해제 및 대체
        free(users);
        users = newUser;
        printf("유저가 삭제되었습니다.\n");
    }
    // 유저 없을 경우
    else
    {
        printf("유저를 찾을 수 없습니다.\n");
    }
}
