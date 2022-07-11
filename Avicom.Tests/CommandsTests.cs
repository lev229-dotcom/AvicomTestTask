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
    public class CommandsTests
    {
        #region Client
        [TestMethod]
        public void AddClient()
        {
            CommandHandler c = new CommandHandler();
            bool TestResult;
            bool ActualResult = true;

            TestResult = c.CreateClientCommand("TestName", "Обычный клиент", 1);
            Assert.AreEqual(ActualResult, TestResult);
        }
        [TestMethod]
        public void UpdateClient()
        {
            CommandHandler c = new CommandHandler();
            bool TestResult;
            bool ActualResult = true;

            TestResult = c.UpdateClientCommand("TestNameUpd", "Обычный клиент", 1);
            Assert.AreEqual(ActualResult, TestResult);
        }
        [TestMethod]
        public void DeleteClient()
        {
            CommandHandler c = new CommandHandler();
            bool TestResult;
            bool ActualResult = true;

            TestResult = c.DeleteClientCommand();
            Assert.AreEqual(ActualResult, TestResult);
        }
        #endregion


        #region Manager
        [TestMethod]
        public void AddManager()
        {
            CommandHandler c = new CommandHandler();
            bool TestResult;
            bool ActualResult = true;

            TestResult = c.CreateClientCommand("TestName", "Обычный клиент", 1);
            Assert.AreEqual(ActualResult, TestResult);
        }
        [TestMethod]
        public void UpdateManager()
        {
            CommandHandler c = new CommandHandler();
            bool TestResult;
            bool ActualResult = true;

            TestResult = c.UpdateClientCommand("TestNameUpd", "Обычный клиент", 1);
            Assert.AreEqual(ActualResult, TestResult);
        }
        [TestMethod]
        public void DeleteManager()
        {
            CommandHandler c = new CommandHandler();
            bool TestResult;
            bool ActualResult = true;

            TestResult = c.DeleteClientCommand();
            Assert.AreEqual(ActualResult, TestResult);
        }
        #endregion

        #region Product
        [TestMethod]
        public void AddProduct()
        {
            CommandHandler c = new CommandHandler();
            bool TestResult;
            bool ActualResult = true;

            TestResult = c.CreateProductCommand("TestName", 1, "Подписка", "Месяц");
            Assert.AreEqual(ActualResult, TestResult);
        }
        [TestMethod]
        public void UpdateProduct()
        {
            CommandHandler c = new CommandHandler();
            bool TestResult;
            bool ActualResult = true;

            TestResult = c.UpdateProductCommand("TestNameUpd", 1, "Подписка", "Год");
            Assert.AreEqual(ActualResult, TestResult);
        }
        [TestMethod]
        public void DeleteProduct()
        {
            CommandHandler c = new CommandHandler();
            bool TestResult;
            bool ActualResult = true;

            TestResult = c.DeleteProductCommand();
            Assert.AreEqual(ActualResult, TestResult);
        }
        #endregion
    }
}
