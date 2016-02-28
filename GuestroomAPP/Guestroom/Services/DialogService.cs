using GalaSoft.MvvmLight.Views;
using System;
using System.Threading.Tasks;

namespace Guestroom.Services
{
    public class DialogService : IDialogService
    {
        /*Window gRStartView = null;
        Window gRListView = null;
        Window gRDetailView = null;
        Window gRRateView = null;

        public DialogService()
        {
        }

        public void ShowStartDialog()
        {
            gRStartView = new GRStartView();
            gRStartView.ShowDialog();
        }

        public void CloseStartDialog()
        {
            if (gRStartView != null)
                gRStartView.Close();
        }

        public void HideStartDialog()
        {
            if (gRStartView != null)
                gRStartView.Hide();
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

        public void ShowRateDialog()
        {
            gRRateView = new GRRateView();
            gRRateView.ShowDialog();
        }

        public void CloseRateDialog()
        {
            if (gRRateView != null)
                gRRateView.Close();
        }

        public void ShowListDialog()
        {
            gRListView = new GRListView();
            gRListView.ShowDialog();
        }
        public void CloseListDialog()
        {
            if (gRListView != null)
                gRListView.Close();
        }*/
        public Task ShowError(Exception error, string title, string buttonText, Action afterHideCallback)
        {
            throw new NotImplementedException();
        }

        public Task ShowError(string message, string title, string buttonText, Action afterHideCallback)
        {
            throw new NotImplementedException();
        }

        public Task ShowMessage(string message, string title)
        {
            throw new NotImplementedException();
        }

        public Task ShowMessage(string message, string title, string buttonText, Action afterHideCallback)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ShowMessage(string message, string title, string buttonConfirmText, string buttonCancelText, Action<bool> afterHideCallback)
        {
            throw new NotImplementedException();
        }

        public Task ShowMessageBox(string message, string title)
        {
            throw new NotImplementedException();
        }
    }
}
