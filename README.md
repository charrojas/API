# Backend - Proyecto LogicalData

Este proyecto corresponde al **backend** de la aplicación LogicalData, desarrollado en **.NET 9** y utilizando **SQL Server** como gestor de base de datos. El mismo fue creado y probado en **Visual Studio 2022**.

---

## Requisitos previos

Antes de ejecutar el proyecto, asegúrate de tener instalados los siguientes componentes:

- Visual Studio 2022
- .NET 9 SDK
- SQL Server (versión Express o superior)
- SQL Server Management Studio (SSMS) para ejecutar scripts SQL

---

## Configuración de la base de datos

1. Abrir el archivo `SqlQueryLogicalDataDB.sql` ubicado en:  
   `src/Core/LogicalData.Data/QueryDB`

2. Copiar todo el contenido del script y pegarlo en **SSMS** en una nueva consulta.

3. Ejecutar el script para **crear la base de datos y las tablas correspondientes**.

4. Verificar que la base de datos `LogicalDataDB` se haya creado correctamente en SSMS.

---

## Configuración del API

1. Abrir el archivo `appsettings.json` ubicado en:  
   `src/API/API/appsettings.json`

2. Modificar la cadena de conexión para apuntar a tu instancia de SQL Server:

  "ConnectionStrings": {
    "DataBase": "Server=CHARLOTTE\\SQLEXPRESS; Database=LogicalDataDB; Trusted_Connection=True; TrustServerCertificate=True"
    }

También en LD.Data -> Context -> LogicalDataDbContext.cs

protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlServer("Server=CHARLOTTE\\SQLEXPRESS; Database=LogicalDataDB; Trusted_Connection=True; TrustServerCertificate=True");

Reemplaza  por el nombre de tu máquina o instancia de SQL Server.

---

## Ejecución del proyecto

Crear un usuario para poder utilizar la aplicación web mediante el endpoint:

POST /api/Usuario/RegistrarUsuario en Swagger

Este endpoint permite registrar un nuevo usuario con nombre, apellido, usuario y contraseña.
