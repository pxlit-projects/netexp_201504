using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using Guestroom.Model;
using Guestroom.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guestroom.ViewModel
{
    public class ListItemViewModel : INotifyPropertyChanged
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
            }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public ListItemViewModel()
        {
            DetailCommand = new RelayCommand(DisplayDetails, CanDisplayDetails);
            RateCommand = new RelayCommand(Rate, CanRate);
            Messenger.Default.Register<GuestRoom>(this, OnSelectedGuestRoomsReceived);
            NavigationService nav = (NavigationService)SimpleIoc.Default.GetInstance<INavigationService>();
        }

        private void OnSelectedGuestRoomsReceived(GuestRoom guestRoom)
        {
            SelectedGuestRoom = guestRoom;
        }

        public RelayCommand DetailCommand { get; private set; }

        private void DisplayDetails()
        {
            NavigationService nav = (NavigationService)SimpleIoc.Default.GetInstance<INavigationService>();
            nav.NavigateTo("DetailView");
            Messenger.Default.Send<GuestRoom>(selectedGuestRoom);
        }

        private bool CanDisplayDetails()
        {
            return true;
        }

        public RelayCommand RateCommand { get; private set; }

        private void Rate()
        {
            NavigationService nav = (NavigationService)SimpleIoc.Default.GetInstance<INavigationService>();
            nav.NavigateTo("RateView");
            Messenger.Default.Send<GuestRoom>(selectedGuestRoom);
        }

        private bool CanRate()
        {
            return true;
        }
    }
}
