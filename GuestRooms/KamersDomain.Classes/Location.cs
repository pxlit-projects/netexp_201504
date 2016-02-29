using Lambert72Converter;

namespace KamersInVlaanderen
{
    public class Location
    {
        public int Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public GuestRoom GuestRoom { get; set; }
        public int GuestRoomId { get; set; }

        public LatLon getLatLon()
        {
            Lambert72 lambert72 = new Lambert72(X, Y);
            LatLon latLon = new LatLon(0, 0);
            if (X != 0 && Y != 0)
            {
                latLon = Lambert72Converter.Lambert72Converter.Lambert72_To_LatLon(lambert72);
            }
            return latLon;
        }
    }
}
