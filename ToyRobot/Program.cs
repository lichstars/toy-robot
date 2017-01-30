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

            Console.WriteLine(  "Toy Robot Simulator. \n" +
                                "\nRobot commands: " +
                                "\nPLACE X,Y,F : Place Robot on table" +
                                "\nMOVE: Move Robot one unit in direction it is facing" + 
                                "\nLEFT: Rotate Robot left by 90 degrees" + 
                                "\nRIGHT: Rotate Robot right by 90 degrees" + 
                                "\nREPORT: Report Robot position" + 
                                "\nEXIT: Quit simulator\n");

            while (true)
            {
                Console.Write(">");
                string command = Console.ReadLine();

                if (command == "EXIT")
                    break;

                if (robotParser.parse(command) == false)
                    Console.WriteLine("Robot does not recognise that command.");
                
            }
        }
    }
}
