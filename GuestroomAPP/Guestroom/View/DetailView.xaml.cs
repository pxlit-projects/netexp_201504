using Guestroom.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Guestroom.View
{
    public partial class DetailView : ContentPage
    {
        public DetailView()
        {
            BindingContext = new DetailViewModel();
            InitializeComponent();
            this.Title = Guestroom.Properties.Resources.AppTitle;
        }
    }
}
