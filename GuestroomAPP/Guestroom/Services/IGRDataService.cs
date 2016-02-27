using Guestroom.Model;
using System.Collections.Generic;

namespace Guestroom.Services
{
    public interface IGRDataService
    {
        List<GuestRoom> getAllGuestRooms();
        GuestRoom getGuestRoomDetail(int id);
        void saveRating(Rating rating);
    }
}
