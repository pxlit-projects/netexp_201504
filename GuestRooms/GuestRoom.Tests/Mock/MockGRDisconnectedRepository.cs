using System;
using System.Collections.Generic;
using KamersInVlaanderen.Model;
using KamersInVlaanderenDomain.DataModel.Services;

namespace KamersInVlaanderen.Tests.Mock
{
    public class MockGRDisconnectedRepository : IGRDisconnectedRepository
    {
        private List<GuestRoom> guestRooms;

        public MockGRDisconnectedRepository()
        {
            guestRooms = LoadMockGuestRooms();
        }

        private List<GuestRoom> LoadMockGuestRooms()
        {
            return new List<GuestRoom>()
            {
                new GuestRoom ()
                {
                    Name = "TestRoom 1",
                    ProductDescription ="TestRoom 1 Description"
                    
                    
                },
                new GuestRoom ()
                {
                    Name = "TestRoom 1",
                    ProductDescription ="TestRoom 1 Description"


                }

            };
        }


        public GuestRoom getGuestRoom(int id)
        {
            throw new NotImplementedException();
        }

        public List<GuestRoom> getGuestRooms()
        {
            return guestRooms;
        }

        public void saveRating(Rating rating)
        {
            throw new NotImplementedException();
        }
    }
}
