using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using tema.Data;
using Tema.DataAccess.Repository.IRepository;
using Tema.Models;

namespace Tema.DataAccess.Repository
{
    public class ParentRepository : Repository<Parent>, IParentRepository
    {
        private ApplicationDbContext _db;
        public ParentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Parent obj)
        {
            _db.Parents.Update(obj); 
        }

        public Parent GetFirstOrDefault(Expression<Func<Parent, bool>> filter, string? includeProperties = null)
        {
            IQueryable<Parent> query = _db.Parents;

            // Apply the filter condition
            query = query.Where(filter);

            // Include related entities if includeProperties is specified
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            // Return the first matching record or null if none found
            return query.FirstOrDefault();
        }
    }
}
