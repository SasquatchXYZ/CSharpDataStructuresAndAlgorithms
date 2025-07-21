namespace ClosestPairOfPoints;

public record Point(int X, int Y)
{
    public float GetDistanceTo(Point other) =>
        (float) Math.Sqrt(
            Math.Pow(X - other.X, 2) +
            Math.Pow(Y - other.Y, 2)
        );
}
