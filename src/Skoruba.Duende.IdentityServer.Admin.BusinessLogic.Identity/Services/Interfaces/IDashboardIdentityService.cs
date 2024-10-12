using System.Threading;
using System.Threading.Tasks;
using PrinceHarry.Duende.IdentityServer.Admin.BusinessLogic.Identity.Dtos.DashboardIdentity;

namespace PrinceHarry.Duende.IdentityServer.Admin.BusinessLogic.Identity.Services.Interfaces;

public interface IDashboardIdentityService
{
    public Task<DashboardIdentityDto> GetIdentityDashboardAsync(CancellationToken cancellationToken = default);
}