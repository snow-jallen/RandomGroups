Feature: RandomGroupAssignment

Help find people with whom someone has not yet worked

Scenario: One set of groups
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

Scenario: Two sets of groups
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
	And group set 2 was
	| Member1  | Member2 |
	| Adam     | Caleb   |
	| Benjamin | Daniel  |
	When I go to set up group set 3
	Then Adam can work with
	| Possible Partners |
	| Daniel            |
	And Caleb can work with
	| Possible Partners |
	| Benjamin          |

Scenario: One set of three-member groups
	Given the following students
	| Name     |
	| Adam     |
	| Benjamin |
	| Caleb    |
	| Daniel   |
	| Ephraim  |
	| Frank    |
	And group set 1 was
	| Member1 | Member2  | Member3 |
	| Adam    | Benjamin | Caleb   |
	| Daniel  | Ephraim  | Frank   |
	When I go to set up group set 2
	Then Adam can work with
	| Possible Partners |
	| Daniel            |
	| Ephraim           |
	| Frank             |
	And Daniel can work with
	| Possible Partners |
	| Adam              |
	| Benjamin          |
	| Caleb             |

Scenario: Two sets of three-member groups
	Given the following students
	| Name     |
	| Adam     |
	| Benjamin |
	| Caleb    |
	| Daniel   |
	| Ephraim  |
	| Frank    |
	And group set 1 was
	| Member1 | Member2  | Member3 |
	| Adam    | Benjamin | Caleb   |
	| Daniel  | Ephraim  | Frank   |
	And group set 2 was
	| Member1  | Member2 | Member3 |
	| Adam     | Daniel  | Ephraim |
	| Benjamin | Caleb   | Frank   |
	When I go to set up group set 2
	Then Adam can work with
	| Possible Partners |
	| Frank             |
	And Benjamin can work with
	| Possible Partners |
	| Daniel            |
	| Ephraim           |
	And Caleb can work with
	| Possible Partners |
	| Daniel            |
	| Ephraim           |

Scenario: Current group, special handling
	Given the following students
	| Name     |
	| Adam     |
	| Benjamin |
	| Caleb    |
	| Daniel   |
	| Ephraim  |
	| Frank    |
	And group set 1 was
	| Member1 | Member2  | Member3 |
	| Adam    | Benjamin | Caleb   |
	| Daniel  | Ephraim  | Frank   |
	And group set 2 was
	| Member1  | Member2 | Member3 |
	| Adam     | Daniel  | Ephraim |
	| Benjamin | Caleb   | Frank   |
	When I go to set up group set 2
	Then Adam can work with
	| Possible Partners |
	| Frank             |
	And Benjamin can work with
	| Possible Partners |
	| Daniel            |
	| Ephraim           |
	And Caleb can work with
	| Possible Partners |
	| Daniel            |
	| Ephraim           |
