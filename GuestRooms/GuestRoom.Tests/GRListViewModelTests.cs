using GuestRoomWPF.Services;
using GuestRoomWPF.ViewModel;
using KamersInVlaanderen.Model;
using KamersInVlaanderen.Tests.Mock;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KamersInVlaanderen.Tests
{
    [TestClass]
    public class GRListViewModelTests
    {
        private IGRDataService gRDataService;
        private IDialogService dialogService;

        private GRListViewModel GetViewModel()
        {
            return new GRListViewModel(this.gRDataService, this.dialogService);
        }

        [TestInitialize]
        public void Init()
        {
            gRDataService = new MockGRDataService();
            dialogService = new MockDialogService();
        }

        [TestMethod]
        public void testInitializationSelectedGuestRoom()
        {
            //Arrange
            GuestRoom guestRoom = null;
            GuestRoom expectedGuestRoom = new GuestRoom();
            expectedGuestRoom.ProductDescription = GuestRoomWPF.Properties.Resources.GRListViewChoose;

            //act
            var viewModel = GetViewModel();
            guestRoom = viewModel.SelectedGuestRoom;

            //assert
            Assert.AreEqual(expectedGuestRoom.ProductDescription, guestRoom.ProductDescription);
        }
    }
}

