using Microsoft.EntityFrameworkCore;
using trilha_Api_TIVIT.Infra.Context;
using trilha_Api_TIVIT.Interface.Repo;
using trilha_Api_TIVIT.Models;

namespace trilha_Api_TIVIT.Infra.Repositories
{
    public class RepositoryGeneric<T> : IRepository<T> where T : BaseModel
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public RepositoryGeneric(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public int Create(T entity)
        {
            _context.Add(entity); //caso dê erro usa .Set<T>
            _context.SaveChanges();
            return entity.Id;
        }

        public void Delete(int id)
        {
            var entity = ReadById(id);
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public bool Exists(int id)
        {
            return _dbSet.Any(e => e.Id == id);
        }

        public List<T> Read()
        {
            return _dbSet.ToList();
        }

        public T ReadById(int id)
        {
            var entity = _dbSet.Find(id) ?? throw new KeyNotFoundException($"Entity com id {id} não encontrada.");
            return entity;
        }

        public void Update(T entity)
        {
            var modelOriginal = ReadById(entity.Id);
            _context.Entry(modelOriginal).CurrentValues.SetValues(entity);
            _context.SaveChanges();
        }
    }
}
