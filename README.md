# appClienteDemo

.Net Core 2.0 Angular2

## Para rodar aplicacao maquina local

Baixar o codigo 

>git clone https://github.com/imitsuo/appClienteDemo.git

`É necessário instalar .Net Core 2.0 e Node.js`

>npm install

>dotnet restore

### Configurar database 

Banco de Dados SqlServer, criar DataBase e atualizar ConnectionString

Arquivos: 

>appsettings.Development.json e appsettings.json


### Rodar Migration

>dotnet ef database update


### Modo Debug

Windows

>set ASPNETCORE_ENVIRONMENT=Development

Linux

>export ASPNETCORE_ENVIRONMENT=Development
 
 ### Execlutar
 
 >dotnet run
