# appClienteDemo
.Net Core 2.0 Angular2

## Rodar aplicacao maquina local
 Npm install
 dotnet restore

### Configurar database 
   Arquivos:
     appsettings.Development.json 
     appsettings.json
     *Criar DataBase e atualizar ConnectionString

### Rodar Migration
  dotnet ef database update


### Modo Debug
   Windows
   set ASPNETCORE_ENVIRONMENT=Development
   Linux
   export ASPNETCORE_ENVIRONMENT=Development
   
 dotnet run
