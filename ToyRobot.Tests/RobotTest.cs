using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace ToyRobot.Tests
{
    [TestClass]
    public class RobotTest
    {
        [TestMethod]
        public void Robot_ShouldNotAcceptMoveCommand_WhenNotFirstPlacedOnTable()
        {
            Robot robot = new Robot();
            robot.send("MOVE");
            string expected = robot.getError();
            Assert.AreEqual(expected, "Robot must be placed on the table first.");
        }
        [TestMethod]
        public void Robot_ShouldAcceptMoveCommand_AfterPlacedOnTable()
        {
            Robot robot = new Robot();
            robot.send("PLACE 0,0,NORTH");
            robot.send("MOVE");
        }
        [TestMethod]
        public void Robot_ShouldNotAcceptPlaceCommand_WhenLocationIsOffTable()
        {
            Robot robot = new Robot();
            robot.send("PLACE -1,0,NORTH");
            string expected = robot.getError();
            Assert.AreEqual(expected, "That move will move the Robot off the table. Try again.");
        }
        [TestMethod]
        public void Robot_ShouldReportPositionCorrectly()
        {
            Robot robot = new Robot();
            robot.send("PLACE 0,0,NORTH");
            string result = robot.report();
            Assert.AreEqual("0,0,NORTH", result);
        }
        [TestMethod]
        public void Robot_ShouldMoveNorthOneUnit_WhenFacingNorthAndMoved()
        {
            Robot robot = new Robot();
            robot.send("PLACE 0,0,NORTH");
            robot.send("MOVE");
            string result = robot.report();
            Assert.AreEqual("0,1,NORTH", result);
        }
        [TestMethod]
        public void Robot_ShouldMoveSouthOneUnit_WhenFacingSouthAndMoved()
        {
            Robot robot = new Robot();
            robot.send("PLACE 0,2,SOUTH");
            robot.send("MOVE");
            string result = robot.report();
            Assert.AreEqual("0,1,SOUTH", result);
        }
        [TestMethod]
        public void Robot_ShouldMoveEastOneUnit_WhenFacingEastAndMoved()
        {
            Robot robot = new Robot();
            robot.send("PLACE 3,0,EAST");
            robot.send("MOVE");
            string result = robot.report();
            Assert.AreEqual("4,0,EAST", result);
        }
        [TestMethod]
        public void Robot_ShouldMoveWestOneUnit_WhenFacingWestAndMoved()
        {
            Robot robot = new Robot();
            robot.send("PLACE 3,0,WEST");
            robot.send("MOVE");
            string result = robot.report();
            Assert.AreEqual("2,0,WEST", result);
        }
        [TestMethod]
        public void Robot_ShouldFaceSouth_WhenTurnedLeftFromWest()
        {
            Robot robot = new Robot();
            robot.send("PLACE 3,0,WEST");
            robot.send("LEFT");
            string result = robot.report();
            Assert.AreEqual("3,0,SOUTH", result);
        }
        [TestMethod]
        public void Robot_ShouldFaceWest_WhenTurnedLeftFromNorth()
        {
            Robot robot = new Robot();
            robot.send("PLACE 3,0,NORTH");
            robot.send("LEFT");
            string result = robot.report();
            Assert.AreEqual("3,0,WEST", result);
        }
        [TestMethod]
        public void Robot_ShouldFaceWest_WhenTurnedRightFromSouth()
        {
            Robot robot = new Robot();
            robot.send("PLACE 3,0,SOUTH");
            robot.send("RIGHT");
            string result = robot.report();
            Assert.AreEqual("3,0,WEST", result);
        }
        [TestMethod]
        public void Robot_ShouldFaceNorth_WhenTurnedRightFromWest()
        {
            Robot robot = new Robot();
            robot.send("PLACE 3,0,WEST");
            robot.send("RIGHT");
            string result = robot.report();
            Assert.AreEqual("3,0,NORTH", result);
        }
    }
}
