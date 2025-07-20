namespace MinimumCoinChange;

public static class CashRegister
{
    private static readonly int[] _euroDenominations = [1, 2, 5, 10, 20, 50, 100, 200, 500];

    private static readonly int[] _dollarDenominations = [1, 5, 10, 25];

    public static List<int> GetEuroCoins(int amount)
    {
        var coins = new List<int>();
        for (var i = _euroDenominations.Length - 1; i >= 0; i--)
        {
            while (amount >= _euroDenominations[i])
            {
                amount -= _euroDenominations[i];
                coins.Add(_euroDenominations[i]);
            }
        }

        return coins;
    }

    public static List<int> GetUsChange(int amount)
    {
        var coins = new List<int>();
        for (var i = _dollarDenominations.Length - 1; i >= 0; i--)
        {
            while (amount >= _dollarDenominations[i])
            {
                amount -= _dollarDenominations[i];
                coins.Add(_dollarDenominations[i]);
            }
        }

        return coins;
    }
}
