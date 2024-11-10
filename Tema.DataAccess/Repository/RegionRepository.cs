using System.Linq.Expressions;
using tema.Data;
using Tema.DataAccess.Repository.IRepository;
using Tema.Models;

namespace Tema.DataAccess.Repository
{
    public class RegionRepository : Repository<Region>, IRegionRepository
    {
        private ApplicationDbContext _db;
        public RegionRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Region obj)
        {
            _db.Regions.Update(obj); 
        }
    }
}
