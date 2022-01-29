Feature: RandomGroupAssignment

Help find people with whom someone has not yet worked

@tag1
Scenario: Second set of groups
	Given the following students
	| Name     |
	| Adam     |
	| Benjamin |
	| Caleb    |
	| Daniel   |
	And group set 1 was
	| Member1 | Member2  |
	| Adam    | Benjamin |
	| Caleb   | Daniel   |
	When I go to set up group set 2
	Then Adam can work with
	| Possible Partners |
	| Caleb             |
	| Daniel            |
	And Caleb can work with
	| Possible Partners |
	| Adam              |
	| Benjamin          |

