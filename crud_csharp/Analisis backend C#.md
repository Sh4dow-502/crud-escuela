

Segun la investigacion que hice sobre hacer una API y un crud con c#, encontre que necesitaba lo siguiente:

## Entorno y Herramientas
- **C#**: El lenguaje de programacion con el que se hara el crud
- **.NET Runtime**: Motor que permite ejecutar codigo de c#
-  **ASP.NET Core**: Es el framework para crear la API, es como "Express.js"
- **NuGet**: Es un gestor de paquetes, es el paquete oficial de .NET, es como npm 
- **Entity Framework Core (EF Core)**: ORM para manejar la base de datos a traves de clases

 - ### Instalaciones
	 - **dotnet-runtime**: Solo incluye lo más basico. Sirve para aplicaciones de consola
	 - **aspnet-runtime**: es necesario para la API, incluye lo básico y más librerias para manejar HTTP, servidores web y certificados.
	 - **dotnet-sdk**: Este es el "paquete completo" incluye los dos anteriores

Lo que yo voy a instalar es dotnet-sdk para tener todo listo para crear el crud


## Estructura del proyecto
Como vamos a usar EF Core para manejar la base de datos, la estructura de carpetas va a ser similar al de Java.

### Carpetas

Controllers/  
	-  **AlumnosController.cs**: Aqui vamos a definir las entradas de la API.  

Data/  
	-   **AppDbContext.cs**: El puente para conectarnos a la base de datos y le indicamos la tabla, como el Spring Data JAP.  

Models/  
	-  **Alumno.cs**: Es la clase que va a representar la tabla de la base de datos.  

Services/  
	-   **IAlumnoService.cs**: Interfazpara el servicio, aqui definimos que metodos se van a usar.  
	-   **AlumnoService**: Implementacions los metodos de IALumnoService.cs y le indicamos como se van a usar.  