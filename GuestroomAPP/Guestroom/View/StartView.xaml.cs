using Guestroom.ViewModel;

using Xamarin.Forms;

namespace Guestroom.View
{
    public partial class StartView : ContentPage
    {
        public StartView()
        {
            BindingContext = new StartViewModel();
            //BindingContext = App.Locator.Start;
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}
