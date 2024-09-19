using MedicalStaff.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalStaff.Application.Interfaces
{
    public interface IDoctorRepository : ICommonRepository<Doctor>
    {
        Task<IEnumerable<Doctor>> GetDoctorsBySpecialtyAsync(string specialty);
        Task<IEnumerable<Patient>> GetDoctorPatientsAsync(int id);

    }
}
