using trilha_Api_TIVIT.Interface.Repo;
using trilha_Api_TIVIT.Models;
using trilha_Api_TIVIT.Models.Enum;
namespace trilha_Api_TIVIT.Service
{
    public class ServiceTarefa : ServiceGeneric<Tarefa>
    {
        public ServiceTarefa(IRepository<Tarefa> repository) : base(repository)
        {
        }

        // update
        public override void Update(Tarefa model)
        {
            var existingTarefa = ReadById(model.Id);
            existingTarefa.Titulo = model.Titulo;
            existingTarefa.Descricao = model.Descricao;
            existingTarefa.Status = model.Status;

            base.Update(existingTarefa);
        }

        // buscar por titulo
        public List<Tarefa> BuscarPorTitulo(string titulo)
        {
            if (string.IsNullOrWhiteSpace(titulo))
                throw new ArgumentException("Título para busca não pode ser vazio.");

            return Read() 
            .Where(t => t.Titulo.Contains(titulo, StringComparison.OrdinalIgnoreCase)) 
            .ToList();
        }

        // buscar por Data de Criação
        public List<Tarefa> BuscarPorDataCriacao(DateTime dataCriacao)
        {
            if (dataCriacao == default)
                throw new ArgumentException("Data de criação inválida.");

            var todasTarefas = Read();
            return todasTarefas.Where(t => t.DataCriacao.Date == dataCriacao.Date).ToList();
        }

        // buscar por Status
        public List<Tarefa> BuscarPorStatus(EnumStatusTarefa status)
        {
            if (!Enum.IsDefined(typeof(EnumStatusTarefa), status))
                throw new ArgumentException("Status inválido.");

            var todasTarefas = Read();
            return todasTarefas.Where(t => t.Status == status).ToList();
        }
    }
};