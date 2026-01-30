using trilha_Api_TIVIT.Infra.Interface;
using trilha_Api_TIVIT.Models;
using trilha_Api_TIVIT.Models.Enum;
namespace trilha_Api_TIVIT.Service
{
    public class TarefaService : GenericaService<Tarefa>
    {
        public TarefaService(IRepository<Tarefa> repository) : base(repository)
        {
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