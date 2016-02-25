using KamersInVlaanderen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestRoomWPF.Services
{
    public interface IGRDataService
    {
        List<GuestRoom> getAllGuestRooms();
        GuestRoom getGuestRoomDetail(int id);
        void saveRating(Rating rating);
    }
}
