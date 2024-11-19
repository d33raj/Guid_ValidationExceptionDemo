
using Guid_Demo.Data;
using Microsoft.EntityFrameworkCore;

namespace Guid_Demo.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly EmployeeContext _context;
        public readonly DbSet<T> _table;
        public Repository(EmployeeContext context)
        {
            _context = context;
            _table=_context.Set<T>();
        }
        public int Add(T entity)
        {
            _table.Add(entity);
            return _context.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return _table.AsQueryable();
        }

        public T GetById(Guid id)
        {
            return _table.Find(id);
        }
    }
}
