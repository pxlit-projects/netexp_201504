using GuestRoomWPF.Utility;
using KamersInVlaanderen;
using System.ComponentModel;

namespace GuestRoomWPF.ViewModel
{
    public class GRDetailViewModel : INotifyPropertyChanged
    {
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
        public GRDetailViewModel()
        {

            Messenger.Default.Register<GuestRoom>(this, OnGuestRoomReceived);
        }

        public void OnGuestRoomReceived(GuestRoom guestRoom)
        {
            selectedGuestRoom = guestRoom;
        }
    }
}
