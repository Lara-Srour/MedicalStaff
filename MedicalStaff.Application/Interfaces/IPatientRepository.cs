using MedicalStaff.Domain;

namespace MedicalStaff.Application.Interfaces
{
    public interface IPatientRepository  : ICommonRepository<Patient>
    {
        Task AddPatientAsync(Patient patient);
        Task UpdatePatientAsync(Patient patient);
        Task DeletePatientAsync(int patientId);
    }
}
