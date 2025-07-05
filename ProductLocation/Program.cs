var productLocationMapping = new Dictionary<string, string>
{
    {
        "5901020304050", "A1"
    },
    {
        "5910203040506", "B5"
    },
    {
        "5920304050607", "C9"
    },
};

productLocationMapping["5930405060708"] = "D7";

const string key = "5940506070809";
if (!productLocationMapping.ContainsKey(key))
{
    productLocationMapping.Add(key, "A3");
}

if (!productLocationMapping.TryAdd(key, "B4"))
{
    Console.WriteLine("Cannot add product - Key already exists.");
}

Console.WriteLine("All Products:");
if (productLocationMapping.Count == 0)
    Console.WriteLine("Empty list.");

foreach (var (product, location) in productLocationMapping)
{
    Console.WriteLine($"{product}: {location}");
}

Console.Write("\nSearch by barcode: ");
var barcode = Console.ReadLine() ?? string.Empty;
if (productLocationMapping.TryGetValue(barcode, out var productLocation))
{
    Console.WriteLine($"Product is located in {productLocation}.");
}
else
{
    Console.WriteLine($"Product with barcode, {barcode}, not found.");
}
