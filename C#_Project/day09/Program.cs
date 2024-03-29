using System;

/*
// 2024/03/28 : C# 대리자

// C# 대리자
// 선언: delegate [자료형] [대리자명] ([매개변수]);
// 대리자는 함수를 대신해서 사용한다.
// 대리자는 함수를 값으로 가진다. 함수의 주소를 기억(함수 포인터 역할)
// 대리자를 사용하기 위해서는 반환하는 형태와 매개변수의 개수가 같은 함수들만 사용할 수 있다.
// 대리자를 주로 함수의 매개변수로 사용해서 같은 함수를 다른 방식으로 활용할 수 있다. (재사용성 커짐)
// 대리자는 하나의 주소만을 가지는 것이 아닌, 여러개의 주소를 가질 수 있다.
// => 입력되는 순서대로 출력된다.(예제 3 참고)
// => ex) 게임 이벤트 시 저장된 함수들을 del 하나의 호출로 출력할 수 있다.

// C# EventHandler
// C# 에서 미리 정의한 대리자
// 이벤트가 발생했을 때 (마우스 클릭, 윈도우 창 크기 변화, ..) 전달됨
// 필드와 메소드 차이점
// EventHandler m_event        - m_event: 필드 
// event EventHandler m_event  - m_event: 메소드(필드 X)
// ex)
// 아래의 내용은 위의 내용과 의미가 같다.
// public int Hp;              - 필드
// public int Hp { get; set; } - 메소드(필드 X )
// => 필드 또는 메소드로 선언 불가 시 메소드 또는 필드로 대체가 가능하다.

*/

// 대리자 예제 1, 2, 3) 
delegate int TestDelegate(int a, int b);

// 대리자 예제 4)
delegate T TestDelegate2<T>(T a, T b);

namespace day09
{
    // 대리자 예제 2, 3) 
    class Calculator
    {
        public int Plus(int a, int b)
        {
            Console.WriteLine("{0} + {1} = {2}", a, b, a + b);
            return a + b;
        }
        public int Minus(int a, int b)
        {
            Console.WriteLine("{0} - {1} = {2}", a, b, a - b);
            return a - b;
        }
        public int Multiply(int a, int b)
        {
            Console.WriteLine("{0} * {1} = {2}", a, b, a * b);
            return a * b;
        }
    }

    // 대리자 예제 4)
    class Calculator2
    {
        public int Plus(int a, int b) { return a + b; }
        public float Plus(float a, float b) { return a + b; }
        public int Minus(int a, int b) { return a - b; }
        public float Minus(float a, float b) { return a - b; }
        public int Multiply(int a, int b) { return a * b; }
        public float Multiply(float a, float b) { return a * b; }
    }

    internal class Program
    {
        // 대리자 예제 1)
        //delegate int TestDelegate(int a, int b);        // 반환값은 int형, 매개변수 int형이 2개인 함수만 대리자로 사용가능.
        public static int Plus(int a, int b) { return a + b; }
        public static int Minus(int a, int b) { return a - b; }

        // 대리자 예제 2)
        public static void Calculator(int a, int b, TestDelegate callback)
        {
            Console.WriteLine(callback(a, b));
        }

        // 대리자 예제 4)
        public static void Calculator2<T>(T a, T b, TestDelegate2<T> callback)
        {
            Console.WriteLine(callback(a, b));
        }

        static void Main(string[] args)
        {
            // 대리자 예제 1)
            {
                Console.WriteLine("대리자 예제 1) ");

                TestDelegate del;                 // TestDelegate 객체 선언
                del = new TestDelegate(Plus);     // 인스턴스 진행. TestDelegate에 Plus를 지정 => del이 Plus의 역할을 대신한다.
                int result = del(20, 30);
                Console.WriteLine("result: " + result);

                del = new TestDelegate(Minus);
                result = del(20, 30);
                Console.WriteLine("result: " + result);
            }

            // 대리자 예제 2) 함수의 매개변수를 delegate로 사용. 
            {
                Console.WriteLine("\n대리자 예제 2) 함수의 매개변수를 delegate로 사용.");

                Calculator cal = new Calculator();

                Calculator(10, 20, cal.Plus);
                Calculator(10, 20, cal.Minus);
                Calculator(10, 20, cal.Multiply);
            }

            // 대리자 예제 3) 대리자 기능: delegate 중첩(여러개의 함수 호출)
            {
                Console.WriteLine("\n대리자 예제 3) 대리자 기능: delegate 중첩(여러개의 함수 호출)");

                Calculator cal = new Calculator();
                TestDelegate del = cal.Plus;

                del += cal.Minus;
                del += cal.Multiply;
                del(10, 20);
                del -= cal.Plus;
                del -= cal.Minus;
                del(20, 30);
            }

            // 대리자 예제 4) 대리자 + 일반화: delegate를 일반화로 선언.
            {
                Console.WriteLine("\n대리자 예제 4) 대리자 + 일반화: delegate를 일반화로 선언.");

                Calculator2 cal = new Calculator2();

                Calculator2(10, 20, cal.Plus);
                Calculator2(54.6f, 96.32f, cal.Plus);
                Calculator2(200.5f, 120.10f, cal.Minus);
                Calculator2(36.5f, 42.3f, cal.Multiply);
            }
        }
    }
}
