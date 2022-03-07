# Ensolvers-Task
 
Built With 🛠️

DataBase: created on PostgreSQL.

FRONTEND: HTML, JS,Boostrap to make a desing Responsive .

BACKEND: to data persistend I worked ORM EntityFrameworkCore on the API, also c#, differents foldes such as Controllers, APIresults, Commands, Models, etc.

1. Open a folder on Visual Studio Code and write on the terminal dotnet new sln and then go to create new proyect, web api, c#, and choose a name.
2. Install:
- Npgsql.EntityFrameworkCore.PostgreSQL
- Microsoft.EntityFrameworkCore.Design
- Swashbuckle.AspNetCore
- Microsoft.AspNetCore.Cors
3. On appsettings.json and appsettings.Developing.json add the string to get access to the database
"ConnectionStrings": {
    "DefaultConnection": "User ID=**; password=***; Server=localhost; Database=toDoList; Integrated Security=true; Pooling=true"
  },

4. On terminal add
dotnet ef dbcontext scaffold "User ID=*; Password=*; Server=localhost; Database=*; Integrated Security=true; Pooling=true" Npgsql.EntityFrameworkCore.PostgreSQL --output-dir Models

User Story
* As an user I want to be able to create, edit and delete a Task
- Acceptance criteria:
  - Buttons Create, Edit and Delete should be visible and change color when hover it.
  - Create Button should add a new Task at the bottom of the List
  - Delete Button should make the task disappear
  - Edit Button should bring the possibility to change the task info.
* As an user I want to see the tasks on a List
- Acceptance criteria:
  - A list of task should appear when uploading the page.
  - Task status should be visible on the List.


MOCKUPS

![ENSOLVERS](https://user-images.githubusercontent.com/100953290/156949023-389bf2b8-fcea-4e0c-800d-69d67b1cf907.jpeg)

![ENSOLVERS](https://user-images.githubusercontent.com/100953290/156949032-8dd41613-cb88-4612-879a-e80227d0dc0f.jpeg)
