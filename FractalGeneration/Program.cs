using System.Drawing;
using System.Drawing.Drawing2D;
using FractalGeneration;
using static FractalGeneration.FractalGenerator;

const int maxSize = 1000;
var lines = new List<Line>();
AddLine(
    lines,
    level: 14,
    x: 0,
    y: 0,
    length: 500,
    angle: (float) Math.PI * 1.5f);

var xMin = lines.Min(l => Math.Min(l.X1, l.X2));
var xMax = lines.Max(l => Math.Max(l.X1, l.X2));
var yMin = lines.Min(l => Math.Min(l.Y1, l.Y2));
var yMax = lines.Max(l => Math.Max(l.Y1, l.Y2));
var size = Math.Max(xMax - xMin, yMax - yMin);
var factor = maxSize / size;
var width = (int) ((xMax - xMin) * factor);
var height = (int) ((yMax - yMin) * factor);

using var bitmap = new Bitmap(width, height);
using var graphics = Graphics.FromImage(bitmap);
graphics.Clear(Color.White);
graphics.SmoothingMode = SmoothingMode.AntiAlias;
using var pen = new Pen(Color.Black, 1);
foreach (var line in lines)
{
    pen.Width = line.GetLength() / 20;
    var sx = (line.X1 - xMin) * factor;
    var sy = (line.Y1 - yMin) * factor;
    var ex = (line.X2 - xMin) * factor;
    var ey = (line.Y2 - yMin) * factor;
    graphics.DrawLine(pen, sx, sy, ex, ey);
}

bitmap.Save($"{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.png");
