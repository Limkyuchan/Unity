using System;

/*
// 2024/03/22 : C# class(접근지정자, Get/Set, property, 정적 변수, 정적 메소드), call by reference (out, ref)

// C# 접근 지정자
// 은닉화가 중요하다.
// => 변수 자체가 public으로 선언되면 아무대서나 변수가 바뀌기 때문에 아무런 의미가 없어진다.
//    기본적으로 변수는 숨겨두고 기능만 표출하여 사용하도록 해야한다. (클래스 변수의 기본 값 private)
// 변수 자체를 사용하는 경우 public으로 선언해도 상관없지만, 변수를 제어하는 기능이 별도로 있는 경우 private으로 선언해야 한다.
// public : 모든 곳에서 사용 가능 (외부 포함)
// private : 다른 곳에서 사용 불가능 (외부에서는 불가능)
// 클래스에서 private 변수 사용 시 Get, Set 함수를 통해 값을 조회 및 변경할 수 있다.

// C# Property
// Get, Set 함수를 한 번에 작성할 수 있다.
// property의 경우 보통 한 줄로 선언을 해도 무방하다.
// property 사용시 변수의 첫 글자는 대문자를 사용하고, 변수 사용하듯이 사용한다.
// property는 기능으로 함수(메소드)로 취급한다.
// ex) public int Hp { get { return hp; } private set { hp = value; } }     // set을 private으로 선언가능
// ex) public int Hp { get { return hp; } set { hp = value; } }

// C# static 정적 변수, 정적 메소드 (클래스 예제 1-1) 참고) 
// 1) 정적 변수
// 정적 키워드(static)로 선언 시 선언과 동시에 정적 영역에 메모리가 바로 잡힌다.
// 즉, new를 통해 객체 인스턴스를 하기 전 정적 영역에 메모리가 바로 잡히게 된다.
// 정적 영역에 이미 메모리가 잡혀 있어서 new를 통해 각각 인스턴스를 할 경우 schoolName은 접근이 제외되고 객체가 생성된다.
// => ex) std1.m_schoolName 이 보이지 않는다. (객체를 통해서는 접근이 불가능)
// => ex) student2.m_schoolName 으로 접근해야 접근이 가능하다. (모든 학생이 동일한 학교에 접근 가능)
// 2) 정적 메소드
// 정적메소드 사용 시 인스턴스 과정 없이 바로 사용이 가능하다. (바로 메모리가 잡히기 때문)
// 정적메소드에서는 정적변수만 사용이 가능하다. (이미 메모리가 잡히기 때문에, 이미 메모리가 잡힌 변수만 사용이 가능)
// 동일한 연산이 필요하여 함수가 하나만 있어도 되는경우 정적메소드를 사용함. ex) 객체 모두가 동일한 schoolName
// 객체별로 함수가 필요하다면 정적 메소드를 사용할 수 없다. (객체에서는 접근 불가능)
// => 정적메소드 사용시 객체를 통한 접근이 아닌 클래스를 통한 접근으로 사용

// C# call by reference 구현 방법
// 반환값 여러개인 경우 참조 방식(call by reference)을 사용해야 한다. 
// 함수의 매개변수일 때 value 타입을 reference 타입처럼 사용하는 방법
// 즉, 포인터의 사용이 필요할 경우 out 과 ref 를 사용할 수 있다.  
// out : 값을 보내기만 가능하고, 값을 가져오는 것은 불가능
// ref : 값을 읽고 전달하는 역할

*/


// 접근지정자 예제 1) public 사용한 잘못된 예제
//class Hero
//{
//    private const int MAX_HP = 500;
//    public int hp = 0;

//    public Hero()
//    {
//        hp = MAX_HP;
//    }
//    public void LevelUp()
//    {
//        hp = MAX_HP;
//    }
//}

// 접근지정자 예제 1-1) private, Get, Set 사용한 올바른 예제
class Hero
{
    private const int MAX_HP = 500;
    private int hp = 0;

    // 접근지정자 예제 1-2) Property (아래 GetHp(), SetHp() 함수를 대신하여 사용.)
    public int Hp { get { return hp; } set { hp = value; } }

    public int GetHp()          // Get 함수 : private인 hp의 값을 가져온다.
    {
        return hp;
    }
    public void SetHp(int hp)   // Set 함수 : private인 hp의 값을 변경한다. 또한, 기능들을 내가 제어할 수 있다.       
    {
        this.hp = hp;
    }
    public Hero()
    {
        hp = MAX_HP;
    }
    public void LevelUp()
    {
        hp = MAX_HP;
    }
}

// 접근지정자 예제 1-3)
class Hero2
{
    private const int MAX_HP = 500;
    private int hp = 0;

    public int GetHp() { return hp; }
    public Hero2()
    {
        hp = MAX_HP;
    }
    public void LevelUp()
    {
        hp = MAX_HP;
    }
    public void Damage(int dmg)
    {
        if (hp - dmg > 0)
        {
            hp -= dmg;
        }
        else
        {
            hp = 0;
        }
    }
}

