using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOOFRobot.Classes
{
    public class Robot
    {
        private int[] position;
        private string facing;
        private bool placed;
        private string reportString;

        public int[] Position
        {
            get { return position; }
            set { position = value; }
        }
        public string Facing
        {
            get { return facing; }
            set { facing = value; }
        }
        public bool Placed
        {
            get { return placed; }
            set { placed = value; }
        }
        public string ReportString
        {
            get { return reportString; }
            set { reportString = value; }
        }


        public Robot()
        {
            Position = new int[] { 0, 0 };
            Facing = "NORTH";
            Placed = false;
        }

        /// <summary>
        /// Checks that the Robot is Placed.
        /// </summary>
        /// <returns></returns>
        private bool IsPlaced()
        {
            if (!placed)
            {
                Console.WriteLine("You must PLACE your robot first.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks that Robot's position (after Placement or Moving) is not out-of-bounds.
        /// </summary>
        /// <param name="x">Robot's current X position.</param>
        /// <param name="y">Robot's current Y position.</param>
        /// <returns></returns>
        private bool IsValidPosition(int x, int y)
        {
            int[] validPositions = new int[] { 0, 1, 2, 3 };

            if (validPositions.Contains(x) &&
                validPositions.Contains(y)) { return true; }
            
            Console.WriteLine("Invalid position. Robot will fall!");

            return false;
        }

        /// <summary>
        /// Checks that user's input is one of the four valid cardinal directions.
        /// </summary>
        /// <param name="f">Robot's current cardinal direction Facing.</param>
        /// <returns></returns>
        private bool IsValidFacing(string f)
        {
            string[] validFacings = new string[] { "NORTH", "EAST", "SOUTH", "WEST" };

            if (validFacings.Contains(f)) { return true; }

            Console.WriteLine("Invalid PLACE command. \r\n Facing should be one of the " +
                "four directions NORTH, EAST, WEST or SOUTH.");

            return false;
        }

        /// <summary>
        /// Sets the Robot's X, Y, Facing and whether it is Placed.
        /// </summary>
        /// <param name="x">X Position on the grid.</param>
        /// <param name="y">Y Position on the grid.</param>
        /// <param name="f">Current cardinal direction Facing.</param>
        public void Place(int x, int y, string f)
        {
            if(IsValidPosition(x, y) && IsValidFacing(f))
            {
                position[0] = x;
                position[1] = y;
                facing = f;
                placed = true;
            }

        }

        /// <summary>
        /// Increases or decreases the X or Y position, depending on Robot's current facing.
        /// </summary>
        public void Move()
        {
            if (!IsPlaced()) return;

            var newPosition = position;
            
            switch(facing)
            {
                case "NORTH":
                    if (IsValidPosition(newPosition[0], (newPosition[1] + 1)))
                        position[1] += 1;
                    break;

                case "SOUTH":
                    if (IsValidPosition(newPosition[0], (newPosition[1] - 1)))
                        position[1] -= 1;
                    break;

                case "EAST":
                    if (IsValidPosition((newPosition[0] + 1), newPosition[1]))
                        position[0] += 1;
                    break;

                case "WEST":
                    if (IsValidPosition((newPosition[0] - 1), newPosition[1]))
                        position[0] -= 1;
                    break;
            }
        }

        /// <summary>
        /// Calls Turn() and passes in an array of anti-clockwise direction strings.
        /// </summary>
        public void Left()
        {
            if (!IsPlaced()) return;
            string[] leftDirections = { "NORTH", "WEST", "SOUTH", "EAST" };
            Turn(leftDirections);
        }

        /// <summary>
        /// Calls Turn() and passes in an array of clockwise direction strings.
        /// </summary>
        public void Right()
        {
            if (!IsPlaced()) return;
            string[] rightDirections = { "NORTH", "EAST", "SOUTH", "WEST" };
            Turn(rightDirections);
        }

        /// <summary>
        /// Receives an array of Direction strings from either Left() or Right().
        /// <br/> The Robot's facing is changed by increasing the index of the next
        /// direction by 1.
        /// </summary>
        /// <param name="directions"></param>
        private void Turn(string[] directions)
        {
            for (int i = 0; i < directions.Length; i++)
            {
                if (facing == directions[3])
                {
                    facing = directions[0];
                    break;
                }
                    
                else if (facing == directions[i])
                {
                    facing = directions[i + 1];
                    break;
                }
                    
            }
        }

        /// <summary>
        /// Reports position and facing of Robot.
        /// </summary>
        public void Report()
        {
            if (!IsPlaced()) return;

            var reportString = "IOOF-Bot is at X: " + position[0]
                + ", Y: " + position[1] + " and facing " + facing + ".";    
            
            ReportString = reportString;
            
            Console.WriteLine(reportString);
        }

        

    }
}
