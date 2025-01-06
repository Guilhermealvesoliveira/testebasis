Projeto para teste Basis

Este projeto consiste em um sistema de gerenciamento desenvolvido com uma abordagem modular e escalável, utilizando tecnologias modernas para o back-end e front-end, e seguindo práticas recomendadas de desenvolvimento de software.

Tecnologias Utilizadas

Back-end

Tecnologia: .NET Core

Arquitetura: Hexagonal (Ports and Adapters)

A arquitetura hexagonal foi escolhida para garantir uma maior separação de responsabilidades e flexibilidade. Isso permite que o núcleo do sistema permaneça independente de detalhes externos, como frameworks ou tecnologias específicas.

Banco de Dados: PostgreSQL

Utilizamos o PostgreSQL pela sua robustez e suporte a recursos avançados. As classes de domínio foram desenvolvidas primeiramente, e o banco de dados foi gerado utilizando Migrations (técnica de migração de esquema, que facilita a evolução do banco de dados de maneira controlada).

Front-end

Tecnologia: Angular

O front-end foi implementado utilizando Angular standalone components para um desenvolvimento mais ágil e organizado. O framework foi escolhido por sua capacidade de criar aplicações ricas e responsivas com ótima performance.

Testes

Implementamos testes unitários no back-end A abordagem de testes foi baseada em boas práticas sugeridas, assegurando que os principais fluxos do sistema estejam devidamente validados.

Estrutura do Projeto

Back-end

O back-end está estruturado em pastas que seguem o padrão da arquitetura hexagonal:

Core: Contém o núcleo da aplicação, incluindo entidades, serviços e regras de negócio.

Ports: 

Adapters: Define as interfaces de entrada (como APIs) e saída (como repositórios). Contém implementações específicas para tecnologias, como acesso ao banco de dados (Dapper).



Integração  entre o front-end e o back-end.

Para executar basta rodar as migrations e inserir a View na base configurada.

