using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

/*
// 2024/04/11 : C# 파일 입출력(직렬화/역직렬화, FileInfo, DirectoryInfo), 무명 형식, 람다식

// C# 직렬화, 역직렬화
// 직렬화: Serialize   역직렬화: Deserialize
// 직렬화를 사용하기 위해서는 [Serializable]을 선언해야 한다.

// C# FileInfo
// FileInfo: 파일의 유무를 확인할 수 있는 클래스
// .CreateText(): 해당 파일이 없을 시 텍스트파일 생성
// .Delete(): 파일 삭제
// .MoveTo(): 파일 경로 이동 및 같은 경로 시 이름 바꿔서 저장

// C# DirectoryInfo
// DirectoryInfo: 폴더의 유무를 확인할 수 있는 클래스
// .Create(): 폴더 생성
// .Delete(true) : 폴더안에 파일이 있어도 삭제
// .Delete(false): 폴더 안에 파일이 들어있으면 삭제되지 않음.
// .GetFiles()   : 폴더 안의 원하는 파일을 찾을 수 있음. (예제 3-1 참고)
//  => *.*: 모든 파일형식, *.txt: 모든 txt파일
// .GetDirectories(): 폴더 안의 폴더 가져오기

// C# 무명 형식
// 읽기 전용이고 수정할 수 없다. 초기화도 불가능
// 이름이 없는 객체
// 필요한 정보만을 추려서 간단하게 사용할 수 있다는 장점.

*/

namespace day18
{
    internal class Program
    {
        #region 파일 입출력 예제 1) 직렬화, 역직렬화 (객체 하나)
        [Serializable]
        class Student
        {
            public int num { get; set; }
            public string name { get; set; }
        }

        private static void FileCreate(string filename)
        {
            string path = @"c:\test\" + filename;

            Student student = new Student() { num = 1, name = "민수" };
            FileStream file = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(file, student);        // 직렬화 진행
            file.Close();

            file = new FileStream(path, FileMode.Open, FileAccess.Read);
            var result = (Student)bf.Deserialize(file);     // 역직렬화 진행
            file.Close();
            Console.WriteLine("번호: {0}, 이름: {1}", result.num, result.name);
        }
        #endregion

        #region 파일 입출력 예제 1-1) 직렬화, 역직렬화 (객체들 List)
        private static void FileCreate2(string filename)
        {
            string path = @"c:\test\" + filename;

            List<Student> stdList = new List<Student>() { new Student() { num = 1, name = "민수"},
                                                          new Student() { num = 2, name = "수지"},
                                                          new Student() { num = 3, name = "설현"}  };
            FileStream file = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(file, stdList);        // 직렬화 진행
            file.Close();

            file = new FileStream(path, FileMode.Open, FileAccess.Read);
            var result = (List<Student>)bf.Deserialize(file);     // 역직렬화 진행
            file.Close();

            for (int i = 0; i < result.Count; i++)
            {
                Console.WriteLine("번호: {0}, 이름: {1}", result[i].num, result[i].name);
            }
        }
        #endregion

        #region 파일 입출력 예제 2) 파일 유무 확인
        private static void FileInfo()
        {
            FileInfo file = new FileInfo(@"c:\test\test.txt");

            if (file.Exists)
            {
                Console.WriteLine(file.Name);
                Console.WriteLine(file.FullName);   // 경로
                Console.WriteLine(file.Extension);  // 확장자
                Console.WriteLine(file.Length);     // 바이트 크기
                Console.WriteLine(file.CreationTime);
                Console.WriteLine(file.LastAccessTime);
                Console.WriteLine(file.DirectoryName);
                Console.WriteLine(file.Attributes);
            }
            else
            {
                Console.WriteLine("해당 파일이 존재하지 않습니다.");
            }
        }
        #endregion

        #region 파일 입출력 예제 2-1) 파일 생성
        private static void FileCreate3(string filename)
        {
            string path = @"c:\test\" + filename;
            FileInfo file = new FileInfo(path);

            if (!file.Exists)
            {
                var sw = file.CreateText();     // 텍스트 파일 생성
                sw.Close();
            }
            else
            {
                Console.WriteLine("파일이 이미 있습니다.");
            }
        }
        #endregion

