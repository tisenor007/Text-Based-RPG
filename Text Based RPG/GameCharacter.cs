﻿using System;
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
        public int xLoc;
        public int yLoc;
        public string Character;

        public void Draw()
        {

            Console.WriteLine(Character);
        }
        public void TakeDamage(int Damage)
        {
            health = health - Damage;
        }
    }
}
