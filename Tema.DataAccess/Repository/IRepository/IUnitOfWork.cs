using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IGenderRepository Gender { get; }
        ICountryRepository Country { get; }
        ICriteriaRepository Criteria { get; }
        ILanguageRepository Language { get; }
        IMaritalStatusRepository MaritalStatus { get; }
        INationalityRepository Nationality { get; }
        IRegionRepository Region { get; }
        IRelationRepository Relation { get; }
        IBankRepository Bank { get; }
        IStatusRepository Status { get; }
        void Save();
    }
}
