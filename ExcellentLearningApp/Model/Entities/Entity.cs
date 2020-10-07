using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcellentLearningApp.Model
{
    public interface IEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
    }
    public class Entity : IEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public Entity()
        {
            this.Init();
        }
    }

    public static class EntityExtension
    {
        public static void Init(this Entity entity)
        {
            entity.Date = DateTime.UtcNow;
        }
    }
}
