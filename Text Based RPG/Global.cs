using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Global
    {
        static string[] Data;
        static string DataLine;
        static string[] DataLineSections;
        

        public static int playerHealth;
        public static int playerShield;
        public static char playerAppearance;
        public static string playerName;
        public static int playerInventorySlotAmount;
        public static string[] playerInventoryData;
        public Global()
        {
            SetPlayerStats();
            Data = System.IO.File.ReadAllLines("PlayerStats.txt");
            for (int i = 0; i <= Data.Length - 1; i = i + 1)
            {
                DataLineSections = Data[i].Split('=');
                for (int l = 0; l <= DataLineSections.Length - 1; l = l + 1)
                {
                    for (int s = 0; s <= playerInventorySlotAmount - 1; s = s + 1)
                    {
                        if (DataLineSections[l].ToLower() == "slot" + s)
                        {
                            if (DataLineSections[l + 1] == Item.ItemType.FirstAidKit.ToString())
                            {
                                playerInventoryData[s -1] = Item.ItemType.FirstAidKit.ToString();
                            }
                        }
                    }
                }
            }
        }
       
        public void SetPlayerStats()
        {
            Data = System.IO.File.ReadAllLines("PlayerStats.txt");
            DataLine = Data[1];
            DataLineSections = DataLine.Split(';');
            playerInventorySlotAmount = int.Parse(DataLineSections[0]);
            DataLine = Data[7];
            DataLineSections = DataLine.Split(';');
            playerHealth = int.Parse(DataLineSections[0]);
            playerShield = int.Parse(DataLineSections[1]);
            playerAppearance = char.Parse(DataLineSections[2]);
            playerName = DataLineSections[3];
            DataLine = Data[4];
            DataLineSections = DataLine.Split(';');
            playerInventoryData = new string[playerInventorySlotAmount];

            //for (int i = 0; i <= playerInventorySlotAmount - 1; i++)
            //{

            //    if (DataLineSections[i] == Item.ItemType.FirstAidKit.ToString())
            //    {
            //        playerInventoryData[i] = Item.ItemType.FirstAidKit.ToString();
            //    }
            //    if (DataLineSections[i] == Item.ItemType.Shield.ToString())
            //    {
            //        playerInventoryData[i] = Item.ItemType.Shield.ToString();
            //    }
            //    if (DataLineSections[i] == Item.ItemType.BrassKnuckles.ToString())
            //    {
            //        playerInventoryData[i] = Item.ItemType.BrassKnuckles.ToString();
            //    }
            //    if (DataLineSections[i] == Item.ItemType.BaseballBat.ToString())
            //    {
            //        playerInventoryData[i] = Item.ItemType.BaseballBat.ToString();
            //    }
            //    if (DataLineSections[i] == Item.ItemType.Knife.ToString())
            //    {
            //        playerInventoryData[i] = Item.ItemType.Knife.ToString();
            //    }
            //    if (DataLineSections[i] == Item.ItemType.Machete.ToString())
            //    {
            //        playerInventoryData[i] = Item.ItemType.Machete.ToString();
            //    }
            //    if (DataLineSections[i] == Item.ItemType.Chainsaw.ToString())
            //    {
            //        playerInventoryData[i] = Item.ItemType.Chainsaw.ToString();
            //    }
            //}

        }
    }
}
