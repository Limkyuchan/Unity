using System;

/*
// 2024/03/25 : C# 값 바꾸기(ref), foreach, 코드 관리(region/endregion), 온도변환 프로그램

// C# foreach 
// 기본적으로 for 문이 foreach 문보다 더 빠르긴 하다.
// 주로 배열과 같이 값이 연속적으로 있는 경우 foreach로 하나씩 접근해서 값을 가져올 수 있다.
// foreach (char c in str)
// => 문자열(str)에서 문자(c) 하나씩 꺼내어 출력한다.
// 문자열은 내부에 배열을 가지고 잇다.

// C# 코드 관리
// 변수명, 주석 관련
// 모든 클래스들은 영역을 나눠놓고 작업을 진행하면 좋다.
// 코드를 영역별로 분할해서 관리 (#region ~ #endregion)
// 일반적인 순서
//  Contants and Fields
//  Public Properties
//  Public Methods and Operators
//  Methods

*/

namespace day06
{
    // 온도 변환 프로그램
    class ChangeTemperature
    {
        public ChangeTemperature() { } 
        
        public float CtoF(float c)
        {
            return (c * 9.0f / 5.0f) + 32.0f;
        }

        public float FtoC(float f)
        {
            return (f - 32.0f) * 5.0f / 9.0f;
        }
    }

    internal class Program
    {
        // 값 바꾸기 예제 1) ref
        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        // foreach 예제 4) 클래스의 배열
        class Point
        {
            private int x, y;
            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
            public void Print()
            {
                Console.WriteLine("({0},{1})", x, y);
            }
        }

        static void Main(string[] args)
        {
            
            // 값 바꾸기 예제 1) ref
            {
                Console.WriteLine("값 바꾸기 예제 1) ref");

                int num1 = 10, num2 = 20;
                Console.WriteLine("바꾸기 전 값: {0} {1}", num1, num2);
                Swap(ref num1, ref num2);
                Console.WriteLine("바꾼 후 값: {0} {1}", num1, num2);
            }

            // foreach 예제 1) foreach, foreach를 for문으로 변환
            {
                Console.WriteLine("\nforeach 예제 1) foreach, foreach를 for문으로 변환");

                string str = "Hello World";
                foreach (char c in str)
                {
                    Console.Write(c);
                }
                Console.WriteLine();

                for (int i = 0; i < str.Length; i++)
                {
                    Console.Write(str[i]);
                }
                Console.WriteLine();
            }

            // foreach 예제 2) foreach, foreach를 for문으로 변환
            {
                Console.WriteLine("\nforeach 예제 2) foreach, foreach를 for문으로 변환");

                int i = 0;
                int[] arr = new int[5] { 10, 20, 30, 40, 50 };

                foreach (int item in arr)
                {
                    Console.WriteLine("arr[{0}] : {1}", i, item);
                    i++;
                }
                Console.WriteLine();

                for (int j = 0; j < arr.Length; j++)
                {
                    Console.WriteLine("arr[{0}] : {1}", j, arr[j]);
                }
            }

            // foreach 예제 3) foreach, foreach를 for문으로 변환
            {
                Console.WriteLine("\nforeach 예제 3) foreach, foreach를 for문으로 변환");

                string[] arr = new string[] { "hello", "sbs", "game", "Academy" };

                foreach (string item in arr)
                {
                    Console.Write("{0} ", item);
                }
                Console.WriteLine();

                for (int i = 0; i < arr.Length; i++)
                {
                    Console.Write("{0} ", arr[i]);
                }
                Console.WriteLine();
            }

            // foreach 예제 4) 클래스의 배열
            {
                Console.WriteLine("\nforeach 예제 4) 클래스의 배열");

                Point[] arr = new Point[3] { new Point(1, 1), new Point(2, 2), new Point(3, 3) };
                //   객체 배열 3개 생성    ->   3개의 객체에 따른 생성자(인스턴스) 3번 생성 진행

                foreach (Point item in arr)
                {
                    item.Print();
                }
                Console.WriteLine();

                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i].Print();
                }
            }


            // 온도 변환 프로그램
            {
                Console.WriteLine("\n온도 변환 프로그램");

                int choice = 0;
                float temperature = 0, result = 0;

                while (true)
                {
                    Console.WriteLine("\n온도 변환 프로그램입니다.");
                    Console.WriteLine("[1] 섭씨 to 화씨 [2] 화씨 to 섭씨 [0] 프로그램 종료");
                    choice = int.Parse(Console.ReadLine());

                    ChangeTemperature changeTemp = new ChangeTemperature();

                    if (choice == 0)
                    {
                        Console.WriteLine("온도 변환 프로그램을 종료합니다.");
                        break;
                    }
                    else if (choice == 1)
                    {
                        Console.WriteLine("몇도의 섭씨온도를 화씨로 변환하시겠습니까?");
                        temperature = float.Parse(Console.ReadLine());
                        result = changeTemp.CtoF(temperature);
                        Console.WriteLine("섭씨온도 {0:F2}도는 화씨온도 {1:F2}도 입니다.", temperature, result);    // 0:F2 실수 두째자리까지
                    }
                    else if (choice == 2)
                    {
                        Console.WriteLine("몇도의 화씨온도를 섭씨로 변환하시겠습니까?");
                        temperature = float.Parse(Console.ReadLine());
                        result = changeTemp.FtoC(temperature);
                        Console.WriteLine("화씨온도 {0:F2}도는 섭씨온도 {1:F2}도 입니다.", temperature, result);
                    }
                    else
                    {
                        Console.WriteLine("메뉴를 다시 선택해주세요.");
                    }
                }
            }
        }
    }
}
