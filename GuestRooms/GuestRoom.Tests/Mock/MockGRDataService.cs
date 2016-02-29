using System;
using System.Collections.Generic;
using GuestRoomWPF.Services;
using KamersInVlaanderen.Model;
using KamersInVlaanderenDomain.DataModel.Services;

namespace KamersInVlaanderen.Tests.Mock
{
    public class MockGRDataService : IGRDataService
    {

        private IGRDisconnectedRepository repo = new MockGRDisconnectedRepository();
        
        public List<GuestRoom> getAllGuestRooms()
        {
            return repo.getGuestRooms();
        }

        public GuestRoom getGuestRoomDetail(int id)
        {
            throw new NotImplementedException();
        }

        public void saveRating(Rating rating)
        {
            throw new NotImplementedException();
        }
    }
}
