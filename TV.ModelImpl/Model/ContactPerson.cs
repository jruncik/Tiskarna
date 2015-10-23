using System;
using NHibernate;
using TV.Core.Context;
using TV.Model;
using TV.ModelImpl.DbModel;

namespace TV.ModelImpl.Model
{
    public class ContactPerson : IContactPerson
    {
        public ContactPerson() :
            this(new DbContactPerson())
        {
        }

        public ContactPerson(DbContactPerson dbContactPerson)
        {
            _dbContactPerson = dbContactPerson;
        }

        public virtual Guid Id
        {
            get { return _dbContactPerson.Id; }
            set { _dbContactPerson.Id = value; }
        }

        public virtual string FirstName
        {
            get { return _dbContactPerson.FirstName; }
            set { _dbContactPerson.FirstName = value; }
        }

        public virtual string LastName
        {
            get { return _dbContactPerson.LastName; }
            set { _dbContactPerson.LastName = value; }

        }

        public virtual string PhoneNumber
        {
            get { return _dbContactPerson.PhoneNumber; }
            set { _dbContactPerson.PhoneNumber = value; }
        }

        public virtual string Email
        {
            get { return _dbContactPerson.Email; }
            set { _dbContactPerson.Email = value; }
        }

        public void Save()
        {
            using (AppliactionContext.Log.LogTime(this, String.Format("Save contact persone '{0} {1}'.", FirstName, LastName)))
            {
                using (ISession session = AppliactionContext.SessionFactory.OpenSession())
                {
                    using (ITransaction tx = session.BeginTransaction())
                    {
                        if (Id == Guid.Empty)
                        {
                            session.Save(_dbContactPerson);
                        }
                        else
                        {
                            session.Update(_dbContactPerson);
                        }
                        tx.Commit();
                    }
                }
            }
        }

        public void Reload()
        {
            using (AppliactionContext.Log.LogTime(this, String.Format("Reload contact person '{0} {1}'.", FirstName, LastName)))
            {
                using (ISession session = AppliactionContext.SessionFactory.OpenSession())
                {
                    using (ITransaction tx = session.BeginTransaction())
                    {
                        DbContactPerson reloadedContactPerson = session.Load<DbContactPerson>(_dbContactPerson.Id);

                        _dbContactPerson.FirstName = reloadedContactPerson.FirstName;
                        _dbContactPerson.LastName = reloadedContactPerson.LastName;
                        _dbContactPerson.PhoneNumber = reloadedContactPerson.PhoneNumber;
                        _dbContactPerson.Email = reloadedContactPerson.Email;
                    }
                }
            }
        }

        public void Delete()
        {
            using (AppliactionContext.Log.LogTime(this, String.Format("Delete contact person '{0} {1}'.", FirstName, LastName)))
            {
                using (ISession session = AppliactionContext.SessionFactory.OpenSession())
                {
                    using (ITransaction tx = session.BeginTransaction())
                    {
                        session.Delete(_dbContactPerson);
                        tx.Commit();
                    }
                }
            }
        }

        private readonly DbContactPerson _dbContactPerson;
    }
}