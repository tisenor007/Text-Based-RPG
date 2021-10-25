using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Global
    {
        static string[] data;
        static string[] dataLineSections;

        public static int playerHealth;
        public static int playerShield;
        public static char playerAppearance;
        public static string playerName;
        public static int playerInventorySlotAmount;
        public static string[] playerInventoryData;
        public static string playerStartingWeapon;

        public static int mapWidth;
        public static int mapHeight;

        public static int lightHealth;
        public static int lightShield;
        public static char lightAppearance;
        public static string lightName;
        public static int lightAttackDamage;

        public static int SCHealth;
        public static int SCShield;
        public static char SCAppearance;
        public static string SCName;
        public static int SCAttackDamage;

        public static int heavyHealth;
        public static int heavyShield;
        public static char heavyAppearance;
        public static string heavyName;
        public static int heavyAttackDamage;

        public static int bossHealth;
        public static int bossShield;
        public static char bossAppearance;
        public static string bossName;
        public static int bossAttackDamage;
        public Global()
        {
            SetMapStats();
            SetPlayerStats();
            SetLightStats();
            SetSCStats();
            SetHeavyStats();
            SetBossStats();
        }
        public void SetBossStats()
        {
            data = System.IO.File.ReadAllLines("DataStats/EnemyStats.txt");
            for (int i = 0; i <= data.Length - 1; i = i + 1)
            {
                dataLineSections = data[i].Split('=');
                for (int l = 0; l <= dataLineSections.Length - 1; l = l + 1)
                {
                    if (dataLineSections[l].ToLower() == "bossappearance")
                    {
                        bossAppearance = char.Parse(dataLineSections[l + 1]);
                    }
                    if (dataLineSections[l].ToLower() == "bossshield")
                    {
                        bossShield = int.Parse(dataLineSections[l + 1]);
                    }
                    if (dataLineSections[l].ToLower() == "bosshealth")
                    {
                        bossHealth = int.Parse(dataLineSections[l + 1]);
                    }
                    if (dataLineSections[l].ToLower() == "bossname")
                    {
                        bossName = dataLineSections[l + 1];
                    }
                    if (dataLineSections[l].ToLower() == "bossattackdamage")
                    {
                        bossAttackDamage = int.Parse(dataLineSections[l + 1]);
                    }
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
                    if (dataLineSections[l].ToLower() == "heavyappearance")
                    {
                        heavyAppearance = char.Parse(dataLineSections[l + 1]);
                    }
                    if (dataLineSections[l].ToLower() == "heavyshield")
                    {
                        heavyShield = int.Parse(dataLineSections[l + 1]);
                    }
                    if (dataLineSections[l].ToLower() == "heavyhealth")
                    {
                        heavyHealth = int.Parse(dataLineSections[l + 1]);
                    }
                    if (dataLineSections[l].ToLower() == "heavyname")
                    {
                        heavyName = dataLineSections[l + 1];
                    }
                    if (dataLineSections[l].ToLower() == "heavyattackdamage")
                    {
                        heavyAttackDamage = int.Parse(dataLineSections[l + 1]);
                    }
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
                    if (dataLineSections[l].ToLower() == "scappearance")
                    {
                        SCAppearance = char.Parse(dataLineSections[l + 1]);
                    }
                    if (dataLineSections[l].ToLower() == "scshield")
                    {
                        SCShield = int.Parse(dataLineSections[l + 1]);
                    }
                    if (dataLineSections[l].ToLower() == "schealth")
                    {
                        SCHealth = int.Parse(dataLineSections[l + 1]);
                    }
                    if (dataLineSections[l].ToLower() == "scname")
                    {
                        SCName = dataLineSections[l + 1];
                    }
                    if (dataLineSections[l].ToLower() == "scattackdamage")
                    {
                        SCAttackDamage = int.Parse(dataLineSections[l + 1]);
                    }
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
                    if (dataLineSections[l].ToLower() == "lightappearance")
                    {
                        lightAppearance = char.Parse(dataLineSections[l + 1]);
                    }
                    if (dataLineSections[l].ToLower() == "lightshield")
                    {
                        lightShield = int.Parse(dataLineSections[l + 1]);
                    }
                    if (dataLineSections[l].ToLower() == "lighthealth")
                    {
                        lightHealth = int.Parse(dataLineSections[l + 1]);
                    }
                    if (dataLineSections[l].ToLower() == "lightname")
                    {
                        lightName = dataLineSections[l + 1];
                    }
                    if (dataLineSections[l].ToLower() == "lightattackdamage")
                    {
                        lightAttackDamage = int.Parse(dataLineSections[l + 1]);
                    }
                }
            }
        }
        public void SetMapStats()
        {
            data = System.IO.File.ReadAllLines("DataStats/MapStats.txt");
            for (int i = 0; i <= data.Length - 1; i = i + 1)
            {
                dataLineSections = data[i].Split('=');
                for (int l = 0; l <= dataLineSections.Length - 1; l = l + 1)
                {
                    if (dataLineSections[l].ToLower() == "width")
                    {
                        mapWidth = int.Parse(dataLineSections[l + 1]);
                    }
                    if (dataLineSections[l].ToLower() == "height")
                    {
                        mapHeight = int.Parse(dataLineSections[l + 1]);
                    }
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
                    if (dataLineSections[l].ToLower() == "pappearance")
                    {
                        playerAppearance = char.Parse(dataLineSections[l+1]);
                    }
                    if (dataLineSections[l].ToLower() == "pshield")
                    {
                        playerShield = int.Parse(dataLineSections[l + 1]);
                    }
                    if (dataLineSections[l].ToLower() == "phealth")
                    {
                        playerHealth = int.Parse(dataLineSections[l+1]);
                    }
                    if (dataLineSections[l].ToLower() == "pname")
                    {
                        playerName = dataLineSections[l+1];
                    }
                    if (dataLineSections[l].ToLower() == "invenslotamount")
                    {
                        playerInventorySlotAmount = int.Parse(dataLineSections[l+1]);
                        playerInventoryData = new string[playerInventorySlotAmount];
                    }
                    if (dataLineSections[l].ToLower() == "startweapon")
                    {
                        if (dataLineSections[l + 1] == Item.ItemType.Fist.ToString())
                        {
                            playerStartingWeapon = Item.ItemType.Fist.ToString();
                        }
                        if (dataLineSections[l + 1] == Item.ItemType.BrassKnuckles.ToString())
                        {
                            playerStartingWeapon = Item.ItemType.BrassKnuckles.ToString();
                        }
                        if (dataLineSections[l + 1] == Item.ItemType.BaseballBat.ToString())
                        {
                            playerStartingWeapon = Item.ItemType.BaseballBat.ToString();
                        }
                        if (dataLineSections[l + 1] == Item.ItemType.Knife.ToString())
                        {
                            playerStartingWeapon = Item.ItemType.Knife.ToString();
                        }
                        if (dataLineSections[l + 1] == Item.ItemType.Machete.ToString())
                        {
                            playerStartingWeapon = Item.ItemType.Machete.ToString();
                        }
                        if (dataLineSections[l + 1] == Item.ItemType.Chainsaw.ToString())
                        {
                            playerStartingWeapon = Item.ItemType.Chainsaw.ToString();
                        }
                    }
                    for (int s = 0; s <= playerInventorySlotAmount; s = s + 1)
                    {
                        if (dataLineSections[l].ToLower() == "slot" + s)
                        {
                            if (dataLineSections[l + 1] == Item.ItemType.FirstAidKit.ToString())
                            {
                                playerInventoryData[s - 1] = Item.ItemType.FirstAidKit.ToString();
                            }
                            if (dataLineSections[l + 1] == Item.ItemType.Shield.ToString())
                            {
                                playerInventoryData[s - 1] = Item.ItemType.Shield.ToString();
                            }
                            if (dataLineSections[l + 1] == Item.ItemType.BrassKnuckles.ToString())
                            {
                                playerInventoryData[s - 1] = Item.ItemType.BrassKnuckles.ToString();
                            }
                            if (dataLineSections[l + 1] == Item.ItemType.BaseballBat.ToString())
                            {
                                playerInventoryData[s - 1] = Item.ItemType.BaseballBat.ToString();
                            }
                            if (dataLineSections[l + 1] == Item.ItemType.Knife.ToString())
                            {
                                playerInventoryData[s - 1] = Item.ItemType.Knife.ToString();
                            }
                            if (dataLineSections[l + 1] == Item.ItemType.Machete.ToString())
                            {
                                playerInventoryData[s - 1] = Item.ItemType.Machete.ToString();
                            }
                            if (dataLineSections[l + 1] == Item.ItemType.Chainsaw.ToString())
                            {
                                playerInventoryData[s - 1] = Item.ItemType.Chainsaw.ToString();
                            }
                        }
                    }
                }
            }

        }
    }
}
