using System.Threading;
using System.Threading.Tasks;
using PrinceHarry.Duende.IdentityServer.Admin.BusinessLogic.Dtos.Dashboard;

namespace PrinceHarry.Duende.IdentityServer.Admin.BusinessLogic.Services.Interfaces;

public interface IDashboardService
{
    Task<DashboardDto> GetDashboardIdentityServerAsync(int auditLogsLastNumberOfDays,
        CancellationToken cancellationToken = default);
}