# Holidays-in-countries
📚 Hi!This is a console application. 📚 

# About
The application applies principles of domain-driven design, where:
- domain holds models, enums, interfaces, services, helpers and extensions;
- infrastructure holds repositories and data context;
- webapi holds controllers.


The project on startup seeds data for supported countries. If a user tries to reach endpoints and the data is not stored in the database, the controller calls methods from the service and repository. Therefore, the service creates a new instance of an object from JSON, and the repository saves that data. The next time user is calling the same endpoint, data will be taken from a database.
In addition, the project has three controllers that use different models, repositories, and services. First, SupportedCountry controller returns a list of all supported countries and country holidays bu a given year. Second, DayStatusController returns are the day in a country working or not. Third, MaxHolidayPeriodController returns the biggest duration of free days in a year for a country.
