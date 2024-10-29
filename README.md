Usando .net Core 7.0<br>
Banco de dados SQL Server<br>
ORM: EntityFramework Core 7<br>
123Vendas tem o back end na pasta scr\Back<br>

O projeto está separadas com as camadas Api, camada service, camada de domínio e camada de persistencia. Verificações para bootstrap do projeto:![Solution](https://github.com/user-attachments/assets/1661e6b7-e4a5-4106-8cf5-21becd67eca9)

Logs com Serilog.

![logs](https://github.com/user-attachments/assets/7e0a03b6-79b3-4559-854d-325795bcb09c)

Ajustar a string de conexao da base na seção do arquivo appsettings.Development.json conforme servidor de banco de dados
{ "ConnectionStrings": { "DefaultConnection": "Server=DESKTOP-7GFSE0V;Database=DbTask;Trusted_Connection=True;Encrypt=False;" }.

Executar as migrações do EF Core no powershell ou via terminal caso use VsCode.
dotnet ef migrations add start -s ../123Vendas.Api
dotnet ef database update -s ../123Vendas.Api

![swaggerApi](https://github.com/user-attachments/assets/995d4936-880f-4858-888f-8fb5a67c0d06)

