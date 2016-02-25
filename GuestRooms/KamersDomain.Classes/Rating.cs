namespace KamersInVlaanderen
{
    public class Rating
    {
        public int Id { get; set; }
        //public GuestRoom guestroom { get; set; }
        public int GuestroomId { get; set; }
        public string User { get; set; }
        public int Value { get; set; }
    }
}
