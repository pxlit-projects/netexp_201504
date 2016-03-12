using Guestroom.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Formatting;
using System.Text;

namespace Guestroom.Services
{
    public class GRDisconnectedRepository : IGRDisconnectedRepository
    {
        public GuestRoom getGuestRoom(int id)
        {
            string apiGuestRooms = Settings.APIBASEURL + "api/GuestRoomsAPI/" + id;
            var uri = new Uri(apiGuestRooms);
            var client = new HttpClient();
            var response = Task.Run(() => client.GetAsync(uri)).Result;
            response.EnsureSuccessStatusCode();
            var result = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
            return JsonConvert.DeserializeObject<GuestRoom>(result);
        }

        public List<GuestRoom> getGuestRooms()
        {
            string apiGuestRooms = Settings.APIBASEURL + "/api/GuestRoomsAPI";
            var uri = new Uri(apiGuestRooms);
            var client = new HttpClient();
            var response = Task.Run(() => client.GetAsync(uri)).Result;
            response.EnsureSuccessStatusCode();
            var result = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
            return JsonConvert.DeserializeObject<List<GuestRoom>>(result);
        }

        public void saveRating(Rating rating)
        {
            string apiRatings = Settings.APIBASEURL + "/api/RatingsAPI";
            var client = new HttpClient();
            try
            {
                //client.PostAsJsonAsync(apiRatings, rating);

                string json = JsonConvert.SerializeObject(rating);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                //HttpResponseMessage response = null;
                //response = await client.PostAsync(url, content);
                client.PostAsync(apiRatings, content);

            }
            catch (Exception e)

            {

            }
        }
    }
}
