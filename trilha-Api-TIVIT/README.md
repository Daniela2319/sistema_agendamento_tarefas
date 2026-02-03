
# 🧱 ESTRUTURA IDEAL DO PROJETO – APP TAREFAS + JWT
### 📁 trilha-Api-TIVIT (Backend .NET)

trilha-Api-TIVIT
│
├── Controllers
│   ├── AuthController.cs        🔐 Login / Register
│   ├── TarefasController.cs     ✅ CRUD de tarefas (protegido)
│   └── UsuariosController.cs    👤 (opcional / admin)
│
├── Models
│   ├── BaseModel.cs
│   ├── Usuario.cs               👤 User da aplicação
│   ├── Tarefa.cs                📝 Entidade principal
│   └── Enums
│       └── StatusTarefa.cs
│
├── DTOs
│   ├── Auth
│   │   ├── LoginRequestDTO.cs
│   │   ├── LoginResponseDTO.cs
│   │   └── RegisterDTO.cs
│   │
│   ├── Usuario
│   │   └── UsuarioResponseDTO.cs
│   │
│   └── Tarefa
│       ├── TarefaCreateDTO.cs
│       ├── TarefaUpdateDTO.cs
│       └── TarefaResponseDTO.cs
│
├── Interfaces
│   ├── Repositories
│   │   ├── IGenericRepository.cs
│   │   ├── ITarefaRepository.cs
│   │   └── IUsuarioRepository.cs
│   │
│   └── Services
│       ├── IAuthService.cs
│       ├── ITarefaService.cs
│       └── IUsuarioService.cs
│
├── Services
│   ├── AuthService.cs            🔐 Geração do JWT
│   ├── TarefaService.cs
│   ├── UsuarioService.cs
│   └── GenericService.cs
│
├── Repositories
│   ├── GenericRepository.cs
│   ├── TarefaRepository.cs
│   └── UsuarioRepository.cs
│
├── Data
│   ├── AppDbContext.cs
│   └── Mappings (Fluent API)
│
├── Security
│   ├── JwtSettings.cs            🔑 Configuração JWT
│   ├── TokenService.cs           🔐 Criação do token
│   └── PasswordHasher.cs
│
├── Middlewares
│   └── ExceptionMiddleware.cs
│
├── Configurations
│   ├── SwaggerConfig.cs
│   ├── JwtConfig.cs
│   └── DependencyInjection.cs
│
├── Program.cs
├── appsettings.json
├── Dockerfile
└── docker-compose.yml