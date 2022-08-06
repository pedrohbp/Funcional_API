using Funcional_API.Interfaces;
using Funcional_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Funcional_API.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly DatabaseContext context;
        private DbSet<T> entities;

        public GenericRepository(DatabaseContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }
        public T GetByConta(int conta)
        {
            return entities.SingleOrDefault(s => s.conta == conta);
        }
        public T Insert(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            entities.Add(entity);
            context.SaveChanges();
            return entity;
        }
        public T Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            context.SaveChanges();
            return entity;
        }
        public int Delete(int conta)
        {
            T entity = entities.SingleOrDefault(s => s.conta == conta);
            entities.Remove(entity);
            context.SaveChanges();
            return conta;
        }
    }
}
