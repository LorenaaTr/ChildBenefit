using System.Linq.Expressions;
using tema.Data;
using Tema.DataAccess.Repository.IRepository;
using Tema.Models;

namespace Tema.DataAccess.Repository
{
    public class CriteriaRepository : Repository<Criteria>, ICriteriaRepository
    {
        private ApplicationDbContext _db;
        public CriteriaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Criteria obj)
        {
            _db.Criteria.Update(obj); 
        }
    }
}
