var usedCoupons = new HashSet<int>();
do
{
    Console.Write("Enter the number: ");
    var number = Console.ReadLine() ?? string.Empty;

    if (!int.TryParse(number, out var coupon))
        break;

    if (usedCoupons.Contains(coupon))
    {
        Console.WriteLine("Invalid coupon - Already used.");
    }
    else
    {
        usedCoupons.Add(coupon);
        Console.WriteLine("Coupon accepted - Thank you!");
    }
} while (true);

Console.WriteLine("\nUsed coupons:");
foreach (var coupon in usedCoupons)
{
    Console.WriteLine(coupon);
}
