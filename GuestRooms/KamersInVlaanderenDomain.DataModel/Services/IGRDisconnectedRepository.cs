using KamersInVlaanderen.Model;
using System.Collections.Generic;

namespace KamersInVlaanderenDomain.DataModel.Services
{
    public interface IGRDisconnectedRepository
    {
        List<GuestRoom> getGuestRooms();
        GuestRoom getGuestRoom(int id);
        void saveRating(Rating rating);
    }
}
