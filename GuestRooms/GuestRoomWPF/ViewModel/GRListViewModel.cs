using KamersInVlaanderen;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System;
using GuestRoomWPF.Services;
using GuestRoomWPF.Extensions;
using System.Windows.Input;
using GuestRoomWPF.Utility;

namespace GuestRoomWPF.ViewModel
{
    public class GRListViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private IGRDataService gRDataService;
        private IDialogService dialogService;
        public ICommand DetailCommand { get; set; }

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

        private GuestRoom selectedGuestRoom;

        public GuestRoom SelectedGuestRoom
        {
            get
            {
                return selectedGuestRoom;
            }
            set
            {
                selectedGuestRoom = value;
                RaisePropertyChanged("SelectedGuestRoom");
            }
        }

        public GRListViewModel()
        {
            this.gRDataService = new GRDataService();
            this.dialogService = new DialogService();
            LoadData();
            LoadCommands();
        }

        private void LoadData()
        {
            GuestRooms = gRDataService.getAllGuestRooms().ToObservableCollection();
        }

        private void LoadCommands()
        {
            DetailCommand = new CustomCommand(DetailGuestRoom, CanDetailGuestRoom);
        }

        private void DetailGuestRoom(object obj)
        {
            Messenger.Default.Send<GuestRoom>(selectedGuestRoom);

            dialogService.ShowDetailDialog();
        }

        private bool CanDetailGuestRoom(object obj)
        {
            if (SelectedGuestRoom != null)
                return true;
            return false;
        }
    }
}
