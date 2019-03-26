using property_api.V1.Infrastructure;
using Tynamix.ObjectFiller;

namespace propertyapi.Tests.V1.Helpers
{
    public static class UhPropertyHelper
    {
        public static UhProperty GenerateRandom()
        {
            var filler = new Filler<UhProperty>();
            filler.Setup()
                .OnType<string>().Use(new MnemonicString(1, 5, 10))
                .OnType<int>().Use(new IntRange(1, 99999));

            return filler.Create();
        }
    }
}

