using MedicalStaff.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalStaff.Application.Interfaces
{
    public interface INurseRepository : ICommonRepository<Nurse>
    {
        Task<IEnumerable<Nurse>> GetNursesInDepartmentAsync(string department);
        Task AddNurseAsync(Nurse nurse);
    }
}
