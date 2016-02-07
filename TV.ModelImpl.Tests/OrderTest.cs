﻿using NUnit.Framework;
using TV.Core.Context;
using TV.ModelImpl.Model;
using TV.Tiskarna;

namespace TV.ModelImpl.Tests
{
    [TestFixture]
    public class OrderTest
    {
        [Test]
        public void CreateOrder()
        {
            ContactPerson cp = new ContactPerson();
            cp.FirstName = "Jarosav";
            cp.LastName = "Runcik";
            cp.Email = "J.Runcik@seznam.cz";
            cp.PhoneNumber = "+420 602 658 348";

            cp.Save();

            try
            {
                Order order = new Order();

                order.Contact = cp;

                order.Save();
                order.Delete();
            }
            finally
            {
                cp.Delete();
            }
        }

        #region Tests Initialization

        [SetUp]
        public void TestInit()
        {
            TiskarnaVosahlo.Autentication.LogIn(MASTER_USERNAME, MASTER_PASSWORD);
        }

        [TearDown]
        public void TestCleanup()
        {
            UserContext.Logout();
        }

        [OneTimeSetUpAttribute]
        public void AllTestsInit()
        {
            new TiskarnaVosahlo();
        }

        [OneTimeTearDownAttribute]
        public void AllTestCleanup()
        {
        }

        #endregion

        private const string MASTER_USERNAME = "UberNjorloj";
        private const string MASTER_PASSWORD = "IddqdIdkfa";
    }
}
