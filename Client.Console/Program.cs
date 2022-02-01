// See https://aka.ms/new-console-template for more information
using Logic;

var contents = File.ReadAllLines("cs1415.txt").ToArray();

var grouper = Grouper.Parse(contents);


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