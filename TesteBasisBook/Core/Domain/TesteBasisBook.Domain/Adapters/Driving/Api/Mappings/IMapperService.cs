namespace TesteBasisBook.Domain.Adapters.Driving.Api.Mappings
{
    public interface IMapperService
    {
        TDestination Map<TSource, TDestination>(TSource source);
    }
}
