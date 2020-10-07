using ExcellentLearningApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExcellentLearningApp.Model.Repositories
{
    public class RepositoryFake<TEntity> : IRepository<TEntity> 
        where TEntity: IEntity
    {
        private static List<TEntity> _entities;
        private static int _nextId;

        public void Reset()
        {
            _entities = new List<TEntity>();
            _nextId = 1;
        }

        public int Create(TEntity entity)
        {
            entity.Id = _nextId;
            _entities.Add(entity);
            _nextId++;
            return entity.Id;
        }

        public void Delete(int id)
        {
            var removingEntity = _entities.FirstOrDefault(x => x.Id == id);
            if(removingEntity == null)
            {
                throw new Exception($"Entity with id={id} is not exists.");
            }
            _entities.Remove(removingEntity);
        }

        public TEntity Get(int id)
        {
            var result = _entities.FirstOrDefault(x => x.Id == id);
            if(result == null)
            {
                throw new Exception($"Entity with id={id} is not exists.");
            }
            return result;
        }

        public IQueryable<TEntity> GetAll() => _entities.AsQueryable();

        public void Update(TEntity entity)
        {
            var updatingEntity = _entities.FirstOrDefault(x => x.Id == entity.Id);
            if (updatingEntity == null)
            {
                throw new Exception($"Entity with id={entity.Id} is not exists.");
            }

            _entities.Remove(updatingEntity);
            _entities.Add(entity);
        }
    }
}
