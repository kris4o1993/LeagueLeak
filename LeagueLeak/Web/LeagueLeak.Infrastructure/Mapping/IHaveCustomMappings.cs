namespace LeagueLeak.Infrastructure.Mapping
{
    using AutoMapper;

    interface IHaveCustomMappings
    {
        void CreateMappings(IConfiguration configuration);
    }
}
