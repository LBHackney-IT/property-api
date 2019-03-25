using AutoMapper;
using property_api.V1.Domain;
using property_api.V1.Infrastructure;

namespace property_api.V1.Factory
{
    public class PropertyFactory
    {
        public Property FromUHProperty(UhProperty uhproperty)
        {
            AutoMapperConfig.Initialize();
            return Mapper.Map<Property>(uhproperty);
        }
    }

    public static class AutoMapperConfig
    {
        public static object thisLock = new object();
        public static void Initialize()
        {
            // This will ensure one thread can access to this static initialize call
            // and ensure the mapper is reseted before initialized. 
            // This is a temp workaround for nunit that won't be necessary when we reduce
            // the Property model as the mapping will likely be done explicitly
            lock (thisLock)
            {
                AutoMapper.Mapper.Reset();
                AutoMapper.Mapper.Initialize(cfg => { cfg.CreateMap<UhProperty, Property>(); });
            }
        }
    }
}
