namespace FractalGeneration;

public record Line(
    float X1,
    float Y1,
    float X2,
    float Y2)
{
    public float GetLength() =>
        (float) Math.Sqrt(
            Math.Pow(X1 - X2, 2) +
            Math.Pow(Y1 - Y2, 2)
        );
}
