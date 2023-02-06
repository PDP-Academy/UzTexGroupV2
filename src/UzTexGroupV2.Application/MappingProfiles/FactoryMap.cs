using UzTexGroupV2.Application.EntitiesDto.Factory;
using UzTexGroupV2.Domain.Entities;

namespace UzTexGroupV2.Application.MappingProfiles;

internal static class FactoryMap
{
    internal static FactoryDto MapToFactoryDto(Factory factory)
    {
        return new FactoryDto(
            id: factory.Id,
            name: factory.Name,
            companyDTO: factory.Company is not null ? CompanyMapper.ToCompanyDTO(factory.Company) : null,
            addressDto: factory.Address is not null ? AddressMap.MapToAddressDto(factory.Address) : null);
    }
}
