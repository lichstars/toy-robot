using NUnit.Framework;

namespace ToyRobot.RobotParserTest
{
	[TestFixture()]
	public class RobotParserTest
	{
		[Test()]
		public void RobotParser_ShouldIgnoreUnrecognisedCommand()
		{
			var parser = new RobotParser(new Robot());
			var result = parser.parse("HELLO");
			Assert.IsFalse(result);
		}
		[Test()]
		public void RobotParser_ShouldAcceptPlaceCommand()
		{
			var parser = new RobotParser(new Robot());
			var result = parser.parse("PLACE 0,0,NORTH");
			Assert.IsTrue(result);
		}
		[Test()]
		public void RobotParser_ShouldReturnFalseOnPlaceCommand_WhenNotEnoughArgumentsGiven()
		{
			var parser = new RobotParser(new Robot());
			var result = parser.parse("PLACE 1,NORTH");
			Assert.IsFalse(result);
		}
		[Test()]
		public void RobotParser_ShouldReturnFalseOnPlaceCommand_WhenXAxisIsNotNumber()
		{
			var parser = new RobotParser(new Robot());
			var result = parser.parse("PLACE X,1,NORTH");
			Assert.IsFalse(result);
		}
		[Test()]
		public void RobotParser_ShouldReturnFalseOnPlaceCommand_WhenYAxisIsNotNumber()
		{
			var parser = new RobotParser(new Robot());
			var result = parser.parse("PLACE 1,Y,NORTH");
			Assert.IsFalse(result);
		}
		[Test()]
		public void RobotParser_ShouldReturnFalseOnPlaceCommand_WhenDirectionIsInvalid()
		{
			var parser = new RobotParser(new Robot());
			var result = parser.parse("PLACE 1,1,NTH");
			Assert.IsFalse(result);
		}
		[Test()]
		public void RobotParser_ShouldNotAcceptTwoCommandsOnOneLine()
		{
			RobotParser parser = new RobotParser(new Robot());
			parser.parse("PLACE 0,0,NORTH");
			bool result = parser.parse("MOVE REPORT");
			Assert.IsFalse(result);
		}
	}
}