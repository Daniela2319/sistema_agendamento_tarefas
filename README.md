
## Sistema de Agendamento Tarefa - Bootcamp DIO - TIVIT
Aplicação fullstack para gerenciamento de tarefas, desenvolvida com .NET 8 no backend e React + Vite no frontend. Permite CRUD e buscas com tarefas de forma simples e eficiente.

##  Tecnologias Utilizadas

### Backend (.NET 8)
- ASP.NET Core Web API
- Swagger (OpenAPI)
- Entity Framework Core
- Injeção de Dependência
- Migrations automatizada
- Docker

### Frontend (React)
- React + Vite
- Axios para chamadas HTTP
- Docker + Nginx
  
### Banco de Dados
- Azure SQL Edge via Docker

## Pré-requisitos
- Docker Desktop instalado
- Git instalado
- Opcional: DBeaver ou Azure Data Studio para acessar o banco

##  Estrutura do Projeto

```
repos-TIVIT/
├── trilha-Api-TIVIT/         # Backend .NET
├── trilha-react-TIVIT/       # Frontend React
├── docker-compose.yml         # Orquestração dos serviços
```



##  Como rodar localmente com Docker

### 1. Clone o repositório:
   ```bash
   git clone git@github.com:Daniela2319/sistema_agendamento_tarefas.git
   cd sistema-agendamento_tarefas
   ```

### 2. Suba os Serviços:
    docker-compose up --build -d
    
    
Isso irá criar e iniciar:

 - tarefas-backend → API .NET 8

 - tarefas-frontend → React

 - tarefas-db → Azure SQL Edge

### 3. Acessar os serviços
- **Frontend (React):**
`http://localhost:3000` (localhost in Bing)

- **Backend (API .NET):**
`http://localhost:8001/swagger` (localhost in Bing)

- **Banco de dados (SQL Edge):**

   - Host: `localhost,14330`

   - Usuário: `SA`

   - Senha: `SenhaForte123!`

   - Banco: `TarefasDB`


##  Desenvolvimento
Durante o desenvolvimento da API, utilizei o banco de dados InMemory para facilitar os testes e simular a persistência de dados de forma rápida e prática. Essa abordagem tornou o processo de desenvolvimento mais ágil e independente de infraestrutura externa.

Agora, além do InMemory, a aplicação também está configurada para se conectar a um banco de dados real via Docker (Azure SQL Edge), garantindo maior flexibilidade: é possível testar cenários simples com InMemory ou validar a persistência completa utilizando o banco containerizado.
## 📸 Screenshots do Projeto

<p align="center">
  <img 
    src="https://github.com/user-attachments/assets/430f0f31-e017-4a69-942f-80f8ab585ba2" 
    alt="Layout do sistema de tarefas no frontend" 
    width="800" 
  />
  <br />
  <i>Layout do sistema de tarefas no frontend</i>
</p>

<p align="center">
  <img 
    src="https://github.com/user-attachments/assets/73123eeb-ed5d-4080-80bf-c0936cd0319c" 
    alt="Documentação da API no Swagger" 
    width="800" 
  />
  <br />
  <i>Documentação da API gerada com Swagger</i>
</p>

<p align="center">
  <img 
    src="https://github.com/user-attachments/assets/8054abb8-d919-4670-805f-e799dfa08b12" 
    alt="Swagger realizando GET na lista de tarefas" 
    width="800" 
  />
  <br />
  <i>Endpoint GET no Swagger retornando a lista de tarefas</i>
</p>





##  Autora
Daniela Velter   
Projeto desenvolvido como parte da trilha .NET da DIO em parceria com TIVIT.

##  Licença
Este projeto está sob a licença MIT. Sinta-se livre para usar, modificar e contribuir!


