using Guestroom.ViewModel;

using Xamarin.Forms;

namespace Guestroom.View
{
    public partial class StartView : ContentPage
    {
        public StartView()
        {
            InitializeComponent();
            BindingContext = App.Locator.Start;
        }
    }
}
