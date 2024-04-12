using System;
using System.IO;
using System.Linq;

/*
// 2024/04/12 : C# 람다식(Where, 대리자 Func/Action), 싱글턴

// C# Where와 람다식
// Where는 using System.Linq;를 사용해아 한다. (예제 2)
// Where의 매개변수에는 함수가 필요하기 때문에, 함수를 따로 생성하지 않고 람다식으로 함수를 대신하여 사용할 수 있다.

// C# 대리자 Func
// 반환값이 있는 경우에만 Func을 사용할 수 있다. (무조건 반환값이 있어야 한다.)
// Func은 대리자로, delegate를 선언하지 않고 Func을 통해 바로 선언할 수 있다.
// 반환값은 무조건 작성하고, 매개변수가 있는 경우 앞쪽에 사용한다. 
// ex) Func<매개변수, 반환값>

// C# 대리자 Action
// 반환값이 없는 경우에는 Action을 사용한다. (모두 void형)
// ex) Action<매개변수>

// C# 싱글턴 (디자인패턴)
// 싱글턴의 조건 2가지
// - 객체가 하나만 존재하는 경우 (물리적으로도 객체가 하나만 존재하도록)
// - 원하면 언제 어디서든 객체에 접근할 수 있다. (접근이 용이하게)
//
// 싱글턴의 특징
// 자신의 객체를 자신의 클래스 내부에 선언 (내부에서 객체 생성)
// 생성자를 private으로 생성한다. (외부에서 인스턴스 절대 불가능)
// 내부에서 Property 만들어서 딱 한번 객체를 생성할 수 있도록.
// => 클래스명.Instance (단 하나만 존재하는 객체에 접근해서 포함된 기능을 사용가능)

*/

namespace day19
{
    #region 싱글턴 예제 1)
    class Singleton
    {
        private static Singleton _instance = null;
        private Singleton() { }

        public static Singleton Instance
        {
            get 
            { 
                if (_instance == null)
                {
                    _instance = new Singleton();
                }
                return _instance;
            }
        }

        public void DrawMessage()
        {
            Console.WriteLine("안녕하세요. SBS 게임 아카데미 입니다.");
        }
    }
    #endregion

    internal class Program
    {
        #region 람다식 예제 1) Compare
        delegate void MyDelegate(int a, int b);
        #endregion

        #region 람다식 예제 2) 폴더 입출력, Where
        static void GetFiles()
        {
            string path = @"c:\test\TestDirectory";

            try
            {
                DirectoryInfo dinfo = new DirectoryInfo(path);

                if (dinfo.Exists)
                {
                    FileInfo[] files = dinfo.GetFiles("*.*", SearchOption.TopDirectoryOnly);
                    string[] filestr = new string[files.Length];
                    for (int i = 0; i < files.Length; i++)
                    {
                        filestr[i] = files[i].ToString();
                    }

                    string[] result = filestr.Where((str) =>        // Where의 매개변수에 함수가 필요하기 떄문에, 함수를 따로 생성하지 않고
                    {                   // 람다식으로 함수를 대신하여 사용
                        string[] exts = new[] { ".bmp", ".txt", ".gif" };
                        return exts.Contains(Path.GetExtension(str), StringComparer.OrdinalIgnoreCase);
                    }).ToArray();
                    for (int i = 0; i < result.Length; i++)
                    {
                        Console.WriteLine(result[i]);
                    }
                }
                else
                {
                    Console.WriteLine("해당 폴더가 없습니다.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        #endregion

        static void Main(string[] args)
        {
            // 람다식 예제 1) Compare
            {
                Console.WriteLine("람다식 예제 1) Compare");

                MyDelegate Compare = (a, b) =>
                {
                    if (a > b)
                    {
                        Console.WriteLine("{0} > {1}", a, b);
                    }
                    else if (a < b)
                    {
                        Console.WriteLine("{0} < {1}", a, b);
                    }
                    else
                    {
                        Console.WriteLine("{0} == {1}", a, b);
                    }
                };

                Compare(30, 60);
                Compare(60, 30);
                Compare(100, 100);
            }

            // 람다식 예제 2) 파일 입출력 (원하는 확장자만 출력하기 : Where)
            {
                Console.WriteLine("\n람다식 예제 2) 파일 입출력 (원하는 확장자만 출력하기 : Where)");

                GetFiles();
            }

            // 람다식 예제 3) 람다식 + Func 예제
            {
                Console.WriteLine("\n람다식 예제 3) 람다식 + Func 예제");

                Func<string> Print = () => "안녕하세요. SBS 게임 아카데미 입니다.";
                Func<int, int, int> Add = (a, b) => a + b;
                Func<int, int, int> Mul = (a, b) => a * b;
                Func<double, double> FtoC = (F) => (F - 32) * 5 / 9;
                Func<double, double> CtoF = (C) => (C * 9 / 5) + 32;

                Console.WriteLine("Func Print 값 : {0}", Print());
                Console.WriteLine("Func Add 값   : {0}", Add(10, 20));
                Console.WriteLine("Func Mul 값   : {0}", Mul(10, 20));
                Console.WriteLine("Func FtoC 값  : {0:F3}", FtoC(132.2d));
                Console.WriteLine("Func CtoF 값  : {0}", CtoF(36.5d));
            }

            // 람다식 예제 4) 람다식 + Action 예제
            {
                Console.WriteLine("\n람다식 예제 4) 람다식 + Action 예제");

                Action<string> Upper = (str) => Console.WriteLine(str.ToUpper());
                Action<int, int> Sum = (a, b) => Console.WriteLine("{0} + {1} = {2}", a, b, (a + b));

                Upper("Action Example");
                Sum(20, 30);
            }

            // 싱글턴 디자인 예제 1)
            {
                Console.WriteLine("\n싱글턴 디자인 예제 1)");

                // 별도의 객체 생성 없이 Singleton을 통해 바로 호출 가능.
                Singleton.Instance.DrawMessage();
            }
        }
    }
}

