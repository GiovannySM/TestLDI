<a name="inicio"></a>
Api REST - Líder De Desarrollo De Integraciones
=======

+ [Instalación](#instalacion)
 	+ [Generalidades](#general)
+ [Uso](#uso)
    + [Modificación appsettings.json](#appsettingsjson)
    + [Ambientes](#test)
    + [Autenticación Header](#autenticacion)


<a name="instalacion"></a>
## Instalación
La Instalación de la base de datos, es automatica ya que se empleo el EF para su correcto funcionamiento, se debe realizar la configuración del appsettings.json

[<sub>Volver a inicio</sub>](#inicio)
<br>

<a name="uso"></a>
## Uso
<a name="appsettingsjson"></a>
### Modificación appsettings.json.

- Modificar la cadena DefaultConnection del appsettings.json, se debe asignar el nombre del servidor, base de datos, usuario y password.
```php
Server=(Local);Database=TestLDI_864746;User=sa;Password=Password;MultipleActiveResultSets=true
```

Se debe validar que se cuente con el acceso al servidor de base de datos, el servidor puede ser local o remoto, el modelo de datos sera el siguiente.

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

<a name="test"></a>
### Ambientes

### Local
Se debe ejecutar 
```php
  http://localhost:{puerto}/api/PhoneDirectories
```
### Swagger
Se debe ejecutar 
```php
  http://localhost:{puerto}/swagger/index.html
```

[<sub>Volver a inicio</sub>](#inicio)
<br>

<a name="autenticacion"></a>
### Autenticación Header
El SDK permite ejecutar las transacciones validando la presencia de un header "JWT". En caso de que este valor no se encuentre presente se debe responder con un código 401 Not Authorized.
Esta funcionalidad es útil para obtener los parámetros de configuración dentro de la implementación.

**Observación**: El "JWT" se debe enviar con el siguiente valor ABCCDEFSS03457273647

[<sub>Volver a inicio</sub>](#inicio)
