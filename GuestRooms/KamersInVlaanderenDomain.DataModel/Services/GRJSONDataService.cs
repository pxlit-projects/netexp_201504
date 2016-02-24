using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;
using KamersInVlaanderen;


namespace KamersInVlaanderenDomain.DataModel.Services
{
    public class GRJSONDataService : IGRJSONDataService
    {
        public List<GuestRoomJSON> getAllGuestRooms()
        {
            string apiGuestRooms = "http://opendata.visitflanders.org/tourist/accommodation/guest-rooms.json?offset=0&limit=10000";
            //var uri = new Uri(String.Format("{0}?format=json", apiGuestRooms));
            var uri = new Uri(apiGuestRooms);
            var client = new HttpClient();
            var response = Task.Run(() => client.GetAsync(uri)).Result;
            response.EnsureSuccessStatusCode();
            var result = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
            //var root = JsonConvert.DeserializeObject<RootObject<GuestRoom>>(result);
            //var guestRooms = root.results;

            return JsonConvert.DeserializeObject<List<GuestRoomJSON>>(result);
        }
    }
    /*class RootObject<T>
    {
        public int count { get; set; }
        public object next { get; set; }
        public object previous { get; set; }
        public List<T> results { get; set; }
    }*/
}
