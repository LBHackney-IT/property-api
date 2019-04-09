using System;
using property_api.V1.Data.Entities;

using AutoMapper;
using property_api.V1.Domain;

namespace property_api.V1.Helpers
{
    public static class PropertyHelper
    {
        public static MapperConfiguration ConfigureMapper()
        {
            return new MapperConfiguration(cfg => { cfg.CreateMap<UhPropertyEntity, Property>(); });
        }
    }
}