using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToyRobot
{
    /*RobotParser is responsible for parsing strings and determining if they are valid for the Robot to process.*/
    public class RobotParser
    {        
        public Robot robot { get; set; }
        
        public RobotParser(Robot robot)
        {
            this.robot = robot;
        }
        /* Parse is the public interface into this class and it will parse strings that it is passed.
         * It will only send valid instructions to the robot to action on. Commands that are not accepted
         * by the Robot will result in the function returning false.
         */
        public bool parse(string instruction)
        {
            string[] commandArray = instruction.Split();

            if (commandArray.Count() <= 0)
                return false;

            string command = commandArray[0];

            if (Constants.ACCEPTED_COMMANDS.Contains(command) == false)
                return false;

            if (command == "PLACE")
            {
                string[] keywords = instruction.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                if (keywords.Count() != 2)
                    return false;

                string[] location = keywords[1].Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                if (location.Count() != 3)
                    return false;

                int value;
                if (int.TryParse(location[0], out value) == false)
                    return false;

                if (int.TryParse(location[1], out value) == false)
                    return false;

                if (Constants.ACCEPTED_DIRECTIONS.Contains(location[2]) == false)
                    return false;
            }

            this.robot.send(instruction);

            return true;

        }
    }
}
