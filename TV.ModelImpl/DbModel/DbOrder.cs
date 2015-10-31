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
        public virtual IContactPerson Contact { get; set; }
        public virtual string OrderType { get; set; }
        public virtual DateTime OrderTime { get; set; }
        public virtual DateTime FinishTime { get; set; }
        public virtual Priority Priority { get; set; }
        public virtual IPaperFormat Format { get; set; }
        public virtual Int32 PageCount { get; set; }
        public virtual Int32 Count { get; set; }
        public virtual Int32 QuireCount { get; set; }
        public virtual Color PrintColor { get; set; }
        public virtual PaperType PaperType { get; set; }
        public virtual PrintImplementation Implementation { get; set; }
        public virtual bool IsSpecimenSupplied { get; set; }
        public virtual bool IsPageCompositionSupplied { get; set; }
        public virtual IList<Proofsheet> Proofsheets { get; set; }
        public virtual FinishingJob Finishing { get; set; }
        public virtual string Details { get; set; }

        public DbOrder()
        {
            Id = Guid.Empty;
            OrderTime = DateTime.Now;
        }
    }
}
