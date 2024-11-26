using System.Linq.Expressions;
using tema.Data;
using Tema.DataAccess.Repository.IRepository;
using Tema.Models;

namespace Tema.DataAccess.Repository
{
    public class ChildRepository : Repository<Child>, IChildRepository
    {
        private ApplicationDbContext _db;
        public ChildRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Child obj)
        {
            _db.Children.Update(obj); 
        }
    }
}
