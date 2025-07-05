using SwimmingPools;

var random = new Random();
var tickets = new Dictionary<PoolType, HashSet<int>>
{
    {
        PoolType.Recreation, []
    },
    {
        PoolType.Competition, []
    },
    {
        PoolType.Thermal, []
    },
    {
        PoolType.Kids, []
    },
};

for (var i = 1; i < 100; i++)
{
    foreach (var (_, ticketSet) in tickets)
    {
        if (random.Next(2) == 1)
        {
            ticketSet.Add(i);
        }
    }
}

Console.WriteLine("Number of visitors by a pool type:");
foreach (var (poolType, ticketSet) in tickets)
{
    Console.WriteLine($"- {poolType}: {ticketSet.Count}");
}

var maxVisitorsPoolType = tickets
    .OrderByDescending(ticketPair => ticketPair.Value.Count)
    .Select(ticketPair => ticketPair.Key)
    .FirstOrDefault();

Console.WriteLine($"\nThe pool with the most visitors is {maxVisitorsPoolType}.");

var any = new HashSet<int>(tickets[PoolType.Recreation]);
any.UnionWith(tickets[PoolType.Competition]);
any.UnionWith(tickets[PoolType.Thermal]);
any.UnionWith(tickets[PoolType.Kids]);
Console.WriteLine($"{any.Count} people visited at least one pool.");

var all = new HashSet<int>(tickets[PoolType.Recreation]);
all.IntersectWith(tickets[PoolType.Competition]);
all.IntersectWith(tickets[PoolType.Thermal]);
all.IntersectWith(tickets[PoolType.Kids]);
Console.WriteLine($"{all.Count} people visited all pools.");
