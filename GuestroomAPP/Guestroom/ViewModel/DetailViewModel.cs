using GalaSoft.MvvmLight.Messaging;
using Guestroom.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guestroom.ViewModel
{
    public class DetailViewModel : INotifyPropertyChanged
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

        public DetailViewModel()
        {
            Messenger.Default.Register<GuestRoom>(this, OnSelectedGuestRoomsReceived);
        }

        private void OnSelectedGuestRoomsReceived(GuestRoom guestRoom)
        {
            SelectedGuestRoom = guestRoom;
        }
    }
}