        #region 파일 입출력 예제 2-2) 중복 파일 처리방법
        private static void FileSave(string filename, string text)
        {
            string path = string.Format(@"c:\test\{0}", filename);
            FileInfo file = new FileInfo(path);

            if (file.Exists)
            {
                Console.WriteLine("같은 파일이 존재합니다. 덮어씌우시겠습니까? (yes, no)");
                string result = Console.ReadLine();

                if (result == "yes")
                {
                    StreamWriter writer = file.CreateText();
                    writer.WriteLine(text);
                    writer.Close();
                }
                else
                {
                    int count = 0;
                    FileInfo tmpFile = null;
                    do
                    {
                        path = string.Format(@"c:\test\사본{0}_{1}", count, filename);
                        tmpFile = new FileInfo(path);
                        count++;
                    } while (tmpFile.Exists);
                    StreamWriter writer = tmpFile.CreateText();     // 복사본 파일 생성
                    writer.WriteLine(text);                         // 복사본 파일에 text 내용 작성
                    writer.Close();
                }
            }
            else
            {
                StreamWriter writer = file.CreateText();    // 파일 생성
                writer.WriteLine(text);                     // 파일에 text 내용 작성
                writer.Close();
            }
        }
        #endregion

        #region 파일 입출력 예제 3) 폴더 유무 확인
        static void CreateDirectory()
        {
            string path = @"c:\test\TestDirectory";

            try
            {
                DirectoryInfo dinfo = new DirectoryInfo(path);
                if (!dinfo.Exists)  // 폴더의 유무 확인이 필요!
                {
                    dinfo.Create();
                    Console.WriteLine("폴더 생성 완료!");
                }
                else
                {
                    Console.WriteLine("이미 폴더가 존재합니다.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        #endregion

        #region 파일 입출력 예제 3-1) 폴더에서 파일 가져오기
        static void GetFiles()
        {
            string path = @"c:\test\TestDirectory";
            try
            {
                DirectoryInfo dinfo = new DirectoryInfo(path);

                if (dinfo.Exists)   // 폴더의 유무를 확인!
                {
                    FileInfo[] files = dinfo.GetFiles("*.txt", SearchOption.TopDirectoryOnly);  // .txt 형식의 모든 파일들 가져오기
                    for (int i = 0; i < files.Length; i++)
                    {
                        Console.WriteLine(files[i].ToString());
                    }
                }
                else
                {
                    Console.WriteLine("해당 폴더 내에 파일이 없습니다.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        #endregion

        #region 람다식 예제 1)
        delegate int MyDelegate(int a, int b);
        delegate void PrintDelegate();
        #endregion

        static void Main(string[] args)
        {
            // 파일 입출력 예제 1) 직렬화, 역직렬화를 이용하여 바이너리 파일 읽고 쓰기 (객체 한 개만)
            {
                Console.WriteLine("파일 입출력 예제 1) 직렬화, 역직렬화를 이용하여 바이너리 파일 읽고 쓰기(객체)");

                //Console.Write("생성할 파일 이름을 입력해주세요: ");
                //string filename = Console.ReadLine();
                //FileCreate(filename);
            }

            // 파일 입출력 예제 1-1) 직렬화, 역직렬화를 이용하여 바이너리 파일 읽고 쓰기 (객체들)
            {
                Console.WriteLine("\n파일 입출력 예제 1-1) 직렬화, 역직렬화를 이용하여 바이너리 파일 읽고 쓰기(객체들)");

                //Console.Write("생성할 파일 이름을 입력해주세요: ");
                //string filename = Console.ReadLine();
                //FileCreate2(filename);
            }

            // 파일 입출력 예제 2) 파일의 유무 확인
            {
                Console.WriteLine("\n파일 입출력 예제 2) 파일의 유무 확인");

                //FileInfo();
            }

            // 파일 입출력 예제 2-1) 해당 파일 없을경우 텍스트파일 생성
            {
                Console.WriteLine("\n파일 입출력 예제 2-1) 해당 파일 없을경우 텍스트파일 생성");

                //Console.Write("생성할 파일 이름을 입력해주세요: ");
                //string filename = Console.ReadLine();
                //FileCreate3(filename);
            }

            // 파일 입출력 예제 2-2) 중복 파일 확인
            {
                Console.WriteLine("\n파일 입출력 예제 2-2) 중복 파일 확인");

                //Console.Write("파일 이름을 입력해주세요: ");
                //string filename = Console.ReadLine();
                //FileSave(filename, "Hello World!");
            }

            // 파일 입출력 예제 3) 폴더의 유무 확인
            {
                Console.WriteLine("\n파일 입출력 예제 3) 폴더의 유무 확인");

                //CreateDirectory();
            }

            // 파일 입출력 예제 3-1) 폴더 내에서 파일들 가져오기
            {
                Console.WriteLine("\n파일 입출력 예제 3-1) 폴더 내에서 파일들 가져오기");

                //GetFiles();
            }

            // 람다식 예제 1)
            {
                Console.WriteLine("\n람다식 예제 1)");

                MyDelegate Add = (a, b) => a + b;
                MyDelegate Multi = (a, b) => a * b;
                PrintDelegate Message = () => Console.WriteLine("안녕하세요 람다식을 배워볼까요?");

                Console.WriteLine(Add(100, 200));
                Console.WriteLine(Multi(20, 50));
                Message();
            }
        }
    }
}
