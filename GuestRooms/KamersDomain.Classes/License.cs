namespace KamersInVlaanderen.Model
{
    public class License
    {
        public int id { get; set; }
        public string licenceComfortClass { get; set; }
        public string licenceStatus { get; set; }
        public System.DateTime licenceLastStatusChangeDate { get; set; }
        public int licenseTotalNumberOfRooms { get; set; }
        public int licenseNumberOfRoomsWithBathShowerAndToilet { get; set; }
        public int licenseMaximumNumberOfPersonsInLargestRoom { get; set; }
        public int licenseMaximumNumberOfPersonsInAllRooms { get; set; }
    }
}
