using UserDetails;

var employees = new Dictionary<int, Employee>
{
    {
        100, new Employee("Marcin", "Jamro", "101-202-303")
    },
    {
        210, new Employee("John", "Smith", "202-303-404")
    },
    {
        303, new Employee("Aline", "Weather", "303-404-505")
    },
};

do
{
    Console.Write("Enter Employee ID: ");
    var userInput = Console.ReadLine() ?? string.Empty;
    if (!int.TryParse(userInput, out var id))
        break;

    if (employees.TryGetValue(id, out var employee))
    {
        Console.WriteLine(
            "Full name: {0} {1}\nPhone number: {2}\n",
            employee.FirstName,
            employee.LastName,
            employee.PhoneNumber);
    }
    else
    {
        Console.WriteLine("Employee not found.\n");
    }
} while (true);
