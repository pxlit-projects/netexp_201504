using Guestroom.ViewModel;

using Xamarin.Forms;

namespace Guestroom.View
{
    public partial class ListView : ContentPage
    {
        public ListView()
        {
            BindingContext = new ListViewModel();
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);


            //not working
            while (Navigation.NavigationStack.Count > 0)
                Navigation.RemovePage(Navigation.NavigationStack[0]);

        }
    }
}
