namespace UzTexGroupV2.Application.EntitiesDto.Factory;

public record FactoryDto(
    Guid id,
    string name,
    Guid companyId,
    Guid addressId);
