﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows
{
    class Program
    {
        static void Main(string[] args)
        {
            BullsAndCowsPlayerOne playerOne = new BullsAndCowsPlayerOne(6);
            playerOne.Run();            
            
            Console.ReadLine();
        }



    }
}
