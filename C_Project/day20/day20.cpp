#include <stdio.h>
#include <Windows.h>

/*
// 2024/03/14: 파일 입출력(파일 포인터), 비트맵 이미지 분석

// 파일 포인터 위치
// ftell(fp) : 파일 포인터의 위치를 알려줌.
// fseek(fp, 0, SEEK_SET) : 파일포인터를 SEEK_SET(맨 처음) 위치로 이동하고 0만큼 이동하라.
//  - SEEK_SET : 파일 포인터를 처음으로 이동
//  - SEEK_END : 파일 포인터를 맨 마지막으로 이동
//  - SEEK_CUR : 파일 포인터를 현재 위치로 이동
//  - 0 (offset) : 현재위치에서 0만큼 이동.(원하는 바이트 크기 만큼 앞 뒤로 이동 가능)

// 텍스트 파일(t) : fprintf, fscanf
// 바이너리 파일(b) : fwrite, fread
// 바이너리 파일은 데이터의 크기만큼을 읽고 쓰기만 하면 된다.
// -> 시작위치부터 크기만큼 적어넣으면 끝
// fwrite((void*)&person, sizeof(person), 1, fp)
//  person주소 찾아가서 / 크기만큼(구조체 크기만큼)을 읽어서 / 1번만 / 파일에다가 적겠다
// fread((void*)&tempperson, sizeof(tempperson), 1, fp)
//  tempperson 주소 찾아가서 / 크기만큼 / 1번만 / 적겠다(저장)

// 리틀 엔디안 방식, 빅 엔디안 방식
// 리틀엔디안 : 데이터를 거꾸로 접근      ex) MB
// 빅엔디안 : 데이터를 순서대로 접근      ex) BM
*/


// 파일 입출력 바이너리파일 예제 1)
struct PERSON
{
    char name[10];
    int age;
    float weight;
};


