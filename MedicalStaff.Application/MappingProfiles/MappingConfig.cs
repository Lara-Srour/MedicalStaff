using Mapster;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Domain;

namespace MedicalStaff.Application.MappingProfiles
{
    public static class MappingConfig
    {
        public static void RegisterMappings()
        {
            // Department mappings
            TypeAdapterConfig<DepartmentDTO, Department>.NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name);

            // Doctor mappings
            TypeAdapterConfig<DoctorDTO, Doctor>.NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Specialty, src => src.Specialty);

            // Nurse mappings
            TypeAdapterConfig<NurseDTO, Nurse>.NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.DepartmentName, src => src.DepartmentName);

            //Patient mappings
            TypeAdapterConfig<PatientDTO, Patient>.NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.DoctorId, src => src.DoctorId)
                .Map(dest => dest.NurseId, src => src.NurseId)
                .Map(dest => dest.RoomNumber, src => src.RoomNumber);

            //Room mappings
            TypeAdapterConfig<RoomDTO, Room>.NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Number, src => src.Number)
                .Map(dest => dest.DepartmentName, src => src.DepartmentName)
                .Map(dest => dest.IsAvailable, src => src.IsAvailable);

        }
    }
}