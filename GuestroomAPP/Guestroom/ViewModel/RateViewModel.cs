using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using Guestroom.Model;
using Guestroom.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guestroom.ViewModel
{
    public class RateViewModel : INotifyPropertyChanged //TODO REMOVE TESTING DATA
    {
        private IGRDisconnectedRepository repo;
        private IGRDataService gRDataService;
        //private IDialogService dialogService;

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

        private string user = Guestroom.Properties.Resources.DefaultUser;
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
        public RelayCommand RatingCommand { get; private set; }
        private void RatingGuestRoom()
        {
            Rating r = new Rating();
            r.User = user;
            r.GuestroomId = SelectedGuestRoom.Id;
            r.Value = rating;
            SelectedGuestRoom.Ratings.Add(r);

            //try
            //{
                gRDataService.saveRating(r);
            /*}
            catch (Exception e)
            {
                //TODO
            }*/
            //Messenger.Default.Send<UpdateListMessage>(new UpdateListMessage());


            NavigationService nav = (NavigationService)SimpleIoc.Default.GetInstance<INavigationService>();
            nav.GoBack();
        }


        private bool CanRatingGuestRoom()
        {
            return true;
            /*if (selectedGuestRoom != null)
                return true;
            return false;*/
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public RateViewModel()//IGRDataService gRDataService, IDialogService dialogService)
        {
            repo = new GRDisconnectedRepository();
            gRDataService = new GRDataService(repo);
            RatingCommand = new RelayCommand(RatingGuestRoom, CanRatingGuestRoom);
            Messenger.Default.Register<GuestRoom>(this, OnSelectedGuestRoomsReceived);
        }

        private void OnSelectedGuestRoomsReceived(GuestRoom guestRoom)
        {
            SelectedGuestRoom = guestRoom;
        }
    }
}
