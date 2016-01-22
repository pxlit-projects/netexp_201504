namespace KamersInVlaanderen
{
    public class GuestRoom
    {
        public int id { get; set; }
        public int businessProductGroupId { get; set; }
        public int businessProductId { get; set; }
        public string discriminator { get; set; }
        public System.DateTime changedTime { get; set; }
        public int deleted { get; set; }
        public string name { get; set; }
        public Address address { get; set; }
        public int addressId { get; set; }
        public Location location { get; set; }
        public int locationId { get; set; }
        public double distance { get; set; }
        public string promotionalRegion { get; set; }
        public string cyclingLabel { get; set; }
        public string greenKeyLabeled { get; set; }
        public string accessibilityLabel { get; set; }
        public string closingPeriod { get; set; }
        public string nextYearClosingPeriod { get; set; }
        public string phone { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public string website { get; set; }
        public string facebook { get; set; }
        public string twitter { get; set; }
        public string flickr { get; set; }
        public string instagram { get; set; }
        public string productDescription { get; set; }
        public string locationType { get; set; }
        public int airconditioning { get; set; }
        public int balcony { get; set; }
        public int bikesAvailable { get; set; }
        public int extraBabyBedPossible { get; set; }
        public int garden { get; set; }
        public int internetConnection { get; set; }
        public int jacuzzi { get; set; }
        public bool noSmoking { get; set; }
        public bool petsAllowed { get; set; }
        public int playGround { get; set; }
        public int sauna { get; set; }
        public int snacks { get; set; }
        public int solarium { get; set; }
        public string specificChildrenFacilities { get; set; }
        public string specificSeniorFacilities { get; set; }
        public string swimming { get; set; }
        public int television { get; set; }
        public int vault { get; set; }
        public License license { get; set; }
        public int licenseId { get; set; }
        public Prices prices { get; set; }
        public int pricesId { get; set; }
        public int parkingAvailable { get; set; }
        public int discountChildren { get; set; }
        public string directBookingLink { get; set; }
        public string imageURL { get; set; }


    }
}
