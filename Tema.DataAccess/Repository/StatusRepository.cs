using System.Linq.Expressions;
using tema.Data;
using Tema.DataAccess.Repository.IRepository;
using Tema.Models;

namespace Tema.DataAccess.Repository
{
    public class StatusRepository : Repository<Status>, IStatusRepository
    {
        private ApplicationDbContext _db;
        public StatusRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Status obj)
        {
            _db.Statuses.Update(obj); 
        }
    }
}
