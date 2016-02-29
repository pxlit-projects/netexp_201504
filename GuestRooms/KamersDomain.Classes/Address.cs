namespace KamersInVlaanderen.Model
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string BoxNumber { get; set; }
        public string PostalCode { get; set; }
        public string CityName { get; set; }
        public string MainCityName { get; set; }
        public GuestRoom GuestRoom { get; set; }
        public int GuestRoomId { get; set; }
    }
}
