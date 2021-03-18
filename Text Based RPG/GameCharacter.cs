using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    abstract class GameCharacter
    {
        //shared gameCharacter data....
        public int health;
        protected int xLoc;
        protected int yLoc;
        public string Character;
    }
}
