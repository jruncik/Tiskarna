using NUnit.Framework;
using TV.ModelImpl.Model;
using TV.Tiskarna;

namespace TV.ModelImpl.Tests
{
    [TestFixture]
    public class ContactPersoneTests
    {
        [Test]
        public void CreateContext()
        {
            ContactPerson cp = new ContactPerson();
            cp.FirstName = "Jarosav";
            cp.LastName = "Runcik";
            cp.Email = "J.Runcik@seznam.cz";
            cp.PhoneNumber = "+420 602 658 348";

            cp.Save();
            cp.Delete();
        }

        #region Tests Initialization

        [SetUp]
        public void TestInit()
        {
            new TiskarnaVosahlo();
        }

        [TearDown]
        public void TestCleanup()
        {
        }

        [TestFixtureSetUp]
        public void AllTestsInit()
        {
        }

        [TestFixtureTearDown]
        public void AllTestCleanup()
        {
        }

        #endregion

        private const string MASTER_USERNAME = "UberNjorloj";
        private const string MASTER_PASSWORD = "IddqdIdkfa";
    }
}
