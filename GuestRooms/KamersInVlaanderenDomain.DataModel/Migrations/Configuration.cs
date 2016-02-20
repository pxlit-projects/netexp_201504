namespace KamersInVlaanderenDomain.DataModel.Migrations
{
    using KamersInVlaanderen;
    using Services;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Diagnostics;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<KamersInVlaanderenDomain.DataModel.KamersContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(KamersInVlaanderenDomain.DataModel.KamersContext context)
        {
            /*context.GuestRooms.AddOrUpdate(g => g.Name,
                new GuestRoom { Name = "B&B01" },
                new GuestRoom { Name = "B&B02" }
            );*/

            // use second instance of visual studio to debug seed method
            /*if (!System.Diagnostics.Debugger.IsAttached)
                System.Diagnostics.Debugger.Launch();*/

            GRJSONDataService dataService = new GRJSONDataService();

            List<GuestRoomJSON> guestRooms = dataService.getAllGuestRooms();
            foreach (GuestRoomJSON guestRoomJSON in guestRooms)
            {
                GuestRoom guestRoom = new GuestRoom();
                guestRoom.Name = guestRoomJSON.Name;
                guestRoom.BusinessProductGroupId = guestRoomJSON.BusinessProductGroupId;
                guestRoom.BusinessProductId = guestRoomJSON.BusinessProductId;

                guestRoom.Phone = guestRoomJSON.Phone;
                guestRoom.Mobile = guestRoomJSON.Mobile;
                guestRoom.Email = guestRoomJSON.Email;
                guestRoom.Website = guestRoomJSON.Website;

                Address address = new Address();
                address.Street = guestRoomJSON.Street;
                address.HouseNumber = guestRoomJSON.HouseNumber;
                address.BoxNumber = guestRoomJSON.BoxNumber;
                address.PostalCode = guestRoomJSON.PostalCode;
                address.CityName = guestRoomJSON.CityName;
                address.MainCityName = guestRoomJSON.MainCityName;

                guestRoom.Address = address;

                Location location = new Location();
                if (guestRoomJSON.X != "" || guestRoomJSON.Y != "")
                {
                    location.X = Convert.ToDouble(guestRoomJSON.X);
                    location.Y = Convert.ToDouble(guestRoomJSON.Y);
                }
                else
                {
                    location.X = 0.0;
                    location.Y = 0.0;
                }
                guestRoom.Location = location;

                guestRoom.ProductDescription = guestRoomJSON.ProductDescription;

                List<ImageURL> imageUrls = new List<ImageURL>();
                if (guestRoomJSON.ImageURLsString != "")
                {
                    string s = guestRoomJSON.ImageURLsString;
                    string sub = s.Substring(0, s.Length - 1);
                    var urlsStrings = sub.Split(',').ToList<string>();
                    foreach (string str in urlsStrings)
                    {
                        ImageURL imageURL = new ImageURL();
                        imageURL.URL = str;
                        imageUrls.Add(imageURL);
                    }
                }
                //guestRoom.ImageURLs = imageUrls;


                context.GuestRooms.AddOrUpdate(
                         g => g.BusinessProductGroupId, guestRoom);

                imageUrls.ForEach(i => context.ImageURLs.Add(i));
                context.SaveChanges();
                imageUrls.ForEach(i => guestRoom.ImageURLs.Add(i));
                context.SaveChanges();

            }
        }
    }
}

