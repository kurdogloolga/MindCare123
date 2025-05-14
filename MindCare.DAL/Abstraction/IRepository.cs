using MindCare.DAL.Entities;

namespace MindCare.DAL.Abstraction;
public interface IRepository<TEntity> where TEntity : BaseEntity
{
    IQueryable<TEntity> GetAll();
    Task<TEntity> GetByIdAsync(Guid id);
    Task AddAsync(TEntity entity);
    void Update(TEntity entity);
    void Remove(TEntity entity);
}
