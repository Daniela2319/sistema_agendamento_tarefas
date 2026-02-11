using trilha_Api_TIVIT.Interface.Repo;
using trilha_Api_TIVIT.Interface.Services;
using trilha_Api_TIVIT.Models;
using trilha_Api_TIVIT.Models.Enum;
namespace trilha_Api_TIVIT.Service
{
    public class ServiceTarefa : ServiceGeneric<Tarefa>, ITarefaService
    {
        private readonly IRepository<Tarefa> _repository;
        public ServiceTarefa(IRepository<Tarefa> repository) : base(repository)
        {
            _repository = repository;
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
            => _repository.Read().Where(t => t.Titulo.Contains(titulo)).ToList();
        

        // buscar por Data de Criação
        public List<Tarefa> BuscarPorDataCriacao(DateTime dataCriacao)
            => _repository.Read().Where(t => t.DataCriacao.Date == dataCriacao.Date).ToList();


        // buscar por Status
        public List<Tarefa> BuscarPorStatus(EnumStatusTarefa status)
            => _repository.Read().Where(t => t.Status == status).ToList();

        public void Finalizar(int id)
        {
            var tarefa = ReadById(id); 

            if (tarefa.Status == EnumStatusTarefa.Finalizado)
                throw new InvalidOperationException("Tarefa já está finalizada.");

            tarefa.Status = EnumStatusTarefa.Finalizado;

            base.Update(tarefa);
        }

    }
};