using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Oef1_ResponsiveUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var context = TaskScheduler.FromCurrentSynchronizationContext();
            Task update = Task.Run(() => { //more eff than Task.Factory.StartNew (or new Task() & t.start())
                for (int i = 0; i < 101; i++)
                {
                    
                    /*Task t2 = new Task(() => {
                        textBlock.Text = i.ToString();
                        progressBar.Value = i;
                    });
                    t2.Start(context);*/

                    Dispatcher.Invoke(() =>
                    {
                        textBlock.Text = i.ToString();
                        progressBar.Value = i;
                    });

                    Thread.Sleep(100);
                }
            });
            MessageBox.Show("Called after async process started.", "", MessageBoxButton.OK);

            

            /*for (int i = 1; i < 101; i++)
            {
                Task t = Task.Run(() =>
                {
                    Thread.Sleep(i*1000);
                });
                Task t2 = t.ContinueWith((antecedent) => updateUI(i), TaskScheduler.FromCurrentSynchronizationContext());

                // Task.Factory.StartNew( () => {} ); // Task.Run...
                
            }*/
        }
    }
}
