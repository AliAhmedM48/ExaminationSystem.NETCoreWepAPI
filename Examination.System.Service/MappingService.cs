using AutoMapper;

namespace Examination.System.Service;
public static class MappingService
{
    public static IMapper Mapper;

    public static destination Map<destination>(this object source)
    {
        return Mapper.Map<destination>(source);
    }

    public static IQueryable<destination> ProjectTo<destination>(this IQueryable<object> source)
    {
        return Mapper.ProjectTo<destination>(source);
    }

    public static destination? ProjectToForFirstOrDefault<destination>(this IQueryable<object> source)
    {
        return Mapper.ProjectTo<destination>(source).FirstOrDefault();
    }
}
