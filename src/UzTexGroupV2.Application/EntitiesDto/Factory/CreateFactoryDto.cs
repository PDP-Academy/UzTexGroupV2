using UzTexGroupV2.Application.EntitiesDto.Addresses;

namespace UzTexGroupV2.Application.EntitiesDto.Factory;

public record CreateFactoryDto(
    Guid? id,
    string name,
    Guid companyId,
    string languageCode,
    CreateAddressDto createAddressDto);

