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
    }
}
