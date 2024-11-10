using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema.Models;

namespace Tema.DataAccess.Repository.IRepository
{
    public interface ICriteriaRepository : IRepository<Criteria>
    {
        void Update(Criteria obj);
    }
}
