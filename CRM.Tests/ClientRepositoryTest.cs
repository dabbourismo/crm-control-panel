
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRM.Repository;
using CRM.Models;
using Moq;
using CRM.Repository.ClientRepositorys;
using System.Data.Entity;

namespace CRM.Tests
{
    [TestClass]
    public class ClientRepositoryTest
    {
        private ClientRepository _repository;
        private Mock<DbSet<Client>> _mockClients;
        [TestInitialize]
        public void TestInitialize()
        {
            _mockClients = new Mock<DbSet<Client>>();
            var mockClients = new Mock<DbSet<Client>>();
            var mockContext = new Mock<AdlinkContext>();
            mockContext.SetupGet(c => c.Clients).Returns(mockClients.Object);
            _repository = new ClientRepository(mockContext.Object);
        }

    }
}
