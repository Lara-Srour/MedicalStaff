using MedicalStaff.Domain;

namespace MedicalStaff.Application.Interfaces

{
    public interface IDepartmentRepository : ICommonRepository<Department>
        
    {
        Task<IEnumerable<Room>> DisplayRoomsInDepartmentAsync(string depName);
        Task UpadateDepartnmentAsync(Department department);
        Task DeleteDepartmentAsync(int departmentId);
    }
}
