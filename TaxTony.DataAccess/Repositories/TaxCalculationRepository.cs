using AutoMapper;
using TaxTony.Core.Contracts.Repositories;
using TaxTony.DataAccess.Contexts;
using TaxTony.DataAccess.Repositories.Base;
using Models = TaxTony.Core.Models;

namespace TaxTony.DataAccess.Repositories
{
    public class TaxCalculationRepository : RepositoryBase<Models.TaxCalculation, Entities.TaxCalculation>, ITaxCalculationRepository
    {
        public TaxCalculationRepository(TaxTonyContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
