using System;
using System.Collections;
using System.Collections.Generic;

/*
// 2024/04/09 : C# 상속(인터페이스, ICompare(정렬), is 연산자, as 연산자)

// C# 인터페이스
// 메소드의 이름이 겹칠 경우. 즉, 동일한 기능을 가진 두 개의 인터페이스를 상속 받을 경우  
// ex) 동일한 이름의 Off  (예제 1. 참고)
// => 인터페이스 이름을 붙여 구분하여 작성, 접근지정자(public) 없이 작성. 
//    (객체를 통한 접근 X, 인터페이스를 통해서는 접근 가능) 
//
// 인터페이스는 인스턴스가 불가능하기 때문에, 우회적으로 인터페이스를 클래스처럼 사용할 수 있다. (예제 2. 참고)

// C# is 연산자, 
// 형 변환 시 is 연산자를 통해 확인이 필요하다.
// is 연산자를 통해 형 변환(캐스팅)이 가능한지의 여부를 확인할 수 있다.
// 형 변환(캐스팅)이 가능하면 True, 불가능하면 False를 리턴한다.

// C# as 연산자
// 형 변환 방법 두 가지
// - as 연산자
// - 명시적 형 변환
// 형 변환(캐스팅)이 성공하면 그 결과를, 불가능하면 NULL 값을 리턴한다.
// 단, Reference Type 간의 캐스팅만 가능하다. (Value Type 불가능)

*/

namespace day16
{
    #region 인터페이스 예제 1) Car 인터페이스
    interface CarControl
    {
        void Gear(int i);
        void Off();
    }

    interface AudioControl
    {
        void Volume(int i);
        void Off();
    }

    class Car : CarControl, AudioControl
    {
        public void Gear(int i)
        {
            Console.WriteLine("현재 기어는 {0} 입니다.", i);
        }

        public void Volume(int i)
        {
            Console.WriteLine("현재 볼륨은 {0} 입니다.", i);
        }

        //public void Off() { Console.WriteLine("시동을 껐습니다."); }     // 사용 불가

        void CarControl.Off()
        {
            Console.WriteLine("자동차 시동을 끕니다.");
        }

        void AudioControl.Off()
        {
            Console.WriteLine("오디오 전원을 끕니다.");
        }
    }
    #endregion

    #region 인터페이스 예제 2) Point 인터페이스
    interface IPoint
    {
        int x { get; set; }
        int y { get; set; }
    }

    class Point : IPoint
    {
        private int _x;
        private int _y;

        public Point(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public int x { get { return _x; } set { _x = value; } }
        public int y { get { return _y; } set { _y = value; } }
    }
    #endregion

    #region 인터페이스 예제 3) ICompare 인터페이스 (학생 정렬 예제)
    public class Student
    {
        public int m_num { get; set; }
        public string m_name { get; set; }
    }

    public class StudentList
    {
        public List<Student> m_list = new List<Student>();

        Ascending m_sortAscending = new Ascending();
        Descending m_sortDescending = new Descending();

        public int Count { get { return m_list.Count; } }

        public void Add(Student student)
        {
            m_list.Add(student);
        }

        public void Clear()
        {
            m_list.Clear();
        }

        public void SortAscening()
        {
            m_list.Sort(m_sortAscending);
        }

        public void SortDescending()
        {
            m_list.Sort(m_sortDescending);
        }

        public class Ascending : IComparer, IComparer<Student>
        {
            public int Compare(Student x, Student y)
            {
                return x.m_num.CompareTo(y.m_num);
            }

            public int Compare(object x, object y)
            {
                return Compare((Student)x, (Student)y);
            }
        }

        public class Descending : IComparer, IComparer<Student>
        {
            public int Compare(Student x, Student y)
            {
                return y.m_num.CompareTo(x.m_num);
            }

            public int Compare(Object x, Object y)
            {
                return Compare((Student)x, (Student)y);
            }
        }
    }
    #endregion

