﻿namespace UzTexGroupV2.Domain.Entities;

public class News : LocalizedObject
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
