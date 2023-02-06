﻿using UzTexGroupV2.Domain.Entities;

namespace UzTexGroupV2.Application.EntitiesDto;

public record ModifyJobDto : LocalizedDTO
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Desription { get; set; }
    public string? WorkTime { get; set; }
    public decimal? Salary { get; set; }
    public Guid? FactoryId { get; set; }
}