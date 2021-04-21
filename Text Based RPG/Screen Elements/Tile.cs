using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Tile
    {
        public char tileCharacter;
        public ConsoleColor tileColour;

        public Tile(char character, ConsoleColor colour)
        {
            tileCharacter = character;
            tileColour = colour;
        }

        public void SetTileColour(char[,] renderer, int x, int y, int offsetX, int offsetY)
        {
            if (renderer[x + offsetX, y + offsetY] == tileCharacter)
            {
                Console.ForegroundColor = tileColour;
            }
            else
            {
                //Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }
}
