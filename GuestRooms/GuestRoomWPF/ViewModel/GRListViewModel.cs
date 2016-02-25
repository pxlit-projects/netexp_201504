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
        public ICommand RateCommand { get; set; }

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

        public GRListViewModel(IGRDataService gRDataService, IDialogService dialogService)
        {
            this.gRDataService = gRDataService;
            this.dialogService = dialogService;
            
            Messenger.Default.Register<ObservableCollection<GuestRoom>>(this, OnGuestRoomsReceived);
            //LoadData();
            LoadCommands();
        }

        private void OnGuestRoomsReceived(ObservableCollection<GuestRoom> guestRooms)
        {
            GuestRooms = guestRooms;
        }

        /*private void LoadData()
        {
            GuestRooms = gRDataService.getAllGuestRooms().ToObservableCollection();
        }*/

        private void LoadCommands()
        {
            DetailCommand = new CustomCommand(DetailGuestRoom, CanDetailGuestRoom);
            RateCommand = new CustomCommand(RateGuestRoom, CanRateGuestRoom);
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

        private void RateGuestRoom(object obj)
        {
            Messenger.Default.Send<GuestRoom>(selectedGuestRoom);
            Messenger.Default.Send<IDialogService>(dialogService);
            dialogService.ShowRateDialog();
        }

        private bool CanRateGuestRoom(object obj)
        {
            if (SelectedGuestRoom != null)
                return true;
            return false;
        }
    }
}
