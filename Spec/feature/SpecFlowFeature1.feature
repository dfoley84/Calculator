# Gherkin DSL

Feature: Getting Blood Pressure

# scenario 1
Scenario: Get Low Blood Pressure
	When the Systolic is 70 and Diastolic is 60
	Then the bloodpressure be 'Low'

# scenario 2
Scenario: Get Ideal Blood Pressure
	When the Systolic is 90 and Diastolic is 70
	Then the bloodpressure be 'Ideal'
	

# scenario 3
Scenario: Get Pre-High Blood Pressure
	When the Systolic is 120 and Diastolic is 80
	Then the bloodpressure be 'PreHigh'

# scenario 4
Scenario: Get High Blood Pressure
	When the Systolic is 140 and Diastolic is 91
	Then the bloodpressure be 'High'
