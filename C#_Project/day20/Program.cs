using System;
using System.Collections.Generic;
using System.Text;

/*
// 2024/04/15 : C# 싱글턴(싱글턴 기본 형식), 문자열(StringBuilder)

// C# 문자열(StringBuilder)
// string 과는 다르게 Boxing이 일어나지 않는다는 장점이 있다.
// Append() : 현재 문자열에 문자열을 추가한다.
// Remove() : 지정한 문자를 제거한다.
// Replace() : 지정한 문자를 변경한다.
// ToString() : 객체를 문자열로 반환한다.
// Insert() : 문자열 사이에 지정한 문자열을 추가한다.
// AppendFormat() : 형식에 맞춘 문자열을 추가한다.
// AppendLine() : 문자열에 "\n"을 추가한다.
// Clear() : 문자열을 삭제한다.

*/

namespace day20
{
    #region 싱글턴 디자인 패턴 예제 1) 싱글턴 형식
    public class Singleton<T> where T : Singleton<T>, new()
    {
        public static T Instance { get; private set; }

        static Singleton()
        {
            if (Instance == null)
            {
                Instance = new T();
            }
        }
    }

    class TestSingleton : Singleton<TestSingleton>
    {
        public void DrawMessage()
        {
            Console.WriteLine("안녕하세요. SBS 게임 아카데미 입니다.");
        }
    }
    #endregion

    #region 싱글턴 디자인 패턴 예제 2) MonsterManager
    public class MonsterManager : Singleton<MonsterManager>
    {
        List<Monster> m_monList = new List<Monster>();
        public int Count { get { return m_monList.Count; } }

        public void Add(Monster mon)
        {
            m_monList.Add(mon);
        }

        public bool Remove(Monster mon)
        {
            return m_monList.Remove(mon);
        }

        public void RemoveAll()
        {
            m_monList.RemoveAll(element => element.m_isAlive == true);
        }

        public void Clear()
        {
            m_monList.Clear();
        }

        public Monster GetMonster(int idx)
        {
            return m_monList[idx];
        }

        public void InitMonsters()
        {
            for (int i = 0; i < m_monList.Count; i++)
            {
                m_monList[i].InitMonster();
            }
        }

        public void DrawMonstersInfo()
        {
            for (int i = 0; i < m_monList.Count; i++)
            {
                m_monList[i].MonsterInfo();
            }
        }
    }

    public class Monster
    {
        public int m_hp { get; set; }
        public int m_def { get; set; }
        public int m_atk { get; set; }
        public bool m_isAlive { get; set; }

        public void InitMonster()
        {
            m_hp = 100;
            m_def = 20;
            m_atk = 150;
            m_isAlive = true;
        }

        public void MonsterInfo()
        {
            Console.WriteLine("Hp : {0}", m_hp);
            Console.WriteLine("DEF: {0}", m_def);
            Console.WriteLine("ATK: {0}", m_atk);
            Console.WriteLine();
        }
    }

    public class Stage
    {
        const int MONSTER_MAX = 10;

        public void CreateMonsters()
        {
            for (int i = 0; i < MONSTER_MAX; i++)
            {
                MonsterManager.Instance.Add(new Monster());
            }
            MonsterManager.Instance.InitMonsters();
        }

        public bool IsClear()
        {
            for (int i = 0; i < MonsterManager.Instance.Count; i++)
            {
                Monster mon = null;
                if ((mon = MonsterManager.Instance.GetMonster(i)) != null)
                {
                    if (mon.m_isAlive)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
    #endregion

    internal class Program
    {
        static void Main(string[] args)
        {
            // 싱글턴 디자인 패턴 예제 1) 싱글턴 형식
            {
                Console.WriteLine("싱글턴 디자인 패턴 예제 1) 싱글턴 형식");

                TestSingleton.Instance.DrawMessage();
            }

            // 싱글턴 디자인 패턴 예제 2) MonsterManager
            {
                Console.WriteLine("\n싱글턴 디자인 패턴 예제 2) MonsterManager");

                Stage stage = new Stage();
                stage.CreateMonsters();
                MonsterManager.Instance.DrawMonstersInfo();
                //MonsterManager.Instance.RemoveAll();
                Console.WriteLine("Stage Clear : {0}", stage.IsClear());
            }

            // 문자열(StringBuilder) 예제 1)
            {
                Console.WriteLine("\n문자열(StringBuilder) 예제 1)");

                StringBuilder sb = new StringBuilder("안녕하세요!");
                Console.WriteLine("생성 문자 :{0}", sb);

                sb.Append(" SBS 게임 아카데미 입니다.");
                Console.WriteLine("Append()  :{0}", sb);

                sb.AppendFormat(" 제 이름은 {0}이고 나이는 {1}살 입니다.", "이순신", 50);
                Console.WriteLine("AppendFormat() :{0}", sb);

                sb.Remove(0, 7);            // 0 ~ 6번째 인덱스 까지 삭제       
                Console.WriteLine("Remove()  :{0}", sb);

                sb.Insert(12, "강남지점");  // 12번째 인덱스에 삽입
                Console.WriteLine("Insert()  :{0}", sb);

                sb.Replace("강남지점", "신촌지점");
                Console.WriteLine("Replace() :{0}", sb);

                sb.Clear();
                Console.WriteLine("Clear() :{0}", sb);
            }
        }
    }
}
