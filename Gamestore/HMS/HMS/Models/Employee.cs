using HMS.Models;

namespace HospitalManagementSystem.Models
{
    public class Employee :UserCreateActivity
    {
        public int Id { get; set; }
        public string EmployeeNo { get; set; }
        public string IdNumber { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {MiddleName} {LastName}".Trim();
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfJoining { get; set; }
        public int RoleId { get; set; }
        public SystemCodeDetail Role { get; set; }

        public int DesignationId { get; set; }
        public SystemCodeDetail Designation { get; set; }
        public int DepartmentId { get; set; } // e.g., Cardiology, Neurology, etc.

        public Department Department { get; set; }

        public int SpecialistId { get; set; }
        public SystemCodeDetail Specialist { get; set; }

        public string FatherName { get; set; }

        public string MotherName { get; set; }

        public int GenderId { get; set; }
        public SystemCodeDetail Gender { get; set; }

        public int MaritalStatusId { get; set; }
        public SystemCodeDetail MaritalStatus { get; set; }

        public int BloodGroupId { get; set; }
        public SystemCodeDetail BloodGroup { get; set; }
        
        public int StatusId { get; set; }
        public SystemCodeDetail Status { get; set; }
        
    }
}
