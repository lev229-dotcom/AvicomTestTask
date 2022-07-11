using Avicom.ForTests;
using Avicom.Model;
using Avicom.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avicom.Tests
{
    [TestClass]
    public class WorkWithClientsViewModelTests
    {
        [TestMethod]
        public void AddClient()
        {
            CreateClientCommandHandler c = new CreateClientCommandHandler();
            bool TestResult;
            bool ActualResult = true;

            TestResult = c.CreateClientCommand("TestName", "Обычный клиент", 1);
            Assert.AreEqual(ActualResult, TestResult);
        }
        [TestMethod]
        public void UpdateClient()
        {
            CreateClientCommandHandler c = new CreateClientCommandHandler();
            bool TestResult;
            bool ActualResult = true;

            TestResult = c.UpdateClientCommand("TestNameUpd", "Обычный клиент", 1);
            Assert.AreEqual(ActualResult, TestResult);
        }
        [TestMethod]
        public void DeleteClient()
        {
            CreateClientCommandHandler c = new CreateClientCommandHandler();
            bool TestResult;
            bool ActualResult = true;

            TestResult = c.DeleteClientCommand();
            Assert.AreEqual(ActualResult, TestResult);
        }

    }
}
