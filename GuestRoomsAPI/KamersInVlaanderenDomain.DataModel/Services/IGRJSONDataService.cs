using KamersInVlaanderen;
using System.Collections.Generic;

namespace KamersInVlaanderenDomain.DataModel.Services
{
    public interface IGRJSONDataService
    {
        List<GuestRoomJSON> getAllGuestRooms();
    }
}
