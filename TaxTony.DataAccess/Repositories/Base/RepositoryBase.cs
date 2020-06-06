using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaxTony.Core.Contracts.Repositories;
using TaxTony.Core.Models.Base;
using TaxTony.DataAccess.Contexts;
using TaxTony.DataAccess.Entities.Base;

namespace TaxTony.DataAccess.Repositories.Base
{
    public class RepositoryBase<Model, Entity>: IRepository<Model>
        where Model : ModelBase
        where Entity :  EntityBase
    {
        #region Constructor and Fields
        private readonly TaxTonyContext _context;
        private readonly IMapper _mapper;

        public RepositoryBase(TaxTonyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion

        public async Task<Model> CreateAsync(Model item)
        {
            if (item.Id == Guid.Empty)
                item.Id = Guid.NewGuid();

            var entity = _mapper.Map<Entity>(item);

            _context.Set<Entity>().Add(entity);
            await _context.SaveChangesAsync();

            return item;
        }


    }
}
