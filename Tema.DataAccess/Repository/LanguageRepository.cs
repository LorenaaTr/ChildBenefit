using System.Linq.Expressions;
using tema.Data;
using Tema.DataAccess.Repository.IRepository;
using Tema.Models;

namespace Tema.DataAccess.Repository
{
    public class LanguageRepository : Repository<Language>, ILanguageRepository
    {
        private ApplicationDbContext _db;
        public LanguageRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Language obj)
        {
            _db.Languages.Update(obj); 
        }
    }
}
