# ServiceFlow Desktop 📋

ServiceFlow Desktop é uma aplicação desktop desenvolvida em C# para gerenciamento de ordens de serviço. O sistema foi pensado para pequenos negócios, prestadores de serviço e equipes internas que precisam registrar clientes, serviços, ordens de serviço, status, valores, prazos e histórico de atendimento.

## Objetivo

O objetivo do projeto é praticar desenvolvimento de software com C#, programação orientada a objetos, interface desktop, banco de dados local, organização em camadas, versionamento com Git/GitHub e gerenciamento de tarefas com GitHub Projects.

Este projeto também tem como finalidade compor portfólio profissional e demonstrar conhecimentos técnicos em entrevistas.

## Funcionalidades previstas

* Cadastro de clientes
* Cadastro de serviços
* Criação de ordens de serviço
* Associação de serviços a uma ordem
* Controle de status da ordem
* Cálculo de valores
* Filtros por status, cliente e período
* Dashboard com indicadores principais
* Relatórios simples
* Persistência local com SQLite
* Testes unitários básicos

## Tecnologias utilizadas

* C#
* WPF
* .NET
* SQLite
* Entity Framework Core
* Git e GitHub
* GitHub Projects
* Testes unitários

## Arquitetura

O projeto utiliza uma arquitetura em camadas, separando responsabilidades entre interface, regras de aplicação, domínio e infraestrutura.

Estrutura geral:

```text
Presentation  -> Telas e ViewModels
Application   -> Serviços de aplicação e validações
Domain        -> Entidades e regras principais
Infrastructure -> Banco de dados, EF Core e repositórios
Tests         -> Testes unitários
```

## Módulos do sistema

* Clientes
* Serviços
* Ordens de Serviço
* Status e acompanhamento
* Dashboard
* Relatórios
* Configurações
* Testes
* Documentação

## Como executar

> Instruções serão atualizadas conforme o desenvolvimento evoluir.

Pré-requisitos:

* Windows
* Visual Studio
* .NET SDK
* SQLite

Passos previstos:

```
git clone https://github.com/ThiagoTranquilim/service-flow-desktop.git
cd serviceflow-desktop
```

Abrir a solução no Visual Studio e executar o projeto desktop.

## Status do projeto

Em desenvolvimento.

## Autor

Desenvolvido por Thiago Rubim Tranquilim como projeto de portfólio em Engenharia de Software.
