# CRUDCatalogoPersonas
Repositorio para versionar el código de la app escrita en .NET y React

# Ejecutar app en un entorno local
1. Crear una base de datos llamada crud_catalogo_personas_db en su servidor de base de datos de preferencia.
2. Reemplazar las credenciales de su servidor de base de datos en el archivo CRUDCatalogosPersonas.Web/appsettings.json.
3. Realizar las migraciones correspondientes, para ello vaya a la Consola del Administrador de Paquetes y, despúes, eliga el proyecto determinado en src\CRUDCatalogosPersonas.Infraestructure.
4. Ejecutar comando Add-Migration Initial
5. Ejecutar comando Update-Database
6. Después ejecutar el proyecto presionando F5.
7. Se abrirá una página simple, para ello, simplemente haga clic en API Documentation (Swagger) o dirigase simplemente a http://localhost:<su_puerto>/swagger/index.html
