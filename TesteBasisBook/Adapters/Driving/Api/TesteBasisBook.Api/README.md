# VCF API

VCF para criação de microserviços.

# Instalação

Use o [Git](https://git-scm.com/) para clonar o repositório.

```bash
$ git clone https://abcbrasil.visualstudio.com/ValueChainFinance/_git/ABCBRASIL.VCF.API #com http
```

Após clonar o repositório para rodar o projeto é necessário a instalação
do **[.NET Core SDK 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)** e a instalação das dependências como
segue abaixo.

Acesse a pasta do projeto:

```bash
$ cd .\VCF.Api
```

Após acessar a pasta do projeto execute o comando para instalar as dependencias:

```bash
$ dotnet restore
```

OBS: Para executar o projeto é necessário subir o banco postgres, utilize a forma que preferir (instalar na máquina,
docker, etc...)

# Executando o projeto localmente

Para subir o projeto execute o comando:

```bash
$ dotnet run
```

# Swagger

[http://localhost:5000/swagger/index.html](http://localhost:5000/swagger/index.html)

# Migrations

Para interagir com as migrations é
necessário [instalar](https://docs.microsoft.com/en-us/ef/core/cli/dotnet#installing-the-tools) a ferramenta do EF no
CLI.

Atualize o banco de dados na versão mais recente:

```bash
set ASPNETCORE_ENVIRONMENT=Developmen
$ dotnet ef  migrations add nomeMigrations --startup-project ..\..\..\Driving\Api\TesteBasisBook.Api
$ dotnet ef database update --startup-project ..\..\..\Driving\Api\TesteBasisBook.Api
```

# Executando Testes

Na raiz do projeto para rodar os testes unitários e de integração é nescessário instalar as dependencias utilizadas nos
testes.

para instalar as dependências execute o comando:

```bash
set ASPNETCORE_ENVIRONMENT=Testing
$ dotnet ef  migrations add nomeMigrations --startup-project ..\..\..\Driving\Api\TesteBasisBook.Api
$ dotnet ef database update --startup-project ..\..\..\Driving\Api\TesteBasisBook.Api
```
```

para rodar os testes execute o comando:

```bash
$ dotnet test
```

# Testes de Integração

Os testes de integração são feitos utilizando a base postgress_test

```
ABCBRASIL.VCF.API/VCF.Api.IntegrationTests/bin/Debug/net6.0/vcf_db_test
```

# Estrutura

Após o download, você irá encontrar os seguintes diretórios e arquivos, logicamente agrupados de acordo com sua
funcionalidade. Você verá algo assim:

```
ABCBRASIL.VCF.API/
├── VCF.Api/
│   ├── Adapters/
│   ├── Configurations/
│   ├── Core/
│   ├── Migrations/
│   ├── Properties/
│   ├── appsettings.json
│   ├── appsettings.Testing.json
│   ├── appsettingsProduction.json
│   ├── Program.cs
│   └── VCF.Api.csproj
├── VCF.Api.IntegrationTests/
│   ├── Adapters/
│   ├── Configurations/
│   └── VCF.Api.IntegrationTests.csproj
├── VCF.UnitTests/
│   ├── Core/
│   └── VCF.UnitTests.csproj
├── .gitignore
├── ABCBRASIL.VCF.API.sln
├── Dockerfile
├── global.json
└── README.md
```

# Contribuindo

É importante que seja seguido o guideline geral de contribuição disponibilizado em [Algum link](#).

## Licença

Todos os direitos reservados para VCF.