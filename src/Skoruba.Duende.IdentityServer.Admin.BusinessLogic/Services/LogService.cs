﻿// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using System;
using System.Threading.Tasks;
using PrinceHarry.AuditLogging.Services;
using PrinceHarry.Duende.IdentityServer.Admin.BusinessLogic.Dtos.Log;
using PrinceHarry.Duende.IdentityServer.Admin.BusinessLogic.Events.Log;
using PrinceHarry.Duende.IdentityServer.Admin.BusinessLogic.Mappers;
using PrinceHarry.Duende.IdentityServer.Admin.BusinessLogic.Services.Interfaces;
using PrinceHarry.Duende.IdentityServer.Admin.EntityFramework.Repositories.Interfaces;

namespace PrinceHarry.Duende.IdentityServer.Admin.BusinessLogic.Services
{
    public class LogService : ILogService
    {
        protected readonly ILogRepository Repository;
        protected readonly IAuditEventLogger AuditEventLogger;

        public LogService(ILogRepository repository, IAuditEventLogger auditEventLogger)
        {
            Repository = repository;
            AuditEventLogger = auditEventLogger;
        }

        public virtual async Task<LogsDto> GetLogsAsync(string search, int page = 1, int pageSize = 10)
        {
            var pagedList = await Repository.GetLogsAsync(search, page, pageSize);
            var logs = pagedList.ToModel();

            await AuditEventLogger.LogEventAsync(new LogsRequestedEvent());

            return logs;
        }

        public virtual async Task DeleteLogsOlderThanAsync(DateTime deleteOlderThan)
        {
            await Repository.DeleteLogsOlderThanAsync(deleteOlderThan);

            await AuditEventLogger.LogEventAsync(new LogsDeletedEvent(deleteOlderThan));
        }
    }
}
