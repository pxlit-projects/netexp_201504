using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KamersInVlaanderen;
using System.Net.Http;
using Newtonsoft.Json;

namespace KamersInVlaanderenDomain.DataModel.Services
{
    public class GRDisconnectedRepository : IGRDisconnectedRepository
    {
        public GuestRoom getGuestRoom(int id)
        {
            string apiGuestRooms = Settings.APIBASEURL + "api/GuestRoomsAPI/" + id;
            //var uri = new Uri(String.Format("{0}?format=json", apiGuestRooms));
            var uri = new Uri(apiGuestRooms);
            var client = new HttpClient();
            var response = Task.Run(() => client.GetAsync(uri)).Result;
            response.EnsureSuccessStatusCode();
            var result = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
            //var root = JsonConvert.DeserializeObject<RootObject<GuestRoom>>(result);
            //var guestRooms = root.results;

            return JsonConvert.DeserializeObject<GuestRoom>(result);
        }

        public List<GuestRoom> getGuestRooms()
        {
            string apiGuestRooms = Settings.APIBASEURL + "/api/GuestRoomsAPI";
            //var uri = new Uri(String.Format("{0}?format=json", apiGuestRooms));
            var uri = new Uri(apiGuestRooms);
            var client = new HttpClient();
            var response = Task.Run(() => client.GetAsync(uri)).Result;
            response.EnsureSuccessStatusCode();
            var result = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
            //var root = JsonConvert.DeserializeObject<RootObject<GuestRoom>>(result);
            //var guestRooms = root.results;

            return JsonConvert.DeserializeObject<List<GuestRoom>>(result);
        }
    }
}
