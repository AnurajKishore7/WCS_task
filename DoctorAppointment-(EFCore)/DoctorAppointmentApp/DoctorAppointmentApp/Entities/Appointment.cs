﻿namespace DoctorAppointmentApp.Entities
{
    public class Appointment
    {
        //Properties
        public int Id { get; set; }
        public  DateTime AppointmentDateTime { get; set; }
        public int PatientId {  get; set; } //foreign key
        public int DoctorId { get; set; } //foreign key
        public string AppointmentReason { get; set; } = string.Empty;

        //Navigation Properties
        public Patient? Patient { get; set; }
        public Doctor? Doctor { get; set; }

        public override string ToString()
        {
            return $@"AppointmentId: {Id}
                ScheduledAt: {AppointmentDateTime}
                PatientId: {PatientId}
                DoctorId: {DoctorId}
                AppointmentReason: {AppointmentReason}";
        }

    }
}
