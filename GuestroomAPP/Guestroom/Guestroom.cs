using Guestroom.Model;
using Guestroom.Services;
using Guestroom.View;
using Guestroom.ViewModel;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Guestroom
{
	public class App : Application
	{
        public App()
        {
            // The root page of your application
            /*IGRDisconnectedRepository repo = new GRDisconnectedRepository();
            IGRDataService gRDataService = new GRDataService(repo);

            List<GuestRoom> guestRooms = gRDataService.getAllGuestRooms();
            GuestRoom guestRoom = guestRooms.ToArray()[0];
            MainPage = new ContentPage {
                Content = new StackLayout {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        new Label {
                            XAlign = TextAlignment.Center,
                            Text = guestRoom.Name//"Welcome to Xamarin Forms!"
						}
					}
				}
			};*/
            MainPage = new StartView();
        }


        private static ViewModelLocator locator;

        public static ViewModelLocator Locator
        {
            get
            {
                return locator ?? (locator = new ViewModelLocator());
            }
        }


        /*public static Page GetMainPage()
        {
            return new NavigationPage(new StartView());
        }*/
    }
}




/* }

 protected override void OnStart ()
 {
     // Handle when your app starts
 }

 protected override void OnSleep ()
 {
     // Handle when your app sleeps
 }

 protected override void OnResume ()
 {
     // Handle when your app resumes
 }
}
}*/

