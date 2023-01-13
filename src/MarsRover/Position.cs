using MarsRover.Exceptions;

namespace MarsRover;

public class Position
{
    private const int MaxX = 10;
    private const int MaxY = 10;
    private const int MinX = -10;
    private const int MinY = -10;
    
    public Position(int x, int y)
    {
        if (x is > MaxX or < MinX)
        {
            throw new InvalidCoordinatesException();
        }

        if (y is > MaxY or < MinY)
        {
            throw new InvalidCoordinatesException();
        }
        
        X = x;
        Y = y;
    }

    public int X { get; }
    
    public int Y { get; }

    public Position NextX(int step)
    {
        var nextX = Next(X, step, MinX, MaxX);

        return new Position(nextX, Y);
    }
    
    public Position NextY(int step)
    {
        var nextY = Next(Y, step, MinY, MaxY);

        return new Position(X, nextY);
    }
    
    private static int Next(int value, int valueToAdd, int min, int max)
    {
        var result = value + valueToAdd;
        if (result > max)
        {
            return min + (result - max-1);
        }

        if (result < min)
        {
            return max - (Math.Abs(result) - Math.Abs(min)-1);
        }

        return result;
    }

    protected bool Equals(Position other)
    {
        return X == other.X && Y == other.Y;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }

        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        return obj.GetType() == GetType() && Equals((Position)obj);
    }
    
    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}