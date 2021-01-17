Feature: Journey Planner

Scenario Outline: 01 Verifying valid journey
	Given I am on plan a journey page
	When I enter from "<From>" and to "<To>" locations and click on plan my journey
	Then I should see my journey results

	Examples:
		| From                              | To                          |
		| Hounslow West Underground Station | Holborn Underground Station |

Scenario Outline: 02 Verifying Invalid journey when the location name is incorrect
	Given I am on plan a journey page
	When I enter from "<From>" and to "<To>" locations and click on plan my journey
	Then I should not see any journey results

	Examples:
		| From                              | To  |
		| Hounslow West Underground Station | hhh |

Scenario Outline: 03 Verifying Invalid journey when no location entered
	Given I am on plan a journey page
	When I enter from "<From>" and to "<To>" locations and click on plan my journey
	Then I should get following field validation error message "The From field is required."

	Examples:
		| From | To                          |
		|      | Holborn Underground Station |

Scenario Outline: 04 Amend Journey
	Given I am on plan a journey page
	When I enter from "<From>" and to "<To>" locations and click on plan my journey
	Then I amend the to location as "<UpdateToLocation>"

	Examples:
		| From                              | To                          | UpdateToLocation |
		| Hounslow West Underground Station | Holborn Underground Station | North Greenwich  |

Scenario: 05 Check recent planned journies
	Given I am on plan a journey page
	When I click on recent tab
	Then I should see results on the recent tab