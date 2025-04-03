EverPost
========

Una aplicación web construida con .NET 8 y Angular 19, diseñada para gestionar publicaciones y comentarios de manera eficiente.

Diagrama de Relación de Entidades
---------------------------------

[Click aquí para ver el diagrama](https://lucid.app/lucidchart/b6033987-8bc6-4583-bc10-0fd67a361347/edit?viewport_loc=343,-40,2217,1087,0_0&)

Estructura del Proyecto
-----------------------

El repositorio está organizado de la siguiente manera:

└── src/      ├── everpost/       # Proyecto Frontend en Angular 19      &&  everpostapi/    # Proyecto Backend en .NET 8   `

### Tecnologías Utilizadas

*   **Backend**: .NET 8
    
*   **Frontend**: Angular 19, PrimeNG, PrimeFlex
    

Configuración e Instalación
---------------------------
En primer lugar clone el repositorio

SQL
----------
Primeramente crearemos la base de datos.
### Pasos a seguir

*   En una instacia local de su equipo ejecute el archivo scriptEverPost.sql ubicado en src/SQLSERVER

### Backend (everpostapi)

El proyecto backend está desarrollado en .NET 8 y contiene toda la lógica de negocio y los endpoints API.

**Pasos para ejecutar:**

1.  Abri la solución.
2.  Ajuste la cadena de conexion a su instacia de Bd
    
3.  Correr la Api deberia funcionar correctamente.
    

El servidor API se iniciará y estará disponible por defecto en https://localhost:7080 o http://localhost:5080.

### Frontend (everpost)

El proyecto frontend está desarrollado con Angular 19, utilizando PrimeNG para componentes UI y PrimeFlex para el diseño responsivo.

**Requisitos previos:**

*   [Node.js](https://nodejs.org/) (versión recomendada: LTS)
    
*   [npm](https://www.npmjs.com/) (incluido con Node.js)
    

**Pasos para ejecutar:**

```javascript
Npm install
```  

###

Características Principales
---------------------------

*   Gestión completa de publicaciones (crear, leer, actualizar, eliminar)
    
*   Sistema de comentarios
    
*   Interfaz de usuario moderna e intuitiva con PrimeNG
    
*   API RESTful con .NET 8


    

### Acceso a la API

La documentación de la API está disponible a través de Swagger UI una vez que el backend está en ejecución:https://localhost:7080/swagger
