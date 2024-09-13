This solution was created to address the following concerns:
  1. Create a web app to track my kids university progress (broken down by students, school years, courses and assessments with attachments).
  2. Explore and deepen my understanding of Domain Driven Design.
  3. Learn the ins and outs of the React client side library.

Here are the prerequisites to run the solution:
  1. Visual Studio 2022.
  2. Microsoft SQL Server 2022.
  3. Docker Desktop

Here are the steps necessary to run the solution:
  1. Create a secret with the SQL Connection string:
    a. Use this string ""sqlconnectionstring": "Server=host.docker.internal;Database=CourseTracker;User Id={your admin Id};Password='{your password}';MultipleActiveResultSets=true;Trust Server Certificate=True"
    b. Follow instructions here to add a secrets.json file to the CourseTracker.Persistence project with the connection string built above.
  2. Run the Entity Framework migrations to build the database:
    a. In Visual Studio, open the 'Package Manager Console' window.
    b. In the Package Manager Consol window, ensure that CourseTracker.Persistence is set as the Default project.
    c. In the Package Manager Console window, issue command 'update-database'. You should see the migrations sucessfully run.
  3. Ensure that the database has been created in SQL Server 2022.
  4. Set 'Docker-Compose' as the setup project.
  5. Hit F5
