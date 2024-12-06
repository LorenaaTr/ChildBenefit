using System.Linq.Expressions;
using tema.Data;
using Tema.DataAccess.Repository.IRepository;
using Tema.Models;

namespace Tema.DataAccess.Repository
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        private ApplicationDbContext _db;
        public PaymentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<Payment> Find(Expression<Func<Payment, bool>> predicate)
        {
            return _db.Payments.Where(predicate).ToList();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Payment obj)
        {
            _db.Payments.Update(obj);
        }
    }
}
