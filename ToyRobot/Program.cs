using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToyRobot
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write(">");
                string command = Console.ReadLine();

                if (command == "q")
                    break;
                
            }
        }
    }
}
