using System;
using System.Collections.Generic;

/*
// 2024/04/04 : C# 상속(protected, base, 상속의 Object, 기본 생성자 상속)

// C# 상속
// 상속의 접근지정자 
// protected: 상속받은 자식에서만 접근이 가능. 그 외엔 접근 불가능.
// private: 상속받은 자식도 접근 불가능.
// 
// 상속 클래스 this, base()
// this: 자기 자신을 지칭
// base: 상속 받아서 인스턴스 된 부모를 지칭(생성자)
// 일반적으로 상속을 받으면 부모의 기본 생성자만 호출이 되기 때문에 부모 클래스의 매개변수를 사용할 수 없다.
// => 부모 클래스의 매개변수를 전달 받아 사용하고자 할 때 base() 를 통해 상속자를 상속받을 수 있다. (예제 2) Shape 참고)
//
// 상속에서의 Object
// Object형은 모든 자료형의 부모가 된다.(기본형)
// 모든 클래스나 구조체는 암묵적으로 Object를 상속받고 있다.
// Object 구조
// - class
// - valuetype 
//   - struct
// 클래스를 선언하면 기본적으로 Object를 상속받고 있다. (클래스 생성 후 : Object 를 하면 흐리게 보이는 것을 확인(이미 상속받고있음))
// ToString()은 Object에 속해 있는 메소드
// => 부모 클래스에 없는 ToString()을 자식 클래스에서 override 하여 ToString() 생성가능. (예제 3) Character 참고)
//
// 기본 생성자 상속
// 부모의 기능을 상속받으면 부모를 먼저 인스턴스하고 자식을 인스턴스한다.(기본 생성자인 경우)
// 자식의 생성자를 호출하면 자동적으로 부모의 생성자를 호출한다. (예제 4) Animal 참고)
// 매개변수는 자동적으로 호출을 못하기 때문에 base로 호출해야 한다.

*/

namespace day14
{
    internal class Program
    {
        #region 상속 예제 1) Car 클래스, 함수들
        // 상속 예제 1) Car
        class Car
        {
            public virtual void DescribeCar()
            {
                Console.WriteLine("4개의 휠이 달린 바퀴와 엔진이 있습니다.");
                ShowDetails();
            }

            public virtual void ShowDetails()
            {
                Console.WriteLine("4명의 사람을 태울 수 있습니다.");
            }
        }

        class ConvertibleCar : Car
        {
            public new void ShowDetails()
            {
                Console.WriteLine("지붕이 열립니다.");
            }
        }

        class Minivan : Car
        {
            public override void ShowDetails()
            {
                Console.WriteLine("7명을 태울 수 있습니다.");
            }
        }

        public static void TestCars1()
        {
            Console.WriteLine("TestCars1");
            Console.WriteLine("-----------");

            Car car1 = new Car();
            car1.DescribeCar();
            Console.WriteLine("-----------");

            ConvertibleCar car2 = new ConvertibleCar();
            car2.DescribeCar();                         // 부모로 접근. 부모의 showdetail 호출(가상함수) -> override 안되있어서 부모의 showdetail 출력
            Console.WriteLine("-----------");           // new한정자는 한정적으로 자기만 사용할 수 있기 때문에 부모로 접근 시 부모의 showdetail이 출력된다.

            Minivan car3 = new Minivan();
            car3.DescribeCar();                         // 부모로 접근. 부모의 showdetail 호출(가상함수) -> override 되어있어서 자식의 showdetail 출력
            Console.WriteLine("-----------");
        }

        public static void TestCars2()  // ☆☆ 같은 부모로 부터 파생된 부모 객체, 자식 인스턴스 (부모 클래스로 자식 클래스에 접근가능)
        {
            Console.WriteLine("\nTestCars2");
            Console.WriteLine("-----------");

            var cars = new List<Car> { new Car(), new ConvertibleCar(), new Minivan() };    // ☆☆ 부모 객체, 자식 인스턴스 (부모 클래스로 자식 클래스에 접근가능)

            foreach (var car in cars)
            {
                car.DescribeCar();
                Console.WriteLine("-----------");
            }
        }

        public static void TestCars3()  // 직접적으로 호출할 경우 자식메소드 출력 가능
        {
            Console.WriteLine("\nTestCars3");
            Console.WriteLine("-----------");
            ConvertibleCar car2 = new ConvertibleCar();
            Minivan car3 = new Minivan();

            car2.ShowDetails();
            car3.ShowDetails();
        }

