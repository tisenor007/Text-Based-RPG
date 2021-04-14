using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Enemy : GameCharacter
    {
        protected enum Moving
        {
            Still,
            Left,
            Right,
            Up,
            Down
        }
        protected Moving direction;
        protected Random rnd = new Random();
        //switches directions/movement behavior
        protected void Move(Moving newDirection)
        {
            direction = newDirection;
            switch (direction)
            {
                case Moving.Still:
                    //do nothing
                    break;
                case Moving.Left:
                    xLoc = xLoc - 1;
                    break;
                case Moving.Right:
                    xLoc = xLoc + 1;
                    break;
                case Moving.Up:
                    yLoc = yLoc - 1;
                    break;
                case Moving.Down:
                    yLoc = yLoc + 1;
                    break;
            }
        }
        //behavior every enemy has.....
        public virtual void Update(Map map, Player player, Camera camera, ItemManager itemManager, EnemyManager enemyManager)
        {
            Console.CursorVisible = false;
            if (vitalStatus == VitalStatus.Alive)
            {
                if (map.IsWallAt(xLoc - 1, yLoc) == true) { Move(Moving.Right); }
                if (map.IsWallAt(xLoc + 1, yLoc) == true) { Move(Moving.Left); }
                if (map.IsWallAt(xLoc, yLoc - 1) == true) { Move(Moving.Down); }
                if (map.IsWallAt(xLoc, yLoc + 1) == true) { Move(Moving.Up); }

                //was causing crashes!!
                //if (itemManager.IsItemAt(xLoc - 1, yLoc) == true) { Move(Moving.Right); }
                //if (itemManager.IsItemAt(xLoc + 1, yLoc) == true) { Move(Moving.Left); }
                //if (itemManager.IsItemAt(xLoc, yLoc - 1) == true) { Move(Moving.Down); }
                //if (itemManager.IsItemAt(xLoc, yLoc + 1) == true) { Move(Moving.Up); }

                //if (enemyManager.IsEnemyAt(xLoc - 1, yLoc) == true) { Move(Moving.Right); }
                //if (enemyManager.IsEnemyAt(xLoc + 1, yLoc) == true) { Move(Moving.Left); }
                //if (enemyManager.IsEnemyAt(xLoc, yLoc - 1) == true) { Move(Moving.Down); }
                //if (enemyManager.IsEnemyAt(xLoc, yLoc + 1) == true) { Move(Moving.Up); }
            }
            else
            {
                SwitchVitalStatus(VitalStatus.Dead);
            }
        }
       
        
    }

    
}
