using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CH07_DependencyInjection.Tests
{
    [TestClass]
    public class UnitTests
    {
        [TestInitialize]
        public void Setup()
        {
            DependencyContainer.Register<ServiceOne, ServiceOne>();
            DependencyContainer.Register<ServiceTwo, ServiceTwo>();
        }

        [TestMethod]
        public void DependencyContainerTestServiceOne()
        {
            var serviceOne = DependencyContainer.Resolve<ServiceOne>();
            Assert.IsInstanceOfType(serviceOne, typeof(ServiceOne));
        }

        [TestMethod]
        public void DependencyContainerTestServiceTwo()
        {
            var serviceTwo = DependencyContainer.Resolve<ServiceTwo>();
            Assert.IsInstanceOfType(serviceTwo, typeof(ServiceTwo));
        }

        [TestMethod]
        public void ConstructorInjectionTestServiceOne()
        {
            var serviceOne = DependencyContainer.Resolve<ServiceOne>();
            var client = new Client(serviceOne);
            Assert.IsInstanceOfType(client.Service, typeof(ServiceOne));
        }

        [TestMethod]
        public void ConstructorInjectionTestServiceTwo()
        {
            var serviceTwo = DependencyContainer.Resolve<ServiceTwo>();
            var client = new Client(serviceTwo);
            Assert.IsInstanceOfType(client.Service, typeof(ServiceTwo));
        }

        [TestMethod]
        public void PropertyInjectTestServiceOne()
        {
            var serviceOne = DependencyContainer.Resolve<ServiceOne>();
            var client = new Client();
            client.Service = serviceOne;
            Assert.IsInstanceOfType(client.Service, typeof(ServiceOne));
        }

        [TestMethod]
        public void PropertyInjectTestServiceTwo()
        {
            var serviceTwo = DependencyContainer.Resolve<ServiceTwo>();
            var client = new Client();
            client.Service = serviceTwo;
            Assert.IsInstanceOfType(client.Service, typeof(ServiceTwo));
        }

        [TestMethod]
        public void MethodInjectionTestServiceOne()
        {
            var serviceOne = DependencyContainer.Resolve<ServiceOne>();
            var client = new Client();
            Assert.AreEqual(client.GetServiceName(serviceOne), "CH07_DependencyInjection.ServiceOne()");
        }

        [TestMethod]
        public void MethodInjectionTestServiceTwo()
        {
            var serviceTwo = DependencyContainer.Resolve<ServiceTwo>();
            var client = new Client();
            Assert.AreEqual(client.GetServiceName(serviceTwo), "CH07_DependencyInjection.ServiceTwo()");
        }
    }
}
