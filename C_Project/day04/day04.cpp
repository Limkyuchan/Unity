// ctrl + k + f : 줄 정렬 단축키
// # : 선행 처리기(전처리기) - 먼저 실행되는 코드
#include <stdio.h>

// 2024/02/16 : 연산자, 제어문

// 착용 무기 선언 (2024.02.16 예제 1)
# define WP_SWORD   0x00000001  // 1        // #을 통해 define(정의함) 미리 실행되도록
# define WP_AXE     0x00000002  // 2
# define WP_GUN     0x00000004  // 4
# define WP_BOW     0x00000008  // 8
# define WP_STAFF   0x00000010  // 16

int main()
{
    // 2024/02/16 : 연산자, 제어문(if, switch)
    
    // 예제 1) 비트 연산자
    // 무기 장착                                 // | 연산자를 통해 iWeapon에 sword, axe, gun 을 포함시킨다.
    int iWeapon = WP_SWORD | WP_AXE | WP_GUN;   // sword 0001, axe 0010, gun 0100 --> iWeapon 0111

    // 무기 장착 해제                            // ~ 연산자를 통해 iWeapn에서 axe 를 제외시킨다.
    iWeapon = iWeapon & ~WP_AXE;                // iWeapon 0111 & ~AXE 1101 --> iWeapon 0101 (axe는 빠진것을 확인)

    if (iWeapon & WP_SWORD)
        printf("SWORD 장착\n");
    if (iWeapon & WP_AXE)
        printf("AXE 장착\n");
    if (iWeapon & WP_GUN)
        printf("GUN 장착\n");
    if (iWeapon & WP_BOW)
        printf("BOW 장착\n");
    if (iWeapon & WP_STAFF)
        printf("STAFF 장착\n");


    // 예제 2) 비트 연산자
    unsigned char val1 = 7, val2 = 5;
    printf("val1 & val2 = %d\n", val1 & val2);  // 5
    printf("val1 | val2 = %d\n", val1 | val2);  // 7
    printf("val1 ^ val2 = %d\n", val1^ val2);   // 2
    printf("~val1 = %d\n", ~val1);              // -8
    printf("val1 << 2 = %d\n", val1 << 2);      // 28
    printf("val2 >> 2 = %d\n", val2 >> 2);      // 1


    // 예제 3) 제어문 if ~ else if ~ else
    int score = 0;
    printf("점수를 입력하세요 (0~100) : ");
    scanf("%d", &score);

    if (score > 100 || score < 0)
    {
        printf("NA\n");
    }
    else if (score >= 90)
    {
        printf("A 학점입니다.\n");
    }
    else if (score >= 80)
    {
        printf("B 학점입니다.\n");
    }
    else if (score >= 70)
    {
        printf("C 학점입니다.\n");
    }
    else if (score >= 60)
    {
        printf("D 학점입니다.\n");
    }
    else
    {
        printf("F 학점입니다.\n");
    }


    // 예제 4) 제어문 switch ~ case
    int score2 = 0;
    printf("점수를 입력하세요 (0~100) : ");
    scanf("%d", &score2);

    if (score2 > 100 || score2 < 0)
    {
        printf("NA\n");
    }
    else
    {
        switch (score2 / 10)
        {
            case 10:
            case 9:
                printf("A 학점입니다.\n");
                break;
            case 8:
                printf("B 학점입니다.\n");
                break;
            case 7:
                printf("C 학점입니다.\n");
                break;
            case 6:
                printf("D 학점입니다.\n");
                break;
            default:
                printf("F 학점입니다.\n");
                break;
        }
    }


    // 과제) 이름, 성별, 키, 몸무게를 입력 받아 BMI 계산하기
    // | 공식 : 체중(kg) / 신장(m)의 제곱
    // | 저체중 : 18.5 미만
    // | 정상체중 : 18.5 ~ 22.9
    // | 과체중 : 23 ~ 24.9
    // | 비만 : 25 ~ 29.9
    // | 고도비만 : 30 ~ 39.9
    // | 출력 예시 : (이름)님 (성별 남/녀) bmi수치 : (값)이고, (저체중) 입니다.

    char name[9];
    char gen[3];
    float height = 0;
    float weight = 0;
    float bmi = 0;

    printf("이름을 입력해주세요 : ");
    scanf("%s", &name);

    printf("성별을 남/여 중 하나를 입력해주세요 :");
    scanf("%s", &gen);

    printf("키(cm)를 입력해주세요 : ");
    scanf("%f", &height);

    printf("몸무게(kg)를 입력해주세요 : ");
    scanf("%f", &weight);

    bmi = weight / (height * height * 0.0001);

    printf("%s 님 성별은 %s 이고, bmi수치는 %.2f 이며 ", name, gen, bmi);
    if (bmi < 18.5)
    {
        printf("저체중 입니다.\n");
    }
    else if (bmi <= 22.9)
    {
        printf("정상체중 입니다.\n");
    }
    else if (bmi <= 24.9)
    {
        printf("과체중 입니다.\n");
    }
    else if (bmi <= 29.9)
    {
        printf("비만 입니다.\n");
    }
    else if (bmi <= 39.9)
    {
        printf("고도비만 입니다.\n");
    }
    
}

