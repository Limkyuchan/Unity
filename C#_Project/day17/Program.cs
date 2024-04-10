using System;
using System.Text;
using System.IO;

/*
// 2024/04/10 : C# 상속, 파일 입출력(텍스트 파일, 바이너리 파일), 직렬화/역직렬화

// C# 파일 입출력
// using System.IO; 를 사용.
// 경로를 표시할 때 @를 사용하면 특수문자(\)를 사용하지 않아도 올바른 경로로 인식한다.
// 텍스트를 읽어올 떄 StreamReader로 불러올 수 있다.
// FileStream : 파일 포인터의 역할을 한다.

// C# 파일 스트림 모드
// FileMode.Create       : 파일 생성
// FileMode.Open         : 파일 열기
// FileMode.OpenOrCreate : 파일을 열거나 없을 시 생성
// FileMode.Truncate     : 파일을 비운 후 열기
// FileMode.Append       : 이어쓰기로 파일 열기

// C# 직렬화, 역직렬화
// 직렬화: 객체를 다른 형식으로 변환하여 데이터를 저장하거나 전송하는 프로세스
// => 데이터를 텍스트의 형식으로 변환하여 데이터를 전송.
// 역직렬화: 직렬화의 반대 과정으로, 직렬화된 데이터를 원래 데이터 구조로 복원하는 작업.
// => 텍스트를 다시 클래스 형태로 되돌리는 형태.

*/

namespace day17
{
    #region 상속 예제 1) Polygon 추상 클래스
    public abstract class Polygon
    {
        public abstract int area(int a);
        public abstract int perimeter(int a);
    }

    public class Square : Polygon
    {
        public override int area(int a)
        {
            return a * a;
        }

        public override int perimeter(int a)
        {
            return 4 * a;
        }
    }

    public class Triangle : Polygon
    {
        public override int area(int a)
        {
            return a * a / 2;
        }

        public override int perimeter(int a)
        {
            return 3 * a;
        }
    }
    #endregion

    internal class Program
    {
        #region 파일 입출력 예제 1) 텍스트 파일 읽기
        private static void FileRead(string filename)
        {
            string path = @"c:\test\" + filename;

            // 1. 파일 모드를 지정.
            FileStream file = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(file);
            string readText = sr.ReadToEnd();
            sr.Close();
            file.Close();
            Console.WriteLine(readText);

            // 2. 단순한 텍스트 파일 읽어오는 방법
            //TextReader tr = new StreamReader(path);     
            //string readText = tr.ReadToEnd();
            //tr.Close();
            //Console.WriteLine(readText);
        }
        #endregion

        #region 파일 입출력 예제 2) 텍스트 파일 쓰기
        private static void FileWrite(string filename, string text)
        {
            string path = @"c:\test\" + filename;

            FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(file);
            sw.WriteLine(text);
            //sw.Flush();       // 원래 Flush를 통해 실제 파일로 text를 전달해야 하지만, Close 실행 시 Flush 기능도 함께 작동
            sw.Close();

            Console.WriteLine("저장 완료!");
        }
        #endregion

        #region 파일 입출력 예제 3) 문자열을 바이트로 전환하기
        public static byte[] WriteStringBytes(string str, FileStream file)
        {
            byte[] bytestr = new UTF8Encoding(true).GetBytes(str);
            file.Write(bytestr, 0, bytestr.Length);     // 0번 부터 Length만큼 작성
            return bytestr;
        }

        private static void FileRead2(string filename)
        {
            string path = @"c:\test\" + filename;
            string outstr = "안녕하세요 SBS 게임 아카데미 입니다.";

            byte[] readbyte = new byte[1024];
            FileStream file = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            WriteStringBytes(outstr, file);

            file.Seek(0, SeekOrigin.Begin);
            UTF8Encoding utf8 = new UTF8Encoding(true);
            file.Read(readbyte, 0, readbyte.Length);

            Console.WriteLine(utf8.GetString(readbyte));
            file.Close();
        }
        #endregion

        #region 파일 입출력 예제 4) 바이너리 파일 읽고 쓰기
        private static void FileCreate(string filename)
        {
            string path = @"c:\test\" + filename;

            FileStream file = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryWriter bw = new BinaryWriter(file);
            bw.Write(int.MaxValue);
            bw.Write(double.MaxValue);
            bw.Write("안녕하세요 SBS 게임 아카데미 입니다.");
            file.Seek(0, SeekOrigin.Begin);

            BinaryReader br = new BinaryReader(file);
            Console.WriteLine("File Size: {0} byte", br.BaseStream.Length);
            Console.WriteLine(br.ReadInt32());
            Console.WriteLine(br.ReadDouble());
            Console.WriteLine(br.ReadString());
            file.Close();
        }
        #endregion

        static void Main(string[] args)
        {
            
            // 상속 예제 1) 다각형이 넓이, 둘레 구하기
            {
                Console.WriteLine("상속 예제 1) 다각형의 넓이, 둘레 구하기");

                Polygon square = new Square();
                Polygon triangle = new Triangle();

                Console.WriteLine("area: {0}, perimeter: {1}", square.area(2), square.perimeter(4));
                Console.WriteLine("area: {0}, perimeter: {1}", triangle.area(3), triangle.perimeter(5));
            }

            // 파일 입출력 예제 1) 텍스트 파일 읽기
            {
                Console.WriteLine("\n파일 입출력 예제 1) 텍스트 파일 읽기");

                Console.Write("읽어올 파일 이름을 입력해주세요: ");
                string filename = Console.ReadLine();

                FileRead(filename);
            }

            // 파일 입출력 예제 2) 텍스트 파일 쓰기
            {
                Console.WriteLine("\n파일 입출력 예제 2) 텍스트 파일 쓰기");

                Console.Write("저장할 파일 이름을 입력해주세요: ");
                string filename = Console.ReadLine();

                FileWrite(filename, "안녕하세요 SBS 게임 아카데미 입니다.");
            }

            // 파일 입출력 예제 3) 문자열을 바이트로 전환하기
            {
                Console.WriteLine("\n파일 입출력 예제 3) 문자열을 바이트로 전환하기");

                Console.Write("파일 이름을 입력해주세요: ");
                string filename = Console.ReadLine();
                FileRead2(filename);
            }
            
            // 파일 입출력 예제 4) 바이너리 파일 읽고 쓰기
            {
                Console.WriteLine("\n파일 입출력 예제 4) 바이너리 파일 읽고 쓰기");

                Console.Write("생성할 파일 이름을 입력해주세요: ");
                string filename = Console.ReadLine();
                FileCreate(filename);
            }
        }
    }
}
