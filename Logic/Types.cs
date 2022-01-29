namespace Logic;
public class Assignment
{
    public int Id { get; init; }
    public string Name { get; init; }
    public ICollection<Group> Groups { get; set; } = new List<Group>();
}

public class Group
{
    public int Id { get; init; }
    public string Name { get; init; }
    public ICollection<Student> Members { get; init; } = new List<Student>();
    public bool ContainsStudent(Student s) => Members.Contains(s);
    public IEnumerable<Student> MembersExcept(Student s) => Members.Where(m => m != s);
}

public record Student
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class Membership
{
    public Group Group { get; set; }
    public Student Student { get; set; }
}

public class Grouper
{
    public ICollection<Student> Students { get; set; } = new List<Student>();
    public ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();

    public void AddStudent(string name, int? id = null)
    {
        Students.Add(new Student
        {
            Id = id ?? Students.Count,
            Name = name
        });
    }

    public Dictionary<Student, IEnumerable<Student>> CalculateNextGroups()
    {
        var possibilities = new Dictionary<Student, IEnumerable<Student>>();
        foreach (var student in Students)
        {
            var previousPartners = (from a in Assignments
                                    from g in a.Groups
                                    where g.ContainsStudent(student)
                                    select g.MembersExcept(student)).SelectMany(x => x);

            var possiblePartners = from s in Students
                                   where s != student && !previousPartners.Contains(s)
                                   select s;

            possibilities.Add(student, possiblePartners);
        }
        return possibilities;
    }
}
