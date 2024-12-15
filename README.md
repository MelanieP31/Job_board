
# JobBoard project

This application is a web platform designed to centralize and streamline the recruitment process for companies while offering an accessible space for candidates to easily apply for job postings.

The goal of this application is to create a space where recruiters can publish job listings, track applications, and manage company information. Candidates can explore job openings, apply and upload their resumes.

## Functionalities Overview

### Users
- A user can register and log in using their email and password.
- Once logged in, a user can access their profile page.
- Users can:
  - View their first name and last name (non-editable).
  - Add, modify, or delete:
    - Email
    - Password (used for authentication)
    - Phone number
    - Description
    - City
    - Skills
    - Education (formations)
    - Work experiences
- Users can view job offers and apply to them.
  - Applications are pre-filled with the user's profile information.
  - Users can add a personalized message to their application.
- Users have access to their application history and can view the status of their applications (`in progress`, `accepted`, `rejected`).

### Companies
- A company can log in using an email and password.
- Once logged in, a company can:
  - Edit their profile information (name, description, location).
  - Create and delete job offers.
  - View details of all job offers.
  - Update the status of applications (`in progress`, `accepted`, `rejected`).

### Administrators
- Administrators log in with specific credentials.
- Administrators have access to a special dashboard where they can:
  - View, edit, or delete:
    - All users
    - All companies
    - All job offers
    - All applications

## Tech Stack

**Client:** Angular TailwindCSS
![Angular](https://img.shields.io/badge/Angular-DD0031?style=for-the-badge&logo=angular&logoColor=white)

**Server:** Developed in C# with ASP.NET Core, following an MVC architecture.
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white) 
![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-5C2D91?style=for-the-badge&logo=.net&logoColor=white)



**Database:** SQL ![SQL](https://img.shields.io/badge/SQL-4479A1?style=for-the-badge&logo=sqlite&logoColor=white)


## UML Diagram

Here is the UML diagram of the database structure:

![UML Diagram](./umlData.png)



CREATION DU BACKEND  

* Installer .NET SDK : https://dotnet.microsoft.com/download  
* Commande : dotnet --version  
* dotnet new webapi -n NameProject  
* cd NameProject  
* dotnet run  

1. Dossier bin : Contient les fichiers compilés.  
2. Dossier obj : Contient les fichiers intermédiaire de compilation.  
3. Dossier Properties : Contient les fichiers de configuration du projet.  
4. Program.cs : Fichier principal où l'exécution de l'application démarre. 
5. appsettings.json : Contient les configurations, comme la connexion à la base de données.   
6. backend.csproj : Fichier avec les dépendances et configurations du projet.  
7. backend.http : Fichier pour tester les requêtes HTTP.