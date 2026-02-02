using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using XFrame.Ids;
using XFrame.ValueObjects.SingleValueObjects;

namespace EventCatalogService.Persistence.ValueObjectConverters
{
    public class IdentityValueConverter<TIdentity> : ValueConverter<TIdentity, string>
        where TIdentity : Identity<TIdentity>
    {
        public IdentityValueConverter(ConverterMappingHints mappingHints = null)
        : base(
            id => id.Value,
            value => typeof(TIdentity).GetConstructor(new Type[] { typeof(string) }).Invoke(new object[] { value }) as TIdentity,
            mappingHints
        )
        { }
    }

    public class SingleValueObjectIdentityValueConverter<TIdentity> : ValueConverter<TIdentity, string>
        where TIdentity : SingleValueObject<string>, IIdentity
    {
        public SingleValueObjectIdentityValueConverter(ConverterMappingHints mappingHints = null)
        : base(
            id => id.Value,
            value => typeof(TIdentity).GetConstructor(new Type[] { typeof(string) }).Invoke(new object[] { value }) as TIdentity,
            mappingHints
        )
        { }
    }
}
