namespace DependencyTests
{
    public interface INice { }

    public class AppleNice : INice { }

    public class BananaNice : INice { }

    public class CarNice : INice
    {
        public CarNice(IJiu jiu) { }
    }

    public interface IJiu { }

    public class RealJiu : IJiu { }
}