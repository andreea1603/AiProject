using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

 

namespace RepositoryLayer.RepositoryPattern
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly PostContext context;

        public Repository(PostContext context)
        {
            this.context = context;
        }
        public Task<TEntity> Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity),"Entity must not be null");
            }
            return AddAsync(entity);
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public Task<TEntity> Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity),"Entity must not be null");
            }

            return DeleteAsync(entity);
        }
        public async Task<TEntity> DeleteAsync(TEntity entity)
        {


            context.Remove(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await context.Set<TEntity>().ToListAsync();
        }
        public Task<TEntity> GetById(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Id must not be empty", nameof(id));
            }
            return GetByIdAsync(id);
        }
        public async Task<TEntity> GetByIdAsync(Guid id)
        {

            return await context.FindAsync<TEntity>(id);
        }

        public Task<TEntity> Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity),"Entity must not be null");
            }
            return UpdateAsync(entity);
        }
            public async Task<TEntity> UpdateAsync(TEntity entity)
        {

            context.Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
