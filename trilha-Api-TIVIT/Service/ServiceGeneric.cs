
using trilha_Api_TIVIT.Interface.Repo;
using trilha_Api_TIVIT.Interface.Services;
using trilha_Api_TIVIT.Models;

namespace trilha_Api_TIVIT.Service
{
    /// <summary>
    /// Serviço genérico responsável por operações comuns de negócio
    /// para entidades que herdam de BaseModel.
    /// </summary>
    /// <typeparam name="T">Tipo da entidade base do serviço</typeparam>
    public class ServiceGeneric<T> : IService<T> where T : BaseModel
  {
    private readonly IRepository<T> _repository;

    public ServiceGeneric(IRepository<T> repository)
    {
        _repository = repository;
    }
    public virtual int Create(T model)
    {
            ArgumentNullException.ThrowIfNull(model);

            return _repository.Create(model);
    }

    public void Delete(int id)
    {
      var entity = _repository.ReadById(id);

        if (entity == null)
                throw new KeyNotFoundException($"Registro não encontrado.");

        _repository.Delete(id);
    }

    public List<T> Read()
    {
      return _repository.Read();
    }

    public T ReadById(int id)
    {
       var entity = _repository.ReadById(id);

        if (entity == null)
                throw new KeyNotFoundException($"Registro {id} não encontrado.");

        return entity;
    }

    public virtual void Update(T model)
    {
      var existing = _repository.ReadById(model.Id) ?? throw new KeyNotFoundException($"Registro {model.Id} não encontrado.");
            _repository.Update(model);
    }
  }
}