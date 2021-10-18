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
        public static int playerInventorySlots;
        //public static 
        public static Item[] playerInventorySlotData;
        public Global()
        {
            SetPlayerStats();
        }
       
        public void SetPlayerStats()
        {
            Data = System.IO.File.ReadAllLines("PlayerStats.txt");
            DataLine = Data[1];
            DataLineSections = DataLine.Split(';');
            playerInventorySlots = int.Parse(DataLineSections[0]);
            DataLine = Data[7];
            DataLineSections = DataLine.Split(';');
            playerHealth = int.Parse(DataLineSections[0]);
            playerShield = int.Parse(DataLineSections[1]);
            playerAppearance = char.Parse(DataLineSections[2]);
            playerName = DataLineSections[3];
            DataLine = Data[4];
            DataLineSections = DataLine.Split(';');
            for (int i = 0; i <= playerInventorySlots; i++)
            {
                //if ()
            }
        }
    }
}
