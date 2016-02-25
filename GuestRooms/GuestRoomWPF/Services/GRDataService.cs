using KamersInVlaanderenDomain.DataModel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KamersInVlaanderen;

namespace GuestRoomWPF.Services
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
