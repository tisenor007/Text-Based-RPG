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
        public int shield;
        public int xLoc;
        public int yLoc;
        public int attackDamage;
        public char character;
        public string name;
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
            //spill over effect
            int remainingDamage = Damage - shield;
            shield = shield - Damage;

            if (shield <= 0)
            {
                //when shield is broken damage takes away from health
                shield = 0;
                health = health - remainingDamage;
            }
            if (health <= 0)
            {
                SwitchVitalStatus(VitalStatus.Dead);
                Console.Beep(1000, 100);
            }
        }
        public void Heal(int hp)
        {
            health = health + hp;
        }
        public void RegenShield(int sp)
        {
            shield = shield + sp;
            if (shield >= 50)
            {
                //shield is capped at 100
                shield = 50;
            } 
        }
        public void Die()
        {
            health = 0;
            character = 'X';
        }
    }
}
