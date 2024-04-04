using System;

/*
// 2024/04/03 : C# 상속(virtual, override, new한정자)

// C# 상속
// 기능을 물려 받는다.
// 선언 방법: class [클래스명] : [상속받고자 하는 클래스명]
//                (자식 클래스)      (부모 클래스)
// 상속받은 자식 클래스는 부모 클래스의 메소드에 접근할 수 있다.
// 부모 클래스로 객체를 선언하고, 자식 클래스로 인스턴스 할 수 있다.☆☆☆☆☆
// => 부모 클래스에서 가상함수를 선언하지 않는다면 부모 클래스에만 접근이 가능하다.
// => 부모 클래스에서 가상함수를 선언하고, 자식 클래스에서 override한다면 자식 클래스에 접근이 가능하다.
// => 부모 클래스에서 가상함수를 선언하고, 자식 클래스에서 new한정자를 사용한다면 자식 클래스에 접근이 불가능하다.

// C# 부모 클래스의 메소드 수정
// 부모의 기능을 다시 정의하고자 할 때 2가지 방법이 있다.
// 1) 가상 함수(virtual, override)
// 메소드에만 사용이 가능하다.
// 부모 클래스의 메소드가 자식 클래스에서 수정이 필요할 때 가상함수를 사용할 수 있다.
// virtual로 선언한 가상 함수는 파생 클래스에서 override로 재정의 할 수 있다.(가상 함수인 경우만)
// virtual로 선언하지 않은 부모 클래스의 함수를 new 키워드로 파생 클래스에서 재정의 할 수 있다.
// - 부모 클래스를 가상 메소드로 선언: virtual
// - 가상함수를 자식 클래스에서 오버라이드로 재정의: override
//
// 2) new한정자
// 필드, 메소드, 클래스 모두 사용이 가능하다.
// 부모의 기능은 모두 무시하고, 자식클래스에서 한정적으로 새로 정의하겠다.
// - 부모 클래스에서 가상 함수를 선언하지 않았을 때 new한정자로 재정의할 수 있다: new

*/

namespace day13
{
    internal class Program
    {
        #region 상속 예제 1, 1-1, 1-2)
        class BaseClass
        {
            // 예제 1, 1-1)
            //public void Method1()
            //{
            //    Console.WriteLine("부모 클래스 - Method1");
            //}

            // 예제 1-2)
            public virtual void Method1()
            {
                Console.WriteLine("부모 클래스 - Method1");
            }

            // 예제 1-1, 1-2)
            public void Method2()
            {
                Console.WriteLine("부모 클래스 - Method2");
            }
        }

        class DerivedClass : BaseClass
        {
            // 예제 1-1) 같은 이름의 함수로 작성할 경우 경고 발생
            //public void Method2()
            //{
            //    Console.WriteLine("자식 클래스 - Method2");
            //}

            // 예제 1-2)
            public override void Method1()
            {
                Console.WriteLine("자식 클래스 - Method1");
            }

            public new void Method2()
            {
                Console.WriteLine("자식 클래스 - Method2");
            }
        }
        #endregion

        #region new 한정자 예제 )
        class BaseC
        {
            public static int x = 55;
            public static int y = 22;

            public class NestedC
            {
                public int a = 200;
                public int b;
            }
        }

        class DerivedC : BaseC
        {
            new public static int x = 100;

            new public class NestedC
            {
                public int a = 100;
                public int b;
                public int c;
            }
        }
        #endregion

        static void Main(string[] args)
        {
            // 상속 예제 1) 부모 클래스, 자식(파생) 클래스 생성
            {
                Console.WriteLine("상속 예제 1) BaseClass");

                BaseClass bc = new BaseClass();
                DerivedClass dc = new DerivedClass();
                BaseClass bcdc = new DerivedClass();

                //bc.Method1();
                //dc.Method1();
                //dc.Method2();
                //bcdc.Method1();     // ☆ 부모 클래스의 객체선언, 자식 클래스의 인스턴스 => 부모 클래스만 접근이 가능하다. (Method2 접근 X)

                // 예제 1-1) 부모 클래스의 메소드가 자식 클래스에서 필요할 떄(경고 발생)
                Console.WriteLine("\n예제 1-1) 부모 클래스의 메소드가 자식 클래스에서 필요할 떄(경고 발생)");

                //bc.Method1();
                //bc.Method2();
                //dc.Method1();
                //dc.Method2();       // 경고 발생: 자식 클래스의 메소드가 늦게 선언되어 자식 클래스의 메소드 출력됨.
                //bcdc.Method1();
                //bcdc.Method2();

                // 예제 1-2) override, new 한정자
                Console.WriteLine("\n예제 1-2) override, new 한정자");

                bc.Method1();
                bc.Method2();
                dc.Method1();
                dc.Method2();
                bcdc.Method1();     // ☆ 접근은 부모로 하지만 가상함수라 자식쪽의 메소드를 호출한다. (접근은 모두 부모쪽으로)
                bcdc.Method2();     // ☆ 가상함수가 아니기 때문에 부모쪽의 메소드를 호출한다. (접근은 모두 부모쪽으로)
            }

      
            // new 한정자 예제 )
            {
                Console.WriteLine("\nnew 한정자 예제 )");

                Console.WriteLine(DerivedC.x);  // 출력: 100
                Console.WriteLine(BaseC.x);     // 출력: 55
                Console.WriteLine(BaseC.y);     // 출력: 22

                DerivedC.NestedC c1 = new DerivedC.NestedC();
                BaseC.NestedC c2 = new BaseC.NestedC();

                Console.WriteLine(c1.a);        // 출력: 100
                Console.WriteLine(c2.a);        // 출력: 200
            }
        }
    }
}
