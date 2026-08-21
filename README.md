# Funcionários API - Clean Architecture 🚀

Este projeto é uma API RESTful para gerenciamento de funcionários, desenvolvida como avaliação prática do respectivo módulo. O sistema foi construído utilizando **.NET 8** e segue rigorosamente os princípios da **Clean Architecture**, garantindo separação de responsabilidades, manutenibilidade e código limpo.

## 🏗️ Estrutura do Projeto (Clean Architecture)
A solução está dividida em 4 camadas principais:
* **01 - Presentation:** Ponto de entrada da aplicação (Controllers, Swagger, JWT).
* **02 - Application:** Regras de negócio, DTOs e Casos de Uso (Services).
* **03 - Infrastructure:** Persistência de dados (Entity Framework Core, Repositórios, Contexto do MySQL).
* **04 - Domain:** O coração do software (Entidades puras e Interfaces).
* **05 - Tests:** Projeto focado na garantia de qualidade da camada de Aplicação.

## 🌿 Estrutura de Branches
Para demonstrar o domínio sobre o controle de versão (Git) e manter o projeto base isolado, as funcionalidades extras (pontos bônus) não foram mescladas na branch principal. Elas podem ser validadas nas seguintes branches:

* `master`: Contém o projeto base completo, valendo a nota máxima padrão (CRUD, EF Core, MySQL, Arquitetura, Documentação XML no Swagger).
* `feature/jwt`: Contém a implementação Bônus 1 (Autenticação e Proteção de Rotas com JWT).
* `feature/tests`: Contém a implementação Bônus 2 (Testes Unitários com xUnit e Moq para o `FuncionarioService`).

## 🛠️ Tecnologias Utilizadas
* C# e .NET 8
* MySQL (Pomelo EntityFrameworkCore)
* Entity Framework Core (Code-First)
* Swagger / OpenAPI (com documentação XML)
* Autenticação JWT (Bearer)
* xUnit e Moq (Testes Unitários)

## 🚀 Como executar o projeto localmente

1. Clone este repositório.
2. Certifique-se de ter o MySQL rodando na sua máquina.
3. No arquivo `01-Presentation/appsettings.json`, altere a `DefaultConnection` com a senha do seu usuário `root` do MySQL.
4. Abra o terminal na raiz da solução e execute os comandos para criar o banco de dados automaticamente:
   ```bash
   dotnet ef database update --project 03-Infrastructure --startup-project 01-Presentation
   ```

5. Execute a aplicação (via Visual Studio ou comando dotnet run).

6. Acesse a interface do Swagger no navegador através da rota /swagger.

## 🧪 Como rodar os testes

Para validar as regras de negócio sem necessidade de banco de dados, faça o checkout para a branch de testes (feature/tests) e execute:
    
    dotnet test

