# TestMonitorTesting
This is the solution with tests for [TestMonitor](https://www.testmonitor.com/) Web Application

## Features
- UI and API tests
- Logging
- Allure report

## Tests list
#### API
- Get, Create, Update, Delete Requirement
- Get, Create, Update, Delete TestSuite

#### UI
- Add Requirement
- Post and Delete Messages

## Technologies
**NuGet packages used in the solution:**
- Microsoft.Extensions.Configuration
- Allure.NUnit
- Newtonsoft.Json
- RestSharp
- Bogus
- NLog
- NUnit
- Selenium.Support
- Selenium.WebDriver

**Approaches used in the development of the framework and tests:**
- Driver Factory
- Page Object
- Wrappers
- Chain of invocation

## Configuration
The solution uses a configuration JSON file:
```Core/Settings/Files/appsettings.json```
```JSON
{
  "Browser": {
    "Url": "Url",
    "HeadLess": "true",
    "Type": "chrome",
    "TimeOutSeconds": 10,
    "TimeOutTearDown": 10,
    "ImplicitTimeOutSeconds": 1,
    "Login": "login",
    "Password": "password"
  },
  "API": {
    "AppUrl": "ApiUrl",
    "AppToken": "ApiToken",
    "MainProjectId": 1
  }
}
```

## Installation
Register on the [TestMonitor](https://www.testmonitor.com/)
Create your API token
Replace  **Url**, **Login**, **Password**, **AppUrl**, and **AppToken** in the config file
You are ready to run UI and API tests
