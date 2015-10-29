using System;
using System.Collections.Generic;
using System.Drawing;
using TV.Model;
using TV.ModelImpl.Model;

namespace TV.ModelImpl.DbModel
{
    public class DbOrder
    {
        public virtual Guid Id { get; set; }
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
        public PaperType PaperType { get; set; }
        public PrintImplementation Implementation { get; set; }
        public bool IsSpecimenSupplied { get; set; }
        public bool IsPageCompositionSupplied { get; set; }
        public IList<Proofsheet> Proofsheets { get; set; }
        public FinishingJob Finishing { get; set; }
        public string Details { get; set; }

        public DbOrder()
        {
            Id = Guid.Empty;
            OrderType = DateTime.Now;
        }

    }
}
