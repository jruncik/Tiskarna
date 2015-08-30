using System;
using NUnit.Framework;
using TV.Core.Context;
using TV.Core.Rights;
using TV.Core.UserManagement;
using TV.CoreImpl.Autentication;
using TV.Tiskarna;

namespace TV.CoreImpl.Tests
{
    [TestFixture]
    public class AutenticationTests
    {
        [Test]
        [ExpectedException(typeof (AutenticationException))]
        public void LoginUserWithEmptyUsername()
        {
            TiskarnaVosahlo.Autentication.LogIn("", PASSWORD);
        }

        [Test]
        [ExpectedException(typeof (AutenticationException))]
        public void LoginUserWithEmptyPassword()
        {
            TiskarnaVosahlo.Autentication.LogIn(USERNAME, "");
        }

        [Test]
        [ExpectedException(typeof (AutenticationException))]
        public void LoginUserWrongUser()
        {
            TiskarnaVosahlo.Autentication.LogIn(WRONG_USERNAME, PASSWORD);
        }

        [Test]
        [ExpectedException(typeof (AutenticationException))]
        public void LoginUserWrongPassword()
        {
            TiskarnaVosahlo.Autentication.LogIn(USERNAME, WRONG_PASSWORD);
        }

        [Test]
        public void LoginUser()
        {
            TiskarnaVosahlo.Autentication.LogIn(USERNAME, PASSWORD);

            Assert.AreEqual(UserContext.User.Username, USERNAME);
            Assert.AreEqual(UserContext.User.Password, PASSWORD);
        }

        [Test]
        public void LoginCaseInsensitiveUser()
        {
            TiskarnaVosahlo.Autentication.LogIn(USERNAME_CASE_INSENSITIVE, PASSWORD);

            Assert.AreEqual(UserContext.User.Username, USERNAME);
            Assert.AreEqual(UserContext.User.Password, PASSWORD);
        }

        [Test]
        public void LoginMasterUser()
        {
            TiskarnaVosahlo.Autentication.LogIn(MASTER_USERNAME, MASTER_PASSWORD);

            Assert.AreEqual(UserContext.User.Username, MASTER_USERNAME);
            Assert.AreEqual(UserContext.User.Password, MASTER_PASSWORD);
            Assert.AreEqual(UserContext.Context.IsInRole(Roles.Unknown), true);
        }

        [Test]
        public void LoginGuestUser()
        {
            TiskarnaVosahlo.Autentication.LogIn(GUEST_USERNAME, GUEST_PASSWORD);

            Assert.AreEqual(UserContext.User.Username, GUEST_USERNAME);
            Assert.AreEqual(UserContext.User.Password, GUEST_PASSWORD);
            Assert.AreEqual(UserContext.Context.IsInRole(Roles.ManageUsers), false);
        }

        #region Tests Initialization

        [SetUp]
        public void TestInit()
        {
            TiskarnaVosahlo.UserManagement.DeleteAllUsers();
            AddTestUser();
        }

        [TearDown]
        public void TestCleanup()
        {
            UserContext.Logout();
            TiskarnaVosahlo.UserManagement.DeleteAllUsers();
        }

        [TestFixtureSetUp]
        public void AllTestsInit()
        {
            new TiskarnaVosahlo();
        }

        [TestFixtureTearDown]
        public void AllTestCleanup()
        {
            TiskarnaVosahlo.UserManagement.DeleteAllUsers();
        }

        private void AddTestUser()
        {
            TiskarnaVosahlo.Autentication.LogIn(MASTER_USERNAME, MASTER_PASSWORD);

            IUserManagement userManagement = TiskarnaVosahlo.UserManagement;
            userManagement.CreateNewUser(USERNAME, PASSWORD);

            UserContext.Logout();
        }

        #endregion

        private const String USERNAME = "TestNjorloj";
        private const String PASSWORD = "TestChorchoj";
        private const String USERNAME_CASE_INSENSITIVE = "TeStNjOrLoJ";

        private const String WRONG_USERNAME = "WrongUsername";
        private const String WRONG_PASSWORD = "WrongPassword";

        private const String MASTER_USERNAME = "UberNjorloj";
        private const String MASTER_PASSWORD = "IddqdIdkfa";

        private const String GUEST_USERNAME = "Guest";
        private const String GUEST_PASSWORD = "guest";
    }
}