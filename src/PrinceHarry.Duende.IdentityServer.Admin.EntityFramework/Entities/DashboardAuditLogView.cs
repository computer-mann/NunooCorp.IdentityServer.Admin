using System.Collections.Generic;

namespace PrinceHarry.Duende.IdentityServer.Admin.EntityFramework.Entities;

public class DashboardAuditLogView
{
    public long AuditLogsTotal { get; set; }
    
    public long AuditLogsAvg { get; set; }
    
    public List<DashboardAuditLogDataView> AuditLogsPerDaysTotal { get; set; }
}