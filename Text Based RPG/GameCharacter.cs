using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class GameCharacter
    {
        //shared gameCharacter data....
        public int health;
        public int xLoc;
        public int yLoc;
        public char Character;
        
        public void Draw(Camera camera)
        {
            camera.DrawToRenderer(Character, xLoc, yLoc);
            //Console.WriteLine(Character);
            
        }
        public void TakeDamage(int Damage)
        {
            health = health - Damage;
        }
        public void Heal(int hp)
        {
            health = health + hp;
        }
    }
}
