using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Global
    {
        //general data
        static string[] data;
        static string[] dataLineSections;

        //All varibles are in this class because they need to be set before instanciated before anything else, but will be used later....
        //player
        public static int playerHealth;
        public static int playerShield;
        public static char playerAppearance;
        public static string playerName;
        public static int playerInventorySlotAmount;
        public static string[] playerInventoryData;
        public static string playerStartingWeapon;
        public static int playerStartMoney;
        public static ConsoleColor playerColour;

        //map
        public static int mapWidth;
        public static int mapHeight;
        public static char[] mapTileIDs = new char[13];
        public static ConsoleColor[] mapTileColours = new ConsoleColor[13];
       

        //LightEnemy
        public static int lightHealth;
        public static int lightShield;
        public static char lightAppearance;
        public static string lightName;
        public static int lightAttackDamage;
        public static ConsoleColor lightColour;

        //SpecializedCombatEnemy
        public static int SCHealth;
        public static int SCShield;
        public static char SCAppearance;
        public static string SCName;
        public static int SCAttackDamage;
        public static ConsoleColor SCColour;

        //HeavyEnemy
        public static int heavyHealth;
        public static int heavyShield;
        public static char heavyAppearance;
        public static string heavyName;
        public static int heavyAttackDamage;
        public static ConsoleColor heavyColour;

        //Boss
        public static int bossHealth;
        public static int bossShield;
        public static char bossAppearance;
        public static string bossName;
        public static int bossAttackDamage;
        public static ConsoleColor bossColour;

        //Shops
        public static char shopAppearance;
        public static string shopName;
        public static int shopPriceMin;
        public static int shopPriceMax;
        public static int shopStartingMoney;
        public static string shopEnterMessage;
        public static string shopBetrayalMessage;
        public static int shopItemAmount;
        public static int shopXLoc;
        public static int shopYLoc;
        public static ConsoleColor shopColour;

        //Items
        public static char firstAidAppearance;
        public static int firstAidHP;
        public static ConsoleColor firstAidColour;
        public static char shieldAppearance;
        public static int ShieldSP;
        public static ConsoleColor shieldColour;
        public static char keyAppearance;
        public static ConsoleColor keyColour;
        public static char valuableAppearance;
        public static ConsoleColor valuableColour;
        public static char weaponAppearance;
        public static int fistDamage;
        public static int BKDamage;
        public static int BBBDamage;
        public static int knifeDamage;
        public static int macheteDamage;
        public static int chainsawDamage;
        public static ConsoleColor weaponColour;
        //public static 
        public Global()
        {
            SetMapStats();
            SetPlayerStats();
            SetLightStats();
            SetSCStats();
            SetHeavyStats();
            SetBossStats();
            SetShopStats();
            SetItemStats();
        }
        public void SetItemStats()
        {
            data = System.IO.File.ReadAllLines("DataStats/ItemStats.txt");
            for (int i = 0; i <= data.Length - 1; i = i + 1)
            {
                dataLineSections = data[i].Split('=');
                for (int l = 0; l <= dataLineSections.Length - 1; l = l + 1)
                {
                    if (dataLineSections[l].ToLower() == "FirstAidappearance".ToLower()) { firstAidAppearance = char.Parse(dataLineSections[l + 1]); }
                    if (dataLineSections[l].ToLower() == "FirstAidHP".ToLower()) { firstAidHP = int.Parse(dataLineSections[l + 1]); }
                    if (dataLineSections[l].ToLower() == "FirstAidColour".ToLower()) { firstAidColour = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true); }
                    if (dataLineSections[l].ToLower() == "Shieldappearance".ToLower()) { shieldAppearance = char.Parse(dataLineSections[l + 1]); }
                    if (dataLineSections[l].ToLower() == "ShieldSP".ToLower()) { ShieldSP = int.Parse(dataLineSections[l + 1]); }
                    if (dataLineSections[l].ToLower() == "ShieldColour".ToLower()) { shieldColour = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true); }
                    if (dataLineSections[l].ToLower() == "Keyappearance".ToLower()) { keyAppearance = char.Parse(dataLineSections[l + 1]); }
                    if (dataLineSections[l].ToLower() == "KeyColour".ToLower()) { keyColour = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true); }
                    if (dataLineSections[l].ToLower() == "Valuableappearance".ToLower()) { valuableAppearance = char.Parse(dataLineSections[l + 1]); }
                    if (dataLineSections[l].ToLower() == "ValuableColour".ToLower()) { valuableColour = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true); }
                    if (dataLineSections[l].ToLower() == "Weaponappearance".ToLower()) { weaponAppearance = char.Parse(dataLineSections[l + 1]); }
                    if (dataLineSections[l].ToLower() == "WeaponColour".ToLower()) { weaponColour = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true); }
                    if (dataLineSections[l].ToLower() == "FistDamage".ToLower()) { fistDamage = int.Parse(dataLineSections[l + 1]); }
                    if (dataLineSections[l].ToLower() == "BrassKnucklesDamage".ToLower()) { BKDamage = int.Parse(dataLineSections[l + 1]); }
                    if (dataLineSections[l].ToLower() == "BaseBallBatDamage".ToLower()) { BBBDamage = int.Parse(dataLineSections[l + 1]); }
                    if (dataLineSections[l].ToLower() == "KnifeDamage".ToLower()) { knifeDamage = int.Parse(dataLineSections[l + 1]); }
                    if (dataLineSections[l].ToLower() == "MacheteDamage".ToLower()) { macheteDamage = int.Parse(dataLineSections[l + 1]); }
                    if (dataLineSections[l].ToLower() == "ChainsawDamage".ToLower()) { chainsawDamage = int.Parse(dataLineSections[l + 1]); }
                }
            }
        }
        public void SetShopStats()
        {
            data = System.IO.File.ReadAllLines("DataStats/ShopKeeperStats.txt");
            for (int i = 0; i <= data.Length - 1; i = i + 1)
            {
                dataLineSections = data[i].Split('=');
                for (int l = 0; l <= dataLineSections.Length - 1; l = l + 1)
                {
                    if (dataLineSections[l].ToLower() == "shopappearance".ToLower()){ shopAppearance = char.Parse(dataLineSections[l + 1]); }
                    if (dataLineSections[l].ToLower() == "startMoney".ToLower()){shopStartingMoney = int.Parse(dataLineSections[l + 1]);}
                    if (dataLineSections[l].ToLower() == "shopName".ToLower()){shopName = dataLineSections[l + 1];}
                    if (dataLineSections[l].ToLower() == "EnterMessage".ToLower()){shopEnterMessage = dataLineSections[l + 1];}
                    if (dataLineSections[l].ToLower() == "BetrayalMessage".ToLower()){shopBetrayalMessage = dataLineSections[l + 1];}
                    if (dataLineSections[l].ToLower() == "PriceRangeMin".ToLower()){shopPriceMin = int.Parse(dataLineSections[l + 1]);}
                    if (dataLineSections[l].ToLower() == "PriceRangeMax".ToLower()){shopPriceMax = int.Parse(dataLineSections[l + 1]);}
                    if (dataLineSections[l].ToLower() == "ItemAmount".ToLower()){shopItemAmount = int.Parse(dataLineSections[l + 1]);}
                    if (dataLineSections[l].ToLower() == "shOpYLoc".ToLower()){shopYLoc = int.Parse(dataLineSections[l + 1]);}
                    if (dataLineSections[l].ToLower() == "shOpXLoc".ToLower()){shopXLoc = int.Parse(dataLineSections[l + 1]);}
                    if (dataLineSections[l].ToLower() == "Colour".ToLower()){shopColour = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true);}
                }
            }
        }
        public void SetBossStats()
        {
            data = System.IO.File.ReadAllLines("DataStats/EnemyStats.txt");
            for (int i = 0; i <= data.Length - 1; i = i + 1)
            {
                dataLineSections = data[i].Split('=');
                for (int l = 0; l <= dataLineSections.Length - 1; l = l + 1)
                {
                    if (dataLineSections[l].ToLower() == "bossappearance".ToLower()){ bossAppearance = char.Parse(dataLineSections[l + 1]);}
                    if (dataLineSections[l].ToLower() == "bossshield".ToLower()) {bossShield = int.Parse(dataLineSections[l + 1]);}
                    if (dataLineSections[l].ToLower() == "bosshealth".ToLower()){ bossHealth = int.Parse(dataLineSections[l + 1]);}
                    if (dataLineSections[l].ToLower() == "bossname".ToLower()){ bossName = dataLineSections[l + 1];}
                    if (dataLineSections[l].ToLower() == "bossattackdamage".ToLower()){ bossAttackDamage = int.Parse(dataLineSections[l + 1]);}
                    if (dataLineSections[l].ToLower() == "BossColour".ToLower()){bossColour = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true);}
                }
            }
        }
        public void SetHeavyStats()
        {
            data = System.IO.File.ReadAllLines("DataStats/EnemyStats.txt");
            for (int i = 0; i <= data.Length - 1; i = i + 1)
            {
                dataLineSections = data[i].Split('=');
                for (int l = 0; l <= dataLineSections.Length - 1; l = l + 1)
                {
                    if (dataLineSections[l].ToLower() == "heavyappearance".ToLower()){heavyAppearance = char.Parse(dataLineSections[l + 1]);}
                    if (dataLineSections[l].ToLower() == "heavyshield".ToLower()){ heavyShield = int.Parse(dataLineSections[l + 1]);}
                    if (dataLineSections[l].ToLower() == "heavyhealth".ToLower()){ heavyHealth = int.Parse(dataLineSections[l + 1]); }
                    if (dataLineSections[l].ToLower() == "heavyname".ToLower()) {heavyName = dataLineSections[l + 1];}
                    if (dataLineSections[l].ToLower() == "heavyattackdamage".ToLower()){ heavyAttackDamage = int.Parse(dataLineSections[l + 1]);}
                    if (dataLineSections[l].ToLower() == "HeavyColour".ToLower()){heavyColour = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true);}
                }
            }
        }
        public void SetSCStats()
        {
            data = System.IO.File.ReadAllLines("DataStats/EnemyStats.txt");
            for (int i = 0; i <= data.Length - 1; i = i + 1)
            {
                dataLineSections = data[i].Split('=');
                for (int l = 0; l <= dataLineSections.Length - 1; l = l + 1)
                {
                    if (dataLineSections[l].ToLower() == "scappearance".ToLower()){SCAppearance = char.Parse(dataLineSections[l + 1]);}
                    if (dataLineSections[l].ToLower() == "scshield".ToLower()){SCShield = int.Parse(dataLineSections[l + 1]);}
                    if (dataLineSections[l].ToLower() == "schealth".ToLower()){SCHealth = int.Parse(dataLineSections[l + 1]);}
                    if (dataLineSections[l].ToLower() == "scname".ToLower()){SCName = dataLineSections[l + 1]; }
                    if (dataLineSections[l].ToLower() == "scattackdamage".ToLower()){ SCAttackDamage = int.Parse(dataLineSections[l + 1]);}
                    if (dataLineSections[l].ToLower() == "SCColour".ToLower()){SCColour = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true);}
                }
            }
        }

        public void SetLightStats()
        {
            data = System.IO.File.ReadAllLines("DataStats/EnemyStats.txt");
            for (int i = 0; i <= data.Length - 1; i = i + 1)
            {
                dataLineSections = data[i].Split('=');
                for (int l = 0; l <= dataLineSections.Length - 1; l = l + 1)
                {
                    if (dataLineSections[l].ToLower() == "lightappearance".ToLower()){lightAppearance = char.Parse(dataLineSections[l + 1]);}
                    if (dataLineSections[l].ToLower() == "lightshield".ToLower()){ lightShield = int.Parse(dataLineSections[l + 1]);}
                    if (dataLineSections[l].ToLower() == "lighthealth".ToLower()){lightHealth = int.Parse(dataLineSections[l + 1]);}
                    if (dataLineSections[l].ToLower() == "lightname".ToLower()){lightName = dataLineSections[l + 1];}
                    if (dataLineSections[l].ToLower() == "lightattackdamage".ToLower()){lightAttackDamage = int.Parse(dataLineSections[l + 1]);}
                    if (dataLineSections[l].ToLower() == "LightColour".ToLower()){lightColour = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true);}
                }
            }
        }
        public void SetMapStats()
        {
            data = System.IO.File.ReadAllLines("DataStats/MapStats.txt");
            for (int i = 0; i <= data.Length - 1; i = i + 1)
            {
                dataLineSections = data[i].Split(';');
                for (int l = 0; l <= dataLineSections.Length - 1; l = l + 1)
                {
                    if (dataLineSections[l].ToLower() == "width".ToLower()){ mapWidth = int.Parse(dataLineSections[l + 1]);}
                    if (dataLineSections[l].ToLower() == "height".ToLower()){mapHeight = int.Parse(dataLineSections[l + 1]);}
                    if (dataLineSections[l].ToLower() == "WaterID".ToLower()){ mapTileIDs[0] = char.Parse(dataLineSections[l + 1]);}
                    if (dataLineSections[l].ToLower() == "WaterColour".ToLower()){mapTileColours[0] = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true);}
                    if (dataLineSections[l].ToLower() == "GrassID".ToLower()){mapTileIDs[1] = char.Parse(dataLineSections[l + 1]);}
                    if (dataLineSections[l].ToLower() == "GrassColour".ToLower()){ mapTileColours[1] = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true);}
                    if (dataLineSections[l].ToLower() == "HillID".ToLower()){mapTileIDs[2] = char.Parse(dataLineSections[l + 1]);}
                    if (dataLineSections[l].ToLower() == "HillColour".ToLower()){ mapTileColours[2] = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true);}
                    if (dataLineSections[l].ToLower() == "mountainID".ToLower()){mapTileIDs[3] = char.Parse(dataLineSections[l + 1]);}
                    if (dataLineSections[l].ToLower() == "mountainColour".ToLower()){mapTileColours[3] = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true);}
                    if (dataLineSections[l].ToLower() == "VertWallID".ToLower()){mapTileIDs[4] = char.Parse(dataLineSections[l + 1]);}
                    if (dataLineSections[l].ToLower() == "VertWallColour".ToLower()){ mapTileColours[4] = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true);}
                    if (dataLineSections[l].ToLower() == "HorizWallID".ToLower()){mapTileIDs[5] = char.Parse(dataLineSections[l + 1]);}
                    if (dataLineSections[l].ToLower() == "HorizWallColour".ToLower()){mapTileColours[5] = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true);}
                    if (dataLineSections[l].ToLower() == "RightCornerWallID".ToLower()){mapTileIDs[6] = char.Parse(dataLineSections[l + 1]);}
                    if (dataLineSections[l].ToLower() == "RightCornerWallColour".ToLower()){mapTileColours[6] = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true);}
                    if (dataLineSections[l].ToLower() == "LeftCornerWallID".ToLower()){mapTileIDs[7] = char.Parse(dataLineSections[l + 1]);}
                    if (dataLineSections[l].ToLower() == "LeftCornerWallColour".ToLower()){mapTileColours[7] = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true);}
                    if (dataLineSections[l].ToLower() == "floorID".ToLower()){ mapTileIDs[8] = char.Parse(dataLineSections[l + 1]);}
                    if (dataLineSections[l].ToLower() == "floorColour".ToLower()){ mapTileColours[8] = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true);}
                    if (dataLineSections[l].ToLower() == "PathID".ToLower()){mapTileIDs[9] = char.Parse(dataLineSections[l + 1]);}
                    if (dataLineSections[l].ToLower() == "PathColour".ToLower()){mapTileColours[9] = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true);}
                    if (dataLineSections[l].ToLower() == "CaveWallID".ToLower()){mapTileIDs[10] = char.Parse(dataLineSections[l + 1]);}
                    if (dataLineSections[l].ToLower() == "CaveWallColour".ToLower()){mapTileColours[10] = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true);}
                    if (dataLineSections[l].ToLower() == "CaveFloorID".ToLower()){mapTileIDs[11] = char.Parse(dataLineSections[l + 1]);}
                    if (dataLineSections[l].ToLower() == "CaveFloorColour".ToLower()){mapTileColours[11] = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true);}
                    if (dataLineSections[l].ToLower() == "CaveDoorID".ToLower()){mapTileIDs[12] = char.Parse(dataLineSections[l + 1]);}
                    if (dataLineSections[l].ToLower() == "CaveDoorColour".ToLower()){ mapTileColours[12] = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true);}
                }
            }
        }
       
        public void SetPlayerStats()
        {
            data = System.IO.File.ReadAllLines("DataStats/PlayerStats.txt");
            for (int i = 0; i <= data.Length - 1; i = i + 1)
            {
                dataLineSections = data[i].Split('=');
                for (int l = 0; l <= dataLineSections.Length - 1; l = l + 1)
                {
                    if (dataLineSections[l].ToLower() == "pmoney".ToLower()){ playerStartMoney = int.Parse(dataLineSections[l + 1]);}
                    if (dataLineSections[l].ToLower() == "pappearance".ToLower()){playerAppearance = char.Parse(dataLineSections[l+1]);}
                    if (dataLineSections[l].ToLower() == "pshield".ToLower()){ playerShield = int.Parse(dataLineSections[l + 1]);}
                    if (dataLineSections[l].ToLower() == "phealth".ToLower()){playerHealth = int.Parse(dataLineSections[l+1]);}
                    if (dataLineSections[l].ToLower() == "pname".ToLower()){ playerName = dataLineSections[l+1];}
                    if (dataLineSections[l].ToLower() == "Colour".ToLower()){playerColour = (ConsoleColor)Enum.Parse(typeof(ConsoleColor),dataLineSections[l + 1], true);}
                    if (dataLineSections[l].ToLower() == "invenslotamount".ToLower()){playerInventorySlotAmount = int.Parse(dataLineSections[l+1]);playerInventoryData = new string[playerInventorySlotAmount];}
                    if (dataLineSections[l].ToLower() == "startweapon".ToLower())
                    {
                        if (dataLineSections[l + 1] == Item.ItemType.Fist.ToString()){playerStartingWeapon = Item.ItemType.Fist.ToString();}
                        if (dataLineSections[l + 1] == Item.ItemType.BrassKnuckles.ToString()){playerStartingWeapon = Item.ItemType.BrassKnuckles.ToString();}
                        if (dataLineSections[l + 1] == Item.ItemType.BaseballBat.ToString()){playerStartingWeapon = Item.ItemType.BaseballBat.ToString();}
                        if (dataLineSections[l + 1] == Item.ItemType.Knife.ToString()){playerStartingWeapon = Item.ItemType.Knife.ToString();}
                        if (dataLineSections[l + 1] == Item.ItemType.Machete.ToString()){playerStartingWeapon = Item.ItemType.Machete.ToString();}
                        if (dataLineSections[l + 1] == Item.ItemType.Chainsaw.ToString()){playerStartingWeapon = Item.ItemType.Chainsaw.ToString();}
                    }
                    for (int s = 0; s <= playerInventorySlotAmount; s = s + 1)
                    {
                        if (dataLineSections[l].ToLower() == "slot" + s)
                        {
                            if (dataLineSections[l + 1] == Item.ItemType.FirstAidKit.ToString()){playerInventoryData[s - 1] = Item.ItemType.FirstAidKit.ToString();}
                            if (dataLineSections[l + 1] == Item.ItemType.Shield.ToString()){playerInventoryData[s - 1] = Item.ItemType.Shield.ToString();}
                            if (dataLineSections[l + 1] == Item.ItemType.BrassKnuckles.ToString()){playerInventoryData[s - 1] = Item.ItemType.BrassKnuckles.ToString();}
                            if (dataLineSections[l + 1] == Item.ItemType.BaseballBat.ToString()){playerInventoryData[s - 1] = Item.ItemType.BaseballBat.ToString();}
                            if (dataLineSections[l + 1] == Item.ItemType.Knife.ToString()){playerInventoryData[s - 1] = Item.ItemType.Knife.ToString();}
                            if (dataLineSections[l + 1] == Item.ItemType.Machete.ToString()){playerInventoryData[s - 1] = Item.ItemType.Machete.ToString();}
                            if (dataLineSections[l + 1] == Item.ItemType.Chainsaw.ToString()){playerInventoryData[s - 1] = Item.ItemType.Chainsaw.ToString();}
                        }
                    }
                }
            }

        }
    }
}
