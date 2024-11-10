using System.Linq.Expressions;
using tema.Data;
using Tema.DataAccess.Repository.IRepository;
using Tema.Models;

namespace Tema.DataAccess.Repository
{
    public class NationalityRepository : Repository<Nationality>, INationalityRepository
    {
        private ApplicationDbContext _db;
        public NationalityRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Nationality obj)
        {
            _db.Nationalities.Update(obj); 
        }
    }
}
