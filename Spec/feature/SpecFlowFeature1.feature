﻿Feature: Getting BP
	Simple Test for getting BP

#Scenario Get Low BP
Scenario: Getting Low BP
When I fill out the mandartory details 1, 70 and 40
Then the message should be "Low Blood Pressure"


"""
@GettingBP
Scenario Outline: Getting Adult Low BP
	#Given That Systolic is <Systolic>
	When I fill out the mandartory details <Age>, <Systolic> and <Diastolic>
	Then the message should be <result>
Examples:
   | Age | Systolic | Diastolic | result                  |
   | 1   | 70       | 40        | Low Blood Pressure      |
   | 1   | 90       | 70        | Ideal Blood Pressure    |
   | 1   | 120      | 81        | Pre-High Blood Pressure |
   | 1   | 140      | 91        | High Blood Pressure     |
"""