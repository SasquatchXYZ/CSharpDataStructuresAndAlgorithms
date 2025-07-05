var usedCoupons = new HashSet<int>();
do
{
    Console.Write("Enter the number: ");
    var number = Console.ReadLine() ?? string.Empty;

    if (!int.TryParse(number, out var coupon))
        break;

    if (usedCoupons.Add(coupon))
    {
        Console.WriteLine("Coupon accepted - Thank you!");
    }
    else
    {
        Console.WriteLine("Invalid coupon - Already used.");
    }
} while (true);

Console.WriteLine("\nUsed coupons:");
foreach (var coupon in usedCoupons)
{
    Console.WriteLine(coupon);
}
