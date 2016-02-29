using GuestRoomWPF.Extensions;
using GuestRoomWPF.Services;
using GuestRoomWPF.Utility;
using KamersInVlaanderen.Model;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace GuestRoomWPF.ViewModel
{
    public class GRStartViewModel
    {
        private IGRDataService gRDataService;
        private IDialogService dialogService;

        private ObservableCollection<GuestRoom> guestRooms;
        public ObservableCollection<GuestRoom> GuestRooms
        { 
            get
            {
                return guestRooms;
            }
            set
            {
                guestRooms = value;
            }
        }
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
                GuestRooms = gRDataService.getAllGuestRooms().ToObservableCollection();
            });
            ShowData();
        }

        private void ShowData()
        {
            Messenger.Default.Send<ObservableCollection<GuestRoom>>(guestRooms);
            Messenger.Default.Send<IDialogService>(dialogService);
            dialogService.ShowListDialog();
            dialogService.HideStartDialog();
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
