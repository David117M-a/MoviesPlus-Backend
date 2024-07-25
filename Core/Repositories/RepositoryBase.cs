using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DB;
using Business.Contracts.Repositories;

namespace Core.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly MoviesPlusDBContext _context;
        public RepositoryBase(MoviesPlusDBContext context)
        {
            _context = context;
        }

        public DbSet<T> DbSet { get { return _context.Set<T>(); } }

        public IEnumerable<T> GetAll(Func<T, bool>? filter = null)
        {
            if (filter == null)
            {
                return DbSet.AsEnumerable();
            }

            return DbSet.AsEnumerable().Where(filter);
        }

        public T Find(Func<T, bool>? filter)
        {
            return DbSet.AsEnumerable().Where(filter).FirstOrDefault();
        }

        public async Task Delete(T entity)
        {
            DbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> Create(T entity)
        {
            EntityEntry<T> newEntity = DbSet.Add(entity);
            await _context.SaveChangesAsync();
            return newEntity.Entity;
        }

        public async Task<T> Update(T entity)
        {
            EntityEntry<T> updatedEntity = DbSet.Update(entity);
            await _context.SaveChangesAsync();
            return updatedEntity.Entity;
        }
    }
}
