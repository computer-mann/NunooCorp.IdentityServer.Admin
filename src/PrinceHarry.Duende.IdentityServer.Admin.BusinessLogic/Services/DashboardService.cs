using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PrinceHarry.Duende.IdentityServer.Admin.BusinessLogic.Dtos.Dashboard;
using PrinceHarry.Duende.IdentityServer.Admin.BusinessLogic.Services.Interfaces;
using PrinceHarry.Duende.IdentityServer.Admin.EntityFramework.Repositories.Interfaces;

namespace PrinceHarry.Duende.IdentityServer.Admin.BusinessLogic.Services;

public class DashboardService : IDashboardService
{
    protected readonly IDashboardRepository DashboardRepository;
    protected readonly IAuditLogService AuditLogService;

    public DashboardService(IDashboardRepository dashboardRepository, IAuditLogService auditLogService)
    {
        DashboardRepository = dashboardRepository;
        AuditLogService = auditLogService;
    }

    public async Task<DashboardDto> GetDashboardIdentityServerAsync(int auditLogsLastNumberOfDays, CancellationToken cancellationToken = default)
    {
       var dashBoardData = await DashboardRepository.GetDashboardIdentityServerAsync(auditLogsLastNumberOfDays, cancellationToken);
       var auditLogs = await AuditLogService.GetDashboardAuditLogsAsync(auditLogsLastNumberOfDays, cancellationToken);
       var auditLogsAverage = await AuditLogService.GetDashboardAuditLogsAverageAsync(auditLogsLastNumberOfDays, cancellationToken);
       
       return new DashboardDto
       {
            ClientsTotal = dashBoardData.ClientsTotal,
            ApiResourcesTotal = dashBoardData.ApiResourcesTotal,
            ApiScopesTotal = dashBoardData.ApiScopesTotal,
            IdentityResourcesTotal = dashBoardData.IdentityResourcesTotal,
            AuditLogsAvg = auditLogsAverage,
            AuditLogsPerDaysTotal = auditLogs,
            IdentityProvidersTotal = dashBoardData.IdentityProvidersTotal
       };
    }
}