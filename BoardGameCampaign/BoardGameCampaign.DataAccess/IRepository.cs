using System.Linq.Expressions;
using BoardGameCampaign.DataAccess.Entities;

namespace BoardGameCampaign.DataAccess
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter);
        T? GetById(int id);
        T? GetById(Guid id);
        T Save(T entity);
        void Delete(T entity);
    }
}