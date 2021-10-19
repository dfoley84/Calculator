# Gherkin DSL

Feature: Getting Blood Pressure

# scenario 1
Scenario: Get Low Blood Pressure
	When the Systolic is 70 and Diastolic is 60
	Then the bloodpressure be "Low"
