using System;

/*
// 2024/03/26 : C# indexer(배열의 Property), 배열 선언 방법, 배열 GetLength()

// C# indexer(배열의 Property)
// 배열은 필드로, private 사용해 노출하지 않도록 한다.
// 배열의 property에서 length를 사용해 배열의 크기를 알 수 있다.
// indexer : ☆배열의 Getter, Setter 역할이고, 메소드 이다.
// => public float this[int index]          // 인스턴스된 자기 자신 [인덱스 번호]
//    {
//      get { return temps[index]; }        // 해당 인덱스의 값을 조회
//      set { temps[index] = value;}        // 해당 인덱스의 값을 변경
//    }
// indexer의 Getter, Setter는 메소드에 속하기 때문에 기능을 커스텀해서 다른 용도로 사용 가능. (예제 2 get 참고)

// C# 배열
// 배열은 Array 클래스의 객체. 하지만 배열의 클래스 선언은 []로 대체
// Heap 메모리를 할당해서 사용해야 한다.
// 배열 선언 방법
//  int[] arrary1 = new int[5];
//  int[] arrary2 = new int[] { 1, 2, 3, 4, 5 };
//  int[,] multiArray1 = new int[2, 3];      // 2차원 배열
//  int[][] jaggedArray = new int[2][];      // 가변 배열 : 행마다 열의 개수가 다를 수도 있다.
//  => 가변 배열이기 때문에 행만 먼저 선언하고, 열은 각 행마다 따로 인스턴스 진행한다.
//     선언할 때 열을 작성하면 모든 열의 개수가 동일하기 때문에 작성하지 않고, 행만 먼저 작성해야 한다. 
// 배열 GetLength()
// i % array.GetLength(1) == 0  =>  3으로 나누었을 때 0인 경우
// GetLength() 소괄호 안에는 인덱스 번호가 들어간다.
// (0): 행의 번호 2, (1): 열의 번호 3

*/
namespace day07
{
    // indexer(배열의 property) 예제 1)
    class TempRecord
    {
        private float[] temps = new float[10] { 56.2F, 56.7F, 56.5F, 56.9F, 58.8F, 61.3F, 65.9F, 62.1F, 59.2F, 57.5F };

        public int Length { get { return temps.Length; } }
        public float this[int index]    // indexer
        {
            get
            {
                return temps[index];
            }
            set
            {
                temps[index] = value;
            }
        }
    }

    // indexer(배열의 property) 예제 2)
    class DayCollection
    {
        string[] days = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

        private int GetDay(string testDay)
        {
            for (int i = 0; i < days.Length - 1; i++)
            {
                if (days[i] == testDay)
                {
                    return i;
                }
            }
            throw new ArgumentOutOfRangeException(testDay, "testDay must be in the from \"Sun\", \"Mon\", etc..");    // 오류를 강제로 발생시킴.
        }

        public int this[string day]
        {
            get
            {                           // private인 GetDay를 호출하여 그 값을 return.
                return GetDay(day);     // 값을 반환, 변경뿐만 아니라 메소드에 속하기 때문에 기능을 커스텀해서 다른 용도로 사용 가능.
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {

            // indexer(배열의 property) 예제 1)
            {
                Console.WriteLine("indexer(배열의 property) 예제 1)");

                TempRecord tempRecord = new TempRecord();

                tempRecord[3] = 111.1F;     // 인스턴스된 자기자신을 배열처럼 접근
                tempRecord[5] = 222.2F;     // 인스턴스된 자기 자신이기 때문에 tempRecord로 접근 가능.
                for (int i = 0; i < tempRecord.Length; i++)
                {
                    Console.WriteLine("tempRecord[{0}] = {1}", i, tempRecord[i]);
                }
            }

            // indexer(배열의 property) 예제 2)
            {
                Console.WriteLine("\nindexer(배열의 property) 예제 2)");

                DayCollection week = new DayCollection();

                Console.WriteLine("week[Mon]: " + week["Mon"]);
                Console.WriteLine("week[Fri]: " + week["Fri"]);
                //Console.WriteLine(week["Have a Nice Day"]);
            }

            // 배열 예제 1) 배열 선언 방법
            {
                Console.WriteLine("\n배열 예제 1) 배열 선언 방법");

                int[] array1 = new int[5];                      // 연속된 5개의 메모리만 할당.
                int[] array2 = new int[] { 1, 2, 3, 4, 5 };     // 선언과 동시에 초기화 진행.     
                int[] array3 = { 1, 2, 3, 4, 5, 6 };            // 값을 바로 할당하는 경우 new 생략 가능. (추천 X)
                int[,] multiDimensionalArray1 = new int[2, 3];
                int[,] multiDimensionalArray2 = { { 1, 2, 3 }, { 4, 5, 6 } };
                int[][] jaggedArray = new int[2][];
                jaggedArray[0] = new int[4] { 1, 2, 3, 4 };
                jaggedArray[1] = new int[3] { 5, 6, 7 };
            }

            // 배열 예제 2) 2차원 배열 출력하기 foreach, for문
            {
                Console.WriteLine("\n배열 예제 2) 2차원 배열 출력하기 foreach, for문");

                int i = 0;
                int[,] array = new int[2, 3]
                {
                    { 1, 2, 3 },
                    { 4, 5, 6 }
                };

                foreach (int num in array)
                {
                    Console.Write(num + " ");
                    i++;

                    if (i % array.GetLength(1) == 0)     // i % array.GetLength(1) == 0  =>  3으로 나누었을 때 0인 경우
                        Console.WriteLine();             // GetLength() 소괄호 안에는 인덱스 번호가 들어간다. (0): 행의 번호 2, (1): 열의 번호 3
                }

                for (int j = 0; j < array.GetLength(0); j++)
                {
                    for (int k = 0; k < array.GetLength(1); k++)
                    {
                        Console.Write(array[j, k] + " ");
                    }
                    Console.WriteLine();
                }
            }

            // 배열 예제 3) 가변 배열, 2중 foreach, for문
            {
                Console.WriteLine("\n배열 예제 3) 가변 배열, 2중 foreach, for문");

                string[][] jagged_str = new string[3][]         // 가변배열: 인스턴스 할 때 행을 먼저 초기화
                {
                    new string[3] { "SBS", "Game", "Academy" },
                    new string[2] { "강남역", "12번 출구로" },
                    new string[]  { "나오시면", "금방", "찾으실", "수", "있습니다.", "!!" },
                };

                // 2중 foreach를 통해 행과 열을 나누어서 출력
                foreach (string[] jagged in jagged_str)         // 각 행(배열)
                {
                    foreach (string str_element in jagged)      // 문자열
                    {
                        Console.Write(str_element + " ");
                    }
                    Console.WriteLine();
                }

                for (int i = 0; i < jagged_str.GetLength(0); i++)
                {
                    for (int j = 0; j < jagged_str[i].Length; j++)      // 가변배열이라 각 행 별 Length로 접근
                    {
                        Console.Write(jagged_str[i][j] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
