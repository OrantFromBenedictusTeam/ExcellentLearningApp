using ExcellentLearningApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExcellentLearningApp.Model.Repositories
{
    public class RepositoryFake<TEntity> : IRepository<TEntity> 
        where TEntity: IEntity
    {
        private static List<TEntity> _issues = new List<TEntity>();
        private static int _nextId = 1; 
        public int Create(TEntity entity)
        {
            entity.Id = _nextId;
            _issues.Add(entity);
            _nextId++;
            return entity.Id;
        }

        public void Delete(int id)
        {
            var removingIssue = _issues.FirstOrDefault(x => x.Id == id);
            if(removingIssue == null)
            {
                throw new Exception($"Issue with id={id} is not exists.");
            }
            _issues.Remove(removingIssue);
        }

        public TEntity Get(int id)
        {
            var result = _issues.FirstOrDefault(x => x.Id == id);
            if(result == null)
            {
                throw new Exception($"Issue with id={id} is not exists.");
            }
            return result;
        }

        public IQueryable<TEntity> GetAll() => _issues.AsQueryable();       
    }
}
