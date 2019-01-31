### Development Environment

- [X] Setup Github repository and branches
- [X] Use Visual Studio to Generate Angular Web Project Template
- [X] Create empty placeholder projects

### Data Management
- [X] Define the initial set of data entities 
- [X] Define data transfer objects for the web application
- [X] Add in required dependencies for EFCore and SQLite
- [X] Implement required classes for data access layer
- [X] Add code to seed the teams table since this data is static
- [X] Add unit test for computation of age from birthdate value
- [x] Add code and unit tests to be able to generate fake/mock data for the data entities
- [X] Pre-generate some of the robot images using python to improve web app performance
- [X] Add in server logging framework
- [X] Add code to seed the database tables with random data (currently only 1 robo fan when database is created)
- [X] Implement REST API controller for fans (**images**, **search**, **creating**, **generating**, **delay**)
- [X] Add in middleware to simulate slower response times
- [ ] Update to pull the database connection string from the configuration file
- [ ] Support for setting up an in memory database for unit testing
- [ ] Write unit tests for fetching images and saving/retrieving from database
- [ ] Write unit tests for the repositories
- [ ] Add in support for data pagination 

### Angular Frontend

- [X] Update Angular to the Latest Version
- [X] Import in Angular Material and stub out the UI
- [X] Implement stub data services which provide data from JSON files
- [X] Implement UI Components using these stub data services
- [X] Add settings page to create single record (specifying fan name/address info only)
- [X] Add settings page to generate more random records
- [X] Add settings page to adjust the web server response delay times
- [X] Update application to use data from actual web service
- [X] Remove mocked data and image assets from the client app directory
- [X] Add in overlay spinner for slow responses
- [ ] Add in settings form validation
- [ ] Add in support for scrolling/paging the list of cards

### Final Items

- [ ] Refactor code to simplify solution
- [ ] Review and update project documentation
- [ ] Verify clean pull from GitHub works properly
