using NUnit.Framework;
using CH06_RhinoMocks;
using Rhino.Mocks;

namespace CH06_RhinoMocks.Tests
{
    [TestFixture]
    public class Tests
    {
        private MockRepository mocks = new MockRepository();

        [Test]
        public void CheckGetMessagePassesWithMock()
        {
            // Arrange
            DataManager manager = new DataManager();
            DataStore<string> mockDataStore = mocks.DynamicMock<DataStore<string>>();
            // Act
            Expect.Call(mockDataStore.Item).PropertyBehavior();
            mocks.ReplayAll();
            manager.SetDataSource(mockDataStore);
            manager.LoadDataStore("Hello World! How do you like Rhino Mocks?");
            // Assert
            Assert.AreEqual("Hello World! How do you like Rhino Mocks?", manager.GetMessage());
            mocks.VerifyAll();
        }
    }
}