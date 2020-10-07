using ExcellentLearningApp.Model;
using ExcellentLearningApp.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            // Act
            var createdEntityId = repository.Create(new Entity());
            var entities = repository.GetAll().ToList();

            // Assert
            repository.Get(createdEntityId); //Should not throw exception
            Assert.True(entities.Count == 1);
        }

        [Fact]
        public void Should_DeleteEntity()
        {
            // Arrange
            IRepository<Entity> repository = new RepositoryFake<Entity>();
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
    }
}
