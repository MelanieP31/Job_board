
# JobBoard project

This application is a web platform designed to help companies published their job opportunity and candidates to apply for job postings.

## Functionalities Overview

### Users
- A user can register and log in using their email and password.
- Once logged in, a user can access their profile page (view, edit, delete, or add informations about them) : 
  - Email, name, description, city, skills, educations, work experiences ...
- Users can view job offers and apply to them.
  - Applications are pre-filled with the user's profile information.
  - Users can add a personalized message to their application.
- Users have access to their application history and can view the status of their applications (`in progress`, `accepted`, `rejected`).
### Companies
- A company can log in using an email and password.
- Edit their profile information (name, description, location).
- Create and delete job offers.
- View details of all applications opn their offers.
- Update the status of applications (`in progress`, `accepted`, `rejected`).
### Administrators
- Administrator system.

## Tech Stack

![Angular](https://img.shields.io/badge/Angular-DD0031?style=for-the-badge&logo=angular&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white) 
![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![SQL](https://img.shields.io/badge/SQL-4479A1?style=for-the-badge&logo=sqlite&logoColor=white)

## UML Diagram
![UML Diagram](data/umldata.png)


## Backend creation
This part is a step to step "lesson" on how I made the backend part of the project, what I learn of C# and ASP.NET CORE as a first time user.

* Download .NET SDK : https://dotnet.microsoft.com/download  
* Basic command : 
```
dotnet -- version
dotnet new webapi -n NameProject
dotnet run
``` 

* Basic files (add a gitignore file): 

| File | Description |
| --- | --- | 
| `bin`| Compiled files &rarr; gitignore |
| `obj` | Intermediate compilation files  &rarr; gitignore | 
| `Properties` | Folder contains configuration files lauchSettings.json (http localhost). |
| `appsettings.json` | Others configuration like database connexion. | 
|`backend.csproj` | Dependances needed to built the project. |
| /!\  `Program.cs` | Principal file, with code for executing the application. |
  

### Stucture des modèles et relations 

1. Entities  
    
| Name | Description |  
| --- | --- |  
| ` Users ` | User of the application, the candidat. |  
| `Companies` | Enterprise which vreate and publy job offer. |
| `Joboffer` | Job offer from an enterprise. |
| `Applications` | Candidature from candidats. | 
| `Competencies` | List of competencies the candidats can have. |
| `UserCompetencies` | Table of liaison between candidats and competencies |
| `Formations` | Formations of the user |
| `Experiences` | Work experiences of the user |
| `Admins` | Administrator which will have all access |

Annoté avec `[Key]` ou `[Column("nomColonneDb")]` ou `[Required]` pour s'assurer que le paramètre ne peut être null. 

2. Relations

* Users → Applications : **Many-To-One** : A user can do multiple applications. 
* JobOffer → Applications : **Many-To-One** : A job offer can receive multiple applications.
* Companies → Joboffer : **Many-To-One** : A companie can create multiple job offer.
* Users → Formations, Experiences : **Many-To-One** : A user can have multiple formation and experiences. 
* Users → Competencies : **Many-to-Many** : A user can have multiple competencies, and multiple users can have the same competencies.

3. Mapping of relations

  - In Models

  Exemple for Users (which have many Applications) : 
  ```
  public ICollection<Applications>? Applications { get; set; }
  ```

  For Applications (connected with one user) : 
  ```
  [Column("user_id")]
  public int UserId {get; set; }

  [ForeignKey("UserId")]
  public Users? User ;
  ```

  - Configuration file : appsetting.json (gitignore)

  - Connection of entities with the database : **JobBoardContext**   
    Map the entities in the database, configuration of entitites object, the relation. Permit to execute the queries and save change in the database. 

    * Need package : 
    ```
    dotnet add package Microsoft.EntityFrameworkCore
    dotnet add package Pomelo.EntityFrameworkCore.MySql
    ```

    * DbSet : representation of database table 
    ```
    public DbSet<Users> Users { get; set; }
    public DbSet<Applications> Applications { get; set; }
    public DbSet<Companies> Companies { get; set; }
    ```

    * Configuration of relations : Overide method OnModelCreating.  
    Exemple de Users avec Applications (Many-To-One)

    ```
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    base.OnModelCreating(modelBuilder);
    modelBuilder.Entity<Applications>()
    .HasOne(a => a.User)
    .WithMany(u => u.Applications)
    .HasForeignKey(a => a.UserId)
    .OnDelete(DeleteBehavior.Cascade);
    }
    ```






