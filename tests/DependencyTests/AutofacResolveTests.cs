using System.Linq;
using Autofac;
using Cosmos.Dependency;
using Shouldly;

namespace DependencyTests
{

    public class AutofacResolveTests
    {
        [Xunit.Fact]
        public void ResolveTest()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<AppleNice>().As<INice>().SingleInstance();
            builder.RegisterType<BananaNice>().As<INice>().SingleInstance();
            var container = builder.Build();

            var resolver = new AutofacServiceResolver(container);

            var instances0 = resolver.ResolveMany<INice>();
            instances0.Count().ShouldBe(2);

            var instances1 = resolver.ResolveMany(typeof(INice));
            instances1.Count().ShouldBe(2);
        }
    }
}