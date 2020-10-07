using ExcellentLearningApp.Model;
using ExcellentLearningApp.Model.Repositories;
using System;
using System.Linq;
using Xunit;

namespace ExcellentLearningApp.Tests
{
    public class RepositoryTest
    {
        [Fact]
        public void Should_CreateEntity()
        {
            // Arrange
            IRepository<Entity> repository = new RepositoryFake<Entity>();
            (repository as RepositoryFake<Entity>).Reset();

            // Act
            var createdEntityId = repository.Create(new Entity());
            var entities = repository.GetAll().ToList();

            // Assert
            repository.Get(createdEntityId); //Should not throw exception
            Assert.True(entities.Count == 1);
            Assert.Equal(1, createdEntityId);
        }

        [Fact]
        public void Should_DeleteEntity()
        {
            // Arrange
            IRepository<Entity> repository = new RepositoryFake<Entity>();
            (repository as RepositoryFake<Entity>).Reset();
            
            // Act
            var deletingEntityId = repository.Create(new Entity());
            repository.Delete(deletingEntityId);
            var entities = repository.GetAll().ToList();

            // Assert
            Assert.Throws<Exception>(() => 
            {
                repository.Get(deletingEntityId);
            });
            Assert.False(entities.Any());
        }

        [Fact]
        public void Should_UpdateEntity()
        {
            // Arrange
            IRepository<Entity> repository = new RepositoryFake<Entity>();
            (repository as RepositoryFake<Entity>).Reset();
            var oldEntity = new Entity();
            var newEntity = new Entity();

            // Act
            var entityId = repository.Create(oldEntity);
            newEntity.Id = entityId;
            repository.Update(newEntity);
            var currentEntity = repository.Get(entityId);

            // Assert
            Assert.Equal(newEntity.Date, currentEntity.Date);
            Assert.Equal(oldEntity.Id, currentEntity.Id);
        }
    }
}
