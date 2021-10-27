using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Map
    {   
        public char[,] map = new char[Global.mapWidth, Global.mapHeight]; // size of map....
        public string[] mapData;
        public string currMapLine;
        public bool openDoors = false;
        private char mapTile;
        private int x;
        private int y;

        public Tile water = new Tile(Global.mapTileIDs[0], Global.mapTileColours[0]);
        public Tile grass = new Tile(Global.mapTileIDs[1], Global.mapTileColours[1]);
        public Tile hill = new Tile(Global.mapTileIDs[2], Global.mapTileColours[2]);
        public Tile mountain = new Tile(Global.mapTileIDs[3], Global.mapTileColours[3]);
        public Tile verticalWall = new Tile(Global.mapTileIDs[4], Global.mapTileColours[4]);
        public Tile horizontalWall = new Tile(Global.mapTileIDs[5], Global.mapTileColours[5]);
        public Tile cornerWallLeft = new Tile(Global.mapTileIDs[7], Global.mapTileColours[7]);
        public Tile cornerWallRight = new Tile(Global.mapTileIDs[6], Global.mapTileColours[6]);
        public Tile floor = new Tile(Global.mapTileIDs[8], Global.mapTileColours[8]);
        public Tile path = new Tile(Global.mapTileIDs[9], Global.mapTileColours[9]);
        public Tile caveWall = new Tile(Global.mapTileIDs[10], Global.mapTileColours[10]);
        public Tile caveFloor = new Tile(Global.mapTileIDs[11], Global.mapTileColours[11]);
        public Tile caveDoor = new Tile(Global.mapTileIDs[12], Global.mapTileColours[12]);

       //loads map
        public Map()
        {
            //mapData reads file through lines - Gets Y
            mapData = System.IO.File.ReadAllLines("DataStats/Map.txt");
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
        //make sure to add tiles to be coloured HERE.....
        public void SetMapColours(char[,] renderer, int x, int y, int offsetX, int offsetY)
        {
            grass.SetTileColour(renderer, x, y, offsetX, offsetY);
            hill.SetTileColour(renderer, x, y, offsetX, offsetY);
            mountain.SetTileColour(renderer, x, y, offsetX, offsetY);
            water.SetTileColour(renderer, x, y, offsetX, offsetY);
            horizontalWall.SetTileColour(renderer, x, y, offsetX, offsetY);
            verticalWall.SetTileColour(renderer, x, y, offsetX, offsetY);
            floor.SetTileColour(renderer, x, y, offsetX, offsetY);
            cornerWallLeft.SetTileColour(renderer, x, y, offsetX, offsetY);
            cornerWallRight.SetTileColour(renderer, x, y, offsetX, offsetY);
            path.SetTileColour(renderer, x, y, offsetX, offsetY);
            caveWall.SetTileColour(renderer, x, y, offsetX, offsetY);
            caveFloor.SetTileColour(renderer, x, y, offsetX, offsetY);
            caveDoor.SetTileColour(renderer, x, y, offsetX, offsetY);
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
       
     
        //for others to detect walls
        public bool IsWallAt(int x, int y)
        {
            //lets you walk on certain tiles but anything else, no
            if (map[x, y] == Global.mapTileIDs[8])
            {
                return false;
            }
            else if (map[x, y] == Global.mapTileIDs[9])
            {
                return false;
            }
            else if (map[x, y] == Global.mapTileIDs[11])
            {
                return false;
            }
            else if (map[x, y] == Global.mapTileIDs[1])
            {
                return false;
            }
            //without key pickup this char is a wall/door until key is collected.....
            if (openDoors == true)
            {
                if (map[x, y] == Global.mapTileIDs[12])
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
