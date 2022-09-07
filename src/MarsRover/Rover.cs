namespace MarsRover;

public class Rover
{
    public Direction Direction { get; private set; }

    public Position Position { get; private set; }

    public Rover(int x, int y, string direction)
    {
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
                    Position = MoveForward();
                    break;
                case 'B':
                    Position = MoveBackward();
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

    private Position MoveBackward()
    {
        return Direction.Value switch
        {
            "N" => new Position(Position.X, Position.Y - 1),
            "E" => new Position(Position.X - 1, Position.Y),
            "S" => new Position(Position.X, Position.Y + 1),
            "W" => new Position(Position.X + 1, Position.Y),
            _ => Position
        };
    }

    private Position MoveForward()
    {
        return Direction.Value switch
        {
            "N" => new Position(Position.X, Position.Y + 1),
            "E" => new Position(Position.X + 1, Position.Y),
            "S" => new Position(Position.X, Position.Y - 1),
            "W" => new Position(Position.X - 1, Position.Y),
            _ => Position
        };
    }
}