using AddressBook;

SortedList<string, Person> people = new()
{
    ["Marcin Jamro"] = new("Marcin Jamro", "Polish Street 1/23", "35-001", "Rzeszow", "PL"),
    ["Martyna Kowalska"] = new("Martyna Kowalska", "World Street 5", "00-123", "Warsaw", "PL"),
};

people.Add("Mark Smith", new Person("Mark Smith", "German Street 6", "10000", "Berlin", "DE"));

foreach (var (key, person) in people)
{
    Console.WriteLine($"{key}: {person.Street}, {person.PostalCode} {person.City}, {person.Country}.");
}
