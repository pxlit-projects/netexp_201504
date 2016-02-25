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
    public class GRStartViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private IGRDataService gRDataService;
        private IDialogService dialogService;

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

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
                RaisePropertyChanged("GuestRooms");
            }
        }

        public GRStartViewModel(IGRDataService gRDataService, IDialogService dialogService)
        {
            this.gRDataService = gRDataService;
            this.dialogService = dialogService;

            LoadData();
        }

        private async Task LoadData()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(5000);// testing double view startup problem
                GuestRooms = gRDataService.getAllGuestRooms().ToObservableCollection();
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
