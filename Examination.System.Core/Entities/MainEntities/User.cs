﻿namespace Examination.System.Core.Entities.MainEntities;

public abstract class User : BaseModel
{
    public string Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
}
