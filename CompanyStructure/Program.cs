using CompanyStructure;
using TreeDatastructures;

var company = new Tree<Person>
{
    Root = new TreeNode<Person>
    {
        Data = new Person("Marcin Jamro", "Chief Executive Officer"),
        Parent = null
    }
};

company.Root.Children =
[
    new TreeNode<Person>
    {
        Data = new Person("John Smith", "Head of Development"),
        Parent = company.Root
    },
    new TreeNode<Person>
    {
        Data = new Person("Alice Batman", "Head of Research"),
        Parent = company.Root
    },
    new TreeNode<Person>
    {
        Data = new Person("Lily Smith", "Head of Sales"),
        Parent = company.Root
    },
];

company.Root.Children[2].Children =
[
    new TreeNode<Person>
    {
        Data = new Person("Anthony Black", "Senior Salse Specialist"),
        Parent = company.Root.Children[2]
    }
];
