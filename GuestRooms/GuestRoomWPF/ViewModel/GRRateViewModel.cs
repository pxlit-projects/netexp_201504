using GuestRoomWPF.Services;
using GuestRoomWPF.Utility;
using KamersInVlaanderen;
using System.ComponentModel;
using System.Windows.Input;

namespace GuestRoomWPF.ViewModel
{
    public class GRRateViewModel : INotifyPropertyChanged
    {
        private IGRDataService gRDataService;
        private IDialogService dialogService;
        public ICommand RatingCommand { get; set; }
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

        private string user = "Anonymous";
        public string User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
                RaisePropertyChanged("User");
            }
        }

        private int rating = 5;
        public int Rating
        {
            get
            {
                return rating;
            }
            set
            {
                rating = value;
                RaisePropertyChanged("Rating");
            }
        }

        public GRRateViewModel(IGRDataService gRDataService, IDialogService dialogService)
        {
            this.dialogService = dialogService;
            this.gRDataService = gRDataService;
            Messenger.Default.Register<GuestRoom>(this, OnGuestRoomReceived);
            LoadCommands();
        }

        private void LoadCommands()
        {
            RatingCommand = new CustomCommand(RatingGuestRoom, CanRatingGuestRoom);
        }

        private void RatingGuestRoom(object obj)
        {
            Rating r = new Rating();
            r.User = user;
            r.GuestroomId = selectedGuestRoom.Id;
            r.Value = rating;
            gRDataService.saveRating(r);
        }

        private bool CanRatingGuestRoom(object obj)
        {
            if (SelectedGuestRoom != null)
                return true;
            return false;
        }

        public void OnGuestRoomReceived(GuestRoom guestRoom)
        {
            SelectedGuestRoom = guestRoom;
        }
    }
}
