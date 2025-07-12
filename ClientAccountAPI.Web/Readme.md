#ClienAccountAPI 
## Es una API Rest desarrollada en .NET Core 8. Contiene las funcionalidades de: 
- Crear un cliente (Informaci�n m�nima)
- Crear una cuenta 
- Realizar Deposito y Retiros
- Historial de transacciones (Depositos y Retiros)
- Consulta de Informaci�n de la cuenta

## Requisitos previos
- [.NET SDK 8.0+](https://dotnet.microsoft.com/download)
- [Visual Studio 2022](https://visualstudio.microsoft.com/es/) con soporte para ASP.NET y EF Core
- [SQLite](https://www.sqlite.org/index.html) 
- [Postman](https://www.postman.com/downloads/)

## �C�mo levantar el proyecto?

### 1. Clonar el repositorio

### 2. Restaurar dependencias
- dotnet restore
- dotnet build

### 3. Migraciones de Base de datos
- dotnet ef migrations add InitialCreate
- dotnet ef database update

### 4. Ejecutar Proyecto
- dotnet run

## Endpoints
- api/customer
- api/customer/{id}
- api/BankAccount
- api/BankAccount/{AccountNumber}
- api/accountHistory/deposito
- api/accountHistory/retiro
- api/accountHistory/history/{accountNumber}



