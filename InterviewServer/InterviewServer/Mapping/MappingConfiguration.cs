using AutoMapper;

namespace InterviewServer.Mapping;

/// <summary>
/// Configuration of AutoMapper
/// </summary>
internal static class MappingConfiguration
{
    /// <summary>
    /// Adding and configuring AutoMapper
    /// </summary>
    /// <param name="services"></param>
    public static void AddAutoMapper(this IServiceCollection services)
    {
        var mappingConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MappingProfile());
        });

        var mapper = mappingConfig.CreateMapper();
        services.AddSingleton(mapper);
    }
}
