using Bogus;
using property_api.V1.Infrastructure;

namespace UnitTests.V1.Helpers
{
    public class UhPropertyHelper
    {

        private readonly Faker<UhProperty> _propertyGenerator;

        public UhPropertyHelper()
        {
            _propertyGenerator = new Faker<UhProperty>("en_GB")
                .RuleFor(u => u.PropRef, f => f.Random.Hash(length: 12))
                .RuleFor(u => u.Telephone, f => f.Phone.PhoneNumber())
                .RuleFor(u => u.NoSingleBeds, f => (short)f.Random.Int(min: 0, max: 10))
                .RuleFor(u => u.NoDoubleBeds, f => (short)f.Random.Int(min: 0, max: 10))
                .RuleFor(u => u.Dtstamp, f => f.Date.Past(yearsToGoBack: 100))
                .RuleFor(u => u.Ownership, f => f.Random.String2(length: 9))
                .RuleFor(u => u.Letable, f => f.Random.Bool())
                .RuleFor(u => u.ManagedProperty, f => f.Random.Bool())
                .RuleFor(u => u.Repairable, f => f.Random.Bool())
                .RuleFor(u => u.Lounge, f => f.Random.Bool())
                .RuleFor(u => u.Laundry, f => f.Random.Bool())
                .RuleFor(u => u.VisitorBed, f => f.Random.Bool())
                .RuleFor(u => u.Store, f => f.Random.Bool())
                .RuleFor(u => u.WardenFlat, f => f.Random.Bool())
                .RuleFor(u => u.Sheltered, f => f.Random.Bool())
                .RuleFor(u => u.Shower, f => f.Random.Bool())
                .RuleFor(u => u.Rtb, f => f.Random.Bool())
                .RuleFor(u => u.CoreShared, f => f.Random.Bool())
                .RuleFor(u => u.OnlineRepairs, f => f.Random.Bool())
                .RuleFor(u => u.Asbestos, f => f.Random.Bool());
        }

        public UhProperty GenerateUhProperty()
        {
            return _propertyGenerator.Generate();
        }
    }
}
