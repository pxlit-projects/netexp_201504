using Guestroom.Model;
using System.Collections.Generic;

namespace Guestroom.Services
{
    public interface IGRDisconnectedRepository
    {
        List<GuestRoom> getGuestRooms();
        GuestRoom getGuestRoom(int id);
        void saveRating(Rating rating);
    }
}
