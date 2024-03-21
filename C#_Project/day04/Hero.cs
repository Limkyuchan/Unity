using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroTest
{
    class Hero
    {
        public int hp;
        public int mp;

        public Hero()       // 생성자
        {                   // 특징 : 자기이름으로 된 함수, 반환값이 없다.
            hp = 100;
            mp = 10;
        }

        public Hero(int _hp)    // 생성자 오버로딩
        {
            hp = _hp;
        }

        public Hero(int _hp, int _mp)   // 생성자 오버로딩
        {
            hp = _hp;
            mp = _mp;
        }
    }
}