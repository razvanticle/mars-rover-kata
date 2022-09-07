using MarsRover.Exceptions;

namespace MarsRover.Tests;

public class RoverTests
{
    [TestCase(0, 0, "N")]
    [TestCase(5, 4, "E")]
    [TestCase(-10, -10, "S")]
    [TestCase(5, -9, "W")]
    public void WhenInitialized_ProperlyHandleInitialization(int x, int y, string direction)
    {
        var rover = CreateSut(x, y, direction);

        Assert.That(rover.Position.X, Is.EqualTo(x));
        Assert.That(rover.Position.Y, Is.EqualTo(y));
        Assert.That(rover.Direction.Value, Is.EqualTo(direction));
    }

    [TestCase(11, 10)]
    [TestCase(-11, 10)]
    [TestCase(10, 11)]
    [TestCase(10, -11)]
    public void WhenInitializedWithInvalidCoordinates_ThrowException(int x, int y)
    {
        Assert.Throws<InvalidCoordinatesException>(() => CreateSut(x, y, "N"));
    }

    [Test]
    public void WhenInitializedWithInvalidDirection_ThrowException()
    {
        Assert.Throws<InvalidDirectionException>(() => CreateSut(0, 0, "invalid"));
    }

    [TestCase("F", "N", 0, 1)]
    [TestCase("FFF", "N", 0, 3)]
    [TestCase("F", "E", 1, 0)]
    [TestCase("FFFF", "E", 4, 0)]
    [TestCase("F", "S", 0, -1)]
    [TestCase("FF", "S", 0, -2)]
    [TestCase("F", "W", -1, 0)]
    [TestCase("FFF", "W", -3, 0)]
    
    [TestCase("B", "N", 0, -1)]
    [TestCase("BBB", "N", 0, -3)]
    [TestCase("B", "E", -1, 0)]
    [TestCase("BBB", "E", -3, 0)]
    [TestCase("B", "S", 0, 1)]
    [TestCase("BBB", "S", 0, 3)]
    [TestCase("B", "W", 1, 0)]
    [TestCase("BBB", "W", 3, 0)]
    
    [TestCase("FFBBBFFF","E",2,0)]
    [TestCase("BFF","S",0,-1)]
    public void WhenValidMoveCommand_MoveForwardOrBackward(string command, string initialDirection, int expectedX, int expectedY)
    {
        var rover = CreateSut(0, 0, initialDirection);

        var (position, direction) = rover.Move(command);

        Assert.That(position.X, Is.EqualTo(expectedX));
        Assert.That(position.Y, Is.EqualTo(expectedY));
        Assert.That(direction.Value, Is.EqualTo(initialDirection));
    }

    [TestCase("R","N","E")]
    [TestCase("R","E","S")]
    [TestCase("R","S","W")]
    [TestCase("R","W","N")]
    
    [TestCase("RR","N","S")]
    [TestCase("RRR","N","W")]
    [TestCase("RRRR","N","N")]
    
    [TestCase("L","N","W")]
    [TestCase("L","E","N")]
    [TestCase("L","S","E")]
    [TestCase("L","W","S")]
    public void WhenValidTurnCommand_TurnRover(string command, string initialDirection, string expectedDirection)
    {
        var rover = CreateSut(0, 0, initialDirection);

        var (position, direction) = rover.Move(command);
        
        Assert.That(position.X, Is.EqualTo(0));
        Assert.That(position.Y, Is.EqualTo(0));
        Assert.That(direction.Value, Is.EqualTo(expectedDirection));
    }

    [TestCase("FLFFFRFLB","N",-2,2,"W")]
    public void WhenValidCommand_MoveAndTurnRover(string command, string initialDirection, int expectedX, int expectedY,
        string expectedDirection)
    {
        var rover = CreateSut(0, 0, initialDirection);
        
        var (position, direction) = rover.Move(command);
        
        Assert.That(position.X, Is.EqualTo(expectedX));
        Assert.That(position.Y, Is.EqualTo(expectedY));
        Assert.That(direction.Value, Is.EqualTo(expectedDirection));
    }
    
    private static Rover CreateSut(int x, int y, string direction)
    {
        return new Rover(x, y, direction);
    }
}