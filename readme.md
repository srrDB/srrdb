# srrdb (database)

## Introduction
This is an idea of how the structure for srrdb could be

## Requirements
- Visual Studio 2019 Community
    - "ASP.NET and web development"

- .NET Core SDK 3.1.301
- MySQL 5.5+

## Installation
First, start by running the following SQL commands to create the required user for MySQL:

- CREATE SCHEMA \`srrdb2.0\` DEFAULT CHARACTER SET utf8mb4;
- CREATE USER \`srrdb2user\`@\`%\` IDENTIFIED BY '123456';
- GRANT ALL PRIVILEGES ON \`srrdb2.0\`.* TO \`srrdb2user\`@\`%\`;
- FLUSH PRIVILEGES;

Open up cmd in the "src" directory and run the following command:

- dotnet tool install --global dotnet-ef
- dotnet tool update --global dotnet-ef

To create the migration and generate the tables automatically run the following commands:

- dotnet ef migrations add InitialCreate
- dotnet ef database update

