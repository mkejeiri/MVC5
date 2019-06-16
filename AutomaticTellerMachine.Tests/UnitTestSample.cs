using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutomaticTellerMachine.Controllers;
using System.Web.Mvc;
using AutomaticTellerMachine.Models;

/************************************************* For test driven development we use ***************************************/
/* Framework to Mock object: 
 * 1- helps deal with creating mocks implemention for dependencies
 *  Rhino Mocks:https://www.nuget.org/packages/RhinoMocks/
 *  https://github.com/Moq
 * 
 * 2- Dependencies containers: handle instantiating the controller with correct db context and other dependencies 
 * Castle Windsor: https://www.nuget.org/packages/Castle.Windsor 
 * Ninject : http://www.ninject.org/
 */
/******************************************************************************************************************************/

namespace AutomaticTellerMachine.Tests
{
    [TestClass]
    public class UnitTestSample
    {
        [TestMethod]
        public void FooActionReturnsAboutView()
        {
            var homeController = new HomeController();
            var result = homeController.Foo() as ViewResult;
            Assert.AreEqual("About", result.ViewName);
        }

        [TestMethod]
        public void ContactFormMessageIsNotNull()
        {
            var homeController = new HomeController();
            var result = homeController.Contact("Thanks, we got your message!") as PartialViewResult;//Assert.AreEqual("Thanks", result.ViewBag.TheMessage);
            Assert.IsNotNull(result.ViewBag.TheMessage);
        }

        [TestMethod]
        public void ContactFormSaysThanks()
        {
            var homeController = new HomeController();
            var message = "Thanks, we got your message!";
            var result = homeController.Contact(message) as PartialViewResult;//Assert.AreEqual("Thanks", result.ViewBag.TheMessage);
            Assert.AreEqual(result.ViewBag.TheMessage, message);
        }

        [TestMethod]
        public void BalanceIsCorrectAfterDeposit()
        {
            var FakeDb = new FakeApplicationDbContext();
            FakeDb.CheckingAccounts = new FakeDbSet<CheckingAccount>();
            var checkingAccount = new CheckingAccount {Id=1, AccountNumber="000123TEST", Balance=0 };
            FakeDb.CheckingAccounts.Add(checkingAccount);

            FakeDb.Transactions = new FakeDbSet<Transaction>();
           var transactionController = new TransactionController(FakeDb);
            transactionController.Deposit(new Transaction { CheckingAccountId = 1, Amount = 25 });
            //checkingAccount.Balance = 25;
            Assert.AreEqual(25, checkingAccount.Balance);
        }
    }
}
