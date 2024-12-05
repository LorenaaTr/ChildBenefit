
using Tema.Models;

namespace Tema.DataAccess.Repository.IRepository
{
    public interface IBankRepository : IRepository<Bank>
    {
        void Update(Bank obj);
        void Save();
    }
}
