using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tema.Models;

namespace Tema.DataAccess.Repository.IRepository
{
    public interface IParentRepository : IRepository<Parent>
    {
        void Update(Parent obj);
        void Save();
        Parent GetFirstOrDefault(Expression<Func<Parent, bool>> filter, string? includeProperties = null);
    }
}
