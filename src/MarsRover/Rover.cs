namespace MarsRover;

public class Rover
{
    private readonly MarsMap marsMap;
    public Direction Direction { get; private set; }

    public Position Position { get; private set; }

    public Rover(int x, int y, string direction, MarsMap marsMap)
    {
        this.marsMap = marsMap;
        Position = new Position(x, y);
        Direction = new Direction(direction);
    }

    public (Position, Direction) Move(string command)
    {
        foreach (char c in command)
        {
            switch (c)
            {
                case 'F':
                    Position = marsMap.GetNextPosition(Direction, Position, 1);
                    break;
                case 'B':
                    Position = marsMap.GetNextPosition(Direction, Position, -1);
                    break;
                case 'R':
                    Direction = Direction.GetRight();
                    break;
                case 'L':
                    Direction = Direction.GetLeft();
                    break;
            }
        }
        
        return (Position, Direction);
    }
}