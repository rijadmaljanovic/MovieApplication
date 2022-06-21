# MovieApplication
This is a project I created from scratch with .NET Core 3.1 and Angular 13.

# Requirements:
 Databases:
 -SQL Server ( SQL Server , graphical tool -> Microsoft SQL Server Management Studio )
 
# Setup:
You can set the connection string in appsettings.json by your requirements or leave the present one.

After you set up the connection string, the next step you should do to properly start the entire application is:

Inside Package Manager Console you should run one command:
 *Make sure if you want to update DatabaseContext your default project should be: MusicApplication.Infrastructure

 `update-database`
 
After that make sure that the startup project is set to 'MusicApplication.Backoffice' and then start the backend. 
After you start the project the database initializer will fill the tables with data and add 5 users:

Username: User1
Password: User1
...
Username: User5
Password: User5

On the frontend type the command `npm install` and after that `ng serve`.

# About the project: 
I decided to create this project as a good template for every startup project. I choose a theme (movies) but it is easy to change to anything that is needed.
I hope this template will find someone who wants to start a new project or learn with it.
If someone who sees this has some questions about the project or whatever else feel free to contact me at:
             Email: rijadmaljanovic98@gmail.com
             
What do I implement?

-Repository pattern with SOLID principles (clean architecture)

-SOLID pattern on the frontend side (DI)
*I always use different design patterns because they encourage us to create more maintainable, understandable and upgradable applications*

-JSON data seed

-Oauth2 auth - JWT

-AutoMapper, Swagger with bearer auth, CORS policy, static files set up for images

-The application is mobile responsive (bootstrap) 

-Lazy loading for movie component
 
