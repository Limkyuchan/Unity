using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HeroTest;     // HeroTest namespace를 참조

/*
// 2024/03/21 : C# var, dynamic, namespace, class(생성자, 소멸자, this, 접근지정자)

// C# string 주의점
// string 사용시 힙 메모리에 계속 데이터가 쌓이는 경우 가비지 값이 계속 생긴다.
// 문자열을 Heap 메모리에 만들어서 계속 Boxing 하면 안된다.. (예제 1)

// C# var (variable) : 모든 유형을 포함할 수 있음. (선언시)
// var는 초기화 하지 않고 선언할 수 없다.
// 무조건 선언할 때 값을 넣어줘야 하고, 값을 넣는 순간 자료형이 결정된다.
// ex) var temp;            (X)
//     var temp = 10;       int 자료형 var
//     var temp = 3.14f;    float 자료형 var
// var는 함수의 반환값을 받을 때 용이하다. (무슨 형을 받을 지 모를 때 사용)

// C# dynamic : 모든 유형을 포함할 수 있음. (런타임)
// 초기화 하지 않고 선언을 먼저 진행하고 이 후에 자료형이 결정된다.
// ex)  dynamic temp;
//      temp = 10;              // 정수로 동작
//      temp = 3.14;            // 실수로 동작
//      temp = new Hero();      // 클래스 변수
//      ((Hero)temp).hp = 10;   // 멤버변수에 접근하기 위해선 Hero로 형 변환을 진행해야 한다.

// C# namespace
// namespace : 명칭들을 보관(저장)하는 장소.
// 사용 이유
// 1) 명칭 중복을 막기 위해 namespace가 사용된다. (다른 기능들 참조해서 사용할 때)
//    같은 명칭의 class라도 다른 namespace 공간이면 중복이 가능하다.
// 2) 카테고리별로 정리를 하는 용도로 사용되기도 한다.  ex) System.Text; System.Linq; ...
//    파일이 여러개로 나뉘더라도 하나의 namespace 카테고리로 묶어서 정리가 가능하다.

// C# 클래스(class)
// class : 객체들의 공통된 개념과 정의를 표현하는 틀
// 생성자 : 객체가 메모리에 할당 될 때 호출되는 메소드. 클래스 이름과 같아야 하고 반환값이 없다.
// 소멸자 : 클래스 이름 앞에 ~ 가 붙으며 중복 정의 할 수 없다. (오버로딩 X) 
//         소멸되는 시점에 자동으로 호출된다.
// this : 메모리에 할당이 되서 인스턴스가 된 자기 자신을 의미한다. (나 자신)
// 클래스의 변수를 필드라고 부른다. 
// 클래스의 기능들을 메소드라고 부른다.
// 필드는 항상 클래스의 상단에 작성해야 한다. (가독성이 좋음)

// C# 접근 지정자
// 은닉화가 중요하다.
// => 변수 자체가 public으로 선언되면 아무대서나 변수가 바뀌기 때문에 아무런 의미가 없어진다.
//    기본적으로 변수는 숨겨두고 기능만 표출하여 사용하도록 해야한다. (클래스 변수의 기본 값 private)
// public : 모든 곳에서 사용 가능 (외부 포함)
// private : 다른 곳에서 사용 불가능 

*/

namespace day04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // string 사용시 주의점 예제)
            {
                //Console.WriteLine("\nstring 사용시 주의점 예제)");

                //int score = 123456789;
                //while (true)
                //{
                //    score += 12;
                //    string scoreLable = string.Format("{0:n0}", score);
                //    Console.WriteLine(scoreLable);
                //    Thread.Sleep(1000);
                //}
            }

            // namespace 예제 1)
            {
                Console.WriteLine("namespace 예제 1)");

                Hero hero = new Hero();
                hero.hp = 100;
                Console.WriteLine(hero.hp);
            }

            // namespace 예제 2)
            {
                Console.WriteLine("namespace 예제 2)");

                A.Point point1 = new A.Point(2, 3);     // 같은 공간에서 똑같은 내용의 class를 담은 namespace 두 개를 사용하기 때문에
                B.Point point2 = new B.Point(4, 5);     // A.Point, B.Point 로 표시를 해줘야 서로 구분이 가능하다.
            }
        }
    }
}

// namespace 예제 2)
namespace A
{
    class Point
    {
        private int x, y;

        public Point(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
    }
}
namespace B
{
    class Point
    {
        private int x, y;

        public Point(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
    }
}
