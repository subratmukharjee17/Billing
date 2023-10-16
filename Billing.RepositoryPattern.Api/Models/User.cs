using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Billing.RepositoryPattern.Api.Models
{
    public class User
    {
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
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string LandMark { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public string Country { get; set; }
        public int RoleId { get; set; }
        public bool IsActive { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}
