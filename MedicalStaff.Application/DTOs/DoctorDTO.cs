﻿namespace MedicalStaff.Application.DTOs
{
    public class DoctorDTO : IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Specialty { get; set; }
    }
}
