# :floppy_disk: Reactivities

Simple app to manage activities.
<br>
This app was created following Clean Architecture - CQRS and MediaR.  

# :mega: Main Teack Stack
:hammer: Frontend: 
<br>
&nbsp; ![React](https://img.shields.io/badge/react-%2320232a.svg?style=for-the-badge&logo=react&logoColor=%2361DAFB)

&nbsp; [![TypeScript](https://badgen.net/badge/icon/typescript?icon=typescript&label)](https://typescriptlang.org)
&nbsp; [![Visual Studio Code](https://img.shields.io/badge/--007ACC?logo=visual%20studio%20code&logoColor=ffffff)](https://code.visualstudio.com/)
&nbsp; [![Npm](https://badgen.net/badge/icon/npm?icon=npm&label)](https://https://npmjs.com/)
&nbsp; [![Mobx](https://img.shields.io/badge/-Mobx-informational?logo=mobx&logoColor=FF9955&style=flat)](https://www.npmjs.com/package/mobx)
&nbsp; [![Mobx React Lite](https://img.shields.io/badge/-Mobx%20React%20Lite-blueviolet?logo=mobx&logoColor=FF9955&style=flat)](https://www.npmjs.com/package/mobx-react-lite)
&nbsp; [![Semantic UI React](https://img.shields.io/badge/-Semantic%20UI%20React-orange?logo=semantic-ui-react&logoColor=35BDB2&style=flat)](https://www.npmjs.com/package/semantic-ui-react)
&nbsp; [![Axios](https://img.shields.io/badge/-Axios-yellowgreen)](https://github.com/axios/axios)
&nbsp; [![Formik](https://img.shields.io/badge/-Formik-green)](https://formik.org/)
&nbsp; [![React Router](https://img.shields.io/badge/-React%20Router-blue)](https://v5.reactrouter.com/web/guides/quick-start)

:hammer: Backend:
<br>
&nbsp; [![.NET Core](https://img.shields.io/badge/-.NET%20Core%206-9cf?logo=.net&logoColor=512BD4&style=for-the-badge)](https://dotnet.microsoft.com/)

&nbsp; [![.NET](https://img.shields.io/badge/--512BD4?logo=.net&logoColor=ffffff)](https://dotnet.microsoft.com/)
&nbsp; [![Clean architecture](https://img.shields.io/badge/-clean%20architecture-important)](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures#clean-architecture)
&nbsp; [![CQRS](https://img.shields.io/badge/CQRS-Command%20and%20Query%20Responsibility%20Segregation-yellow)](https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs)
&nbsp; [![MediatR](https://img.shields.io/badge/MediatR-Mediator%20Pattern-yellowgreen)](https://dotnetcoretutorials.com/2019/04/30/the-mediator-pattern-part-3-mediatr-library/)
&nbsp; [![Entity Framework](https://img.shields.io/badge/ORM-Entity%20Framework%20Core-blueviolet)](https://docs.microsoft.com/en-us/ef/core/)
&nbsp; [![Migrations](https://img.shields.io/badge/EF%20Migrations-Code%20First-orange)](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli)
&nbsp; ![SQLite](https://img.shields.io/badge/Database-SQLite-lightgrey)
 
## 📍 Useful .NET CLI Commands
<br/>
:speaker: .NET CLI REFERENCE: https://docs.microsoft.com/en-us/ef/core/cli/dotnet
<br/>
:computer: Info
```dotnetcli
dotnet --info
```
:computer: Help
```dotnetcli
dotnet -h
```
:computer:  List templates available to create new dotnet projects or files or solutions
```dotnetcli
dotnet new -l
```

:computer: Creates a Solution with the name of the current directory by default
```dotnetcli
mkdir 'SolutionName'
cd 'SolutionName'
dotnet new sln
```
:computer: Creates all necessary .Net Projects for this app
```dotnetcli
dotnet new classlib -n Application
dotnet new webapi -n API (gives a name of API)
dotnet new classlib -n Domain
dotnet new classlib -n Persistence
```

:computer: Add projects to the solution
```dotnetcli
dotnet sln (commands available for the solution)
dotnet sln add API/API.csproj
dotnet sln add Application (no need to specify the csproj file. Looks inside the folder and if finds .csproj than adds to the solution).
dotnet sln add Persistence
dotnet sln add Domain
```

:computer: Add onion-architecture style dependencies
```dotnetcli
cd API
dotnet add reference ../Application
cd ../Application
dotnet add reference ../Persistence
dotnet add reference ../Domain
cd ../Persistence
dotnet add reference ../Domain
```
:speaker: For visual studio code, if you do not wish to keep .bin and .obj folders. go to file-> prefrences -> settings-> type exclude: Add **/bin, add **/obj.
The files will be deleted and regerenated everytime we build and run the application.

:computer: Run the API
```dotnetcli
dotnet watch run
```
## 📍 Useful .NET Migrations Commands
<br>
Useful notes about package dependencies and cli commands.
<br>
:speaker: Useful EF Tutorial: https://www.entityframeworktutorial.net/efcore/pmc-commands-for-ef-core-migration.aspx
<br><br>
:speaker: Notes
1. Make sure you have the right EF Package installed at your Persistence Layer (Or wherever the DbContext lives)
and startup project contains Microsoft.EntitiyFrameworkCore.Design
E.g. DbContext at X.Persistence project have "Microsoft.EntitiyFrameworkCore.SqlServer" installed.
2. Need to have and DbContext class in your persistence layer with a dbset.
3. Check if you have the dotnet tools installed at the Solution level.:computer: dotnet tool list --global. if dotnet-ef is not listed, go to www.nuget.org/packages/dotnet-ef and run the .NET CLI command as instructed
 (dotnet tool install --global dotnet-ef --version 5.0.1). Note that if is already installed and you wish to update just change the word "install" for "update".


:computer: List of commands available
```dotnetcli
dotnet ef -h
```
:computer: Adding migrations: -p (Project) -s (StartupProject)
```dotnetcli
dotnet ef migrations add MigrationsName -p .\'PersistenceProjectDirectory' -s .\'StartupProjectDirectory'
```
:computer: Removing migrations
```dotnetcli
dotnet ef migrations remove (remove latest migration)
```
:computer: Database Help
```dotnetcli
dotnet ef database -h
```

:computer: Database Update 
```dotnetcli
dotnet ef database update (latest migration)
dotnet ef database update 'migrationName' (Specific migration)
```

📍 GitHub license
<br>
&nbsp; ![GitHub license](https://img.shields.io/github/license/Naereen/StrapDown.js.svg)