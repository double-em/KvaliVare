using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KvalitetLibrary.App;
using KvalitetLibrary.Domain;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
     
        [TestMethod]
        public void TestCreateCustomer()
        {
            CustomerRepository c = new CustomerRepository();
            Customer cust = c.CreateCustomer(1, "test", "testaddress", "1234", "testtown", "12344567");
            c.AddCustomer(cust);
            Assert.AreEqual(cust,c.GetCustomer("1"));
        }
    }
}
