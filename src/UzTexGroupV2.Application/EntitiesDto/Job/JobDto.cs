﻿using UzTexGroupV2.Application.EntitiesDto.Factory;

namespace UzTexGroupV2.Application.EntitiesDto;

public record JobDto(
    Guid id,
    string name,
    string description,
    string workTime,
    decimal salary,
    FactoryDto? factoryDto);