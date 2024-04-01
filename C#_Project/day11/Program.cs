using System;
using System.Collections;

/*
// 2024/04/01 : C# 컬렉션(ArrayList, Queue, Stack, Hashtable)

// C# 컬렉션 (Collection)
// 자료를 관리하는 구조(자료구조)
// Node(노드): 자료를 담아놓는 틀
// 컬렉션들은 모두 object형으로 Boxing/UnBoxing이 발생하여 가비지값이 자주 발생할 수 있다.
//
// 1) ArrayList(배열의 리스트)
// 단일 연결(싱글) 리스트(한 쪽 방향으로만 연결)
// 중간 삽입, 중간 삭제가 용이하다.
// .Add(값): 마지막에 값을 추가. (노드를 하나 생성하고 그 안에 값을 넣어서 Node* next를 통해 노드끼리 연결)
// .Remove(값): 값을 찾아서 삭제. (처음부터 값을 찾아서 지움)
// .RemoveAt(인덱스): 인덱스 값을 찾아서 삭제. 
// .Insert(인덱스, 값): 인덱스 위치에 값 삽입.
//
// 2) Queue(큐)
// FIFO(First In First Out): 선입선출
// Queue에 값이 저장되어 있다가 사용을 하게되면 값을 꺼내어서 사용하는 구조(데이터 소모)
// Queue의 내용 출력 시 주로 while문을 사용한다. 
// for문의 queue.Count 사용 시 Queue의 개수가 실시간으로 줄어들기 때문에 원하는 값 출력 X
// .Enqueue: 데이터를 입력(추가)
// .Dequeue: 데이터를 꺼내어 사용(데이터 소모)
//
// 3) Stack(스택)
// LIFO(Last In First Out): 후입선출
// Stack의 내용 출력 시 주로 while문을 사용한다. 
// for문의 stack.Count 사용 시 Queue의 개수가 실시간으로 줄어들기 때문에 원하는 값 출력 X
// ex) Game UI 구조
// .Push: 데이터를 입력(추가) 
// .Pop: 데이터를 꺼내어 사용(데이터 소모)
//
// 4) Hashtable(해시테이블)
// 키와 데이터를 한 쌍으로 가지고 있다. (데이터를 보관하는 방식은 배열)
// 컬렉션 중에서 데이터를 가장 빠르게 접근할 수 있다.
// 키 값에 따라 해시함수를 거쳐 데이터가 저장되기 때문에 순서대로 저장되지 않는다.
// 키 값을 가지고 인덱스에 접근하다 보니 키 값은 절대 중복될 수 없다.
// => ☆반드시 키 값이 중복되는지를 .ContainsKey()를 통해 확인해야 한다.
// .ContainsKey("키 값"): 키 값이 중복되는지를 반드시 확인!!
// .Add(키 값, 데이터): 데이터 추가
// .Keys: 키 값들이 저장되어 있다.
// .Values: 데이터들이 저장되어 있다.
// ht[키]: 키 값을 통해 데이터를 찾을 수 있다.

*/
namespace day11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ArrayList(배열의 리스트)
            {
                Console.WriteLine("ArrayList(배열의 리스트)");

                ArrayList list = new ArrayList();

                list.Add(10);           // 값 추가
                list.Add(20);
                list.Add(30);
                list.RemoveAt(1);       // 1번 인덱스 값 삭제
                list.Insert(1, 36.5f);  // 1번 인덱스 위치에 값 삽입
                list.Add("SBS 게임 아카데미");
                for (int i = 0; i < list.Count; i++)
                {
                    Console.WriteLine(list[i]);
                }
            }

            // Queue(큐)
            {
                Console.WriteLine("\nQueue(큐)");

                Queue queue = new Queue();

                queue.Enqueue(10);        // 데이터 입력        
                queue.Enqueue(20);
                queue.Enqueue(30);
                queue.Dequeue();          // 데이터 소모
                queue.Enqueue(4.4);
                queue.Dequeue();
                queue.Enqueue("ABC");

                while (queue.Count > 0)
                {
                    Console.WriteLine(queue.Dequeue());
                }
            }

            // Stack(스택)
            {
                Console.WriteLine("\nStack(스택)");

                Stack stack = new Stack();

                stack.Push(10);         // 데이터 입력
                stack.Push(20);
                stack.Push(30);
                stack.Pop();            // 데이터 소모
                stack.Push(4.4);
                stack.Pop();
                stack.Push("ABC");

                while (stack.Count > 0)
                {
                    Console.WriteLine(stack.Pop());
                }
            }

            // Hashtable(해시테이블)
            {
                Console.WriteLine("\nHashtable(해시테이블)");

                Hashtable ht = new Hashtable();

                if (!ht.ContainsKey("오렌지"))     // Hashtable 사용 시 반드시 키 값 중복 확인
                {
                    ht.Add("오렌지", "Orange");    // Add(키 값, 데이터)
                }
                if (!ht.ContainsKey("바나나"))
                {
                    ht.Add("바나나", "Banana");
                }
                if (!ht.ContainsKey("사과"))
                {
                    ht.Add("사과", "Apple");
                }

                foreach (string key in ht.Keys)
                {
                    Console.WriteLine("키 값: " + key + "\t데이터: " + ht[key]);                     
                }

                if (ht.ContainsKey("오렌지"))
                    Console.WriteLine(ht["오렌지"]);
                if (ht.ContainsKey("바나나"))
                    Console.WriteLine(ht["바나나"]);
                if (ht.ContainsKey("사과"))
                    Console.WriteLine(ht["사과"]);
            }
        }
    }
}
