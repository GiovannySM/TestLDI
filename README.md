<a name="inicio"></a>
Api REST - Líder De Desarrollo De Integraciones
=======

+ [Instalación](#instalacion)
 	+ [Modificación ConnectionString](#appsettingsjson)
	+ [Generar Token](#token)	
	+ [Instalar Base de Datos](#installDB)
+ [Uso](#uso)


<a name="instalacion"></a>
## Instalación
El API REST desarrollado en .NET Core, usará las migraciones para crear la base de datos a partir del modelo de EF Core, para tener el acceso a datos básicos mediante Entity Framework Core.

<a name="appsettingsjson"></a>
### Modificación appsettings.json.

Modificar la cadena de conexión DefaultConnection del appsettings.json, se debe asignar el nombre del servidor, base de datos, usuario y password.

```php
Server=(Local);Database=TestLDI_864746;User=sa;Password=Password;MultipleActiveResultSets=true
```

Se debe validar que se cuente con el acceso al servidor de base de datos, el servidor puede ser local o remoto, el modelo de datos será el siguiente.


Campo       | Descripción           | Tipo de dato | Ejemplo
------------|-----------------------|--------------|--------
id          | Id del Directorio Telefónico    | autonumérico     | 1
name      | Nombre   | string       | "Giovanny"
surnames        | Apellidos | string       | "Salamanca"
email     | Email          | EmailAddress     | "giovannysalamanca1986@gmail.com"
phone | Telefóno      | int       | 7818181
cellphone | Telefóno Celular    | int       | 3008506622

Ejemplo de respuesta:

```php
  {
    "id": 0,
    "name": "string",
    "surNames": "string",
    "email": "string",
    "phone": "string",
    "cellPhone": "string"
  }
```
[<sub>Volver a inicio</sub>](#inicio)
<br>

<a name="token"></a>
### Generar Token

El API REST, contiene autenticación por JWT JSON Web Token. En caso de que este valor no se encuentre presente se debe responder con un código 401 Unauthorized, para ello se deberá iniciar la aplicación de la siguiente manera:

```php
  http://localhost:{puerto}/swagger/index.html
```

### Tokens
### Get /api/Tokens

Enviar en el Parámetro *ApiKey* el Valor: ABCCDEFSS03457273647, si se envía otro valor salda error en el ApiKey.

**Observación**: Todos los métodos del API REST, requieren autenticación por Token.

El Token generado deberá enviarse en el menú Authorize el valor del token: Authorization: Bearer {token generado}

Se podrá tener acceso a los métodos del *InstallDB, PhoneDirectories*

[<sub>Volver a inicio</sub>](#inicio)
<br>

<a name="installDB"></a>
### Instalar Base de Datos

Después de realizar la autenticación, se debe consumir el método 'GET' del api/InstallDB

### InstallDB
### Get /api/InstallDB

```php
  http://localhost:{puerto}/swagger/index.html
  http://localhost:{puerto}/api/InstallDB
```
[<sub>Volver a inicio</sub>](#inicio)
<br>

<a name="uso"></a>
### Uso

Su uso y documentación está basado en Swashbuckle.AspNetCore, que permite ejecutar la aplicación con Swagger.

```php
  http://localhost:{puerto}/swagger/index.html
```
[<sub>Volver a inicio</sub>](#inicio)
<br>
