using GuestRoomWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestRoomWPF.Services
{
    public interface IDialogService
    {
        void ShowStartDialog();
        void CloseStartDialog();
        void CloseDetailDialog();
        void ShowDetailDialog();
        void CloseRateDialog();
        void ShowRateDialog();
        void ShowListDialog();
    }
}
