Feature: TMFeature
	As a TurnUp portal admin
	I would like to create, edit and delete time and material records
	So that I can manage employees time and materials successfully


@tmtest @regression
Scenario: create time and material record with valid details
	Given I Logged into turnup portal sucessfully
	And I nagivate to Time and material page
	When I create time and material record.
	Then Thre record should be created sucessfully
	
@tmtest @regression
Scenario Outline: edit time and material record with valid details
	Given I Logged into turnup portal sucessfully
	And I nagivate to Time and material page
	When I update '<Description>' '<TypeCode>' '<Price>' on an existing time and material record.
	Then the record should have the updated '<Description>'

	Examples: 
	| Description | TypeCode |Price
	| new desc    | T        | 123
	| updated desc| M        | 45




@tmtest @regression
Scenario: delete Time and Material record with valid details
	Given I Logged into turnup portal sucessfully
	And I nagivate to Time and material page
	When I delete the time and marerial record
	Then there record should be deleted sucessfully	

