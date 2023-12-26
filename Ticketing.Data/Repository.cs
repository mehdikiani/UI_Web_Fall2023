﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Core.Entities;

namespace Ticketing.Data
{
    public class Repository<T> : IRepository<T>
        where T :class // EntityBase
    {
        private readonly TicketDbContext db;
        private DbSet<T> entities;
        public Repository(
            TicketDbContext db)
        {
            this.db = db;
        }
        public DbSet<T> Entities
        {
            get
            {
                if (entities == null)
                    entities = db.Set<T>();
                return entities;
            }
        }
        public int Delete(T entity)
        {
            //if (!entity.IsValidState(EntityAction.Delete))
            //    return 0;
            Entities.Remove(entity);
            return db.SaveChanges();
        }

        public async Task<int> DeleteAsync(T entity, CancellationToken token = default)
        {
            Entities.Remove(entity);
            return await db.SaveChangesAsync();
        }

        public IQueryable<T> GetAll()
        {
            return Entities;
        }

        public int Insert(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            //if (!entity.IsValidState(EntityAction.Insert))
            //    return 0;
            Entities.Add(entity);
            return db.SaveChanges();
        }

        public async Task<int> InsertAsync(T entity, CancellationToken token = default)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            //if (!entity.IsValidState(EntityAction.Insert))
            //    return 0;
            Entities.Add(entity);
            return await db.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(T entity, CancellationToken token = default)
        {
            return await db.SaveChangesAsync();
        }

        public int Update(T entity)
        {
            //if (!entity.IsValidState(EntityAction.Update))
            //    return 0;
            return db.SaveChanges();
        }

        public IQueryable<T> GetRandomRow(int count)
        {
            return Entities.OrderBy(r => Guid.NewGuid()).Take(count);
        }
    }
}
