using System.Linq.Expressions;
using tema.Data;
using Tema.DataAccess.Repository.IRepository;
using Tema.Models;

namespace Tema.DataAccess.Repository
{
    public class BankRepository : Repository<Bank>, IBankRepository
    {
        private ApplicationDbContext _db;
        public BankRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Bank obj)
        {
            _db.Banks.Update(obj); 
        }
    }
}
