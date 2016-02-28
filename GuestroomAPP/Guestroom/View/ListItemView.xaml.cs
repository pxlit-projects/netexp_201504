using Guestroom.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Guestroom.View
{
    public partial class ListItemView : ContentPage
    {
        public ListItemView()
        {
            BindingContext = new ListItemViewModel();
            InitializeComponent();
            this.Title = Guestroom.Properties.Resources.AppTitle;
        }
    }
}
