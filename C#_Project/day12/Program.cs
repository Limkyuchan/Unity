using System;
using System.Collections.Generic;

/*
// 2024/04/02 : C# 제너릭 컬렉션(Dictionary, SortedList, LinkedList, List, Queue, Stack) 

// C# 제너릭 컬렉션
// 1) Dictionary<>
// Hashtable의 일반화 선언 버전
// 선언방법: Dictionary<키 값 타입, 데이터 타입> dic = new Dictionary<키 값 타입, 데이터 타입>();
//          dic.Add("키 값", "데이터");
// KeyValuePair: Key와 Value를 모두 한 쌍으로 포함하고 있다.(객체가 들어있다.)
//
// 2) SortedList<>
// 키 값으로 정렬이 이루어진다.
// Dictionary와 사용 방법은 똑같지만, 키 값을 기준으로 정렬된다.
// .Count: 실제 요소의 갯수
// .Remove(키 값): 키 값으로 데이터 삭제
// .Capacity: 실제로 할당되어 있는 메모리의 크기 => 요소의 개수가 증가함에 따라 메모리 크기도 4의 배수만큼 증가. 하지만 요소가 삭제되더라도 메모리 크기는 동일.
// .TrimExcess(): 메모리의 공백을 제거          => 실행 조건: 실제 요소 수가 현재 용량의 90% 미만인 경우
//                                               
// 3) LinkedList<>
// 이중 연결 리스트: 포인터가 2개 (앞의 노드를 가르키는 Previous, 뒤의 노드를 가르키는 Next)
// 값을 앞, 뒤로 모두 추가가 가능하다.
// 맨 앞의 노드는 First(Head), 맨 뒤의 노드는 Last(Tail)로 부른다.
// .AddFirst(): 맨 앞의 노드에 추가
// .AddLast(): 맨 뒤의 노드에 추가
// .AddAfter(.Find("특정 값"), 값): 특정 값을 찾고 그 뒤에 값을 추가
// .AddBefore(.Find("특정 값"), 값): 특정 값을 찾고 그 앞에 값을 추가
// .Remove(값): 값을 찾아서 삭제
// .First.Value: 맨 앞의 노드의 값 조회
// .Last.Value: 맨 뒤의 노드의 값 조회
//
// 4) List<>
// ArrayList의 일반화 선언 버전
// 배열과 같은 형식으로 사용하고, 중간 삽입/삭제가 용이하다.
// 리스트는 배열로의 변환도 쉽기 때문에 리스트를 많이 사용한다.
// .Remove(값): 값을 찾아서 삭제. (처음부터 순차적으로 값을 찾아서 지움) => 중복된 값이 있을 경우 앞 부분의 값 하나만 삭제된다.
// .RemoveAt(인덱스): 인덱스 값을 찾아서 삭제. 
// .ToArray(): 리스트의 값을 배열로 변환해서 반환.
// .Sort(): 정렬 
//
// 5) Queue<>
// 선입선출(First In First Out)
//
// 6) Stack<>
// 후입선출(Last In First Out)

*/