// 클래스 예제 1)
class Student
{
    public string m_name;
    public string m_schoolName;
}

// 클래스 예제 1-1) 정적 변수, 정적 메소드
class Student2
{
    private string m_name;
    public static string m_schoolName;      // 객체별로 메모리가 잡히는 것이 아니고 "정적변수"로 메모리를 잡음으로서 한 가지 값만을 사용.

    public string Name { get { return m_name; } set { m_name = value; } }   //property
    public void Intro()
    {
        Console.WriteLine("{0}에 다니는 {1}입니다.", m_schoolName, m_name);
    }

    // 정적메소드 추가 1-2)
    public static void IntroMyUniv()
    {
        Console.WriteLine("우리 학교는 {0} 입니다.", m_schoolName);
    }
}


namespace day05
{
    internal class Program
    {

        // call by reference 구현 예제 1) out
        static void Add(int c, int d, out int sum)      // out int sum : 값을 보내는 것은 가능하지만 값을 가져올 순 없다.
        {
            sum = c + d;
        }

        // call by reference 구현 예제 2) ref
        static void Increment(ref int num)              // ref int num : 값을 넘겨주는 것이 아닌 참조 방식으로 접근(주소 참조)
        {
            num++;
        }


        static void Main(string[] args)
        {
            // 접근지정자 예제 1) public으로 선언되어 변수의 값이 의도하지 않은대로 변경.
            {
                //Console.WriteLine("접근지정자 예제 1) public으로 선언되어 변수의 값이 의도하지 않은대로 변경.");

                //Hero myHero = new Hero();
                //myHero.hp -= 1200;          // public으로 선언된 hp
                //Console.WriteLine("현재 HP: " + myHero.hp);
            }

            // 접근지정자 예제 1-1) private으로 선언. Get, Set을 이용하여 값을 변경 및 조회.
            {
                Console.WriteLine("\n접근지정자 예제 1-1) private으로 선언. Get, Set을 이용하여 값을 변경 및 조회");

                Hero myHero = new Hero();
                if (myHero.GetHp() - 300 > 0)
                {
                    myHero.SetHp(myHero.GetHp() - 300);
                }
                Console.WriteLine("현재 Hp: " + myHero.GetHp());
            }

            // 접근지정자 예제 1-2) property : Get, Set 한번에 선언
            {
                Console.WriteLine("\n접근지정자 예제 1-2) property : Get, Set 한번에 선언");

                Hero myHero = new Hero();
                if (myHero.Hp - 300 > 0)        // property는 변수를 사용하는 것과 비슷하게 사용된다.
                {                               // ex) myHero.Hp
                    myHero.Hp = (myHero.Hp - 300);
                }
                Console.WriteLine("현재 Hp: " + myHero.Hp);
            }

            // 접근지정자 예제 1-3) (최종)변수는 노출하지 않고 기능들을 의도한대로 설계
            {
                Console.WriteLine("\n접근지정자 예제 1-3) 변수는 노출하지 않고 기능들을 의도한대로 설계");

                Hero2 myHero2 = new Hero2();
                myHero2.Damage(120);
                Console.WriteLine("현재 Hp: " + myHero2.GetHp());
            }

            // 클래스 예제 1) Student 클래스 선언 후 값 대입. 
            {
                Console.WriteLine("\n클래스 예제 1) Student 클래스 선언 후 값 대입. ");

                Student std1 = new Student();
                Student std2 = new Student();

                std1.m_schoolName = "서울대학교";
                std1.m_name = "홍길동";
                std2.m_schoolName = "서울대학교";
                std2.m_name = "아무개";
            }

            // 클래스 예제 1-1) static 정적변수 사용 (정적영역을 통해 동일한 대학교 저장)
            {
                Console.WriteLine("\n클래스 예제 1-1) static 정적변수 사용 (정적영역을 통해 동일한 대학교 저장)");

                Student2.m_schoolName = "서울대학교";
                Student2 std1 = new Student2();
                Student2 std2 = new Student2();

                std1.Name = "홍길동";
                std2.Name = "아무개";
                std1.Intro();
                std2.Intro();

                // 정적메소드 추가 1-2) 정적메소드는 클래스 Strudent2로만 접근 가능
                Console.WriteLine("\n정적메소드 추가 1-2) 정적메소드는 클래스 Strudent2로만 접근 가능");
                Student2.IntroMyUniv();
            }

            // call by reference 구현 예제 1) out
            {
                Console.WriteLine("\ncall by reference 구현 예제 1) out");

                int num1 = 10, num2 = 20;
                int sum;
                Add(num1, num2, out sum);       // out sum 의미: 값을 담아서 보내주세요. 

                Console.WriteLine("{0} + {1} = {2}", num1, num2, sum);
            }

            // call by reference 구현 예제 2) ref
            {
                Console.WriteLine("\ncall by reference 구현 예제 2) ref");

                int num = 10;
                Console.WriteLine("현재 값 : {0}", num);
                Increment(ref num);
                Console.WriteLine("중가 후 값 : {0}", num);
            }
        }
    }
}
