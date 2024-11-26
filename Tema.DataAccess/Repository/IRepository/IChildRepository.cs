using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema.Models;

namespace Tema.DataAccess.Repository.IRepository
{
    public interface IChildRepository : IRepository<Child>
    {
        void Update(Child obj);
        void Save();
    }
}
