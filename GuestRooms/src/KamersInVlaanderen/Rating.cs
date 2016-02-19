namespace KamersInVlaanderen
{
    public class Rating
    {
        public int id { get; set; }
        public GuestRoom guestroom { get; set; }
        public int guestroomId { get; set; }
        public User user { get; set; }
        public int userId { get; set; }
    }
}
