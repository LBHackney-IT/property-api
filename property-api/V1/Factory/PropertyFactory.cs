using AutoMapper;
using property_api.V1.Domain;
using property_api.V1.Data.Entities;

namespace property_api.V1.Factory
{
    public class PropertyFactory
    {
        private readonly IMapper _mapper;

        public PropertyFactory(IMapper mapper)
        {
            _mapper = mapper;
        }
        public Property FromUHProperty(UhPropertyEntity uhproperty)
        {
            return _mapper.Map<Property>(uhproperty);
        }
    }
}
