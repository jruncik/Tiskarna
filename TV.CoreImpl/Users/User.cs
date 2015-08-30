using System;
using NHibernate;
using TV.Core;
using TV.Core.Context;
using TV.Core.Users;
using TV.ModelImpl.DbModel;

namespace TV.CoreImpl.Users
{
    internal class User : IUser
    {
        public User(DbUser dbUser)
        {
            _dbUser = dbUser;
        }

        public User():
            this(new DbUser())
        {
        }

        public User(String username, String password) :
            this(new DbUser())
        {
            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
            {
                AppliactionContext.Log.Debug(this, "Username or password is empty.");
                throw new TvException(Resources.UsernameOrPasswordIsEmpty);
            }

            Username = username;
            Password = password;
        }

        public Guid Id
        {
            get { return DbUser.Id; }
            set { DbUser.Id = value; }
        }

        public string Username
        {
            get { return DbUser.Username; }
            set { DbUser.Username = value; }
        }

        public string Password
        {
            get { return DbUser.Password; }
            set { DbUser.Password = value; }
        }

        internal DbUser DbUser
        {
            get { return _dbUser; }
        }

        public bool IsBuiltIn
        {
            get
            {
                return false;
            }
        }

        public void Save()
        {
            using (AppliactionContext.Log.LogTime(this, String.Format("Save user '{0}'.", Username)))
            {
                using (ISession session = AppliactionContext.SessionFactory.OpenSession())
                {
                    using (ITransaction tx = session.BeginTransaction())
                    {
                        if (Id == Guid.Empty)
                        {
                            session.Save(_dbUser);
                        }
                        else
                        {
                            session.Update(_dbUser);
                        }
                        tx.Commit();
                    }
                }
            }
        }

        public void Reload()
        {
            using (AppliactionContext.Log.LogTime(this, String.Format("Reload user '{0}'.", Username)))
            {
                using (ISession session = AppliactionContext.SessionFactory.OpenSession())
                {
                    using (ITransaction tx = session.BeginTransaction())
                    {
                        DbUser reloadedUser = session.Load<DbUser>(_dbUser.Id);

                        _dbUser.Password = reloadedUser.Password;
                        _dbUser.Username = reloadedUser.Username;
                    }
                }
            }
        }

        internal void Delete()
        {
            using (AppliactionContext.Log.LogTime(this, String.Format("Delete user '{0}'.", Username)))
            {
                using (ISession session = AppliactionContext.SessionFactory.OpenSession())
                {
                    using (ITransaction tx = session.BeginTransaction())
                    {
                        session.Delete(_dbUser);
                        tx.Commit();
                    }
                }
            }
        }

        private readonly DbUser _dbUser;
    }
}