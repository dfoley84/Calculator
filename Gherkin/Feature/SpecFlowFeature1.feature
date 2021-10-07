Feature: SpecFlowFeature1


@smoke
Scenario: Get Low Blood Pressure
	Given the first number is 70
	And the second number is 40
	When the two numbers are added
	Then the result should be "Low Blood Pressure"