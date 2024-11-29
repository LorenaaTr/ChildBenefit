using System.Linq.Expressions;
using tema.Data;
using Tema.DataAccess.Repository.IRepository;
using Tema.Models;

namespace Tema.DataAccess.Repository
{
    public class FeedbackRepository : Repository<Feedback>, IFeedbackRepository
    {
        private ApplicationDbContext _db;
        public FeedbackRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Feedback obj)
        {
            _db.Feedbacks.Update(obj); 
        }
    }
}
