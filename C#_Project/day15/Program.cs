using System;
using System.Collections.Generic;

/*
// 2024/04/08 : C# 상속(추상 클래스, 인터페이스)

// C# 상속
// private은 override 안됨.
// public이나 protected만 override가 가능하다.

// C# 추상 클래스
// 인스턴스가 되기 전 상태(실체화가 되기 전) 추상만 하는 단계
// 추상 클래스는 인스턴스 불가하고, 무조건 상속을 받아서만 구현 가능하다. (new로 인스턴스 불가능!)
// sealed 한정자로 수정 불가.
// 추상 클래스를 상속 받은 클래스에서는 모든 추상 메소드의 구현이 "반드시" 포함되어야 한다.
// virtual과 마찬가지로 override 키워드로 재정의 해야 한다.
// => 가상함수의 경우 자식쪽에서 override를 해도 되고 안해도 되지만, 
// => 추상 클래스에서는 반드시 override로 재정의를 해야 한다.
// 정적 속성을 추상화가 불가.
//
// 부모: 기능이 없는 추상 메소드 선언
// 자식: 상속 받은 자식이 실체화 및 구체화. 재정의 진행.
// 부모의 기능을 필수적으로 사용해야 할 경우 가상함수 보다 추상클래스로 선언하는것이 좋다.
//
// C# 가상 함수와 추상 클래스
// 추상 클래스로 선언하더라도 가상 메소드, 일반 메소드, 정적 메소드 모두 선언은 가능하다. (예제 1 참고)
// 가상함수를 사용할 경우 부모쪽의 기능과 자식의 기능 모두 사용이 가능하다.

// C# 인터페이스
// 다중 상속이 가능하다. (하나 이상의 인터페이스를 상속 가능)
// 인터페이스는 인스턴스가 불가하고, 필드를 선언할 수 없다.
// 인터페이스 선언 시 구분을 위해 보통 맨 앞에 i를 붙여서 선언한다.
// => ex) iMonster, iAnimal ...
// 인터페이스는 접근지정자를 작성하지 않는다.
// 인터페이스에 정의한 메소드는 상속 받은 곳에서 "반드시" 구현이 필요. 하지만 override는 작성하지 않음.
// => 무조건 상속 받은 곳에서 override가 아닌 "public"으로 선언해야 한다.(강제)
// 인터페이스에서는 필드 선언이 불가하다. => 메소드 형식으로 선언가능. (Property 형식으로)
// => ex) 부모: float Power { get; set; }
//        자식: float _power;
//        자식: public float Power { get { return _power; } set { _power = value; } }

*/

namespace day15
{
    #region 추상 클래스 예제 1) Abstract (필드, 추상메소드, 가상메소드, 일반메소드)
    abstract class Abstract
    {
        protected int x = 10;                   // 필드
        public abstract int X { get; set; }     // 추상 메소드

        public virtual void func()              // 가상 메소드
        {
            Console.WriteLine("가상 메소드 선언");
        }

        public void func2()                     // 일반 메소드
        {
            Console.WriteLine("일반 메소드 선언 및 호출");
        }
    }

    class General : Abstract
    {
        public override int X                   // 추상 메소드
        {
            get { return x + 20; }
            set { x = value; }
        }

        public override void func()             // 가상 메소드(부모 메소드 호출, 자식 메소드 호출 모두 가능)
        {
            base.func();
            Console.WriteLine("가상 메소드 구현");
        }
    }
    #endregion

    #region 추상 클래스 예제 2) Animal 클래스
    abstract class Animal
    {
        public abstract void Bark();
        public abstract void Attack();
    }

    class Cat : Animal
    {
        public Cat()
        {
            Console.WriteLine("나는 고양이 입니다.");
        }

        public override void Bark()
        {
            Console.WriteLine("냐옹");
        }

        public override void Attack()
        {
            Console.WriteLine("핡퀴기 공격.");
        }
    }

    class Dog : Animal
    {
        public Dog()
        {
            Console.WriteLine("나는 개 입니다.");
        }

        public override void Bark()
        {
            Console.WriteLine("멍멍");
        }

        public override void Attack()
        {
            Console.WriteLine("물기 공격");
        }
    }

    class Bird : Animal
    {
        public Bird()
        {
            Console.WriteLine("나는 새 입니다.");
        }

        public override void Bark()
        {
            Console.WriteLine("짹짹");
        }

        public override void Attack()
        {
            Console.WriteLine("쪼기 공격");
        }
    }
    #endregion

    #region 인터페이스 예제 1) 다중 상속(interface)
    interface interA
    {
        void a();
    }

    interface interB
    {
        void b();
    }

    interface interC : interA
    {
        void c();
    }

    class MultiInheritance : interB, interC
    {
        // 인터페이스 선언 시 재정의 할 때 반드시 public 으로 작성!!
        public void a()
        {
            Console.WriteLine("a 메소드 호출");
        }

        public void b()
        {
            Console.WriteLine("b 메소드 호출");
        }

        public void c()
        {
            Console.WriteLine("c 메소드 호출");
        }
    }
    #endregion

    internal class Program
    {
        static void Main(string[] args)
        {
            // 상속 예제 1) Monster, MonsterBoss, Stage
            {
                Console.WriteLine("상속 예제 1) Monster, Monster_Boss, Stage");

                Stage stage = new Stage();
                stage.Start();
                stage.DrawMonster();
            }

            // 추상 클래스 예제 1) Abstract (필드, 추상메소드, 가상메소드, 일반메소드)
            {
                Console.WriteLine("\n추상 클래스 예제 1) Abstract (필드, 추상메소드, 가상메소드, 일반메소드)");

                //Abstract ab = new Abstract();     // 에러: 추상 클래스는 인스턴스 불가
                General general = new General();
                Console.WriteLine("프로퍼티 x의 값: " + general.X);
                general.func();
                general.func2();
            }

            // 추상 클래스 예제 2) Animal 클래스
            {
                Console.WriteLine("\n추상 클래스 예제 2) Animal 클래스");

                Cat cat = new Cat();
                Dog dog = new Dog();
                Bird bird = new Bird();

                cat.Bark();
                dog.Bark();
                bird.Bark();

                List<Animal> listAnimal = new List<Animal>() { new Dog(), new Bird(), new Cat() };
                for (int i = 0; i < listAnimal.Count; i++)
                {
                    listAnimal[i].Attack();
                }
            }

            // 인터페이스 예제 1) 다중 상속(interface)
            {
                Console.WriteLine("\n인터페이스 예제 1) 다중 상속(interface)");

                MultiInheritance mi = new MultiInheritance();

                // 인스턴스는 불가하지만, 이미 인스턴스 된 객체를 통해 접근은 가능하다.
                interA interface1 = mi;     // a만 접근 가능
                interB interface2 = mi;     // b만 접근 가능
                interC interface3 = mi;     // a, c만 접근 가능

                Console.WriteLine("인터페이스를 통한 접근");
                interface1.a();
                interface2.b();
                interface3.a();
                interface3.c();

                Console.WriteLine("클래스를 통한 접근");
                mi.a();
                mi.b();
                mi.c();
            }
        }
    }
}
