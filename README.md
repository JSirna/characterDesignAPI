# General
Backend for the Character Design Form

## Stack
- .NET Framework (ASP.NET, Entity Framework Core, MVC model)
- SQL Server + Docker

## Setup
### Docker
1. Create Docker container & volume:
    - `docker run -d -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=YOUR_PASSWORD" -p 1433:1433 -v mssql_data:/var/opt/mssql --name YOUR_SERVER_NAME mcr.microsoft.com/mssql/server:2022-latest`
2. Create database and tables
    - See [SQL Script for DB setup](./CharacterDesignForm.sql)

## How to Run
Via Postman: 
- GET request:  `http://localhost:5067/api/character`
- Sample Output:
```json
[
    {
        "characterId": "62e0f76f-d2cd-4f85-889c-b5aa44b76b8e",
        "fullName": "Heather Wong",
        "reasonName": "There is always a reason",
        "nickname": "",
        "reasonNickname": "",
        "birthdate": "02-13-1996",
        "age": 29,
        "dateCreated": "2025-06-05T23:09:10.207"
    }
]
```
