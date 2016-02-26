using GuestRoomWPF.Services;
using GuestRoomWPF.ViewModel;
using KamersInVlaanderenDomain.DataModel.Services;

namespace GuestRoomWPF
{
    public class ViewModelLocator
    {
        private static IDialogService dialogService = new DialogService();
        private static IGRDataService gRDataService = new GRDataService(new GRDisconnectedRepository());

        private static GRStartViewModel gRStartViewModel = new GRStartViewModel(gRDataService, dialogService);
        private static GRListViewModel gRListViewModel = new GRListViewModel(gRDataService, dialogService);
        private static GRDetailViewModel gRDetailViewModel = new GRDetailViewModel();
        private static GRRateViewModel gRRateViewModel = new GRRateViewModel(gRDataService);

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

        public static GRStartViewModel GRStartViewModel
        {
            get
            {
                return gRStartViewModel;
            }
        }

        public static GRRateViewModel GRRateViewModel
        {
            get
            {
                return gRRateViewModel;
            }
        }
    }
}
