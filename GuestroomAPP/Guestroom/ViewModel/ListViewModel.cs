using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using Guestroom.Extensions;
using Guestroom.Model;
using Guestroom.Services;
using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Guestroom.ViewModel
{
    public class ListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
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
                NavigationService nav = (NavigationService)SimpleIoc.Default.GetInstance<INavigationService>();
                nav.NavigateTo("ListItemView");
                Messenger.Default.Send<GuestRoom>(selectedGuestRoom);
            }
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

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public ListViewModel()
        {
            GetGeoLocation();
            //SortCommand = new RelayCommand(SortGuestRooms, CanSortGuestRooms);
            Messenger.Default.Register<ObservableCollection<GuestRoom>>(this, OnGuestRoomsReceived);
            NavigationService nav = (NavigationService)SimpleIoc.Default.GetInstance<INavigationService>();
        }

        private async void GetGeoLocation()
        {
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;

                var position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);
                
                XCoordinate = position.Latitude;
                YCoordinate = position.Longitude;

                if (XCoordinate > 0 && YCoordinate > 0)
                    SortGuestRooms();
            }
            catch (Exception ex)
            {
                //TODO
            }
        }

        private void OnGuestRoomsReceived(ObservableCollection<GuestRoom> guestRooms)
        {
            GuestRooms = guestRooms;
        }

        /*public RelayCommand SortCommand { get; private set; }

        private bool CanSortGuestRooms()
        {
            if (xCoordinate == 0 || yCoordinate == 0)
                return false;
            return true;
        }*/

        private void SortGuestRooms()
        {
            //double xBilzen = 230000.0;
            //double yBilzen = 170000.0;


            var notSorted = new List<GuestRoom>(guestRooms);
            foreach (GuestRoom guestroom in notSorted)
            {
                guestroom.distanceFromCoordinates = Math.Sqrt(Math.Pow((xCoordinate - guestroom.Location.getLatLon().Lat), 2.0) + Math.Pow((yCoordinate - guestroom.Location.getLatLon().Lon), 2.0));
            }
            notSorted.Sort((x, y) => x.distanceFromCoordinates.CompareTo(y.distanceFromCoordinates));
            GuestRooms = notSorted.ToObservableCollection<GuestRoom>();
        }

    }
}
