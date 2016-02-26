using KamersInVlaanderen;
using System.Collections.ObjectModel;
using System.ComponentModel;
using GuestRoomWPF.Services;
using GuestRoomWPF.Extensions;
using System.Windows.Input;
using GuestRoomWPF.Utility;
using GuestRoomWPF.Messages;
using System;
using System.Collections.Generic;

namespace GuestRoomWPF.ViewModel
{
    public class GRListViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private IGRDataService gRDataService;
        private IDialogService dialogService;
        public ICommand DetailCommand { get; set; }
        public ICommand RateCommand { get; set; }
        public ICommand SortCommand { get; set; }

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

        private double xCoordinate;
        public double XCoordinate
        {
            get
            {
                return xCoordinate;
            }
            set
            {
                xCoordinate = value;
                RaisePropertyChanged("XCoordinate");
            }
        }

        private double yCoordinate;
        public double YCoordinate
        {
            get
            {
                return yCoordinate;
            }
            set
            {
                yCoordinate = value;
                RaisePropertyChanged("YCoordinate");
            }
        }

        public GRListViewModel(IGRDataService gRDataService, IDialogService dialogService)
        {
            this.gRDataService = gRDataService;
            this.dialogService = dialogService;
            selectedGuestRoom = new GuestRoom();
            selectedGuestRoom.ProductDescription = GuestRoomWPF.Properties.Resources.GRListViewChoose;
            Messenger.Default.Register<ObservableCollection<GuestRoom>>(this, OnGuestRoomsReceived);
            Messenger.Default.Register<UpdateListMessage>(this, OnUpdateListMessageReceived);
            LoadCommands();
            
        }

        private void OnUpdateListMessageReceived(UpdateListMessage obj)
        {
            LoadData();
            dialogService.CloseRateDialog();
        }

        private void OnGuestRoomsReceived(ObservableCollection<GuestRoom> guestRooms)
        {
            GuestRooms = guestRooms;
        }

        private void LoadData()
        {
            GuestRooms = gRDataService.getAllGuestRooms().ToObservableCollection();
        }

        private void LoadCommands()
        {
            DetailCommand = new CustomCommand(DetailGuestRoom, CanDetailGuestRoom);
            RateCommand = new CustomCommand(RateGuestRoom, CanRateGuestRoom);
            SortCommand = new CustomCommand(SortGuestRooms, CanSortGuestRooms);
        }

        private bool CanSortGuestRooms(object obj)
        {
            if (xCoordinate < 20000 || xCoordinate > 300000)
                return false;
            if (yCoordinate < 20000 || yCoordinate > 300000)
                return false;
            return true;
        }

        private void SortGuestRooms(object obj)
        {
            //double xBilzen = 230000.0;
            //double yBilzen = 170000.0;


            var notSorted = new List<GuestRoom>(guestRooms);
            foreach(GuestRoom guestroom in notSorted)
            {
                guestroom.distanceFromCoordinates = Math.Sqrt(Math.Pow((xCoordinate - guestroom.Location.X), 2.0) + Math.Pow((yCoordinate - guestroom.Location.Y),2.0));
            }
            notSorted.Sort((x, y) => x.distanceFromCoordinates.CompareTo(y.distanceFromCoordinates));
            GuestRooms = notSorted.ToObservableCollection<GuestRoom>();
        }

        private void DetailGuestRoom(object obj)
        {
            Messenger.Default.Send<GuestRoom>(selectedGuestRoom);

            dialogService.ShowDetailDialog();
        }

        private bool CanDetailGuestRoom(object obj)
        {
            if (SelectedGuestRoom != null && SelectedGuestRoom.ProductDescription != GuestRoomWPF.Properties.Resources.GRListViewChoose)
                return true;
            return false;
        }

        private void RateGuestRoom(object obj)
        {
            Messenger.Default.Send<GuestRoom>(selectedGuestRoom);
            dialogService.ShowRateDialog();
        }

        private bool CanRateGuestRoom(object obj)
        {
            if (SelectedGuestRoom != null && SelectedGuestRoom.ProductDescription != GuestRoomWPF.Properties.Resources.GRListViewChoose)
                return true;
            return false;
        }
    }
}
