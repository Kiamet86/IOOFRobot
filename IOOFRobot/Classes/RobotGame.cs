using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOOFRobot.Classes
{
    /// <summary>
    /// Passes input from user to the Robot.
    /// </summary>
    class RobotGame
    {
        public RobotGame()
        {

        }

        /// <summary>
        /// Controls the flow of the game.
        /// </summary>
        public void Play()
        {
            var robot = new Robot();

            Console.WriteLine("Welcome to IOOF-Robot. \r\nPress Enter to start, " +
                "or type 'PLACE X,Y,F' to choose a starting position.\n" +
                "\r\nChoose an X and Y value between 0 and 4. " +
                "\r\nChoose a facing of NORTH, EAST, SOUTH, or WEST." +
                "\r\ne.g. 'PLACE 1,3,NORTH'");

            // Loops through input commands from the user until they type QUIT.
            // Switch statement reads the command and passes it to Robot object.

            var input = Console.ReadLine().ToUpper();
            
            while (input != "QUIT")
            {
                var inputArray = input.Split(new char[] { ' ', ',' });

                switch (inputArray[0])
                {
                    case "PLACE":
                        try
                        {
                            robot.Place(Convert.ToInt32(inputArray[1]),
                                    Convert.ToInt32(inputArray[2]),
                                    inputArray[3]);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid X or Y co-ordinate. Please use 0 - 4 only.");
                        }
                        
                        break;

                    case "MOVE":
                        robot.Move();
                        break;

                    case "LEFT":
                        robot.Left();
                        break;

                    case "RIGHT":
                        robot.Right();
                        break;

                    case "REPORT":
                        robot.Report();
                        break;

                    default:
                        Console.WriteLine("Invalid input." +
                            "\r\nPLACE X,Y,F = Place Robot on Grid." +
                            "\r\nMOVE = Moves Robot forward in direction it's facing." +
                            "\r\nLEFT = Turns Robot left." +
                            "\r\nRIGHT = Turns Robot right." +
                            "\r\nREPORT = Show Robot's current positiong and facing.");
                        break;

                }

                input = Console.ReadLine().ToUpper();
            }

            Console.WriteLine("Thanks for playing!");
            
        }
    }
}
