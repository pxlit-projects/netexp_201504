using GuestRoomWPF.Extensions;
using GuestRoomWPF.Services;
using GuestRoomWPF.Utility;
using KamersInVlaanderen;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace GuestRoomWPF.ViewModel
{
    public class GRStartViewModel
    {
        private IGRDataService gRDataService;
        private IDialogService dialogService;

        private ObservableCollection<GuestRoom> guestRooms;

        public GRStartViewModel(IGRDataService gRDataService, IDialogService dialogService)
        {
            this.gRDataService = gRDataService;
            this.dialogService = dialogService;

            var task = LoadData();
        }

        private async Task LoadData()
        {
            await Task.Run(() =>
            {
                guestRooms = gRDataService.getAllGuestRooms().ToObservableCollection();
            });
            ShowData();
        }

        private void ShowData()
        {
            Messenger.Default.Send<ObservableCollection<GuestRoom>>(guestRooms);
            
            dialogService.ShowListDialog();
            OnRequestClose(); //close startup window
        }


        //added to close startup window
        public event EventHandler RequestClose;

        protected void OnRequestClose()
        {
            if (RequestClose != null)
                RequestClose(this, EventArgs.Empty);
        }
    }
}
