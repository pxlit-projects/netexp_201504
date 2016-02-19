﻿using KamersInVlaanderen;
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

namespace KamersWPF
{
    /// <summary>
    /// Interaction logic for DetailsWindow.xaml
    /// </summary>
    public partial class DetailsWindow : Window
    {
        public GuestRoom selectedGuestRoom;

        public DetailsWindow()
        {
            InitializeComponent();
            this.Loaded += GuestRoomDetailView_Loaded;
        }

        void GuestRoomDetailView_Loaded(object sender, RoutedEventArgs e)
        {
            //LoadData();
            this.DataContext = selectedGuestRoom;
        }

        //private void LoadData()
        //{
        //    CoffeeNameLabel.Content = SelectedCoffee.CoffeeName;
        //    CoffeeIdTextBox.Text = SelectedCoffee.CoffeeId.ToString();
        //    CoffeeDescriptionTextBox.Text = SelectedCoffee.Description;
        //    CoffeePriceTextBox.Text = SelectedCoffee.Price.ToString();
        //    StockAmountTextBox.Text = SelectedCoffee.AmountInStock.ToString();
        //    FirstTimeAddedTextBox.Text = SelectedCoffee.FirstAddedToStockDate.ToShortDateString();
        //    if (SelectedCoffee is SuperiorCoffee)
        //        ExtraDescriptionTextBox.Text = (SelectedCoffee as SuperiorCoffee).ExtraDescription;
        //    else
        //        ExtraDescriptionTextBox.Text = "NA";

        //    BitmapImage img = new BitmapImage();
        //    img.BeginInit();
        //    img.UriSource = new Uri("/JoeCoffeeStore.StockManagement.App;component/Images/coffee" + SelectedCoffee.CoffeeId + ".jpg", UriKind.Relative);
        //    img.EndInit();
        //    CoffeeImage.Source = img;
        //}

        private void buttonFont_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
