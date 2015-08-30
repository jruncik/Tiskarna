using System;

namespace TV.Model
{
    public interface IContactPerson
    {
        Guid Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string PhoneNumber { get; set; }
        string Email { get; set; }
    }
}