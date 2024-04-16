using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TrainSystem.Entities;
using System.Linq.Expressions;

namespace TrainSystem.Repositories
{
    public class BaseRepository<T>
        where T : BaseEntity
    {
        protected TrainDBContext Context { get; set; }
        protected DbSet<T> Items { get; set; }

        public BaseRepository()
        {
            Context = new TrainDBContext();
            Items = Context.Set<T>();
        }

        public int Count(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = Items;

            if (filter != null)
                query = query.Where(filter);

            return query.Count();
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = Items;

            if (filter != null)
                query = query.Where(filter);

            return query.ToList();
        }

        public T FirstOrDefault(Expression<Func<T, bool>> filter)
        {
            return Items.FirstOrDefault(filter);
        }

        public T GetById(int id)
        {
            return Items.FirstOrDefault(u => u.Id == id);
        }

        public void Delete(T item)
        {
            Items.Remove(item);

            Context.SaveChanges();
        }

        public void Save(T item)
        {
            if (item.Id > 0)
                Items.Update(item);
            else
                Items.Add(item);

            Context.SaveChanges();
        }
    }
}
