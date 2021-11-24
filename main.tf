terraform {
  required_providers {
      azurerm = {
      source = "hashicorp/azurerm"
      version = "=2.71.0"
    }
  }
}

# Configure the Microsoft Azure Provider
provider "azurerm" {
  features {}
}

resource "azurerm_resource_group" "CA_Resource" {
  name     = "CA3"
  location = "Central US"
}

resource "azurerm_app_service_plan" "service-plan" {
  name = "simple-service-plan"
  location = azurerm_resource_group.CA_Resource.location
  resource_group_name = azurerm_resource_group.CA_Resource.name
  reserved = false
  sku {
    tier = "Standard"
    size = "S1"
  }
  tags = {
    environment = "Production"
  }
}

resource "azurerm_app_service" "webapp" {
  name                = "webapp-ca2"
  location            = azurerm_resource_group.CA_Resource.location
  resource_group_name = azurerm_resource_group.CA_Resource.name
  app_service_plan_id = azurerm_app_service_plan.service-plan.id
  site_config {
    windows_fx_version = "DOTNETCORE|3.5"
   # dotnet_framework_version = "v3.5"
  }
}

resource "azurerm_app_service_slot" "example" {
  name                = "webapp-ca2dev"
  app_service_name    = azurerm_app_service.webapp.name
  location            = azurerm_resource_group.CA_Resource.location
  resource_group_name = azurerm_resource_group.CA_Resource.name
  app_service_plan_id = azurerm_app_service_plan.service-plan.id
  tags = {
    environment = "Development"
  }
  }
