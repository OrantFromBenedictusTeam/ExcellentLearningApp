using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcellentLearningApp.Model.Repositories
{
    public interface IRepository<TEntity>
    {
        int Create(TEntity entity);
        void Delete(int id);
        TEntity Get(int id);
        IQueryable<TEntity> GetAll();
    }
}
