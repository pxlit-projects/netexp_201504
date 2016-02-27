using Guestroom.Model;
using Guestroom.Services;
using System.Collections.Generic;

namespace Guestroom.Services
{
    public class GRDataService: IGRDataService
    {
        IGRDisconnectedRepository repo;

        public GRDataService(IGRDisconnectedRepository repo)
        {
            this.repo = repo;
        }

        public List<GuestRoom> getAllGuestRooms()
        {
            return repo.getGuestRooms();
        }

        public GuestRoom getGuestRoomDetail(int id)
        {
            return repo.getGuestRoom(id);
        }

        public void saveRating(Rating rating)
        {
            repo.saveRating(rating);
        }
    }
}
