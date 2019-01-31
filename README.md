# RoboFan Web Application
The purpose this learning project is to build a web application that can satisfy the following requirements.

## Business Requirements

- The application accepts search input in a text box and then displays in a pleasing style a list of people where any 
  part of their first or last name matches what was typed in the search box (displaying at least name, address, age, 
  interests, and a picture). 
    - [X] Displaying required information (likes/dislikes are the interests).   
    - [X] Displaying two images (one is a static resource and other is served from the database).
    - [X] Search box allows user to filter the records by the name fields.             
- Solution should either seed data or provide a way to enter new users or both.
    - [X] When database is creating, it will be seeded with three (3) randomly generated records.  
    - [X] Users can create a single record specifying the name values on the Settings/Create tab. 
    - [X] Users can generate more random records from the Settings/Generate tab.              
- Simulate search being slow and have the UI gracefully handle the delay.
    - [X] Users can adjust the response dely values on the Settings/Delay tab.   

## Technical Requirements
- A Web Application using WebAPI and a front-end JavaScript framework (e.g., Angular, AngularJS, React, Aurelia, etc.) 
    - [X] .NET Core ASP.NET Web Application using Angular.   
- Use an ORM framework to talk to the database.
    - [X] Entity Framework for .NET Core using Code First and SQLite Database.   
- Unit Tests for appropriate parts of the application.
    - [X] XUnit testing framework.   

## Design
### Overview
The RoboFan application will manage a list of people/fans in which each person will identify a single MLS Soccer
Team as their primary team.  Each fan will also be able to identify a set of other teams as either likeable or unlikeable.
The teams are randomly assigned to each fan.

### Web Application
The web application will provide a UI that will display a list of cards for each RoboFan.  The Card will display 
their primary MLS team along with the RoboFan demographic information.  The [**RoboHash**](https://robohash.org/) 
website will be used to generate an image for each RoboFan.  The web UI will provide a text box that will allow 
the user filter the list of fans by their name values (first and last names).

Initially when the web application creates a new database, it will seed the database with a random set of RoboFan
records.  The web application will also provide a way for the end user to generate more random records into the
database.  The user can also create a single record in which they can specify some of the fan information.

The web application will also provide a method in which the end user can enable a delay into each response
from the web backend.  This will be used to simulate slower network connections so the web UI can be validated
under different conditions.

### Development Tools and Environment
- Visual Studio 2017 Community Edition
- Angular 7 with Material Design UI
  - Angular CLI (v7.2.3)
  - NodeJs (v10.15.0)
- .NET Core 2.2
- Microsoft.EntityFrameworkCore
- SQLite Database
  - DB Browser for SQLite Utility
- xUnit Testing Framework
- GitHub Source Code Repository
  - **master** branch will hold tagged intermediate releases along with final release
  - **develop** branch will be used for developing new features
- ToDo List to manage list of development tasks
