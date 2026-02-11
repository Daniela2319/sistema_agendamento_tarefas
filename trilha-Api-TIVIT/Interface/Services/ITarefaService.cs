using trilha_Api_TIVIT.Models;
using trilha_Api_TIVIT.Models.Enum;

namespace trilha_Api_TIVIT.Interface.Services
{
    public interface ITarefaService : IService<Tarefa>
    {
        

        List<Tarefa> BuscarPorTitulo(string titulo);
        List<Tarefa> BuscarPorDataCriacao(DateTime dataCriacao);
        List<Tarefa> BuscarPorStatus(EnumStatusTarefa status);

        void Finalizar(int id);
    }
}
