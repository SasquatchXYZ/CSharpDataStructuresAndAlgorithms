using static ClosestPairOfPoints.Calculator;
using ClosestPairOfPoints;

List<Point> points = [
    new Point(6, 45), // A
    new Point(12, 8), // B
    new Point(14, 31), // C
    new Point(24, 18), // D
    new Point(32, 26), // E
    new Point(40, 41), // F
    new Point(44, 6), // G
    new Point(57, 20), // H
    new Point(60, 35), // I
    new Point(72, 9), // J
    new Point(73, 41), // K
    new Point(85, 25), // L
    new Point(92, 8), // M
    new Point(93, 43) // N
];

points.Sort((a, b) => a.X.CompareTo(b.X));
var closestPair = FindClosestPair(points.ToArray());
if (closestPair is not null)
{
    Console.WriteLine(
        "Closest Pair: ({0}, {1}) and ({2}, {3}) with distance: {4:F2}",
        closestPair.P1.X,
        closestPair.P1.Y,
        closestPair.P2.X,
        closestPair.P2.Y,
        closestPair.Distance
    );
}
