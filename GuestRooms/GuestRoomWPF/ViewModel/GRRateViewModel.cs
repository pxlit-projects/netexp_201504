using GuestRoomWPF.Services;
using GuestRoomWPF.Utility;
using KamersInVlaanderen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestRoomWPF.ViewModel
{
    class GRRateViewModel : INotifyPropertyChanged
    {
        private IDialogService dialogService;

        public event PropertyChangedEventHandler PropertyChanged;


        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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

        public GRRateViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;

            Messenger.Default.Register<GuestRoom>(this, OnGuestRoomReceived);
        }

        public void OnGuestRoomReceived(GuestRoom guestRoom)
        {
            SelectedGuestRoom = guestRoom;
        }
    }
}
