﻿namespace UzTexGroupV2.Application.EntitiesDto.Addresses;
public record ModifyAddressDto(
    string? Country,
    string? Region,
    string? District,
    string? Street,
    short? PostalCode);
