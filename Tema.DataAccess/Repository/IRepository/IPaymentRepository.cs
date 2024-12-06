using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tema.Models;

namespace Tema.DataAccess.Repository.IRepository
{
    public interface IPaymentRepository : IRepository<Payment>
    {
        void Update(Payment obj);
        void Save();
        // Add the Find method
        IEnumerable<Payment> Find(Expression<Func<Payment, bool>> predicate);
    }
}
