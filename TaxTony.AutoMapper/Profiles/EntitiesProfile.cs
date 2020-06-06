using AutoMapper;
using Models = TaxTony.Core.Models;
using Entities = TaxTony.DataAccess.Entities;

namespace TaxTony.AutoMapper.Profiles
{
    public class EntitiesProfile : Profile
    {
        public EntitiesProfile()
        {
            CreateMap<Models.TaxCalculation, Entities.TaxCalculation>().ReverseMap();
        }
    }
}
