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
        if (x > MaxX || x < MinX)
        {
            throw new InvalidCoordinatesException();
        }

        if (y > MaxY || y < MinY)
        {
            throw new InvalidCoordinatesException();
        }
        
        X = x;
        Y = y;
    }

    public int X { get; }
    
    public int Y { get; }
}