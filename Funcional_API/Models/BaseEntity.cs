using Funcional_API.Interfaces;
using System;

namespace Funcional_API.Models
{
    public abstract class BaseEntity : IEntity
    {
        public int id { get; set; }
        public int conta { get; set; }
        public DateTime? data_criacao { get; set; }

    }
}
