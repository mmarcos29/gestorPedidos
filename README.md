# Gestor de Pedidos

Sistema desenvolvido para simular o fluxo de pedidos de bebidas entre revendas e distribuidoras, garantindo confiabilidade no envio mesmo em cenários de instabilidade. Utiliza boas práticas de arquitetura, mensageria com RabbitMQ, containerização com Docker e exposição via Swagger para testes rápidos.

---

## ✨ Visão Geral

Este projeto tem como objetivo fornecer um sistema robusto para:

- Cadastro completo de revendas
- Cadastro de clientes vinculados a revendas
- Realização de pedidos por clientes
- Emissão de pedidos pelas revendas para a distribuidora
- Garantia de envio com sucesso mesmo em APIs instáveis, via **RabbitMQ**

---

## 🏗️ Arquitetura

A aplicação foi construída utilizando o padrão **DDD (Domain-Driven Design)**, respeitando a separação de responsabilidades em **quatro camadas principais**:

- **API**: Camada de exposição, responsável por receber as requisições HTTP.
- **Application**: Regras de orquestração da aplicação e serviços.
- **Domain**: Regras de negócio puras e entidades do domínio.
- **Infra**: Responsável pela persistência de dados e integração com serviços externos como SQL Server e RabbitMQ.

---

## 📦 Tecnologias Utilizadas

- .NET Core 8 (C#)
- Entity Framework Core
- SQL Server 2022
- RabbitMQ (com dashboard de gerenciamento)
- Docker e Docker Compose
- Swagger para documentação da API

---

## 🧱 Funcionalidades

### 🏪 Cadastro de Revendas
- CNPJ (validação obrigatória)
- Razão Social
- Nome Fantasia
- E-mail
- Telefones (múltiplos opcionais)
- Contatos (múltiplos, com um principal obrigatório)
- Endereços de entrega (múltiplos)

### 👥 Clientes
- Cada revenda pode cadastrar seus próprios clientes

### 🛒 Pedidos de Clientes
- Identificação do cliente
- Lista de produtos com quantidades
- Não há valor mínimo

### 🚚 Emissão de Pedido para Distribuidora
- Apenas pedidos com soma ≥ 1000 unidades são aceitos
- API externa simulada (mock)
- Se falhar, o pedido é re-enfileirado automaticamente até o sucesso
- Uso de **fila RabbitMQ** para garantir **entrega eventual**

---

## 🐳 Como Executar com Docker

### Pré-requisitos
- Docker
- Docker Compose

### Passos

1. Clone o repositório:
   ```bash
   git clone https://github.com/seuusuario/gestor-pedidos.git
   cd gestor-pedidos
   ```

2. Suba a aplicação:
   ```bash
   docker-compose up --build
   ```

3. Acesse a documentação Swagger:
   [http://localhost:5140/swagger/index.html](http://localhost:5140/swagger/index.html)

---

## ⚙️ Composição dos Containers

| Serviço       | Porta Externa | Descrição                        |
|---------------|----------------|----------------------------------|
| API           | 5000           | Interface REST da aplicação      |
| SQL Server    | 1433           | Banco de dados relacional        |
| RabbitMQ      | 15672 (UI), 5672 | Mensageria (fila de pedidos)     |

---

## 🚀 Seeds e Inicialização

A aplicação **aguarda o SQL Server estar ativo** antes de executar as seeds de dados, garantindo que não ocorra falhas por indisponibilidade do banco no momento da carga.

---

## 🧪 Testes e Demonstração

A aplicação está completamente integrada ao Swagger. Você pode testar todos os endpoints diretamente via:

👉 [http://localhost:5140/swagger/index.html](http://localhost:5140/swagger/index.html)

---

## 👨‍💻 Autor

**João Marcos dos Santos Batista**  
📧 joaomarcosdeveloperfull@gmail.com  
💼 Desenvolvedor Fullstack .NET / Arquitetura DDD / Microsserviços / Mensageria  

---

## 📄 Licença

Este projeto é de uso privado, fornecido apenas para fins de avaliação técnica.