    #region 인터페이스 예제 4) BaseC 인터페이스 (형 변환 예제)
    class BaseC
    {
        public virtual void PrintMethod()
        {
            Console.WriteLine("부모 클래스 Method");
        }
    }

    class DerivedC : BaseC
    {
        public override void PrintMethod()
        {
            Console.WriteLine("부모 Method 재정의!!");
        }

        public void PrintMethod2()
        {
            Console.WriteLine("자식 클래스 Method");
        }
    }
    #endregion

    internal class Program
    {
        // 인터페이스 예제 2)
        static void PrintPoint(IPoint p)
        {
            Console.WriteLine("x = {0}, y = {1}", p.x, p.y);
        }

        // 인터페이스 예제 4)
        void CastingTest(object obj)
        {
            BaseC baseC;

            // is 연산자 (형변환 하기 전 확인 필수)
            bool already = obj is BaseC;
            if (already)
            {
                // 형 변환 방법 2가지 (as 연산자, 명시적 형 변환)
                // 1. as 연산자
                baseC = obj as BaseC;
                if (baseC != null)  baseC.PrintMethod();

                // 2. 명시적 형변환
                BaseC baseC2 = (BaseC)obj;
                baseC2.PrintMethod();
            }
        }

        static void Main(string[] args)
        {
            // 인터페이스 예제 1) Car 인터페이스
            {
                Console.WriteLine("인터페이스 예제 1) 동일한 기능(Off) 두 개가 중복 될 경우");

                Car mycar = new Car();
                mycar.Gear(3);
                mycar.Volume(5);
                //mycar.Off();  // 사용 불가: CarControl, AudioControl 모두 포함한 기능으로 누구의 Off인지 알 수 없음.

                CarControl carCon = mycar;      // 접근지정자(public) 없이 작성하여 객체를 통한 접근 X.
                AudioControl audioCon = mycar;  // 인터페이스를 통해서 접근이 가능하다.
                carCon.Off();
                audioCon.Off();
            }

            // 인터페이스 예제 2) Point 인터페이스
            {
                Console.WriteLine("\n인터페이스 예제 2) 인터페이스를 클래스와 동일하게 사용 (우회적으로..)");

                Point point = new Point(2, 3);
                Console.Write("현재 좌표는 : ");
                PrintPoint(point);
            }

            // 인터페이스 예제 3) ICompare 인터페이스 (학생 정렬 예제)
            {
                Console.WriteLine("\n인터페이스 예제 3) ICompare를 활용한 학생 정렬 함수");

                List<Student> tmpList = new List<Student>() { new Student() { m_num = 1, m_name = "민수" },
                                                              new Student() { m_num = 2, m_name = "수지" },
                                                              new Student() { m_num = 3, m_name = "설현" },};

                StudentList stdList = new StudentList();
                for (int i = 0; i < tmpList.Count; i++)
                {
                    stdList.Add(tmpList[i]);
                }

                Console.WriteLine("내림차순 정렬 결과");
                stdList.SortDescending();
                for (int i = 0; i < stdList.Count; i++)
                {
                    Console.WriteLine("번호 : {0}, 이름: {1}", stdList.m_list[i].m_num, stdList.m_list[i].m_name);
                }
                Console.WriteLine("-----------------");
                Console.WriteLine("오름차순 정렬 결과");
                stdList.SortAscening();
                for (int i = 0; i < stdList.Count; i++)
                {
                    Console.WriteLine("번호 : {0}, 이름 : {1}", stdList.m_list[i].m_num, stdList.m_list[i].m_name);
                }
            }

            // 인터페이스 예제 4) BaseC 인터페이스 (형 변환 예제)
            {
                Console.WriteLine("\n인터페이스 예제 4) is 연산자, as 연산자 ");

                DerivedC derivedC = new DerivedC();
                new Program().CastingTest(derivedC);

                derivedC.PrintMethod();
                derivedC.PrintMethod2();
            }
        }
    }
}
