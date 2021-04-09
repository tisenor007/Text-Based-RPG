using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Map
    {   
        public char[,] map = new char[269, 63]; // size of map....
        public string[] mapData;
        public string currMapLine;
        public bool openDoors = false;
        private char mapTile;
        private int x;
        private int y;
        
       //loads map
        public Map()
        {
            //mapData reads file through lines - Gets Y
            mapData = System.IO.File.ReadAllLines("Map.txt");
            for (y = 0; y <= mapData.Length - 1; y = y + 1)
            { 
                //string created to be = to 1 / current line of map
                currMapLine = mapData[y];
                for (x = 0; x <= currMapLine.Length - 1; x = x + 1)
                {
                    //char mapTile = mapData[y][x];
                    //map tile is = to map line split by x
                     mapTile = currMapLine[x];
                    //map[x,y] is = to map tile for exact location
                    map[x, y] = mapTile;  
                }
            }
        }
       //draws map to the renderer
        public void DrawToRender(char[,] renderer)
        {
            for (int i = 0; i < mapData.Length; i++)
            {
                for (int d = 0; d < currMapLine.Length; d++)
                {
                    renderer[d, i] = map[d, i]; 
                }
            }
        }
        //DO NOT NEED UPDATE NO MORE
     
        //for others to detect walls
        public bool IsWallAt(int x, int y)
        {
            //lets you walk on certain tiles but anything else, no
            if (map[x, y] == '=')
            {
                return false;
            }
            else if (map[x, y] == '#')
            {
                return false;
            }
            else if (map[x, y] == '░')
            {
                return false;
            }
            else if (map[x, y] == '`')
            {
                return false;
            }
            //without key pickup this char is a wall/door until key is collected.....
            if (openDoors == true)
            {
                if (map[x, y] == '&')
                {
                    return false;
                }
                return true;
            }
            else
            {
                return true;
            }
        }
    }
}
