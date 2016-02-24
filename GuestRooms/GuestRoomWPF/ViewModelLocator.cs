using GuestRoomWPF.Services;
using GuestRoomWPF.ViewModel;
using KamersInVlaanderenDomain.DataModel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestRoomWPF
{
    public class ViewModelLocator
    {
        private static IDialogService dialogService = new DialogService();
        private static IGRDataService gRDataService = new GRDataService(new GRDisconnectedRepository());

        private static GRListViewModel gRListViewModel = new GRListViewModel(gRDataService, dialogService);
        private static GRDetailViewModel gRDetailViewModel = new GRDetailViewModel(dialogService);

        public static GRDetailViewModel GRDetailViewModel
        {
            get
            {
                return gRDetailViewModel;
            }
        }

        public static GRListViewModel GRListViewModel
        {
            get
            {
                return gRListViewModel;
            }
        }
    }
}
