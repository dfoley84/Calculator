Feature: SpecFlowFeature1
	Simple calculator for adding two numbers

@smoke
Scenario: Getting Users Low Blood Pressure
	Given That Systolic is 70 and Diastolic is 40
	When I Click Submit
	Then The result should be "Low Blood Pressure" 