int main()
{
    // 2024/03/14 : 파일 입출력(파일 포인터), 비트맵 이미지 분석

    /*
    // 텍스트 파일 입출력 예제) 파일 읽기, 쓰기를 한 번에 처리
    FILE* fp;
    int num1 = 0, num2 = 0, result = 0;
    char ch1, ch2;

    fp = fopen("multiple_table.txt", "wt+");   // wt: write text
    if (fp == NULL)
    {
       printf("파일을 여는데 실패했습니다.");
       return 0;
    }
    for (int i = 1; i < 10; i++)
    {
       fprintf(fp, "2 x %d = %d\n", i, 2 * i);
    }

    printf("현재 파일 포인터 위치 %d\n", ftell(fp));
    fseek(fp, 0, SEEK_SET);
    printf("현재 파일 포인터 위치 %d\n", ftell(fp));

    for (int i = 1; i < 10; i++)
    {
       fscanf(fp, "%d %c %d %c %d", &num1, &ch1, &num2, &ch2, &result);
       printf("%d %c %d %c %d\n", num1, ch1, num2, ch2, result);
    }
    fclose(fp);



    // 입출력 바이너리파일 입출력 예제 1)
    PERSON person = { 0 };
    PERSON tempperson;
    FILE* fp;

    fp = fopen("person.txt", "wb+");
    if (fp == NULL)
    {
       printf("파일을 여는데 실패했습니다.");
       return 0;
    }

    printf("이름을 입력하세요: ");
    scanf("%s", person.name);
    printf("나이를 입력하세요: ");
    scanf("%d", &person.age);
    printf("몸무게를 입력하세요: ");
    scanf("%f", &person.weight);
                                                            // fwrite : person내용 읽고
    fwrite((void*)&person, sizeof(person), 1, fp);          // person주소 찾아가서, 크기만큼(구조체 크기만큼)을 읽어서, 1번만, 파일에 적겠다
    fseek(fp, 0, SEEK_SET);
                                                            // fread : tempperson 에 값 작성
    fread((void*)&tempperson, sizeof(tempperson), 1, fp);   // tempperson 주소 찾아가서, 크기만큼, 1번만, 파일에 적겠다(저장)
    printf("이름: %s, 나이: %d, 몸무게: %.2f\n", tempperson.name, tempperson.age, tempperson.weight);
    fclose(fp);



    // 비트맵(.bmp) 파일 분석 1)
    FILE* fp;
    BITMAPFILEHEADER bfh;         // 비트맵 파일헤더 (14Byte)
    BITMAPINFOHEADER bih;         // 비트맵 인포헤더 (40Byte)
    unsigned char* image;

    fp = fopen("image.bmp", "rb");   // 바이너리로 저장한 파일 불러오기

    // FileHeader 정보 가져오기
    fread(&bfh, sizeof(BITMAPFILEHEADER), 1, fp);
    if (bfh.bfType != 'MB')         // 2Byte 문자(글자)이기 때문에 '' 로 작성. 문자열 아님!
    {                        // 리틀엔디안이라 MB로 작성.
       printf("비트맵 파일이 아닙니다.\n");
       fclose(fp);
       exit(0);   // == return 0;
    }
    else
    {
       printf("비트맵 파일이 맞습니다.\n");
    }
    printf("비트맵 타입 %c%c\n", bfh.bfType, bfh.bfType >> 8);         // 리틀엔디안 기준 : M을 B의 자리로 이동하기위해 >> 8 을 작성.
    printf("비트맵 파일 크기 %.2fMB\n", bfh.bfSize / 1024.0f / 1024.0f);   // bfsize: Byte크기


    // InfoHeader 정보 가져오기
    fread(&bih, sizeof(BITMAPINFOHEADER), 1, fp);
    printf("비트맵 비트수 %dbit\n", bih.biBitCount);
    printf("비트맵 가로 넓이 %dpixel\n", bih.biWidth);
    printf("비트맵 세로 높이 %dpixel\n", bih.biHeight);
    printf("비트맵 이미지 크기 %.2fMB\n", bih.biSizeImage / 1024.0f / 1024.0f);


    // 이미지 크기 할당 (칼라 정보)
    image = (unsigned char*)malloc(bih.biSizeImage);
    fread(image, bih.biSizeImage, 1, fp);      // 이미지데이터 불러서 메모리에 넣어주는거
    fclose(fp);


    // 파일이 잘 저장 됐는지 확인
    fp = fopen("output.bmp", "wb");
    fwrite(&bfh, sizeof(BITMAPFILEHEADER), 1, fp);      // 파일헤더 작성
    fwrite(&bih, sizeof(BITMAPINFOHEADER), 1, fp);      // 인포헤더 작성
    fwrite(image, bih.biSizeImage, 1, fp);              // 이미지데이터 작성
    fclose(fp);
    */



    // 비트맵(.bmp) 파일 분석 1-1) 이미지 색상을 회색으로 (rgb값 모두 동일하면 회색)
    FILE* fp;
    BITMAPFILEHEADER bfh;         // 비트맵 파일헤더 (14Byte)
    BITMAPINFOHEADER bih;         // 비트맵 인포헤더 (40Byte)
    unsigned char* image;         // 비트맵 이미지정보
    unsigned char r = 0, g = 0, b = 0;
    int color = 0;

    fp = fopen("image.bmp", "rb");   // 바이너리로 저장한 파일 불러오기

    // FileHeader 정보 가져오기
    fread(&bfh, sizeof(BITMAPFILEHEADER), 1, fp);
    if (bfh.bfType != 'MB')         // 2Byte 문자(글자)이기 때문에 '' 로 작성. 문자열 아님!
    {                               // 리틀엔디안이라 MB로 작성.
        printf("비트맵 파일이 아닙니다.\n");
        fclose(fp);
        exit(0);   // == return 0;
    }
    else
    {
        printf("비트맵 파일이 맞습니다.\n");
    }
    printf("비트맵 타입 %c%c\n", bfh.bfType, bfh.bfType >> 8);             // 리틀엔디안 기준 : M을 B의 자리로 이동하기위해 >> 8 을 작성.
    printf("비트맵 파일 크기 %.2fMB\n", bfh.bfSize / 1024.0f / 1024.0f);   // bfsize: Byte크기


    // InfoHeader 정보 가져오기
    fread(&bih, sizeof(BITMAPINFOHEADER), 1, fp);
    printf("비트맵 비트수 %dbit\n", bih.biBitCount);
    printf("비트맵 가로 넓이 %dpixel\n", bih.biWidth);
    printf("비트맵 세로 높이 %dpixel\n", bih.biHeight);
    printf("비트맵 이미지 크기 %.2fMB\n", bih.biSizeImage / 1024.0f / 1024.0f);


    // 이미지 크기 할당 (컬러r,g,b 정보)
    image = (unsigned char*)malloc(bih.biSizeImage);    // 이미지 데이터를 동적할당을 통해 저장
    fread(image, bih.biSizeImage, 1, fp);               // 이미지데이터 불러서 메모리에 넣어주기
    fclose(fp);


    // 파일이 잘 저장 됐는지 확인
    fp = fopen("output.bmp", "wb");
    fwrite(&bfh, sizeof(BITMAPFILEHEADER), 1, fp);      // 파일헤더 작성
    fwrite(&bih, sizeof(BITMAPINFOHEADER), 1, fp);      // 인포헤더 작성

    for (int i = 0; i < bih.biSizeImage - 3; i += 3)    // RGB 3개씩 한번에 확인하기 위해 3개씩 건너뛰고, -3 전까지 읽어야 한다.
    {
        r = image[i + 0];               // 순서대로 r, g, b의 값들이 저장되어 있다.
        g = image[i + 1];
        b = image[i + 2];
        color = (r + g + b) / 3;        // r,g,b 세 값의 평균으로 값을 지정하면 회색으로 출력된다.

        image[i + 0] = color;
        image[i + 1] = color;
        image[i + 2] = color;
    }
    fwrite(image, bih.biSizeImage, 1, fp);            // 이미지데이터 작성
    fclose(fp);


}
