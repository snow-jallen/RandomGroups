using Logic;
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
        var assignment = new Assignment()
        {
            Id = groupNumber,
            Name = $"Assignment {groupNumber}"
        };
        int groupNum = 1;
        foreach (var row in table.Rows)
        {
            var group = new Group
            {
                Id = groupNum,
                Name = $"Group {groupNum++}"
            };
            foreach (var member in row.Values)
            {
                group.Members.Add(grouper.Students.Single(s => s.Name == member));
            }
        }
        context.Add(assignment.Name, assignment);
    }

    [When(@"I go to set up group set (.*)")]
    public void WhenIGoToSetUpGroupSet(int p0)
    {
        var grouper = getGrouper();
        var possibilities = grouper.CalculateNextGroups();
    }

    [Then(@"Adam can work with")]
    public void ThenAdamCanWorkWith(Table table)
    {
        throw new PendingStepException();
    }

    [Then(@"Caleb can work with")]
    public void ThenCalebCanWorkWith(Table table)
    {
        throw new PendingStepException();
    }
}
