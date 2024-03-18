using System;

/*
// 2024/03/18 : C# 출력 방법, 자료형, 서식문자, 구조체와 클래스의 차이점(생성자)

// C# 자료형
// 1) Value Type (값 형식) : 선언함과 동시에 메모리를 할당받기 때문에 Stack 영역으로 잡힌다.
// bool : true or false(초기값), Boolean value
// byte : 1byte, 부호 없는 8bit 정수
// char : 2byte, 유니코드 16bit 문자
// long : 8byte, 부호 있는 64bit 정수
// decimal : 28~29 자릿수의 128bit 소수
// sbyte : 1byte, 부호 있는 8bit 정수
//  => 위의 자료형들은 구조체로 정의되어 있기때문에 .을 사용해 기능들에 접근할 수 있다.
//  => ☆구조체는 전부 Value Type(값 형식)이다.
//
// 2) Value Type이 아닌 친구들
// object : 모든 타입의 기본 클래스로 모든 유형을 포함할 수 있음.
// string : 유니코드 문자열
// var : 모든 유형을 포함할 수 있음.(선언 시)
// dynamic : 모든 유형을 포함할 수 있음.(런타임)
//  => string은 class로 구성.

// C# 클래스와 구조체의 차이점
// 구조체는 value type (값 형식) -> 선언된 위치에서 바로 메모리가 잡힌다(주로 Stack, Data영역)
// 클래스는 reference type (참조 형식) -> 힙 메모리를 참조하기 위해 사용(Heap 영역)
// 구조체는 선언한 위치에서 메모리가 잡히기 때문에 힙 영역에 저장되지 않는다.
// 힙 영역에 저장하기 위해서 참조 방식인 class를 사용한다.
// 구조체 예시) Monster mon; (가능)
//             mon.hp = 1;
// 클래스 예시) Hero hero; (에러 발생)
//             hero.hp = 1;
// 클래스는 Heap영역에 저장되고, Stack에는 저장할 공간이 없기 때문에 에러가 발생한다. => 참조가 필요함
// 클래스 사용할 때는 반드시 Heap 메모리를 참조해야 사용 가능 -> 클래스를 사용하면 "구조체 포인터"의 역할을 한다.
// 클래스 예시) Hero hero = new Hero(); 
//             hero.hp = 1; 
// new Hero() : Heap 메모리에 Hero 클래스 크기만큼(해당 크기만큼) 새로 메모리를 달라 
//  => 생성할 때 호출하는 함수라고 해서 "생성자"라고 부른다. Heap 메모리의 주소를 참조할 수 있도록 하는 역할(포인터의 역할)

// C#에서는 유니코드로 작성되기 때문에 한글로 함수, 변수명을 사용할 수 있다. 하지만 사용은 지양!
//  ex) void 덧셈프로그램() {} 
//      int 숫자 = 100;

// C# 서식문자 (중괄호, 숫자 : {0})
// 숫자를 작성할 때 반드시 0번부터 순서대로 작성해야 한다.
// 자료형은 전혀 신경쓰지 않고, 인덱스 번호만 작성하면 된다.
// 0번부터 작성은 해야하지만, 그 안에서의 순서는 바뀌어도 된다.
//  ex) Console.WriteLine("{2} {1} {0}", num1, num2, num3);

*/


namespace day01
{
    internal class Program
    {
        // 구조체는 value type (값 형식) -> 선언된 위치에서 바로 메모리가 잡힌다.
        struct Monster
        {
            public int hp;  // 기본형은 private
        }
        // 클래스는 reference type (참조 형식) -> 힙 메모리를 참조하기 위해 사용.
        class Hero
        {
            public int hp;
        }


        static void Main(string[] args)
        {
            // 기본 출력 방법
            {
                Console.WriteLine("기본 출력 방법");
                Console.Write("Hi ");
                Console.WriteLine("Hello ");
                Console.WriteLine();    // == newline
            }

            // 변수 출력 방법(문자열)
            {
                Console.WriteLine("\n변수 출력 방법(문자열)");
                int num = 100;
                float pi = 3.14f;
                Console.WriteLine("Hello world!" + ' ' + num + ' ' + pi);

                Console.WriteLine("\n문자열 출력");
                string str = "hello world!";        // Stack에 할당되기 때문에 1mb를 넘길 수 없는 단점.
                Console.WriteLine(str);
            }

            // 변수 출력 예시
            {
                Console.WriteLine("\n변수 출력 예시");
                Console.WriteLine("int 형의 크기: " + sizeof(int) + ", 최소 값: " + int.MinValue + ", 최대 값: " + int.MaxValue);
                Console.WriteLine("long 형의 크기: " + sizeof(long) + ", 최소 값: " + long.MinValue + ", 최대 값: " + long.MaxValue);
                Console.WriteLine("char 형의 크기: " + sizeof(char) + ", 최소 값: " + char.MinValue + ", 최대 값: " + char.MaxValue);
                Console.WriteLine("float 형의 크기: " + sizeof(float) + ", 최소 값: " + float.MinValue + ", 최대 값: " + float.MaxValue);
                Console.WriteLine("double 형의 크기: " + sizeof(double) + ", 최소 값: " + double.MinValue + ", 최대 값: " + double.MaxValue);
                Console.WriteLine("decimal 형의 크기: " + sizeof(decimal) + ", 최소 값: " + decimal.MinValue + ", 최대 값: " + decimal.MaxValue);
            }

            // 자료형 차이
            {
                Console.WriteLine("\n자료형 차이");
                char ch = 'B';
                //char ch = 50;         // 대입할 수 없음
                Console.WriteLine("char형의 크기: " + sizeof(char));
                Console.WriteLine("char 변수 ch의 값: " + ch);
            }

            // 서식문자(중괄호, 숫자{0})
            {
                Console.WriteLine("\n서식문자(중괄호, 숫자{0})");
                int num1 = 10;
                int num2 = 20;
                Console.WriteLine("{0} x {1} = {2}", num1, num2, num1 * num2);
            }

            // 동적 할당 방법 : new 생성자 (C#은 포인터가 없다.)
            {
                Monster mon;
                //Monster* mon2;        // 포인터가 없어서 사용 불가.
                mon.hp = 1;

                //Hero hero;            // 반드시 힙 메모리 참조해야 사용 가능. -> 클래스를 사용하면 구조체 포인터의 역할을 한다.
                Hero hero = new Hero(); // 생성자라고 부른다. 포인터의 역할을 대신함.
                hero.hp = 1;            // 힙 메모리의 주소를 참조할 수 있도록 하는 역할.
            }
        }

    }
}
