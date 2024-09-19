using MedicalStaff.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalStaff.Application.Interfaces
{
    public interface IRoomRepository : ICommonRepository<Room>
    {
        Task<IEnumerable<Room>> DisplayAvailableRoomsAsync(string depertment);
        Task AddRoomAsync(Room room);
        Task UpdateRoomAsync(Room room);
        Task DeleteRoomAsync(int roomId);



    }
}
