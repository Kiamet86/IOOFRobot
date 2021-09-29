using System;
using Xunit;
using IOOFRobot.Classes;

namespace IOOFRobotTests
{
    public class RobotTests
    {
        [Fact]
        public void IsPlaced_PlacedIsFalse_ProhibitsCommands()
        {
            // Arrange - Create new Robot object.
            var robot = new Robot();

            // Act - Attempt a Left Command, to change facing from NORTH to WEST.
            robot.Left();

            // Assert - Confirm that facing is still NORTH.
            Assert.True(robot.Facing == "NORTH");
        }

        [Fact]
        public void Right_PlacedIsTrue_ChangesFacing()
        {
            // Arrange - Create new Robot object, set Placed property to true.
            var robot = new Robot();
            robot.Placed = true;

            // Act - Attempt a Right Command, to change facing from NORTH to EAST.
            robot.Right();

            // Assert - Confirm that new facing is EAST.
            Assert.True(robot.Facing == "EAST");
        }

        [Fact]
        public void Place_ValidInput_ChangesRobotProperties()
        {
            // Arrange - Create new Robot object.
            var robot = new Robot();

            // Act - Attempt a Place Command, with new position and facing.
            robot.Place(1, 2, "EAST");

            // Assert - Confirm that Robot's position and facing have been changed.
            Assert.True(robot.Position[0] == 1);
            Assert.True(robot.Position[1] == 2);
            Assert.True(robot.Facing == "EAST");
            Assert.True(robot.Placed == true);
        }

        [Fact]
        public void Place_InvalidInput_RejectsChanges()
        {
            // Arrange - Create new Robot object.
            var robot = new Robot();

            // Act - Attempt a Place Command, with incorrect position.
            robot.Place(1, 4, "EAST");

            // Assert - Confirm that Robot's position and facing have NOT been changed.
            Assert.True(robot.Position[0] == 0);
            Assert.True(robot.Position[1] == 0);
            Assert.True(robot.Facing == "NORTH");
            Assert.True(robot.Placed == false);
        }

        [Fact]
        public void Move_ValidMovement_ChangesRobotPosition()
        {
            // Arrange - Create new Robot object and Place on grid.
            var robot = new Robot();
            robot.Place(1, 2, "EAST");

            // Act - Attempt a Move Command.
            robot.Move();

            // Assert - Confirm that Robot's position has changed.
            Assert.True(robot.Position[0] == 2);
            Assert.True(robot.Position[1] == 2);
            Assert.True(robot.Facing == "EAST");
            Assert.True(robot.Placed == true);
        }

        [Fact]
        public void Move_InvalidMovement_NoChangeToRobotPosition()
        {
            // Arrange - Create new Robot object and Place on grid.
            var robot = new Robot();
            robot.Place(0, 3, "NORTH");

            // Act - Attempt a Move Command.
            robot.Move();

            // Assert - Confirm that Robot's position has NOT changed.
            Assert.True(robot.Position[0] == 0);
            Assert.True(robot.Position[1] == 3);
            Assert.True(robot.Facing == "NORTH");
            Assert.True(robot.Placed == true);
        }

        [Fact]
        public void Report_ValidRobotPlacement_ReportsPositionAndFacing()
        {
            // Arrange - Create new Robot object and Place on grid.
            var robot = new Robot();
            robot.Place(0, 3, "NORTH");

            // Act - Attempt a Report Command.
            robot.Report();

            // Assert - Report command should match expected string.
            Assert.True(robot.ReportString == "IOOF-Bot is at X: 0, Y: 3 and facing NORTH.");
        
        }

    }
}
