using UzTexGroupV2.Application.EntitiesDto.Addresses;

namespace UzTexGroupV2.Application.EntitiesDto.Application;

public record ModifyApplicationDto(
    Guid id,
    string? firstName,
    string? lastName,
    string? phoneNumber,
    string? applicationMassage,
    Guid? jobId,
    ModifyAddressDto? modifyAddressDto);
