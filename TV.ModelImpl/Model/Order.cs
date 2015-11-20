using NHibernate;
using System;
using System.Drawing;
using TV.Core.Context;
using TV.Model;
using TV.ModelImpl.DbModel;

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

        public IContactPerson Contact { get; set; }

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

        public Priority Priority { get; set; }

        public IPaperFormat Format { get; set; }

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

        public Color PrintColor { get; set; }

        public IPaperType PaperType { get; set; }

        public IPrintImplementation Implementation { get; set; }

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

        public IProofsheet Proofsheets { get; set; }

        public IFinishingJob Finishing { get; set; }

        public string Details
        {
            get { return _dbOrder.Details; }
            set { _dbOrder.Details = value; }
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
                        using (AppliactionContext.Log.LogTime(this, $"Update contact persone"))
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
                    using (AppliactionContext.Log.LogTime(this,$"Reload contact person"))
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
                    using (AppliactionContext.Log.LogTime(this, $"Delete contact person."))
                    {
                        session.Delete(_dbOrder);
                    }
                    tx.Commit();
                }
            }
        }

        private DbOrder _dbOrder;
    }
}