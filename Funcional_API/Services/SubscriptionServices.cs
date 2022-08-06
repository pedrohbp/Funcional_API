using Funcional_API.Interfaces;

namespace Funcional_API.Services
{
    public class SubscriptionServices : ISubscriptionServices
    {
        public SubscriptionServices()
        {
            this.ContaAddedService = new ContaAddedService();
        }
        public ContaAddedService ContaAddedService { get; }
    }
}
