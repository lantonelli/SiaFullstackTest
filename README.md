# SIAFullstackTest

Se realizaron dos proyectos dentro de la misma solucion:
- SIAFullstackTest.API: Proyecto backend desarrollado en .NET 8 Web API.
- SIAFullstackTest.Client: Proyecto frontend desarrollado en Angular 16.

## Proyecto Backend
Se usó una base de datos en memoria para simplificar la implementación y evitar la necesidad de configurar una base de datos externa.

Se utilizó .net Entity Framework para la gestión de datos en el backend. Se usó el enfoque Code First para definir el modelo de datos y crear la base de datos en memoria'.
No obstante, se muestra a continuación los scripts SQL para crear las tablas necesarias. 

```sql
CREATE TABLE dbo.Category (
	CategoryId INT NOT NULL CONSTRAINT PK_Category PRIMARY KEY,
	[Name] NVARCHAR(100) NOT NULL
)

CREATE TABLE dbo.Product (
	ProductId INT NOT NULL CONSTRAINT PK_Product PRIMARY KEY,
	[Name] NVARCHAR(100) NOT NULL,
	[Description] NVARCHAR(500) NOT NULL,
	[Image] NVARCHAR(500) NULL
)

CREATE TABLE dbo.ProductCategory (
	CategoriesCategoryId INT NOT NULL CONSTRAINT FK_ProductCategory_Category FOREIGN KEY REFERENCES dbo.Category(CategoryId),
	ProductsProductId INT NOT NULL CONSTRAINT FK_ProductCategory_Product FOREIGN KEY REFERENCES dbo.Product(ProductId),
	CONSTRAINT PK_ProductCategory PRIMARY KEY (CategoriesCategoryId,ProductsProductId)
)
```

## Swagger UI
El proyecto backend incluye Swagger UI para facilitar la exploración y prueba de las API. Una vez que el proyecto esté en ejecución, puede acceder a Swagger UI en la siguiente URL:
```
https://localhost:7089/swagger/index.html

```
Reemplazar el puerto en función del que se publique la solución.


## Proyecto Frontend

para ejecutar el proyecto frontend, desde la línea de comandos y ubicados en la carpeta correspondiente al proyecto (donde se ubica el archivo package.json), Ejecutar el siguiente comando:

```bash
npm start
```
Una vez que hayan corridos todos los proceso e instalar las dependencias necesarisas, se ejecutará el proyecto

### Configuración
Dentro de la carpeta environtments encontraremos un archivo de configuración "environment.ts"

En este lugar se deberá configurar la ruta de la api del backend

```typescript
export const environment = {
  production: false,
  apiUrl: 'https://localhost:7089/api'
};

```