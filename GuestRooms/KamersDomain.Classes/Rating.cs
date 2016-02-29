namespace KamersInVlaanderen
{
    public class Rating
    {
        public int Id { get; set; }
        public GuestRoom GuestRoom { get; set; }
        public int GuestRoomId { get; set; }
        public string User { get; set; }
        public int Value { get; set; }
    }
}
