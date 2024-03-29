using System;

/*
// 2024/03/27 : C# 배열, 배열의 기능, 일반화(함수 일반화, 클래스 일반화)

// C# 배열
// 클래스를 배열로 선언할 경우, 객체의 생성과 각 객체별 인스턴스 생성 시 주의해야 함
// => 첫 new는 객체를 생성한 것이지 아직 인스턴스가 된 것이 아니다. 
//    각 객체별 new 통해 인스턴스를 생성해야 한다. (배열 예제 1) 참고)

// C# 배열의 기능
// Array : 정적 메소드. 선언과 동시에 메모리가 잡혀서 바로 Array.Copy 사용 가능.
// Array.Copy(orgArr, 0, copyArr, 2, 3) : orgArr 0번째부터 3개의 값을 copyArr의 2번째부터 3개의 값에 복사해서 넣겠다.(덮어쓴다)
// Clone() : 원본의 값을 복제한다. 해당 객체의 값을 Clone하기 위해서는 정적 메소드는 사용 불가능.(객체마다 사용)
// => 주의점: Clone()을 사용하여 복제한 값을 수정한다고 해서 원본 데이터는 수정되지 않는다. 
//           하지만 Clone()이 아닌 대입을 통해 복사해서 사용할 경우 원본 데이터도 수정됨으로 주의해야 한다.

// C# 일반화
// 일반화 함수 선언 : <T>
// 어떤 타입(Type)이 들어오는지 모를 때 사용.
// 타입을 지정받는 일반화 함수를 사용할 경우 함수의 재사용성이 높아진다.
// 일반화 제약조건
// where T : struct - 들어오는 타입을 구조체로 제한하겠다.
// where T : class  - 들어오는 타입을 클래스로 제한하겠다.
// where T : new()  - 들어오는 타입의 생성자는 매개변수가 없어야 한다(기본 생성자만)로 제한.
//
// 선언방법: void print<T> (T value) where T : struct     
//          {
//             Console.WriteLine(value);
//          }
// 출력방법: print<int>(10);
//          print<float>(3.14f);

// C# 대리자
// 대리자: 함수 포인터 역할.

*/

namespace day08
{
    // 배열 예제 1)
    class PocketMon
    {
        private string type;
        private string name;

        public PocketMon(string type, string name)
        {
            this.type = type;
            this.name = name;
        }

        public void PrintPocketMon()
        {
            Console.WriteLine("종류: {0} / 이름: {1}", type, name);
        }
    }

    // 일반화 예제 2)
    class List<T>
    {
        private T[] arr;                        // ~ 형 배열 생성
        public List() { arr = new T[2]; }       // ~ 타입의 배열
        public int Length { get { return arr.Length; } }
        public void InitArray(int index, T value) { arr[index] = value; }   // Setter 
        public T GetValue(int index) { return arr[index]; }                 // Getter, 반환값 ~ 타입
    }


