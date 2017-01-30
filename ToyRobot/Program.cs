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
            RobotParser robotParser = new RobotParser(new Robot());

            while (true)
            {
                Console.Write(">");
                string command = Console.ReadLine();

                if (command == "q")
                    break;

                if (robotParser.parse(command) == false)
                    Console.WriteLine("Robot does not recognise that command.");
                
            }
        }
    }
}
