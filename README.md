# AssestmenNowOptics

This is an ASP.NET API made for the techncal Assesment for Now Optics. Here are some instructions to run the project:

1. Clone the repository.
2. Set the connection string in appsettings.json file. Please keep the property Encrypt in false.
3. Run migrations: In the project directory, run the following command:
   ``` dotnet ef database update ```. It will create the database and his tables.

4. Run the project.

The project has Swagger documentation to see the list and uses for each endpoint. For example, if you run the project in the port number 7038, the documentation URL is: http://localhost:7038/swagger/index.html. 
