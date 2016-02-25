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
            var uri = new Uri(apiGuestRooms);
            var client = new HttpClient();
            var response = Task.Run(() => client.GetAsync(uri)).Result;
            response.EnsureSuccessStatusCode();
            var result = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
            return JsonConvert.DeserializeObject<List<GuestRoomJSON>>(result);
        }
    }
}
