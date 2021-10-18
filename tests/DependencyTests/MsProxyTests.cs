using System.Linq;
using Autofac;
using CosmosStack.Dependency;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Xunit;

namespace DependencyTests
{
    public class MsProxyTests
    {
        [Fact]
        public void ProxyTest()
        {
            IServiceCollection services = new ServiceCollection();
            using (var proxy = new MicrosoftProxyRegister(services))
            {
                proxy.AddSingleton<IJiu, RealJiu>();
                proxy.AddSingleton<INice, AppleNice>();
                proxy.AddSingleton<INice, BananaNice>();
                proxy.AddSingleton<INice, CarNice>(r => new CarNice(r.Resolve<IJiu>()));
                proxy.AddTestMyself();
            }

            var container = services.BuildServiceProvider();

            var resolver = new MicrosoftServiceResolver(container);

            var instances0 = resolver.ResolveMany<INice>();
            instances0.Count().ShouldBe(3);

            var instances1 = resolver.ResolveMany(typeof(INice));
            instances1.Count().ShouldBe(3);
        }
    }

    public static class MsProxyExtensions
    {
        public static DependencyProxyRegister AddTestMyself(this DependencyProxyRegister register)
        {
            return register;
        }
    }
}