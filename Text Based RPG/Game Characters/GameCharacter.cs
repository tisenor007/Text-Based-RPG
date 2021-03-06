using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class GameCharacter
    {
        //status for game character to be alive or dead, every game character can live and die.
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
        public string name;
        protected VitalStatus vitalStatus;
        public Tile characterTile = new Tile(' ', ConsoleColor.White);
        //to switch or set if the game character is dead or alive
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
        //draw method because every gamecharacter will need to be drawn.....
        public void Draw(Camera camera)
        {
            camera.DrawToRenderer(characterTile.tileCharacter, xLoc, yLoc);
        }
        //take damage for every gamecharacter
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
                //makes them dead when they're health becomes 0
                SwitchVitalStatus(VitalStatus.Dead);
                Console.Beep(1000, 100);
            }
        }
        //heal method, self explainitory
        public void Heal(int hp)
        {
            health = health + hp;
        }
        //regenerate sheild method
        public void RegenShield(int sp)
        {
            shield = shield + sp;
            if (shield >= 50)
            {
                //shield is capped at 100
                shield = 50;
            } 
        }
        //properties for dead game characters
        public void Die()
        {
            characterTile.tileColour = ConsoleColor.White;
            health = 0;
            characterTile.tileCharacter = 'X';
        }
    }
}
