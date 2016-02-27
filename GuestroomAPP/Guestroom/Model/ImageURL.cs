namespace Guestroom.Model
{
    public class ImageURL
    {
        public int Id { get; set; }
        public string URL { get; set; }
        // virtual gives error at azure ap
        //public virtual GuestRoom GuestRoom { get; set; }
       // public GuestRoom GuestRoom { get; set; }
        public int GuestRoomId { get; set; }
    }
}
