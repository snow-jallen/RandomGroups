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
}

public class Student
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


}
