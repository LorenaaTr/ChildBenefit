using System.Linq.Expressions;
using tema.Data;
using Tema.DataAccess.Repository.IRepository;
using Tema.Models;

namespace Tema.DataAccess.Repository
{
    public class MaritalStatusRepository : Repository<MaritalStatus>, IMaritalStatusRepository
    {
        private ApplicationDbContext _db;
        public MaritalStatusRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(MaritalStatus obj)
        {
            _db.MaritalStatus.Update(obj); 
        }
    }
}
