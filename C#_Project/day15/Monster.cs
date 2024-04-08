using System;

namespace day15
{
    internal class Monster
    {
        public int m_Hp { get; set; }
        public int m_Atk { get; set; }

        public Monster()
        {
            Start();
        }

        virtual protected void Start()
        {
            InitStat();
        }

        virtual public void InitStat()
        {
            m_Hp = 10;
            m_Atk = 20;
        }

        public bool IsLive()
        {
            return m_Hp > 0;
        }

        public void Info()
        {
            Console.WriteLine("-------------------");
            Console.WriteLine("HP : " + m_Hp);
            Console.WriteLine("ATK: " + m_Atk);
            Console.WriteLine("-------------------");
        }
    }
}
