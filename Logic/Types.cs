namespace Logic;
public class Assignment
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Group> Groups { get; set; }
}

public class Group
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Membership> Members { get; set; }
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
