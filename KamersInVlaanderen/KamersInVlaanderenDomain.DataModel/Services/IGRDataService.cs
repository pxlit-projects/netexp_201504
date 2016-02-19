using KamersInVlaanderen;
using System.Collections.Generic;

namespace KamersInVlaanderenDomain.DataModel.Services
{
    interface IGRDataService
    {
        List<GuestRoomJSON> getAllGuestRooms();
    }
}
