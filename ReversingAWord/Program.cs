const string text = "MARCIN";

Console.WriteLine(text);
Console.WriteLine("-------------");

var stack = new Stack<char>();
foreach (var character in text)
{
    stack.Push(character);
}

while (stack.Count > 0)
{
    Console.Write(stack.Pop());
}
