using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class GameCharacter
    {
        protected enum VitalStatus
        {
            Alive,
            Dead
        }
        //shared gameCharacter data....
        public int health;
        public int xLoc;
        public int yLoc;
        public char character;
        protected VitalStatus vitalStatus;
        
        protected void SwitchVitalStatus(VitalStatus newVitalStatus)
        {
            vitalStatus = newVitalStatus;

            switch (vitalStatus)
            {
                case VitalStatus.Alive:
                    break;
                case VitalStatus.Dead:
                    Die();
                    break;
            }

        }
        public void Draw(Camera camera)
        {
            camera.DrawToRenderer(character, xLoc, yLoc);
            //Console.WriteLine(Character);
            
        }
        public void TakeDamage(int Damage)
        {
            health = health - Damage;
            if (health <= 0)
            {
                SwitchVitalStatus(VitalStatus.Dead);
            }
        }
        public void Heal(int hp)
        {
            health = health + hp;
        }
        public void Die()
        {
            health = 0;
            character = 'X';
        }
    }
}
