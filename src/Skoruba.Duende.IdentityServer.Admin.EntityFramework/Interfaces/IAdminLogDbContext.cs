// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using Microsoft.EntityFrameworkCore;
using PrinceHarry.Duende.IdentityServer.Admin.EntityFramework.Entities;

namespace PrinceHarry.Duende.IdentityServer.Admin.EntityFramework.Interfaces
{
    public interface IAdminLogDbContext
    {
        DbSet<Log> Logs { get; set; }
    }
}
