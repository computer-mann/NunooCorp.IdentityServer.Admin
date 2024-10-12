using PrinceHarry.AuditLogging.Events;
using PrinceHarry.Duende.IdentityServer.Admin.BusinessLogic.Dtos.IdentityProvider;

namespace PrinceHarry.Duende.IdentityServer.Admin.BusinessLogic.Events.IdentityProvider
{
    public class IdentityProviderRequestedEvent : AuditEvent
    {
        public IdentityProviderDto IdentityProvider { get; set; }

        public IdentityProviderRequestedEvent(IdentityProviderDto identityProvider)
        {
            IdentityProvider = identityProvider;
        }
    }
}