using Microsoft.VisualStudio.TestTools.UnitTesting;
using GuestRoomWPF.ViewModel;
using GuestRoomWPF.Services;
using KamersInVlaanderen.Tests.Mock;
using KamersInVlaanderen.Model;
using GuestRoomWPF.Utility;

namespace KamersInVlaanderen.Tests
{
    [TestClass]
    public class GRRateViewModelTests
    {
        private IGRDataService gRDataService;
        private IDialogService dialogService;

        private GRRateViewModel GetViewModel()
        {
            return new GRRateViewModel(gRDataService, dialogService);
        }

        [TestInitialize]
        public void Init()
        {
            gRDataService = new MockGRDataService();
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

