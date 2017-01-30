using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ToyRobot.Tests
{
    [TestClass]
    public class RobotTest
    {
        [TestMethod]
        public void Robot_ShouldNotAcceptMoveCommand_WhenNotFirstPlacedOnTable()
        {
            Robot robot = new Robot();
            bool result = robot.send("MOVE");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void Robot_ShouldAcceptMoveCommand_AfterPlacedOnTable()
        {
            Robot robot = new Robot();
            robot.send("PLACE 0,0,NORTH");
            bool result = robot.send("MOVE");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Robot_ShouldNotAcceptPlaceCommand_WhenLocationIsOffTable()
        {
            Robot robot = new Robot();
            bool result = robot.place("PLACE -1,0,NORTH");
            Assert.IsFalse(result);
        }
    }
}
