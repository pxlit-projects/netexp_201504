using KamersInVlaanderen;
using System.Collections.Generic;

namespace KamersInVlaanderenDomain.DataModel.Services
{
    

    public class GRConnectedRepository: IGRConnectedRepository
    {
        private readonly KamersContext context = new KamersContext();
        private static List<GuestRoom> guestRooms;

        public GRConnectedRepository()
        {
        }
    }
}
