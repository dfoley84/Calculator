# Gherkin DSL

Feature: Getting Blood Pressure

# scenario 1
Scenario: Get Low Blood Pressure
	Given the Systolic is 70
	When the Diastolic is 60
	Then the bloodpressure be "Low"
