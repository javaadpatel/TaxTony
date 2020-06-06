using AutoMapper;
using System;
using TaxTony.AutoMapper.Profiles;

namespace TaxTony.AutoMapper.Builders
{
    public static class MapperBuilder
    {
        private static readonly Lazy<IConfigurationProvider> _configurationProvider =
            new Lazy<IConfigurationProvider>(DefaultConfiguration, System.Threading.LazyThreadSafetyMode.ExecutionAndPublication);

        private static readonly Lazy<IMapper> _mapper =
            new Lazy<IMapper>(DefaultMapper, System.Threading.LazyThreadSafetyMode.ExecutionAndPublication);

        public static IMapper Mapper
        {
            get
            {
                return _mapper.Value;
            }
        }

        public static IConfigurationProvider ConfigurationProvider
        {
            get
            {
                return _configurationProvider.Value;
            }
        }

        private static IConfigurationProvider DefaultConfiguration()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<EntitiesProfile>();
            });

            return configuration;
        }

        private static IMapper DefaultMapper()
        {
            var mapper = ConfigurationProvider.CreateMapper();
            return mapper;
        }
    }
}
