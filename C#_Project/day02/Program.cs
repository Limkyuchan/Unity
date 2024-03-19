using System;

/*
// 2024/03/19 : C# 문자열 생성자(string), C# 특징, 메소드 오버로딩

// C# 특징 (.NET 기능 확인하기 : F1, 정의 내용 확인하기 : F12)
// 1) 메모리를 할당해서 객체를 할당 즉, 실체화 하는것을 인스턴스라고 한다.
//    인스턴스를 해야지만 객체를 사용할 수 있다. (클래스 변수 => 객체)
// 2) C에서 정의한 함수는 C#에서는 메소드의 명칭을 사용한다. 
// 3) 함수는 구조체나 클래스 내부에 멤버로서 존재(작성)해야 한다.
// 4) 매개 변수가 다르다면 동일한 이름의 함수를 사용할 수 있다. => 메소드 오버로딩
// 5) 배열은 참조 형식으로 무조건 Heap 메모리로 사용된다.(동적 할당)
//    반드시 new를 함께 사용해야 한다.  ex) char[] texts = new char[5];  

// C# 문자열 (string)
// string은 참조형식이기 때문에 가지는 값은 주소이다.
// str1 == str2 : 원래는 주소비교가 이루어져야 하지만 문자를 관리하는 자료형으로 사용되기 때문에
//                == 는 문자열끼리의 비교가 이루어지도록 오버로딩되어짐. (예제에서 값은 같다는 의미)
// string.ReferenceEquals(str1, str2) : 참조하고 있는 주소의 비교 (예제에서 주소는 다르다는 의미)
// str1.CompareTo(str3) : 문자열을 서로 비교 (st1과 같으면 0, str1이 작으면 -1, str1이 크면 1)

*/

namespace day02
{
    internal class Program
    {
        // 클래스는 reference type (참조 형식) -> 힙 메모리를 참조하기 위해 사용.
        class Hero
        {
            public int hp;
            public int mp;

            public Hero()       // 생성자
            {                   // 특징 : 자기이름으로 된 함수, 반환값이 없다.
                hp = 100;
                mp = 10;
            }

            public Hero(int _hp)    // 생성자 오버로딩
            {
                hp = _hp;
            }

            public Hero(int _hp, int _mp)   // 생성자 오버로딩
            {
                hp = _hp;
                mp = _mp;
            }
        }

        // 매개 변수가 다르면 같은 이름의 함수를 생성할 수 있다.(메소드 오버로딩)
        static void Sum(int a, int b)
        {
            Console.WriteLine("{0} + {1} = {2}", a, b, a + b);
        }
        static void Sum(float a, float b)
        {
            Console.WriteLine("{0} + {1} = {2}\n", a, b, a + b);
        }

        static void Main(string[] args)
        {
            // 문자열(String)
            {
                Console.WriteLine("문자열(String)");

                string str = "aaaa";        // == string str = new string('a', 4);
                Console.WriteLine(str);     // string은 class이기 때문에 str이 Heap 메모리의 hello 주소를 참조하고 있다.(동적 할당)
            }

            // 메소드 오버로딩
            {
                Console.WriteLine("\n메소드 오버로딩");

                Sum(10, 20);
                Sum(10.5f, 20.4f);

                Hero hero = new Hero();
                Console.WriteLine("hero.hp: " + hero.hp);

                Hero hero2 = new Hero(300);
                Console.WriteLine("hero2.hp: " + hero2.hp);
            }

            // 문자열 예시 1) 생성자
            {
                Console.WriteLine("\n문자열 예시 1) 생성자");

                string str = "Hello";
                char[] chArr = new char[] { 'W', 'o', 'r', 'l', 'd' };
                string str2 = new string(chArr);
                string str3 = new string(chArr, 2, 3);  // 2번째 요소부터 3개를 출력
                string str4 = new string('w', 4);       // 'w'를 4개 저장
                Console.WriteLine(str);
                Console.WriteLine(str2);
                Console.WriteLine(str3);
                Console.WriteLine(str4);
                Console.WriteLine(str + str2);
            }

            // 문자열 예시 2) 값, 주소값 비교
            {
                Console.WriteLine("\n문자열 예시 2) 값, 주소값 비교");

                char[] chArr = new char[] { 'h', 'e', 'l', 'l', 'o' };
                string str1 = new string(chArr);
                string str2 = "hello";         
                string str3 = "world";
                Console.WriteLine(str1 == str2);                        // 문자열끼리의 비교가 이루어지도록 오버로딩되어짐. (값은 같다.)
                Console.WriteLine(string.ReferenceEquals(str1, str2));  // 참조하고 있는 주소의 비교 (주소는 다르다.)
                Console.WriteLine(str1.CompareTo(str3));                // 문자열을 서로 비교 
            }
        }
    }
}
