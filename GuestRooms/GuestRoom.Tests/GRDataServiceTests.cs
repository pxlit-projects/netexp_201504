using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KamersInVlaanderenDomain.DataModel.Services;
using KamersInVlaanderen.Tests.Mock;
using GuestRoomWPF.Services;

namespace KamersInVlaanderen.Tests
{
    [TestClass]
    public class GRDataServiceTests
    {

        private IGRDisconnectedRepository repo;


        [TestInitialize]
        public void Init()
        {
            repo = new MockGRDisconnectedRepository();
        }

        [TestMethod]
        public void GetGuestRoomsTest()
        {
            //arrange
            var service = new GRDataService(repo);

            //act
            var guestrooms = service.getAllGuestRooms();

            //assert
            Assert.IsNotNull(guestrooms);

        }
    }
}
