using static ArtGallery.Artwork;
using ArtGallery;

var artwork = GetArtwork();
CircularLinkedList<string[]> images = new();

foreach (var art in artwork)
    images.AddLast(art);

var node = images.First!;
var key = ConsoleKey.Spacebar;
do
{
    if (key == ConsoleKey.RightArrow)
    {
        node = node.Next();
    }
    else if (key == ConsoleKey.LeftArrow)
    {
        node = node.Previous();
    }

    Console.Clear();
    if (node is not null)
    {
        foreach (var line in node.Value)
        {
            Console.WriteLine(line);
        }
    }
} while ((key = Console.ReadKey().Key) != ConsoleKey.Escape);
