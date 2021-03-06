using FluentAssertions;
using Logic;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace Tests;

[Binding]
public class Steps
{
    private readonly ScenarioContext context;

    public Steps(ScenarioContext context)
    {
        this.context = context;
    }

    [Given(@"the following students")]
    public void GivenTheFollowingStudents(Table table)
    {
        var grouper = getGrouper();
        table.Rows.ToList().ForEach(r => grouper.AddStudent(r[0]));
    }

    private Grouper getGrouper()
    {
        if (!context.TryGetValue<Grouper>(out var grouper))
        {
            grouper = new Grouper();
            context.Set(grouper);
        }
        return grouper;
    }

    [Given(@"group set (.*) was")]
    public void GivenGroupSetWas(int groupNumber, Table table)
    {
        var grouper = getGrouper();
        grouper.AddAssignment($"Group {groupNumber}", table.Rows.Select(row => row.Values.ToArray()).ToArray());
    }

    [When(@"I go to set up group set (.*)")]
    public void WhenIGoToSetUpGroupSet(int p0)
    {
        var grouper = getGrouper();
        var possibilities = grouper.CalculateNextGroups();
        context.Add("possibilities", possibilities);
    }

    [Then(@"(.*) can work with")]
    public void Then_____CanWorkWith(string studentName, Table table)
    {
        var possibilities = context.Get<Dictionary<Student, IEnumerable<Student>>>("possibilities");
        var grouper = getGrouper();
        var student = grouper.Students.Single(s => s.Name == studentName);
        var expectedPossiblePartners = table.Rows.Select(name => grouper.Students.Single(s => s.Name == name[0]));

        possibilities[student].Should().BeEquivalentTo(expectedPossiblePartners);
    }
}
