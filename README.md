# Peirre's Bakery

#### By Richelle Thorpe 

#### This application set in a bakery that lets the uses keep track of treats offered and the flavor tags associated with them.

## Technologies Used

- C#
- CSHTML
- .NET 6
- ASP.NET Core
- Markdown
- Entity Framework Core & Identity


## Description

- This application will allow the user to register an account and then login. Once they do that they will be able to add baked goods (treats) and flavors to the system. It will also allow the user to add multiple flavors to treats as well as to add multiple treats to flavors.

## Setup/Installation Requirements

**DATABASE**
- Install and configure MySQL using these [instructions](https://www.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-and-configuring-mysql).
- Install [MySQL Workbench](https://www.mysql.com/products/workbench/) on your computer if it isn't already.


**REPOSITORY**
- Clone this repository.
- Within the production directory "Bakery", create a new file called appsettings.json.
- Within appsettings.json, put in the following code, replacing the database name with your database naming convention, uid and pwd values with your own username and password for MySQL. 

>{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=[database_name];uid=[id_here];pwd=[your_password];"
  }
}

- Once appsettings.json is complete and you have created your models with all object variables that you want in your database completed, run `dotnet ef migrations add Initial`. Then `dotnet ef database update` to complete migration to your database.
- Run `dotnet watch run` in the command line to start the project in development mode with a watcher.
- Open the browser to _https://localhost:5001_. If you cannot access localhost:5001 it is likely because you have not configured a .NET developer security certificate for HTTPS. To learn about this, review this lesson: [Redirecting to HTTPS and Issuing a Security Certificate](https://www.learnhowtoprogram.com/c-and-net/basic-web-applications/redirecting-to-https-and-issuing-a-security-certificate).

## Known Bugs

- No known bugs.

## License

Copyright 2023 Richelle Thorpe; Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions: The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software. THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.