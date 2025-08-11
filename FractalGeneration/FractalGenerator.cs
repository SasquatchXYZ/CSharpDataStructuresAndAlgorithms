namespace FractalGeneration;

public class FractalGenerator
{
    public static void AddLine(
        List<Line> lines,
        int level,
        float x,
        float y,
        float length,
        float angle)
    {
        if (level < 0) return;

        var endX = x + (float) (length * Math.Cos(angle));
        var endY = y + (float) (length * Math.Sin(angle));
        lines.Add(new Line(x, y, endX, endY));

        AddLine(
            lines,
            level - 1,
            endX,
            endY,
            length * 0.8f,
            angle + (float) (Math.PI * 0.3f));

        AddLine(
            lines,
            level - 1,
            endX,
            endY,
            length * 0.6f,
            angle + (float) (Math.PI * 1.7f));
    }
}
