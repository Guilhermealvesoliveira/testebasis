using AutoMapper;
using TesteBasisBook.Domain.Adapters.Driving.Api.Mappings;

namespace TesteBasisBook.Api.Mappings
{
    public class MapperService : IMapperService
    {
        private readonly IMapper _mapper;

        public MapperService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return _mapper.Map<TSource, TDestination>(source);
        }
    }

}
