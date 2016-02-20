using Newtonsoft.Json;

namespace KamersInVlaanderen
{
    public class GuestRoomJSON
    {
        [JsonIgnore]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "business_product_group_id")]
        public int BusinessProductGroupId { get; set; }
        [JsonProperty(PropertyName = "business_product_id")]
        public int BusinessProductId { get; set; }
        
        //public string discriminator { get; set; }
        //public System.DateTime changedTime { get; set; }
        //public int deleted { get; set; }

        //[JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        //public Address Address { get; set; }
        //public int AddressId { get; set; }
        public string Street { get; set; }
        [JsonProperty(PropertyName = "house_number")]
        public string HouseNumber { get; set; }
        [JsonProperty(PropertyName = "box_number")]
        public string BoxNumber { get; set; }
        [JsonProperty(PropertyName = "postal_code")]
        public string PostalCode { get; set; }
        [JsonProperty(PropertyName = "city_name")]
        public string CityName { get; set; }
        [JsonProperty(PropertyName = "main_city_name")]
        public string MainCityName { get; set; }

        //public Location location { get; set; }
        //public int locationId { get; set; }
        public string X { get; set; }
        public string Y { get; set; }

        //public double distance { get; set; }
        //public string promotionalRegion { get; set; }
        //public string cyclingLabel { get; set; }
        //public string greenKeyLabeled { get; set; }
        //public string accessibilityLabel { get; set; }
        //public string closingPeriod { get; set; }
        //public string nextYearClosingPeriod { get; set; }

        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        //NO DATA public string Facebook { get; set; }
        //NO DATA public string Twitter { get; set; }
        //NO DATA public string Flickr { get; set; }
        //NO DATA public string Instagram { get; set; }

        [JsonProperty(PropertyName = "product_description")]
        public string ProductDescription { get; set; }

        //public string locationType { get; set; }
        //public int airconditioning { get; set; }
        //public int balcony { get; set; }
        //public int bikesAvailable { get; set; }
        //public int extraBabyBedPossible { get; set; }
        //public int garden { get; set; }
        //public int internetConnection { get; set; }
        //public int jacuzzi { get; set; }
        //public bool noSmoking { get; set; }
        //public bool petsAllowed { get; set; }
        //public int playGround { get; set; }
        //public int sauna { get; set; }
        //public int snacks { get; set; }
        //public int solarium { get; set; }
        //public string specificChildrenFacilities { get; set; }
        //public string specificSeniorFacilities { get; set; }
        //public string swimming { get; set; }
        //public int television { get; set; }
        //public int vault { get; set; }
        //public License license { get; set; }
        //public int licenseId { get; set; }
        //public Prices prices { get; set; }
        //public int pricesId { get; set; }
        //public int parkingAvailable { get; set; }
        //public int discountChildren { get; set; }
        //public string directBookingLink { get; set; }

        [JsonProperty(PropertyName = "imagesurl")]
        public string ImageURLsString { get; set; }


    }
}
