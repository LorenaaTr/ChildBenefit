using System.Linq.Expressions;
using tema.Data;
using Tema.DataAccess.Repository.IRepository;
using Tema.Models;

namespace Tema.DataAccess.Repository
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        private ApplicationDbContext _db;
        public CountryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Country obj)
        {
            _db.Countries.Update(obj); 
        }
    }
}
