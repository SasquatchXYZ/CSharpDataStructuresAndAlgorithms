using ListOfPeople;

List<Person> people =
[
    new("Marcin", 35, "PL"),
    new("Sabine", 25, "DE"),
    new("Mark", 31, "PL"),
];

var sortedPeople = people.OrderBy(person => person.Name).ToList();

foreach (var person in sortedPeople)
{
    Console.WriteLine($"{person.Name} ({person.Age}) from {person.Country}.");
}
