using System;

// 모든 클래스들은 영역을 나눠놓고 작업을 진행하면 좋다.
// 코드를 영역별로 분할해서 관리 (#region ~ #endregion)

// 일반적인 순서
// Contants and Fields
// Public Properties
// Public Methods and Operators
// Methods

namespace day06
{
    internal class region_endregion
    {
        #region Contants and Fields
        public int hp;
        public int mp;
        #endregion

        #region Public Properties
        public int Hp { get { return hp; } set { hp = value; } }
        #endregion

        #region Public Methods and Operators
        public region_endregion()
        {
            hp = 100;
            mp = 10;
        }

        public region_endregion(int _hp)
        {
            hp = _hp;
        }

        public region_endregion(int _hp, int _mp)
        {
            hp = _hp;
            mp = _mp;
        }
        #endregion

        #region Methods
        void Reset()
        {
            hp = 0;
            mp = 0;
        }
        #endregion
    }
}
