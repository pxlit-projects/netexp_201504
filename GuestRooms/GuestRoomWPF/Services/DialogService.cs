using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GuestRoomWPF.Services
{
    public class DialogService : IDialogService
    {

        Window gRDetailView = null;

        public DialogService()
        {
        }

        public void ShowDetailDialog()
        {
            gRDetailView = new GRDetailView();
            gRDetailView.ShowDialog();
        }

        public void CloseDetailDialog()
        {
            if (gRDetailView != null)
                gRDetailView.Close();
        }
    }
}
