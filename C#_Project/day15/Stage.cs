using System;
using System.Collections.Generic;

namespace day15
{
    internal class Stage
    {
        protected List<Monster> m_MobList = new List<Monster>();

        public void Start()
        {
            m_MobList.Add(new Monster());
            m_MobList.Add(new Monster());
            m_MobList.Add(new MonsterBoss());
        }

        public void DrawMonster()
        {
            for (int i = 0; i < m_MobList.Count; i++)
            {
                Monster tmp = (Monster)m_MobList[i];
                tmp.Info();
            }
        }

        public bool CheckClear()
        {
            for (int i = 0; i < m_MobList.Count; i++)
            {
                Monster tmp = (Monster)m_MobList[i];
                if (tmp.IsLive())
                {
                    return false;
                }
            }
            return true;
        }
    }
}