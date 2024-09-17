# Back-End Program

This repository contains the back-end of the Productivity Managemer application repository.

The back-end was created using .NET framework in C#, implementing repository pattern.

Starting with the Context folder, which contains the Dapper context initialization, a library to connect your program to SQL databases. Then the Model folder, containing 2 files,
one for the default model object as it is from the database, and another one customized for the project needs. Then the Interface folder that defines the functions to be used, from
Get, Delete, Add and Update. Next, the Repo folder that contains the file that implements the interface functions using Dapper context to write and execute queries. Finally, the Controller
folder that has the HTTP methods that will be displayed on the browser once running.

All the dependency injections and services addition are commented in the Program.cs file.
