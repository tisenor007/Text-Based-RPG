﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            GameManager gameManager = new GameManager();
            //runs game through game manager.....
            gameManager.RunGame();

            Console.ReadKey(true);
        }
    }
}
