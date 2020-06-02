using System.Linq;
using Autofac;
using Cosmos.Dependency;
using Shouldly;
using Xunit;

namespace DependencyTests
{
    public class AutofacProxyTests
    {
        [Fact]
        public void ProxyTest()
        {
            var builder = new ContainerBuilder();
            using (var proxy = new AutofacProxyRegister(builder))
            {
                proxy.AddSingleton<INice, AppleNice>();
                proxy.AddSingleton<INice, BananaNice>();
                proxy.AddSingleton<INice, CarNice>(r => new CarNice(r.Resolve<IJiu>()));
            }

            var container = builder.Build();

            var resolver = new AutofacServiceResolver(container);

            var instances0 = resolver.ResolveMany<INice>();
            instances0.Count().ShouldBe(3);

            var instances1 = resolver.ResolveMany(typeof(INice));
            instances1.Count().ShouldBe(3);
        }
    }
}