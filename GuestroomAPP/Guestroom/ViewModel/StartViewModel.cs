using GalaSoft.MvvmLight.Messaging;
using Guestroom.Extensions;
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
    public class StartViewModel : INotifyPropertyChanged
    {
        private IGRDataService gRDataService;
        //private IDialogService dialogService;
        

        private ObservableCollection<GuestRoom> guestRooms;

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

        public StartViewModel()//IGRDataService gRDataService, IDialogService dialogService)
        {
            SelectedGuestRoom = new GuestRoom();
            SelectedGuestRoom.Name = "testing binding";

            IGRDisconnectedRepository repo = new GRDisconnectedRepository();// TODO remove this line after proper mvvm
            this.gRDataService = new GRDataService(repo);//gRDataService;
            //this.dialogService = dialogService;

            var task = LoadData();
        }

        private async Task LoadData()
        {
            await Task.Run(() =>
            {
                guestRooms = gRDataService.getAllGuestRooms().ToObservableCollection();
            });
            ShowData();
        }

        private void ShowData()
        {
            //Testing
            SelectedGuestRoom = guestRooms.ToArray()[0];

            Messenger.Default.Send<ObservableCollection<GuestRoom>>(guestRooms);
            //Messenger.Default.Send<IDialogService>(dialogService);
            //dialogService.ShowListDialog();
            //dialogService.HideStartDialog();
            OnRequestClose(); //close startup window

        }


        //added to close startup window
        public event EventHandler RequestClose;

        protected void OnRequestClose()
        {
            if (RequestClose != null)
                RequestClose(this, EventArgs.Empty);
        }
    }
}
