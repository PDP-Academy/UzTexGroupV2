using UzTexGroupV2.Application.EntitiesDto.Addresses;

namespace UzTexGroupV2.Application.EntitiesDto.Factory;

public record ModifyFactoryDto(
    Guid id,
    string? name,
    Guid? companyId,
    ModifyAddressDto? modifyAddressDto);

