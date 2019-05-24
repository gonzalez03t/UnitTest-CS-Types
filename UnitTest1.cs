using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest_CS_Types
{
    public class Invoice
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
    }

    [TestClass]
    public class ReferenceTypesAndValueTypes
    {
        [TestMethod]
        public void IdentityTest()
        {
            Invoice firstInvoice = new Invoice(); //Instantiate first invoice object
            firstInvoice.ID = 1;
            firstInvoice.Description = "Test";
            firstInvoice.Amount = 0.0M;

            Invoice secondInvoice = new Invoice(); //Instantiate first invoice object
            secondInvoice.ID = 1;
            secondInvoice.Description = "Test";
            secondInvoice.Amount = 0.0M;

            //Testing Reference Types
            Assert.IsFalse(object.ReferenceEquals(secondInvoice, firstInvoice));
            Assert.IsTrue(firstInvoice.ID == 1);

            secondInvoice.ID = 2;

            Assert.IsTrue(secondInvoice.ID == 2);
            Assert.IsTrue(firstInvoice.ID == 1);

            secondInvoice = firstInvoice;

            Assert.IsTrue(object.ReferenceEquals(secondInvoice, firstInvoice));

            secondInvoice.ID = 5;

            Assert.IsTrue(firstInvoice.ID == 5);
        }

        [TestMethod]
        public void ValueTypeTest()
        {
            int x = 5;
            int y = x;

            y = 10;

            Assert.IsTrue(x == 5);
            Assert.IsTrue(y == 10);
        }

        [TestMethod]
        public void PassByValue()
        {
            Invoice invoice = new Invoice();
            invoice.ID = 1;
            int value;

            DoWork(ref invoice, out value);

            Assert.IsTrue(invoice.ID == 5);
            Assert.IsTrue(value == 3);
        }

        void DoWork(ref Invoice invoice, out int value)
        {
            invoice = new Invoice();
            invoice.ID = 5;

            value = 3;
        }

        [TestMethod]
        public void StringTest()
        {
            string name = " Jesus ";

            name = name.Trim(); //Remove all leading and trailing white spaces

            Assert.IsTrue(name.Equals("Jesus", StringComparison.CurrentCulture));
        }

    }
}
