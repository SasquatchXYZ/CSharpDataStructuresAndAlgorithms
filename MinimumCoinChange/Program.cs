using static MinimumCoinChange.CashRegister;

var coins = GetEuroCoins(158);
Console.WriteLine($"Euro coins: {string.Join(", ", coins)}");

var change = GetUsChange(158);
Console.WriteLine($"US coins: {string.Join(", ", change)}");
