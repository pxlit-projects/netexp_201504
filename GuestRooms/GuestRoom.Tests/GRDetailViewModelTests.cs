using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GuestRoomWPF.ViewModel;
using GuestRoomWPF.Utility;
using KamersInVlaanderen.Model;

namespace KamersInVlaanderen.Tests
{
    [TestClass]
    public class GRDetailViewModelTests
    {
        private GRDetailViewModel GetViewModel()
        {
            return new GRDetailViewModel();
        }

        [TestInitialize]
        public void Init()
        {
           
        }

        [TestMethod]
        public void TestMessenger()
        {
            //Arrange
            GuestRoom guestRoom = null;
            GuestRoom expectedGuestRoom = new GuestRoom();

            //act
            var viewModel = GetViewModel();
            Messenger.Default.Send<GuestRoom>(expectedGuestRoom);
            guestRoom = viewModel.SelectedGuestRoom;

            //assert
            Assert.AreEqual(expectedGuestRoom, guestRoom);
        }
    }
}

