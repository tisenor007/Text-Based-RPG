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
        static string[] ColourNames = new string[16];

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
            SetAvailableColours();
            SetMapStats();
            SetPlayerStats();
            SetLightStats();
            SetSCStats();
            SetHeavyStats();
            SetBossStats();
            SetShopStats();
            SetItemStats();
        }
        private void SetAvailableColours()
        {
            ColourNames[0] = "Black";
            ColourNames[1] = "DarkBlue";
            ColourNames[2] = "DarkGreen";
            ColourNames[3] = "DarkCyan";
            ColourNames[4] = "DarkRed";
            ColourNames[5] = "DarkMagenta";
            ColourNames[6] = "DarkYellow";
            ColourNames[7] = "Gray";
            ColourNames[8] = "DarkGray";
            ColourNames[9] = "Blue";
            ColourNames[10] = "Green";
            ColourNames[11] = "Cyan";
            ColourNames[12] = "Red";
            ColourNames[13] = "Magenta";
            ColourNames[14] = "Yellow";
            ColourNames[15] = "White";
        }
        private void SetItemStats()
        {
            data = System.IO.File.ReadAllLines("DataStats/ItemStats.txt");
            for (int i = 0; i <= data.Length - 1; i = i + 1)
            {
                dataLineSections = data[i].Split('=');
                for (int l = 0; l <= dataLineSections.Length - 1; l = l + 1)
                {
                    for (int c = 0; c <= ColourNames.Length - 1; c++)
                    {
                        if (dataLineSections[l].ToLower() == "FirstAidappearance".ToLower()) { if (isOneCharacter(dataLineSections[l + 1])) { firstAidAppearance = char.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "FirstAidHP".ToLower()) { if (isNumeric(dataLineSections[l + 1])) { firstAidHP = int.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "FirstAidColour".ToLower()) { if (dataLineSections[l + 1] == ColourNames[c]) { firstAidColour = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true); } }
                        if (dataLineSections[l].ToLower() == "Shieldappearance".ToLower()) { if (isOneCharacter(dataLineSections[l + 1])) { shieldAppearance = char.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "ShieldSP".ToLower()) { if (isNumeric(dataLineSections[l + 1])) { ShieldSP = int.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "ShieldColour".ToLower()) { if (dataLineSections[l + 1] == ColourNames[c]) { shieldColour = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true); }}
                        if (dataLineSections[l].ToLower() == "Keyappearance".ToLower()) { if (isOneCharacter(dataLineSections[l + 1])) { keyAppearance = char.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "KeyColour".ToLower()) {if (dataLineSections[l + 1] == ColourNames[c]) { keyColour = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true); }}
                        if (dataLineSections[l].ToLower() == "Valuableappearance".ToLower()) { if (isOneCharacter(dataLineSections[l + 1])) { valuableAppearance = char.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "ValuableColour".ToLower()) {if (dataLineSections[l + 1] == ColourNames[c]) { valuableColour = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true); } }
                        if (dataLineSections[l].ToLower() == "Weaponappearance".ToLower()) { if (isOneCharacter(dataLineSections[l + 1])) { weaponAppearance = char.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "WeaponColour".ToLower()) {if (dataLineSections[l + 1] == ColourNames[c]) { weaponColour = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true); }}
                        if (dataLineSections[l].ToLower() == "FistDamage".ToLower()) { if (isNumeric(dataLineSections[l + 1])) { fistDamage = int.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "BrassKnucklesDamage".ToLower()) { if (isNumeric(dataLineSections[l + 1])) { BKDamage = int.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "BaseBallBatDamage".ToLower()) { if (isNumeric(dataLineSections[l + 1])) { BBBDamage = int.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "KnifeDamage".ToLower()) { if (isNumeric(dataLineSections[l + 1])) { knifeDamage = int.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "MacheteDamage".ToLower()) { if (isNumeric(dataLineSections[l + 1])) { macheteDamage = int.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "ChainsawDamage".ToLower()) { if (isNumeric(dataLineSections[l + 1])) { chainsawDamage = int.Parse(dataLineSections[l + 1]); } }
                    }
                }
            }
        }
        private void SetShopStats()
        {
            data = System.IO.File.ReadAllLines("DataStats/ShopKeeperStats.txt");
            for (int i = 0; i <= data.Length - 1; i = i + 1)
            {
                dataLineSections = data[i].Split('=');
                for (int l = 0; l <= dataLineSections.Length - 1; l = l + 1)
                {
                    for (int c = 0; c <= ColourNames.Length - 1; c++)
                    {
                        if (dataLineSections[l].ToLower() == "shopappearance".ToLower()) { if (isOneCharacter(dataLineSections[l + 1])) { shopAppearance = char.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "startMoney".ToLower()) { if (isNumeric(dataLineSections[l + 1])) { shopStartingMoney = int.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "shopName".ToLower()) { shopName = dataLineSections[l + 1]; }
                        if (dataLineSections[l].ToLower() == "EnterMessage".ToLower()) { shopEnterMessage = dataLineSections[l + 1]; }
                        if (dataLineSections[l].ToLower() == "BetrayalMessage".ToLower()) { shopBetrayalMessage = dataLineSections[l + 1]; }
                        if (dataLineSections[l].ToLower() == "PriceRangeMin".ToLower()) { if (isNumeric(dataLineSections[l + 1])) { shopPriceMin = int.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "PriceRangeMax".ToLower()) { if (isNumeric(dataLineSections[l + 1])) { shopPriceMax = int.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "ItemAmount".ToLower()) { if (isNumeric(dataLineSections[l + 1])) { shopItemAmount = int.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "shOpYLoc".ToLower()) { if (isNumeric(dataLineSections[l + 1])) { shopYLoc = int.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "shOpXLoc".ToLower()) { if (isNumeric(dataLineSections[l + 1])) { shopXLoc = int.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "Colour".ToLower()) { if (dataLineSections[l + 1] == ColourNames[c]) { shopColour = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true); } }
                    }
                }
            }
        }
        private void SetBossStats()
        {
            data = System.IO.File.ReadAllLines("DataStats/EnemyStats.txt");
            for (int i = 0; i <= data.Length - 1; i = i + 1)
            {
                dataLineSections = data[i].Split('=');
                for (int l = 0; l <= dataLineSections.Length - 1; l = l + 1)
                {
                    for (int c = 0; c <= ColourNames.Length - 1; c++)
                    {
                        if (dataLineSections[l].ToLower() == "bossappearance".ToLower()) { if (isOneCharacter(dataLineSections[l + 1])) { bossAppearance = char.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "bossshield".ToLower()) { if (isNumeric(dataLineSections[l + 1])) { bossShield = int.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "bosshealth".ToLower()) { if (isNumeric(dataLineSections[l + 1])) { bossHealth = int.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "bossname".ToLower()) { bossName = dataLineSections[l + 1]; }
                        if (dataLineSections[l].ToLower() == "bossattackdamage".ToLower()) { if (isNumeric(dataLineSections[l + 1])) { bossAttackDamage = int.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "BossColour".ToLower()) { if (dataLineSections[l + 1] == ColourNames[c]) { bossColour = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true); } }
                    }
                }
            }
        }
        private void SetHeavyStats()
        {
            data = System.IO.File.ReadAllLines("DataStats/EnemyStats.txt");
            for (int i = 0; i <= data.Length - 1; i = i + 1)
            {
                dataLineSections = data[i].Split('=');
                for (int l = 0; l <= dataLineSections.Length - 1; l = l + 1)
                {
                    for (int c = 0; c <= ColourNames.Length - 1; c++)
                    {
                        if (dataLineSections[l].ToLower() == "heavyappearance".ToLower()) { if (isOneCharacter(dataLineSections[l + 1])) { heavyAppearance = char.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "heavyshield".ToLower()) { if (isNumeric(dataLineSections[l + 1])) { heavyShield = int.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "heavyhealth".ToLower()) { if (isNumeric(dataLineSections[l + 1])) { heavyHealth = int.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "heavyname".ToLower()) { heavyName = dataLineSections[l + 1]; }
                        if (dataLineSections[l].ToLower() == "heavyattackdamage".ToLower()) { if (isNumeric(dataLineSections[l + 1])) { heavyAttackDamage = int.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "HeavyColour".ToLower()) { if (dataLineSections[l + 1] == ColourNames[c]) { heavyColour = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true); } }
                    }
                }
            }
        }
        private void SetSCStats()
        {
            data = System.IO.File.ReadAllLines("DataStats/EnemyStats.txt");
            for (int i = 0; i <= data.Length - 1; i = i + 1)
            {
                dataLineSections = data[i].Split('=');
                for (int l = 0; l <= dataLineSections.Length - 1; l = l + 1)
                {
                    for (int c = 0; c <= ColourNames.Length - 1; c++)
                    {
                        if (dataLineSections[l].ToLower() == "scappearance".ToLower()) { if (isOneCharacter(dataLineSections[l + 1])) { SCAppearance = char.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "scshield".ToLower()) { if (isNumeric(dataLineSections[l + 1])) { SCShield = int.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "schealth".ToLower()) { if (isNumeric(dataLineSections[l + 1])) { SCHealth = int.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "scname".ToLower()) { SCName = dataLineSections[l + 1]; }
                        if (dataLineSections[l].ToLower() == "scattackdamage".ToLower()) { if (isNumeric(dataLineSections[l + 1])) { SCAttackDamage = int.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "SCColour".ToLower()) { if (dataLineSections[l + 1] == ColourNames[c]) { SCColour = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true); } }
                    }
                }
            }
        }

        private void SetLightStats()
        {
            data = System.IO.File.ReadAllLines("DataStats/EnemyStats.txt");
            for (int i = 0; i <= data.Length - 1; i = i + 1)
            {
                dataLineSections = data[i].Split('=');
                for (int l = 0; l <= dataLineSections.Length - 1; l = l + 1)
                {
                    for (int c = 0; c <= ColourNames.Length - 1; c++)
                    {
                        if (dataLineSections[l].ToLower() == "lightappearance".ToLower()) { if (isOneCharacter(dataLineSections[l + 1])) { lightAppearance = char.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "lightshield".ToLower()) { if (isNumeric(dataLineSections[l + 1])) { lightShield = int.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "lighthealth".ToLower()) { if (isNumeric(dataLineSections[l + 1])) { lightHealth = int.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "lightname".ToLower()) { lightName = dataLineSections[l + 1]; }
                        if (dataLineSections[l].ToLower() == "lightattackdamage".ToLower()) { if (isNumeric(dataLineSections[l + 1])) { lightAttackDamage = int.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "LightColour".ToLower()) { if (dataLineSections[l + 1] == ColourNames[c]) { lightColour = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true); } }
                    }
                }
            }
        }
        private void SetMapStats()
        {
            data = System.IO.File.ReadAllLines("DataStats/MapStats.txt");
            for (int i = 0; i <= data.Length - 1; i = i + 1)
            {
                dataLineSections = data[i].Split(';');
                for (int l = 0; l <= dataLineSections.Length - 1; l = l + 1)
                {
                    for (int c = 0; c <= ColourNames.Length - 1; c++)
                    {
                        if (dataLineSections[l].ToLower() == "width".ToLower()) { if (isNumeric(dataLineSections[l + 1])) { mapWidth = int.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "height".ToLower()) { if (isNumeric(dataLineSections[l + 1])) { mapHeight = int.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "WaterID".ToLower()) { if (isOneCharacter(dataLineSections[l + 1])) { mapTileIDs[0] = char.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "WaterColour".ToLower()) { if (dataLineSections[l + 1] == ColourNames[c]) { mapTileColours[0] = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true); } }
                        if (dataLineSections[l].ToLower() == "GrassID".ToLower()) { if (isOneCharacter(dataLineSections[l + 1])) { mapTileIDs[1] = char.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "GrassColour".ToLower()) { if (dataLineSections[l + 1] == ColourNames[c]) { mapTileColours[1] = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true); } }
                        if (dataLineSections[l].ToLower() == "HillID".ToLower()) { if (isOneCharacter(dataLineSections[l + 1])) { mapTileIDs[2] = char.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "HillColour".ToLower()) { if (dataLineSections[l + 1] == ColourNames[c]) { mapTileColours[2] = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true); } }
                        if (dataLineSections[l].ToLower() == "mountainID".ToLower()) { if (isOneCharacter(dataLineSections[l + 1])) { mapTileIDs[3] = char.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "mountainColour".ToLower()) { if (dataLineSections[l + 1] == ColourNames[c]) { mapTileColours[3] = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true); } }
                        if (dataLineSections[l].ToLower() == "VertWallID".ToLower()) { if (isOneCharacter(dataLineSections[l + 1])) { mapTileIDs[4] = char.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "VertWallColour".ToLower()) { if (dataLineSections[l + 1] == ColourNames[c]) { mapTileColours[4] = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true); } }
                        if (dataLineSections[l].ToLower() == "HorizWallID".ToLower()) { if (isOneCharacter(dataLineSections[l + 1])) { mapTileIDs[5] = char.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "HorizWallColour".ToLower()) { if (dataLineSections[l + 1] == ColourNames[c]) { mapTileColours[5] = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true); } }
                        if (dataLineSections[l].ToLower() == "RightCornerWallID".ToLower()) { if (isOneCharacter(dataLineSections[l + 1])) { mapTileIDs[6] = char.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "RightCornerWallColour".ToLower()) { if (dataLineSections[l + 1] == ColourNames[c]) { mapTileColours[6] = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true); } }
                        if (dataLineSections[l].ToLower() == "LeftCornerWallID".ToLower()) { if (isOneCharacter(dataLineSections[l + 1])) { mapTileIDs[7] = char.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "LeftCornerWallColour".ToLower()) { if (dataLineSections[l + 1] == ColourNames[c]) { mapTileColours[7] = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true); } }
                        if (dataLineSections[l].ToLower() == "floorID".ToLower()) { if (isOneCharacter(dataLineSections[l + 1])) { mapTileIDs[8] = char.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "floorColour".ToLower()) { if (dataLineSections[l + 1] == ColourNames[c]) { mapTileColours[8] = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true); } }
                        if (dataLineSections[l].ToLower() == "PathID".ToLower()) { if (isOneCharacter(dataLineSections[l + 1])) { mapTileIDs[9] = char.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "PathColour".ToLower()) { if (dataLineSections[l + 1] == ColourNames[c]) { mapTileColours[9] = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true); } }
                        if (dataLineSections[l].ToLower() == "CaveWallID".ToLower()) { if (isOneCharacter(dataLineSections[l + 1])) { mapTileIDs[10] = char.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "CaveWallColour".ToLower()) { if (dataLineSections[l + 1] == ColourNames[c]) { mapTileColours[10] = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true); } }
                        if (dataLineSections[l].ToLower() == "CaveFloorID".ToLower()) { if (isOneCharacter(dataLineSections[l + 1])) { mapTileIDs[11] = char.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "CaveFloorColour".ToLower()) { if (dataLineSections[l + 1] == ColourNames[c]) { mapTileColours[11] = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true); } }
                        if (dataLineSections[l].ToLower() == "CaveDoorID".ToLower()) { if (isOneCharacter(dataLineSections[l + 1])) { mapTileIDs[12] = char.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "CaveDoorColour".ToLower()) { if (dataLineSections[l + 1] == ColourNames[c]) { mapTileColours[12] = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true); } }
                    }
                }
            }
        }
       
        private void SetPlayerStats()
        {
            data = System.IO.File.ReadAllLines("DataStats/PlayerStats.txt");
            for (int i = 0; i <= data.Length - 1; i = i + 1)
            {
                dataLineSections = data[i].Split('=');
                for (int l = 0; l <= dataLineSections.Length - 1; l = l + 1)
                {
                    for (int c = 0; c <= ColourNames.Length - 1; c++)
                    {
                        if (dataLineSections[l].ToLower() == "pmoney".ToLower()) { if (isNumeric(dataLineSections[l + 1])) { playerStartMoney = int.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "pappearance".ToLower()) { if (isOneCharacter(dataLineSections[l + 1])) { playerAppearance = char.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "pshield".ToLower()) { if (isNumeric(dataLineSections[l + 1])) { playerShield = int.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "phealth".ToLower()) { if (isNumeric(dataLineSections[l + 1])) { playerHealth = int.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "pname".ToLower()) { playerName = dataLineSections[l + 1]; }
                        if (dataLineSections[l].ToLower() == "Colour".ToLower()) { if (dataLineSections[l + 1] == ColourNames[c]) { playerColour = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true); } }
                        if (dataLineSections[l].ToLower() == "invenslotamount".ToLower()) { if (isNumeric(dataLineSections[l + 1])) { playerInventorySlotAmount = int.Parse(dataLineSections[l + 1]); playerInventoryData = new string[playerInventorySlotAmount]; } }
                        if (dataLineSections[l].ToLower() == "startweapon".ToLower())
                        {
                            if (dataLineSections[l + 1] == Item.ItemType.Fist.ToString()) { playerStartingWeapon = Item.ItemType.Fist.ToString(); }
                            if (dataLineSections[l + 1] == Item.ItemType.BrassKnuckles.ToString()) { playerStartingWeapon = Item.ItemType.BrassKnuckles.ToString(); }
                            if (dataLineSections[l + 1] == Item.ItemType.BaseballBat.ToString()) { playerStartingWeapon = Item.ItemType.BaseballBat.ToString(); }
                            if (dataLineSections[l + 1] == Item.ItemType.Knife.ToString()) { playerStartingWeapon = Item.ItemType.Knife.ToString(); }
                            if (dataLineSections[l + 1] == Item.ItemType.Machete.ToString()) { playerStartingWeapon = Item.ItemType.Machete.ToString(); }
                            if (dataLineSections[l + 1] == Item.ItemType.Chainsaw.ToString()) { playerStartingWeapon = Item.ItemType.Chainsaw.ToString(); }
                        }
                        for (int s = 0; s <= playerInventorySlotAmount; s = s + 1)
                        {
                            if (dataLineSections[l].ToLower() == "slot" + s)
                            {
                                if (dataLineSections[l + 1] == Item.ItemType.FirstAidKit.ToString()) { playerInventoryData[s - 1] = Item.ItemType.FirstAidKit.ToString(); }
                                if (dataLineSections[l + 1] == Item.ItemType.Shield.ToString()) { playerInventoryData[s - 1] = Item.ItemType.Shield.ToString(); }
                                if (dataLineSections[l + 1] == Item.ItemType.BrassKnuckles.ToString()) { playerInventoryData[s - 1] = Item.ItemType.BrassKnuckles.ToString(); }
                                if (dataLineSections[l + 1] == Item.ItemType.BaseballBat.ToString()) { playerInventoryData[s - 1] = Item.ItemType.BaseballBat.ToString(); }
                                if (dataLineSections[l + 1] == Item.ItemType.Knife.ToString()) { playerInventoryData[s - 1] = Item.ItemType.Knife.ToString(); }
                                if (dataLineSections[l + 1] == Item.ItemType.Machete.ToString()) { playerInventoryData[s - 1] = Item.ItemType.Machete.ToString(); }
                                if (dataLineSections[l + 1] == Item.ItemType.Chainsaw.ToString()) { playerInventoryData[s - 1] = Item.ItemType.Chainsaw.ToString(); }
                            }
                        }
                    }
                }
            }

        }
        public static bool isNumeric(String stringToCheck)
        {
            int intValue;

            if (stringToCheck == null || stringToCheck.Equals(""))
            {
                return false;
            }

            try
            {
                intValue = int.Parse(stringToCheck);
                return true;
            }
            catch (FormatException)
            {

            }
            return false;
        }
        public static bool isOneCharacter(string stringToCheck)
        {
            if (stringToCheck.Length <= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //public static bool isColourName(string stringToCheck)
        //{
        //    for (int c = 0; c< ColourNames.Length - 1; c++)
        //    {
        //        if (stringToCheck == ColourNames[c])
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    return false;
        //}
    }
}
