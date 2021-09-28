using System;
using System.Collections.Generic;
using System.Device.Location;

namespace Model
{
    public class Dto_Listing : Dto
    {
        public int propertyID { get; set; }
        public int cleaningLevelID { get; set; }
        public int listingID { get; set; }
        public int userID { get; set; }
        public DateTime listingStartTime { get; set; }
        public DateTime listingExpiryTime { get; set; }
        public string additionalInfo { get; set; }
        public bool isLive { get; set; }
        public GeoCoordinate location { get; set; }

        public string ListingInfo
        {
            get { return string.Format("{0},{1}", propertyID, listingID); }
        }

        public void setLocation(GeoCoordinate obj)
        {
            location = new GeoCoordinate(obj.Latitude, obj.Longitude);
        }

    }
}