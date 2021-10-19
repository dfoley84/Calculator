﻿Feature: Getting BP
	Simple Test for getting BP

#Scenario Get Low BP
Scenario: Getting Low BP
  When I fill out the mandartory details 1, 70 and 40
  Then Low Blood Pressure
