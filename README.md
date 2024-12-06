# Sistemi i Shtesav te Femijeve - Kalkulim i Pagesave

Ky është një sistem i ndërtuar me .NET MVC, duke përdorur arkitekturën Clean Architecture. Sistemi është ndarë në katër projekte kryesore, për të siguruar një strukturë të pastër dhe të mirëorganizuar:

- **Tema**: Projekti kryesor që përmban logjikën e biznesit dhe aplikimin e metodave për kalkulimin e pagesave.
- **Tema.DataAccess**: Përdoret për menaxhimin e të dhënave të databazës dhe lidhjen me SQL Database.
- **Tema.Models**: Përmban modelet e përdorura në sistem.
- **Tema.Utilitys**: Përmban funksionalitete të ndryshme ndihmëse për përdorimin e aplikacionit.

## Teknologjitë e Përdorura

- **.NET MVC**: Për zhvillimin e aplikacionit.
- **Dependency Injection**: Përdorur për të siguruar menaxhimin e varësive dhe ndarjen e logjikës.
- **Repository Pattern**: Përdorur për menaxhimin e të dhënave dhe lehtësimin e qasjes në databazë.
- **Unit Of Work**: Për të menaxhuar transaksionet dhe për të siguruar që çdo veprim i bazës së të dhënave të bëhet në mënyrë të integruar.
- **SQL Database**: Përdorur për ruajtjen e të dhënave të sistemit.
- **Librari për Gjenerimin e Raporteve**: Përdorur për krijimin dhe menaxhimin e raporteve.
- **Email Automation**: Përdorur për të dërguar email automatikisht nga sistemi, bazuar në një kusht të caktuar.

## Funksionaliteti Kryesor

Sistemi është zhvilluar për të mundësuar kalkulimin automatik të pagesave të shtesave të fëmijëve për qytetarët e Kosovës, duke u bazuar në kriteret e përcaktuara nga Qeveria e Kosovës. Kriteret janë si më poshtë:

- Nëna me 1 deri në 2 fëmijë paguhet **20 euro për fëmijë**.
- Nëna me më shumë se 3 fëmijë paguhet **30 euro për fëmijë**.

Në sistem janë implementuar gjithashtu mundësitë për të dërguar email automatikisht me një klikim të vetëm, në përputhje me kushtet e caktuara për çdo rast.



# Child Benefits Payment Calculation System

This is a system built with .NET MVC, following the Clean Architecture pattern. The system is divided into four main projects to ensure a clean and organized structure:

- **Tema**: The main project containing business logic and methods for calculating payments.
- **Tema.DataAccess**: Used for managing database operations and connecting to the SQL database.
- **Tema.Models**: Contains the models used within the system.
- **Tema.Utilitys**: Contains helper functions for the application's operation.

## Technologies Used

- **.NET MVC**: Used for developing the application.
- **Dependency Injection**: Utilized to manage dependencies and separate logic.
- **Repository Pattern**: Used for managing data access and simplifying database interactions.
- **Unit Of Work**: Ensures that database transactions are managed and committed as a unit.
- **SQL Database**: Used for storing the system's data.
- **Report Generation Libraries**: Used for creating and managing reports.
- **Email Automation**: Used to send automatic emails from the system based on specific conditions.

## Key Functionality

The system was developed to enable automatic payment calculation for child benefits in the Republic of Kosovo, based on criteria set by the Kosovo government. The criteria are as follows:

- A mother with 1 to 2 children receives **20 euros per child**.
- A mother with more than 3 children receives **30 euros per child**.

The system also includes functionality to automatically send emails with a single click, based on specific conditions for each case.
