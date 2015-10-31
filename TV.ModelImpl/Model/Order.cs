using System;
using System.Collections.Generic;
using System.Drawing;
using TV.Model;
using TV.ModelImpl.DbModel;

namespace TV.ModelImpl.Model
{
    public class Order : IOrder
    {
        public Guid Id { get; set; }
        public IContactPerson Contact { get; set; }
        public string OrderType { get; set; }
        public DateTime OrderTime { get; set; }
        public DateTime FinishTime { get; set; }
        public Priority Priority { get; set; }
        public IPaperFormat Format { get; set; }
        public Int32 PageCount { get; set; }
        public Int32 Count { get; set; }
        public Int32 QuireCount { get; set; }
        public Color PrintColor { get; set; }
        public IPaperType PaperType { get; set; }
        public IPrintImplementation Implementation { get; set; }
        public bool IsSpecimenSupplied { get; set; }
        public bool IsPageCompositionSupplied { get; set; }
        public IList<IProofsheet> Proofsheets { get; set; }
        public IFinishingJob Finishing { get; set; }
        public string Details { get; set; }

        // private DbOrder _dbOrder;

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Reload()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }
    }
}