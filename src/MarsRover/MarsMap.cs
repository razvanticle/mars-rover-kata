namespace MarsRover;

public class MarsMap
{
    private readonly List<Position> obstacles;

    public MarsMap(List<Position> obstacles)
    {
        this.obstacles = obstacles;
    }

    public Position GetNextPosition(Direction direction, Position currentPosition, int step)
    {
        var nextPosition = direction.Value switch
        {
            "N" => currentPosition.NextY(step),
            "E" => currentPosition.NextX(step),
            "S" => currentPosition.NextY(-1 * step),
            "W" => currentPosition.NextX(-1 * step),
            _ => currentPosition
        };

        return obstacles.Contains(nextPosition) ? currentPosition : nextPosition;
    }
}