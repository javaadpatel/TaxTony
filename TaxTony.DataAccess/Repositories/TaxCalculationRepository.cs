using AutoMapper;
using TaxTony.DataAccess.Contexts;
using TaxTony.DataAccess.Repositories.Base;
using Models = TaxTony.Core.Models;

namespace TaxTony.DataAccess.Repositories
{
    public class TaxCalculationRepository : RepositoryBase<Models.TaxCalculation, Entities.TaxCalculation>
    {
        public TaxCalculationRepository(TaxTonyContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
