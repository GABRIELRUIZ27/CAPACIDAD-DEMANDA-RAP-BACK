🚀 ¿Cómo ejecutar este proyecto?


Editar la cadena de conexión en el archivo appsettings.json:

🔐 Importante: Asegúrate de ingresar una contraseña válida para tu servidor SQL.

Aplicar la migración a la base de datos:

dotnet ef database update

Esto creará la base de datos y sus tablas automáticamente.

📥 ¿Cómo funciona?
Esta API expone un endpoint tipo POST en /api/PotenciaParticipante/todos que, al ser llamado, descarga y guarda información simulada en la base de datos.

El frontend en Angular es el que realiza esta llamada, por lo que no es necesario ejecutarla manualmente desde Postman o Swagger.

⚠️ Importante
Asegúrate de que el puerto en el que corre esta API coincida con el configurado en el servicio del frontend (potencia.service.ts).
Ejemplo: http://localhost:5063
