using NHibernate;
using System;
using System.Drawing;
using TV.Core.Context;
using TV.Model;
using TV.ModelImpl.DbModel;
using TV.ModelImpl.Model.PaperFormats;

namespace TV.ModelImpl.Model
{
    public class Order : IOrder
    {
        public Order():
            this(new DbOrder())
        { }

        public Order(DbOrder dbOrder)
        {
            _dbOrder = dbOrder;
        }

        public Guid Id
        {
            get { return _dbOrder.Id; }
            set { _dbOrder.Id = value; }
        }

        public IContactPerson Contact
        {
            get { return _contactPerson; }
            set { _contactPerson = (ContactPerson)value; }
        }

        public string OrderType
        {
            get { return _dbOrder.OrderType; }
            set { _dbOrder.OrderType = value; }
        }

        public DateTime OrderTime
        {
            get { return _dbOrder.OrderTime; }
            set { _dbOrder.OrderTime = value; }
        }

        public DateTime FinishTime
        {
            get { return _dbOrder.FinishTime; }
            set { _dbOrder.FinishTime = value; }
        }

        public Priority Priority
        {
            get { return (Priority)_dbOrder.Priority; }
            set { _dbOrder.Priority = (int)value; }
        }

        public IPaperFormat Format
        {
            get { return _paperFormat; }
            set { _paperFormat = value; }
        }

        public int PageCount
        {
            get { return _dbOrder.PageCount; }
            set { _dbOrder.PageCount = value; }
        }

        public int Count
        {
            get { return _dbOrder.Count; }
            set { _dbOrder.Count = value; }
        }

        public int QuireCount
        {
            get { return _dbOrder.QuireCount; }
            set { _dbOrder.QuireCount = value; }
        }

        public Color PrintColor
        {
            get { return Color.FromArgb(_dbOrder.PrintColor); }
            set { _dbOrder.PrintColor = value.ToArgb(); }
        }

        public IPaperType PaperType
        {
            get { return _paperType; }
            set { _paperType = (PaperType)value; }
        }

        public IPrintImplementation Implementation
        {
            get { return _implementation; }
            set { _implementation = (PrintImplementation)value; }
        }

        public bool IsSpecimenSupplied
        {
            get { return _dbOrder.IsSpecimenSupplied; }
            set { _dbOrder.IsSpecimenSupplied = value; }
        }

        public bool IsPageCompositionSupplied
        {
            get { return _dbOrder.IsPageCompositionSupplied; }
            set { _dbOrder.IsPageCompositionSupplied = value; }
        }

        public IProofsheet Proofsheets
        {
            get { return _proofsheets; }
            set { _proofsheets = (Proofsheet)value; }
        }


        public IFinishingJob Finishing
        {
            get { return _finishing; }
            set { _finishing = (FinishingJob)value; }
        }

        public string Details
        {
            get { return _dbOrder.Details; }
            set { _dbOrder.Details = value; }
        }

        IProofsheet IOrder.Proofsheets
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public void Save()
        {
            using (ISession session = UserContext.SessionFactory.OpenSession())
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    if (Id == Guid.Empty)
                    {
                        using (AppliactionContext.Log.LogTime(this, $"Save order"))
                        {
                            session.Save(_dbOrder);
                        }
                    }
                    else
                    {
                        using (AppliactionContext.Log.LogTime(this, $"Update order"))
                        {
                            session.Update(_dbOrder);
                        }
                    }
                    tx.Commit();
                }
            }
        }

        public void Reload()
        {
            using (ISession session = UserContext.SessionFactory.OpenSession())
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    using (AppliactionContext.Log.LogTime(this,$"Reload order."))
                    {
                        DbOrder reloadedObOrder = session.Load<DbOrder>(_dbOrder.Id);
                    }
                    tx.Commit();
                }
            }
        }

        public void Delete()
        {
            using (ISession session = UserContext.SessionFactory.OpenSession())
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    using (AppliactionContext.Log.LogTime(this, $"Delete order."))
                    {
                        session.Delete(_dbOrder);
                    }
                    tx.Commit();
                }
            }
        }

        private DbOrder _dbOrder;
        private ContactPerson _contactPerson;
        private IPaperFormat _paperFormat;
        private PaperType _paperType;
        private PrintImplementation _implementation;
        private Proofsheet _proofsheets;
        private FinishingJob _finishing;
    }
}