namespace day12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Dictionary 예제 1) 키와 데이터 모두 string형
            {
                Console.WriteLine("Dictionary 예제 1) 키와 데이터 모두 string형");

                Dictionary<string, string> genDic = new Dictionary<string, string>();

                if (!genDic.ContainsKey("txt"))
                    genDic.Add("txt", "notepad.exe");
                if (!genDic.ContainsKey("bmp"))
                    genDic.Add("bmp", "paint.exe");
                if (!genDic.ContainsKey("mp3"))
                    genDic.Add("mp3", "wmplayer.exe");

                Console.WriteLine("[Dictionary]");
                foreach (KeyValuePair<string, string> key in genDic)
                {
                    Console.WriteLine("Key = {0}, Value = {1}", key.Key, key.Value);
                }
            }

            // Dictionary 예제 2) 키는 int형, 데이터는 string형
            {
                Console.WriteLine("\nDictionary 예제 2) 키는 int형, 데이터는 string형");

                Dictionary<int, string> colorDic = new Dictionary<int, string>();

                if (!colorDic.ContainsKey(1))
                    colorDic.Add(1, "Red");
                if (!colorDic.ContainsKey(2))
                    colorDic.Add(2, "Blue");
                if (!colorDic.ContainsKey(3))
                    colorDic.Add(3, "Green");

                foreach (int key in colorDic.Keys)
                {
                    Console.WriteLine("조회된 Color key는 {0}", key);
                }
                foreach (string value in colorDic.Values)
                {
                    Console.WriteLine("조회된 Color value는 {0}", value);
                }
                foreach (KeyValuePair<int, string> keyvalue in colorDic)
                {
                    Console.WriteLine("Key {0}의 색깔은 {1}", keyvalue.Key, keyvalue.Value);
                }
            }

            // SortedList 예제 1)
            {
                Console.WriteLine("\nSortedList 예제 1)");

                SortedList<int, string> colorSort = new SortedList<int, string>();

                if (!colorSort.ContainsKey(1))
                    colorSort.Add(1, "Red");
                if (!colorSort.ContainsKey(3))
                    colorSort.Add(3, "Green");
                if (!colorSort.ContainsKey(2))
                    colorSort.Add(2, "Blue");

                Console.WriteLine("[SortedList]");
                foreach (KeyValuePair<int, string> color in colorSort)
                {
                    Console.WriteLine("Key: {0}, Value: {1}", color.Key, color.Value);
                }
                Console.WriteLine("현재 리스트의 크기: {0}", colorSort.Capacity);
                colorSort.TrimExcess();         // 실행 X

                Console.WriteLine("현재 리스트의 크기: {0}, 요소의 갯수: {1}", colorSort.Capacity, colorSort.Count);
                colorSort.Remove(2);
                colorSort.TrimExcess();
                Console.WriteLine("현재 리스트의 크기: {0}, 요소의 갯수: {1}", colorSort.Capacity, colorSort.Count);
            }

            // LinkedList(이중 연결 리스트) 예제 1)
            {
                Console.WriteLine("\nLinkedList(이중 연결 리스트) 예제 1)");

                LinkedList<string> genLL = new LinkedList<string>();

                genLL.AddLast("4등");
                genLL.AddFirst("1등");
                genLL.AddAfter(genLL.Find("1등"), "2등");
                genLL.AddBefore(genLL.Find("4등"), "3등");
                genLL.Remove("1등");

                Console.WriteLine("[LinkedList]");
                foreach (string str in genLL)
                {
                    Console.WriteLine("Value = {0}", str);
                }
            }

            // LinkedList(이중 연결 리스트) 예제 2) LinkedListNode<> 응용하기
            {
                Console.WriteLine("\nLinkedList(이중 연결 리스트) 예제 2) LinkedListNode<> 응용하기");

                LinkedList<int> linkedList = new LinkedList<int>();

                linkedList.AddFirst(1);
                LinkedListNode<int> firstNode = linkedList.First;                           // firstNode --> 1
                LinkedListNode<int> currentNode = linkedList.AddAfter(firstNode, 3);        // currentNode --> 3
                currentNode = linkedList.AddBefore(currentNode, 2);                         // currentNode --> 2

                Console.WriteLine("첫 번째 노드의 값: {0}", currentNode.Previous.Value);
                Console.WriteLine("두 번째 노드의 값: {0}", currentNode.Value);
                Console.WriteLine("세 번째 노드의 값: {0}", currentNode.Next.Value);
            }

            // List 예제 1)
            {
                Console.WriteLine("\nList 예제 1)");

                List<string> list = new List<string>();

                list.Add("트럼프");
                list.Add("오바마");
                list.Add("힐러리");

                Console.WriteLine("[List]");
                for (int i = 0; i < list.Count; i++)
                {
                    Console.WriteLine("{0}. {1} 대통령", i, list[i]);
                }
                Console.WriteLine("컬렉션의 현재 배열 크기(Capacity): {0}", list.Capacity);
                Console.WriteLine("컬렉션에 저장된 요소의 수(Count) : {0}", list.Count);

                list.Insert(1, "부시");
                Console.WriteLine("리스트 1번째 대통령: {0}", list[1]);
                list.RemoveAt(1);
                Console.WriteLine("리스트 1번째 대통령: {0}", list[1]);
            }

            // Queue 예제 1)
            {
                Console.WriteLine("\nQueue 예제 1)");

                Queue<int> genQueue = new Queue<int>();

                genQueue.Enqueue(1);
                genQueue.Enqueue(2);
                genQueue.Enqueue(3);

                Console.WriteLine("[Queue]");
                while (genQueue.Count > 0)
                {
                    Console.WriteLine("Value = {0}", genQueue.Dequeue());
                }

                //for (int i = 0; i < genQueue.Count; i++)
                //{
                //    Console.WriteLine("Value = {0}", genQueue.Dequeue());
                //}
            }
        }
    }
}
