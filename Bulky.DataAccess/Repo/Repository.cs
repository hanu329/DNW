using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repo.IRepo;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repo
{
    public class Repository<T> : IRepository<T> where T:class
    {
        private readonly ApplicationDbContext1  _repo;
        public DbSet<T> dbSet;
        public Repository(ApplicationDbContext1 db)
        {
           _repo = db;
            dbSet = _repo.Set<T>();

        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>>filter)
        {
            IQueryable<T> q = dbSet;
            q =q.Where(filter);
            return q.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> q = dbSet;
            return q;
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}
