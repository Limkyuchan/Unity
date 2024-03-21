using System;

/*
// 2024/03/20 : C# 문자열 기능, 문자열 변환, 입력 받기, 예외처리(try ~ catch), Object

// C# 문자열 기능
// 1) 문자열 서식문자
// .Format({0:000}, 10) => 4자리수로 채운다. ex) 0010
// .Format({0:n0})  => 세 자리 수마다 , 찍는다. ex) 123,456,789
// 2) 문자열 삽입
// .Insert(1, "문자열") => 1번 위치에 문자열을 추가하겠다.
//  문자열을 추가하고 새로운 메모리를 참조해서 그 결과를 반환.(원본 데이터는 변하지 않는다.)
// 3) 필드지정 정렬
// .PadLeft(10)  => 전체 공간은 10개고, 공간이 남으면 왼쪽부터 공백으로 비운다.
// .PadRight(10) => 전체 공간은 10개고, 공간이 남으면 오른쪽을 공백으로 비운다.
// .PadLeft(10, '*')  => 전체 공간은 10개고, 공간이 남으면 왼쪽부터 *로 채운다.
// .PadRight(10, '*') => 전체 공간은 10개고, 공간이 남으면 오른쪽부터 *로 채운다.
// 4) 문자열 삭제
// .Remove(4) => 4번째 인덱스부터 나머지를 모두 지운다. 
// .Remove(4, 2) => 4번째 인덱스부터 2개를 지운다.
// 5) 공백 제거
// .Trim() => 앞쪽과 뒤쪽의 공백을 제거
// 6) 알파벳만 해당
// .ToUpper() => 모두 대문자로 변경
// .ToLower() => 모두 소문자로 변경

// C# 문자열 변환 Parse, 예외 처리
// int.Parse("456") = 문자열 "456"을 정수값 456으로 변경
// 에러 발생 예시 
// - 값이 null일 경우 에러 발생
// - 값이 이름과 같은 문자일 경우 에러 발생
// - 값이 정수값을 벗어나게 되도 에러 발생 (overflow)
// => 에러 발생 시 try ~ catch를 통해 예외 처리를 할 수 있다.

// C# 사용자 입력받기
// Console.ReadLine(); : 입력된 값은 무조건 문자열로 읽어온다.

// C# Object
// 자료형 상관없이 모든 자료형을 대입하여 값을 가질 수 있다. (참조 형식이라 가능)
// 특징) Reference Type, Boxing/UnBoxing이 이루어지기 때문에 가비지값이 생길 수 있다.
//      Boxing : Heap메모리에 메모리를 생성한다.
//      UnBoxing : Heap 메모리에서 값을 꺼내온다.
// ex) ① int num = 10;
//     ② Object o = num; (Boxing)
//     ③ o = 1234;
//     ④ num = (int)o;   (UnBoxing)
//  ①② Object는 Heap영역이기 때문에 stack에 생성된 num의 주소를 object는 참조할 수 없다.
//  ②  Boxing : num과 동일한 크기의 메모리를 Heap 메모리에 복제(메모리가 늘어남). 생성된 Heap메모리의 주소를 참조하게 된다.
//  ③  Heap 영역에 1234의 메모리 만들고 o가 다시 참조한다. 전에 참조하던 num을 더이상 참조하지 않음 => 여기서 혼자 남게된 Heap영역의 num은 가비지 값.
//  ④  UnBoxing : Heap 영역의 1234 값을 int형 변환을 하고 값을 꺼내온다.

*/
namespace day03
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // string 기능 예제 1) Format
            {
                Console.WriteLine("string 기능 예제 1) Format");

                string str = string.Format("이름: {0} 나이: {1:000}", "홍길동", 40);   // {1:000} = 세자리로 채운다.
                Console.WriteLine(str);
            }

            // string 기능 예제 2) Insert, PadLeft, PadRight, Remove, Trim, ToUpper, ToLower
            {
                Console.WriteLine("\nstring 기능 예제 2) Insert, PadLeft, PadRight, Remove, Trim, ToUpper, ToLower");

                string str = "    world";
                string str2 = "HELLO";

                // 부분 문자열 삽입
                Console.WriteLine(str.Insert(1, "Hello"));
                // 문자열 패딩 
                Console.WriteLine(str.PadLeft(10));
                Console.WriteLine(str.PadLeft(10, '*'));
                Console.WriteLine(str.PadRight(10));
                Console.WriteLine(str2.PadRight(10, '*'));
                // 문자열 삭제
                Console.WriteLine(str.Remove(4));       // 인덱스 4부터 부분 문자열 제거
                Console.WriteLine(str.Remove(4, 2));    // 인덱스 4부터 2개의 부분 문자 제거
                // 소문자, 대문자로 변경
                Console.WriteLine(str.ToUpper());
                Console.WriteLine(str2.ToLower());
                // 앞, 뒤의 공백 제거
                Console.WriteLine(str.Trim());
            }

            // string 기능 예제 3) 문자열 변환, 입력 받기
            {
                Console.WriteLine("\nstring 기능 예제 3) 문자열 변환, 입력 받기");

                int num;
                string strnum = "456";

                num = int.Parse(strnum);
                Console.WriteLine("변환한 숫자 : {0}", num);
                num = int.Parse(Console.ReadLine());        // ReadLine 값은 모두 문자열로 읽어오기 때문에 int형으로 변환
                Console.WriteLine("입력한 숫자: {0}", num);
            }

            // string 기능 예제 4) 문자열 변환 시 예외처리 try ~ catch 
            {
                Console.WriteLine("\nstring 기능 예제 4) 문자열 변환 시 예외처리 try ~ catch ");

                string str = null;
                int result = 0;
                bool isTry = false;

                do
                {
                    isTry = false;
                    // 모든 형식에 대한 예외처리 (Exception e) 
                    try
                    {
                        str = Console.ReadLine();
                        result = int.Parse(str);
                    }
                    catch (Exception e)                 // 모든 형식에 대한 예외처리 : (Exception e) 
                    {                                   // 한 가지만 지정한 예외처리 : (FormatException e)
                        Console.WriteLine(e.Message);   // 에러 메시지 출력
                        isTry = true;
                    }
                } while (isTry);

                Console.WriteLine("result : " + result);
            }

            // Object 예제 )
            {
                Console.WriteLine("\nObject 예제 )");

                object obj1 = 20;
                object obj2 = 20;
                int num1 = 10;
                int num2 = 10;

                if (obj1 == obj2)
                    Console.WriteLine("object obj1과 obj2는 같습니다.");
                else
                    Console.WriteLine("object obj1과 obj2는 같지 않습니다.");

                if (num1 == num2)
                    Console.WriteLine("object num1과 num2는 같습니다.");
                else
                    Console.WriteLine("object num1과 num2는 같지 않습니다.");
            }
        }
    }
}
