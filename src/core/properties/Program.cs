﻿using System;
using System.Text;

namespace Otiose
{
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            uint secondsToSleep = 3;

            while (secondsToSleep > 0)
            {
                Console.WriteLine($"{secondsToSleep} seconds until launch.");
                System.Threading.Thread.Sleep(1000);

                secondsToSleep--;
            }

            using (var game = new GameCore())
                game.Run();
        }
    }
}
