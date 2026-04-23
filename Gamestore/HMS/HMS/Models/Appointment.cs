using HMS.Models;

namespace HospitalManagementSystem.Models
{
    public class Appointment : UserCreateActivity
    {
        public int Id { get; set; }
        public string AppointmentNo { get; set; }
        public int? PatientId { get; set; }
        public Patient Patient { get; set; }
        public int DoctorId { get; set; }
        public Employee Doctor { get; set; }
        public int SlotId { get; set; }
        public AppointmentSlot Slot { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int PriorityId { get; set; }
        public SystemCodeDetail Priority { get; set; }
        public int PaymentModeId { get; set; }
        public SystemCodeDetail PaymentMode { get; set; }
        public int StatusId { get; set; }
        public SystemCodeDetail Status { get; set; }
        public string Address { get; set; }
        public string Remarks { get; set; }
    }
    public class AppointmentSlot : UserCreateActivity
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public Employee Doctor { get; set; }
        public int ShiftId { get; set; }
        public SystemCodeDetail Shift { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public int StatusId { get; set; }
        public SystemCodeDetail Status { get; set; }

    }
}
