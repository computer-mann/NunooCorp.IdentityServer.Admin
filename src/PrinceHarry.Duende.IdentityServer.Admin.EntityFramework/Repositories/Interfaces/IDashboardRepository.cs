using System.Threading;
using System.Threading.Tasks;
using PrinceHarry.Duende.IdentityServer.Admin.EntityFramework.Entities;

namespace PrinceHarry.Duende.IdentityServer.Admin.EntityFramework.Repositories.Interfaces;

public interface IDashboardRepository
{
    Task<DashboardDataView> GetDashboardIdentityServerAsync(int auditLogsLastNumberOfDays,
        CancellationToken cancellationToken = default);
}