﻿namespace ProEShop.Entities;

public abstract class EntityBase
{
    public long Id { get; set; }
    public bool IsDeleted { get; set; }
}
