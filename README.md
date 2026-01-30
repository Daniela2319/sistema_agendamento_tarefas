
## Sistema de Agendamento Tarefa - Bootcamp DIO - TIVIT
Aplicação fullstack para gerenciamento de tarefas, desenvolvida com .NET 8 no backend e React + Vite no frontend. Permite CRUD e buscas com tarefas de forma simples e eficiente.



##  Tecnologias Utilizadas

### Backend (.NET 8)
- ASP.NET Core Web API
- Swagger (OpenAPI)
- Entity Framework Core
- Injeção de Dependência
- CORS configurado para React
- Docker

### Frontend (React)
- React + Vite
- Axios para chamadas HTTP
- Docker + Nginx



##  Estrutura do Projeto

```
repos-TIVIT/
├── trilha-Api-TIVIT/         # Backend .NET
├── trilha-react-TIVIT/       # Frontend React
├── docker-compose.yml         # Orquestração dos serviços
```



##  Como rodar localmente com Docker

1. Clone o repositório:
   ```bash
   git clone https://github.com/seu-usuario/tarefas-app.git
   cd tarefas-app
   ```
2. Suba os Serviços:
    ```bash
    docker-compose up --build -d
    ```
##  CORS e Comunicação
O backend está configurado para aceitar requisições do frontend via política "AllowReact". O frontend se comunica com o backend usando axios apontando para http://backend:8001/api.

##  Desenvolvimento
Durante o desenvolvimento da API, utilizei o banco de dados InMemory para facilitar os testes e simular persistência de dados. Essa abordagem também permitiu realizar o deploy da aplicação de forma mais leve e rápida, sem depender de uma infraestrutura externa de banco.

##  Autora
Daniela Velter   
Projeto desenvolvido como parte da trilha .NET da DIO em parceria com TIVIT.

##  Licença
Este projeto está sob a licença MIT. Sinta-se livre para usar, modificar e contribuir!


