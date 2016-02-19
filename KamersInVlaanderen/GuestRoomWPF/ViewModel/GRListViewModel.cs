using KamersInVlaanderen;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System;
using KamersWPF.Services;
using GuestRoomWPF.Extensions;

namespace GuestRoomWPF.ViewModel
{
    public class GRListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private IGRDataService gRDataService;

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

        public GRListViewModel()
        {
            loadData();
        }

        private void loadData()
        {
            GuestRooms = gRDataService.getAllGuestRooms().ToObservableCollection();
        }
    }
}
