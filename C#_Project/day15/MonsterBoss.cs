using System;

namespace day15
{
    internal class MonsterBoss : Monster
    {
        protected override void Start()
        {
            base.Start();
            Console.WriteLine("보스몬스터 초기화!");
        }

        public override void InitStat()
        {
            m_Hp = 100;
            m_Atk = 50;
        }
    }
}
