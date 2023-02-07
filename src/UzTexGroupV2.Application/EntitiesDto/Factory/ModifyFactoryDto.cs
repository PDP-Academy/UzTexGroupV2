using UzTexGroupV2.Application.EntitiesDto.Addresses;
using UzTexGroupV2.Application.EntitiesDto.Company;

namespace UzTexGroupV2.Application.EntitiesDto.Factory;

public record ModifyFactoryDto(
    Guid id,
    string? name,
    ModifyCompanyDTO? companyDto,
    ModifyAddressDto? modifyAddressDto);

