- dotnet tool install -g dotnet-aspnet-codegenerator
- dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
- dotnet restore

- dotnet aspnet-codegenerator controller -name AlumnoController -m Alumno -dc EscuelaContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries -f
