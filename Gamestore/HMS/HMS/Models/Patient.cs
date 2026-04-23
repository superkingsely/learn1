using HMS.Models;

namespace HospitalManagementSystem.Models
{
    public class Patient : UserCreateActivity
    {
        public int Id { get; set; }
        public string PatientNo { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {MiddleName} {LastName}".Trim();
        public string PhoneNumber { get; set; }
        public string IdNumber { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string GuardianName { get; set; }
        public string GuardianPhoneNumber { get; set; }
        public string Address { get; set; }
        public int SexId { get; set; }
        public SystemCodeDetail Sex { get; set; }
        public int BloodGroupId { get; set; }
        public SystemCodeDetail BloodGroup { get; set; }
        public int? MaritalStatusId { get; set; }
        public SystemCodeDetail MaritalStatus { get; set; }
        public string Remarks { get; set; }
        public string Allergies { get; set; }
    }
}
