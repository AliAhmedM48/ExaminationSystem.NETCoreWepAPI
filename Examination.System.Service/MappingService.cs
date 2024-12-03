using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Examination.System.Service;
public static class MappingService
{
    public static IMapper Mapper;

    public static destination Map<destination>(this object source) => Mapper.Map<destination>(source);

    public static destination? MapToExistingEntity<destination>(this object source, destination existingEntity) => Mapper.Map<object, destination>(source, existingEntity);

    public static IQueryable<destination> ProjectTo<destination>(this IQueryable<object> source) => Mapper.ProjectTo<destination>(source);

    public static async Task<destination?> ProjectToForFirstOrDefaultAsync<destination>(this IQueryable<object> source) => await Mapper.ProjectTo<destination>(source).FirstOrDefaultAsync();
}
