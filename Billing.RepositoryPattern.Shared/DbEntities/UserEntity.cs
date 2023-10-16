using System;

namespace Billing.RepositoryPattern.Shared.DbEntities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LoginName { get; set; }
        public string EmailId { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Dob { get; set; }
        public int Gender { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int AddressId { get; set; }
        public int RoleId { get; set; }
        public bool IsActive { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}
