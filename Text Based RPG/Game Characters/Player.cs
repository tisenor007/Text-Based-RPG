using System;

namespace Text_Based_RPG
{
    class Player : GameCharacter
    {
        private bool wallExist;
        private bool enemyExist;
        private bool itemExist;
        public int collectedValuables;
        public Weapon equippedWeapon = new Weapon(0,0,Item.ItemType.Fist);

        private int previousXLoc;
        private int previousYLoc;

        public Player()
        {
            //loads player position, character, health
            SwitchVitalStatus(VitalStatus.Alive);
            characterTile.tileCharacter = Global.playerAppearance;
            characterTile.tileColour = ConsoleColor.Cyan;
            health = Global.playerHealth;
            shield = Global.playerShield;
            healthCap = Global.playerHealth;
            shieldCap = Global.playerShield;
            collectedValuables = 0;
            name = Global.playerName;
            if (Global.playerStartingWeapon == Item.ItemType.Fist.ToString())
            {
                equippedWeapon.SwitchWeapon(Item.ItemType.Fist, this);
            }
            if (Global.playerStartingWeapon == Item.ItemType.BrassKnuckles.ToString())
            {
                equippedWeapon.SwitchWeapon(Item.ItemType.BrassKnuckles, this);
            }
            if (Global.playerStartingWeapon == Item.ItemType.BaseballBat.ToString())
            {
                equippedWeapon.SwitchWeapon(Item.ItemType.BaseballBat, this);
            }
            if (Global.playerStartingWeapon == Item.ItemType.Knife.ToString())
            {
                equippedWeapon.SwitchWeapon(Item.ItemType.Knife, this);
            }
            if (Global.playerStartingWeapon == Item.ItemType.Machete.ToString())
            {
                equippedWeapon.SwitchWeapon(Item.ItemType.Machete, this);
            }
            if (Global.playerStartingWeapon == Item.ItemType.Chainsaw.ToString())
            {
                equippedWeapon.SwitchWeapon(Item.ItemType.Chainsaw, this);
            }
            else if (Global.playerStartingWeapon == null || Global.playerStartingWeapon == "")
            {
                equippedWeapon.SwitchWeapon(Item.ItemType.Fist, this);
            }

            previousXLoc = xLoc;
            previousYLoc = yLoc;
        }
        //specific to the player...

        
        public void CollectValuable(int money)
        {
            collectedValuables = collectedValuables + money;
        }
        public void InitPlayerFromWorldLoc(char[,] world, int X, int Y)
        {
            if (world[X, Y] == '@') { xLoc = X; yLoc = Y; }
        }
        public void Update(Map map, EnemyManager enemyManager, ItemManager itemManager, GameOver gameOver, Inventory inventory, ShopManager shopManager)
        {
            Console.CursorVisible = false;
            ConsoleKey keyPressed = Console.ReadKey(true).Key;
            if (vitalStatus == VitalStatus.Alive)
            {
                if (keyPressed == ConsoleKey.W)
                {
                    //collision
                    if (wallExist = map.IsWallAt(xLoc, yLoc - 1))
                    {
                        //do nothing 
                    }
                    else if (enemyExist = enemyManager.IsEnemyAt(xLoc, yLoc - 1))
                    {
                        enemyManager.CheckEnemies(xLoc, yLoc - 1, attackDamage);
                    }
                    else if (itemExist = itemManager.IsItemAt(xLoc, yLoc - 1) && inventory.settingUpInventory == false)
                    {
                        
                        if (inventory.IsInventorySlotAvailable() == true)
                        {
                            itemManager.CheckAndPickupItems(xLoc, yLoc - 1);
                        }
                        else
                        {
                            inventory.inventoryIsFull = true;
                        }
                    }
                    else
                    {
                        previousXLoc = xLoc;
                        previousYLoc = yLoc;
                        yLoc = yLoc - 1;
                    }
                }
                if (keyPressed == ConsoleKey.A)
                {
                    if (wallExist = map.IsWallAt(xLoc - 1, yLoc))
                    {
                        //do nothing
                    }
                    else if (enemyExist = enemyManager.IsEnemyAt(xLoc - 1, yLoc))
                    {
                        enemyManager.CheckEnemies(xLoc - 1, yLoc, attackDamage);
                    }
                    else if (itemExist = itemManager.IsItemAt(xLoc - 1, yLoc))
                    {
                        
                        if (inventory.IsInventorySlotAvailable() == true)
                        {
                            itemManager.CheckAndPickupItems(xLoc - 1, yLoc);
                        }
                        else
                        {
                            inventory.inventoryIsFull = true;
                        }
                    }
                    else
                    {
                        previousXLoc = xLoc;
                        previousYLoc = yLoc;
                        xLoc = xLoc - 1;
                    }
                }
                if (keyPressed == ConsoleKey.S)
                {
                    if (wallExist = map.IsWallAt(xLoc, yLoc + 1))
                    {
                        //do nothing
                    }
                    else if (enemyExist = enemyManager.IsEnemyAt(xLoc, yLoc + 1))
                    {
                        enemyManager.CheckEnemies(xLoc, yLoc + 1, attackDamage);
                    }
                    else if (itemExist = itemManager.IsItemAt(xLoc, yLoc + 1))
                    {
                        if (inventory.IsInventorySlotAvailable() == true)
                        {
                            itemManager.CheckAndPickupItems(xLoc, yLoc + 1);
                        }
                        else
                        {
                            inventory.inventoryIsFull = true;
                        }
                    }  
                    else
                    {
                        previousXLoc = xLoc;
                        previousYLoc = yLoc;
                        yLoc = yLoc + 1;
                    }
                }
                if (keyPressed == ConsoleKey.D)
                {
                    if (wallExist = map.IsWallAt(xLoc + 1, yLoc))
                    {
                        //do nothing
                    }
                    else if (enemyExist = enemyManager.IsEnemyAt(xLoc + 1, yLoc))
                    {
                        enemyManager.CheckEnemies(xLoc + 1, yLoc, attackDamage);
                    }
                    else if (itemExist = itemManager.IsItemAt(xLoc + 1, yLoc))
                    {
                        if (inventory.IsInventorySlotAvailable() == true)
                        {
                            itemManager.CheckAndPickupItems(xLoc + 1, yLoc);
                        }
                        else
                        {
                            inventory.inventoryIsFull = true;
                        }
                    }
                    else
                    {
                        previousXLoc = xLoc;
                        previousYLoc = yLoc;
                        xLoc = xLoc + 1;
                    }
                }
                if (keyPressed == ConsoleKey.I)
                {
                    inventory.inventoryIsOpen = true;
                }
                //determines win
                if (collectedValuables >= 600)
                {
                    gameOver.gameOverWin = true;
                }
            }
            else
            {
                SwitchVitalStatus(VitalStatus.Dead);
            }
            //determines loss...
            if (vitalStatus == VitalStatus.Dead)
            {
                gameOver.gameOverLoss = true;
            }
        }
        //for others to detect collision with player
        public bool isPlayerAt(int x, int y)
        {
          
            if (x == xLoc)
            {
                if (y == yLoc)
                {
                    return true;
                }
            }
            
            return false;
        }

        public void ReturnToLastPosition()
        {
            xLoc = previousXLoc;
            yLoc = previousYLoc;
        }
    }
}
