namespace ClosestPairOfPoints;

public static class Calculator
{
    public static Result? FindClosestPair(Point[] points)
    {
        if (points.Length <= 1) return null;
        if (points.Length <= 3) return Closest(points);

        var m = points.Length / 2;
        var r = Closer(
            FindClosestPair(points.Take(m).ToArray())!,
            FindClosestPair(points.Skip(m).ToArray())!
        );

        var strip = points
            .Where(point =>
                Math.Abs(point.X - points[m].X) < r.Distance)
            .ToArray();

        return Closer(r, Closest(strip));
    }

    /// <summary>
    /// Compares two results and returns the one with the shorter distance between points.
    /// </summary>
    /// <param name="r1">The first result containing a pair of points and their distance.</param>
    /// <param name="r2">The second result containing a pair of points and their distance.</param>
    /// <returns>
    /// The <see cref="Result"/> object with the smaller distance between points.
    /// </returns>
    private static Result Closer(Result r1, Result r2) =>
        r1.Distance < r2.Distance
            ? r1
            : r2;

    /// <summary>
    /// Finds the closest pair of points from the provided array of points by evaluating all possible pairs.
    /// </summary>
    /// <param name="points">An array of points to evaluate for the closest pair.</param>
    /// <returns>
    /// A <see cref="Result"/> object containing the closest pair of points and their distance.
    /// </returns>
    private static Result Closest(Point[] points)
    {
        var result = new Result(points[0], points[0], double.MaxValue);
        for (var i = 0; i < points.Length; i++)
        {
            for (var k = i + 1; k < points.Length; k++)
            {
                var distance = points[i].GetDistanceTo(points[k]);
                if (distance < result.Distance)
                {
                    result = new Result(points[i], points[k], distance);
                }
            }
        }

        return result;
    }
}
