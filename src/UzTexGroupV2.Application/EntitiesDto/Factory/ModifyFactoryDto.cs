using UzTexGroupV2.Application.EntitiesDto.Addresses;

namespace UzTexGroupV2.Application.EntitiesDto.Factory;

internal record ModifyFactoryDto(
    Guid id,
    string? name,
    Guid? companyId,
    ModifyAddressDto? modifyAddressDto);

