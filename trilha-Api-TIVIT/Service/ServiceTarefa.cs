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
            return new List<Tarefa>(); 
            return Read() 
            .Where(t => t.Titulo.Contains(titulo, StringComparison.OrdinalIgnoreCase)) 
            .ToList();
        }

        // buscar por Data de Criação
        public List<Tarefa> BuscarPorDataCriacao(DateTime dataCriacao)
        {
            var todasTarefas = Read();
            return todasTarefas.Where(t => t.DataCriacao.Date == dataCriacao.Date).ToList();
        }

        // buscar por Status
        public List<Tarefa> BuscarPorStatus(EnumStatusTarefa status)
        {
            var todasTarefas = Read();
            return todasTarefas.Where(t => t.Status == status).ToList();
        }
    }
};