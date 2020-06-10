using Microsoft.Extensions.DependencyInjection;

namespace Lottery.Infra.CrossCutting.Storage.Tests.Fixtures
{
    public class ServiceProviderFixture
    {
        public ServiceCollection ServiceCollection { get; }
        public ServiceProviderFixture()
        {
            ServiceCollection = new ServiceCollection();
        }
    }
}