    internal class Program
    {
        // 배열 예제 2)
        static void PrintArray(string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + "{0}", i < arr.Length - 1 ? " " : "");   // 배열의 마지막이 아니면 " "을 찍고, 마지막이면 ""을 찍는다.
            }
            Console.WriteLine();
        }

        // 배열 예제 3)
        static void Print2DArray(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write("arr[{0},{1}] = {2}  ", i, j, arr[i, j]);
                }
                Console.WriteLine();
            }
        }

        // 일반화 예제 1, 2, 3)
        static void Print<T>(T value)
        {
            Console.WriteLine(value);
        }

        // 일반화 예제 3)
        static void CopyArray<T>(T[] src, T[] dest)
        {
            src.CopyTo(dest, 0);         //src 값을 0번째 부터 dest로 복사한다.
        }


        static void Main(string[] args)
        {
            // 배열 예제 1) 객체(배열), 객체 별 인스턴스 생성 foreach, for문
            {
                Console.WriteLine("배열 예제 1) 객체(배열), 객체 별 인스턴스 생성 foreach, for문");

                PocketMon[] pomon = new PocketMon[4];           // 객체(배열) 4개 생성
                pomon[0] = new PocketMon("노멀", "잠만보");      // 각 객체별 인스턴스 생성
                pomon[1] = new PocketMon("불꽃", "파이리");
                pomon[2] = new PocketMon("전기", "피카츄");
                pomon[3] = new PocketMon("물", "꼬부기");

                foreach (PocketMon po in pomon)
                {
                    po.PrintPocketMon();
                }
                Console.WriteLine();
                for (int i = 0; i < pomon.Length; i++)
                {
                    pomon[i].PrintPocketMon();
                }
            }

            // 배열 예제 2) 배열을 매개변수로 사용하는 경우
            {
                Console.WriteLine("\n배열 예제 2) 배열을 매개변수로 사용하는 경우");

                string[] weekDays = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
                PrintArray(weekDays);
            }

            // 배열 예제 3) 2차원 배열을 매개변수로 사용하는 경우
            {
                Console.WriteLine("\n배열 예제 3) 2차원 배열을 매개변수로 사용하는 경우");

                int[,] arr = new int[,] { { 1, 2 }, { 3, 4, }, { 5, 6 }, { 7, 8 } };

                Print2DArray(arr);
                Console.WriteLine();
                Print2DArray(new int[,] { { 1, 2 }, { 3, 4, }, { 5, 6 }, { 7, 8 } });   // 함수 내 바로 작성 가능
            }

            // 배열 기능 예제 1) Array.Copy
            {
                Console.WriteLine("\n배열 기능 예제 1) Array.Copy");

                int[] orgArr = new int[] { -1, -2, -3, -5, -7, -9 };
                int[] copyArr = { 2, 4, 6, 8, 10 };

                Array.Copy(orgArr, 0, copyArr, 2, 3);
                for (int i = 0; i < copyArr.Length; i++)
                {
                    Console.WriteLine("copyArr[{0}] = {1}", i, copyArr[i]);
                }
            }

            // 배열 기능 예제 2) Clone(복제)
            {
                Console.WriteLine("\n배열 기능 예제 2) Clone(복제)");

                int[] orgArr = new int[] { 10, 20, 30, 40 };
                int[] copyArr = (int[])orgArr.Clone();      // 배열 타입으로 형변환

                for (int i = 0; i < copyArr.Length; i++)
                {
                    Console.WriteLine("copyArr[{0}] = {1}", i, copyArr[i]);
                }
            }

            // 일반화 예제 1) 함수 일반화 선언 및 출력
            {
                Console.WriteLine("\n일반화 예제 1) 함수 일반화 선언 및 출력");

                string name = "홍길동";
                int age = 37;
                float height = 178.5f;
                double weight = 74.5d;

                Print<string>(name);        // C#에서 투명한 값들은 없어도 무방함을 의미 
                Print<int>(age);            // ex) Print <>안의 string, int ...
                Print(height);
                Print(weight);
            }

            // 일반화 예제 2) 클래스 일반화 선언 및 출력
            {
                Console.WriteLine("\n일반화 예제 2) 클래스 일반화 선언 및 출력");

                List<int> intList = new List<int>();
                List<float> floatList = new List<float>();
                List<string> stringList = new List<string>();

                intList.InitArray(0, 58);
                intList.InitArray(1, 30);
                floatList.InitArray(0, 75.2f);
                floatList.InitArray(1, 65.5f);
                stringList.InitArray(0, "아모개");
                stringList.InitArray(1, "홍길동");

                for (int i = 0; i < intList.Length; i++)
                {
                    Print("이름: " + stringList.GetValue(i));
                    Print("나이: " + intList.GetValue(i));
                    Print("몸무게: " + floatList.GetValue(i));
                }
            }

            // 일반화 예제 3) 함수 일반화 선언 및 출력
            {
                Console.WriteLine("\n일반화 예제 3) 함수 일반화 선언 및 출력");

                int[] srcInt = { 1, 2, 3, 4, 5 };
                int[] tagInt = new int[srcInt.Length];
                string[] srcStr = { "hello", "sbs", "game", "academy" };
                string[] tagStr = new string[srcStr.Length];

                CopyArray<int>(srcInt, tagInt);
                CopyArray<string>(srcStr, tagStr);

                for (int i = 0; i < tagInt.Length; i++)
                {
                    Print(tagInt[i]);
                }
                for (int i = 0; i < tagStr.Length; i++)
                {
                    Print(tagStr[i]);
                }
            }
        }
    }
}
