using KamersInVlaanderen;
using GuestRoomWPF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GuestRoomWPF
{
    /// <summary>
    /// Interaction logic for ListWindow.xaml
    /// </summary>
    public partial class GRListView : Window
    {

        public GRListView()
        {
            InitializeComponent();
            //loadData();
        }

        /*private void loadData()
        {
            IGRDataService guestRoomDataService = new GRDataService();
            guestRooms = guestRoomDataService.getAllGuestRooms();
            guestRoomListView.ItemsSource = guestRooms;
        }

        private void buttonDetail_Click(object sender, RoutedEventArgs e)
        {
            DetailsWindow detailsWindow = new DetailsWindow();
            detailsWindow.selectedGuestRoom = selectedGuestRoom;
            detailsWindow.Show();
            this.Close();
        }

        private void guestRoomListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedGuestRoom = e.AddedItems[0] as GuestRoom;

            if (e != null)
            {

                textBlockGRName.Text = selectedGuestRoom.Name;

                /*BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.UriSource = new Uri("/JoeCoffeeStore.StockManagement.App;component/Images/coffee" + selectedCoffee.CoffeeId + ".jpg", UriKind.Relative);
                img.EndInit();
                CoffeeImage.Source = img;*/
            /*}
        }*/
    }
}
