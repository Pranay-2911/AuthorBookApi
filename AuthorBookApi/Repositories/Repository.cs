
using AuthorBookApi.Data;
using Microsoft.EntityFrameworkCore;

namespace AuthorBookApi.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AuthorContext _context;
        private readonly DbSet<T> _table;

        public Repository(AuthorContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public int Add(T entity)
        {
           _table.Add(entity);
            return _context.SaveChanges();
        }

        public int Delete(T entity)
        {
            _table.Remove(entity);
            return _context.SaveChanges();
        }

        public T Get(int id)
        {
            var entity = _table.Find(id);
            return entity;
        }
        public IQueryable<T> GetAll()
        {
            return _table.AsQueryable();
        }

        public T Update(T entity)
        {
            _table.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
