// See https://aka.ms/new-console-template for more information
using Logic;

var contents = File.ReadAllLines("cs1415.txt").ToArray();

var grouper = new Grouper();
foreach (var student in contents.First().Split(',', StringSplitOptions.RemoveEmptyEntries))
{
    grouper.AddStudent(student);
}

for (int i = 2; i < contents.Length; i++)
{
    if (contents[i].Trim() == String.Empty)
        continue;

    var assignmentName = contents[i++].Trim();
    var groups = new List<IEnumerable<string>>();
    while (i < contents.Length && contents[i].Trim() != String.Empty)
    {
        groups.Add(contents[i++].Split(',', StringSplitOptions.RemoveEmptyEntries));
    }
    grouper.AddAssignment(assignmentName, groups);
}


var possibilities = grouper.CalculateNextGroups();
foreach (var student in possibilities.Keys)
{
    Console.WriteLine($"{student.Name} could work with");
    foreach (var other in possibilities[student])
    {
        Console.WriteLine($"\t{other.Name}");
    }
    Console.WriteLine();
}
Console.ReadLine();