        public static void TestCars4()  // 객체는 부모 객체(메모리 접근은 부모). 가상함수(virtual)여서 자식 메소드의 override를 확인.(new는 접근 X)
        {
            Console.WriteLine("\nTestCars4");
            Console.WriteLine("-----------");
            Car car2 = new ConvertibleCar();    // 부모 객체를 자식으로 인스턴스
            Car car3 = new Minivan();

            car2.ShowDetails();
            car3.ShowDetails();
        }
        #endregion

        #region 상속 예제 2) Shape 클래스
        public class Shape
        {
            public const double PI = Math.PI;
            protected double x, y;

            public Shape() { }
            public Shape(double x, double y)
            {
                this.x = x;
                this.y = y;
            }
            public virtual double Area()
            {
                return x * y;
            }
        }

        public class Circle : Shape
        {
            public Circle(double r) : base(r, 0) { }
            public override double Area()
            {
                return PI * x * x;
            }
        }

        public class Sphere : Shape
        {
            public Sphere(double r) : base(r, 0) { }
            public override double Area()
            {
                return 4 * PI * x * x;
            }
        }

        public class Cylinder : Shape
        {
            public Cylinder(double r, double h) : base(r, h) { }
            public override double Area()
            {
                return 2 * PI * x * x + 2 * PI * x * y;
            }
        }
        #endregion

        #region 상속 예제 3) Character 클래스
        public class Character
        {
            public virtual void ReadyToBattle()
            {
                Console.WriteLine("전투 태세를 취합니다.");
            }
        }

        public class Knight : Character
        {
            public override void ReadyToBattle()
            {
                Console.WriteLine("기사: 칼을 뽑아 전투 태세를 취합니다.");
            }

            public override string ToString()
            {
                return "기사 클래스";
            }
        }

        public class Archer : Character
        {
            public override void ReadyToBattle()
            {
                Console.WriteLine("궁수: 활을 뽑아 전투 태세를 취합니다.");
            }

            public override string ToString()
            {
                return "궁수 클래스";
            }
        }
        #endregion

        #region 상속 예제 4) Animal 클래스
        class Animal
        {
            public Animal()
            {
                Console.WriteLine("나는 동물 입니다.");
            }
            public virtual void Bark()
            {
                Console.WriteLine("울음 소리를 냅니다.");
            }
            public virtual void Attack()
            {
                Console.WriteLine("공격을 시작합니다.");
            }
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
                Console.WriteLine("할퀴기 공격");
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
        #endregion

        static void Main(string[] args)
        {
            // 상속 예제 1) Car
            {
                Console.WriteLine("상속 예제 1) Car");

                TestCars1();
                TestCars2();    // ☆☆ 부모 객체, 자식 인스턴스
                TestCars3();
                TestCars4();
            }

            // 상속 예제 2) Shape
            {
                Console.WriteLine("\n상속 예제 2) Shape");

                double r = 3.0, h = 5.0;
                Shape circle = new Circle(r);
                Shape sphere = new Sphere(r);
                Shape cylinder = new Cylinder(r, h);

                Console.WriteLine("원의 면적: {0:F2}", circle.Area());
                Console.WriteLine("구의 면적: {0:F2}", sphere.Area());
                Console.WriteLine("원통 면적: {0:F2}", cylinder.Area());
            }

            // 상속 예제 3) Character
            {
                Console.WriteLine("\n상속 예제 3) Character");

                Character[] characters = new Character[2];

                characters[0] = new Knight();
                characters[1] = new Archer();

                for (int i = 0; i < characters.Length; i++)
                {
                    Console.WriteLine(characters[i].ToString());
                    characters[i].ReadyToBattle();
                }
            }

            // 상속 예제 4) Animal
            {
                Console.WriteLine("\n상속 예제 4) Animal");

                Animal animal = new Animal();
                Cat cat = new Cat();
                Dog dog = new Dog();

                animal.Bark();
                cat.Bark();
                dog.Bark();

                List<Animal> listAnimal = new List<Animal>() { new Animal(), new Cat(), new Dog() };
                for (int i = 0; i < listAnimal.Count; i++)
                {
                    listAnimal[i].Attack();
                }
            }
        }
    }
}
