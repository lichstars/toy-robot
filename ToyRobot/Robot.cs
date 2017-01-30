using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToyRobot
{
    /* Robot class is responsible for receiving instructions and actioning the appropriate move.*/
    public class Robot
    {
        private const int TABLE_SIZE = 5;
        private int? x;
        private int? y;
        private string direction;

        /* Send() will receive commands and determine which method to call for the Robot to action upon.
         * If the Robot has not been placed on a table yet, the user will be warned with a message.
         */
        public bool send(string command)
        {
            bool response = true;

            if (command.StartsWith("PLACE"))
                place(command);

            else
            {
                if (!isRobotOnTable(this.x, this.y))
                {
                    Console.WriteLine("Command ignored. Robot must be placed on the table first.");
                    return false;
                }
                if (command == "MOVE")
                    move();

                if (command == "REPORT")
                    Console.WriteLine(report());
                

            }
            return response;
        }

        /* Function to check if the Robot is currently on the table
         * */
        private bool isRobotOnTable(int? x, int? y)
        {
            if (!x.HasValue || !y.HasValue || x < 0 || y < 0 || x >= TABLE_SIZE || y >= TABLE_SIZE)
                return false;

            return true;
        }

        /* Before moving a Robot, check if the new location is on the table. If it is not on the table a
         * warning message is sent to the user.
         */
        private bool isMoveValid(int xPos, int yPos, string direction, string command)
        {
            if (!isRobotOnTable(xPos, yPos))
            {
                Console.WriteLine("That move will move the Robot off the table. Try again.");
                return false;
            }

            return true;
        }

        /* Place will put the Robot on the table in location, which is a composite of position X, Y and facing DIRECTION.
         * The acceptable format of a command is "PLACE 1,1,NORTH". If the location is located on the table the Robot will
         * be placed in the new location, otherwise the command will be ignored.
         * */
        public bool place(string command)
        {
            string[] keywords = command.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string[] location = keywords[1].Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            int xPos = Convert.ToInt16(location[0]);
            int yPos = Convert.ToInt16(location[1]);
            string direction = location[2];

            if (!isMoveValid(xPos, yPos, direction, "PLACE"))
                return false;
                        
            this.x = xPos;
            this.y = yPos;
            this.direction = direction;
            
            return true;            
        }

        /* Move will move the Robot one unit forward in the direction it is currently facing. 
         * If the Robot is not on the table or if the move pushes the Robot off the table the move will be ignored. 
         * */
        private bool move()
        {
            return true;
        }

        public string report()
        {
            return String.Format("{0},{1},{2}", this.x, this.y, this.direction);
            
        }

    }
}
