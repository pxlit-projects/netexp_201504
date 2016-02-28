using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using Guestroom.Extensions;
using Guestroom.Model;
using Guestroom.Services;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Guestroom.ViewModel
{
    public class StartViewModel
    {
        private IGRDataService gRDataService;

        private ObservableCollection<GuestRoom> guestRooms;

        public StartViewModel()//IGRDataService gRDataService, IDialogService dialogService)
        {
            
            IGRDisconnectedRepository repo = new GRDisconnectedRepository();// TODO 
            this.gRDataService = new GRDataService(repo);//gRDataService;

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
            NavigationService nav = (NavigationService)SimpleIoc.Default.GetInstance<INavigationService>();
            nav.NavigateTo("ListView");
            Messenger.Default.Send<ObservableCollection<GuestRoom>>(guestRooms);
        }
    }
}
