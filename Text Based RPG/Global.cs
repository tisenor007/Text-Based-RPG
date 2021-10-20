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
        static string[,] allData = new string[Data.Length, DataLine.Length];
        static string DataLine;
        static string[] DataLineSections;
        static char dataTile;
        

        public static int playerHealth;
        public static int playerShield;
        public static char playerAppearance;
        public static string playerName;
        public static int playerInventorySlotAmount;
        public static string[] playerInventoryData;
        public Global()
        {
            Data = System.IO.File.ReadAllLines("PlayerStats.txt");
            for (int y = 0; y <= Data.Length - 1; y = y + 1)
            {
                DataLine = Data[y];
                for (int x = 0; x <= DataLine.Length - 1; x = x + 1)
                {
                    dataTile = DataLine[x];
                    //allData[y,x] = dataTile;
                    if (allData[1,x] == "1")
                    {
                        DataLine.Split('=');

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

            for (int i = 0; i <= playerInventorySlotAmount - 1; i++)
            {

                if (DataLineSections[i] == Item.ItemType.FirstAidKit.ToString())
                {
                    playerInventoryData[i] = Item.ItemType.FirstAidKit.ToString();
                }
                if (DataLineSections[i] == Item.ItemType.Shield.ToString())
                {
                    playerInventoryData[i] = Item.ItemType.Shield.ToString();
                }
                if (DataLineSections[i] == Item.ItemType.BrassKnuckles.ToString())
                {
                    playerInventoryData[i] = Item.ItemType.BrassKnuckles.ToString();
                }
                if (DataLineSections[i] == Item.ItemType.BaseballBat.ToString())
                {
                    playerInventoryData[i] = Item.ItemType.BaseballBat.ToString();
                }
                if (DataLineSections[i] == Item.ItemType.Knife.ToString())
                {
                    playerInventoryData[i] = Item.ItemType.Knife.ToString();
                }
                if (DataLineSections[i] == Item.ItemType.Machete.ToString())
                {
                    playerInventoryData[i] = Item.ItemType.Machete.ToString();
                }
                if (DataLineSections[i] == Item.ItemType.Chainsaw.ToString())
                {
                    playerInventoryData[i] = Item.ItemType.Chainsaw.ToString();
                }
            }

        }
    }
}
