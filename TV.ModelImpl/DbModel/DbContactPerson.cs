using System;

namespace TV.ModelImpl.DbModel
{
    public class DbContactPerson
    {
        public virtual Guid Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual string Email { get; set; }
    }
}