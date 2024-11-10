using System.Linq.Expressions;
using tema.Data;
using Tema.DataAccess.Repository.IRepository;
using Tema.Models;

namespace Tema.DataAccess.Repository
{
    public class RelationRepository : Repository<Relation>, IRelationRepository
    {
        private ApplicationDbContext _db;
        public RelationRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Relation obj)
        {
            _db.Relations.Update(obj); 
        }
    }
}
