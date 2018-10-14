using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OMHRD.Model
{
    public class UserProfileDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Nullable<DateTime> DOB { get; set; }
        public string ContactNo { get; set; }
        public string ReferenceBy { get; set; }
        public System.DateTime RegistrationDate { get; set; }
        public string CompanyName { get; set; }
        public string IdentificationType { get; set; }
        public string TexExempt { get; set; }
        public string WFile { get; set; }
        public Nullable<DateTime> AnniversaryDate { get; set; }
        public Nullable<DateTime> SmartDeliveryDate { get; set; }
        public string Website { get; set; }
        public string Fax { get; set; }
        public string CoApplicant { get; set; }
        public string Language { get; set; }
        public string Skype { get; set; }
        public string Twitter { get; set; }
        public string Facebook { get; set; }
        public byte[] PhotoImage { get; set; }
        public string Status { get; set; }
        public Nullable<int> UserParentId { get; set; }
        public decimal WalletBalance { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public Nullable<bool> IsSpecialUser { get; set; }
    }
}
