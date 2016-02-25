using GuestRoomWPF.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GuestRoomWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class GRStartView : Window
    {
        

        public GRStartView()
        {
            InitializeComponent();

            //added to close startup window
            var vm = (GRStartViewModel)this.DataContext;
            vm.RequestClose += delegate (object sender, EventArgs args) { this.Close(); };
        }

        /*private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            GRListView listWindow = new GRListView();
            listWindow.Show();
            this.Close();
        }*/
    }
}
