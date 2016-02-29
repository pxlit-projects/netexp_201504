using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KamersInVlaanderen.Tests.Mock;
using GuestRoomWPF.ViewModel;
using GuestRoomWPF.Services;
using System.Collections.ObjectModel;
using KamersInVlaanderen.Model;
using System.Threading;

namespace KamersInVlaanderen.Tests
{
    [TestClass]
    public class GRStartViewModelTests
    {
        private IGRDataService gRDataService;
        private IDialogService dialogService;

        private GRStartViewModel GetViewModel()
        {
            return new GRStartViewModel(this.gRDataService, this.dialogService);
        }

        [TestInitialize]
        public void Init()
        {
            gRDataService = new MockGRDataService();
            dialogService = new MockDialogService();
        }

        [TestMethod]
        public void loadAllGuestRooms()
        {
            //Arrange
            ObservableCollection<GuestRoom> guestRooms = null;
            var expectedGuestRooms = gRDataService.getAllGuestRooms();

            //act
            var viewModel = GetViewModel();
            Thread.Sleep(1000); //give aync method time to complete
            guestRooms = viewModel.GuestRooms;
            //assert
            CollectionAssert.AreEqual(expectedGuestRooms, guestRooms);
        }
    }
}
