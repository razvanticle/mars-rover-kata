using MarsRover.Exceptions;

namespace MarsRover;

public class Direction
{
    private readonly List<string> directions = new() { "N", "E", "S", "W" };
    
    public string Value { get; }

    public Direction(string direction)
    {
        if (!directions.Contains(direction))
        {
            throw new InvalidDirectionException();
        }
        
        Value = direction;
    }
    
    public Direction GetLeft()
    {
        var currentDirectionIndex = directions.IndexOf(Value);
        var leftDirection = currentDirectionIndex == 0
            ? directions.Last()
            : directions[currentDirectionIndex - 1];

        return new Direction(leftDirection);
    }

    public Direction GetRight()
    {
        var currentDirectionIndex = directions.IndexOf(Value);
        var rightDirection = currentDirectionIndex == directions.Count - 1
            ? directions.First()
            : directions[currentDirectionIndex + 1];

        return new Direction(rightDirection);
    }
}