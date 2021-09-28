using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Dto_User : Dto
    {
        public int UserID { get; set; }
        public Nullable<int> UserTypeID { get; set; }
        public string Email { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public Nullable<bool> Pet { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<double> Rating { get; set; }
        public Nullable<int> NumOfRatings { get; set; }


        public string FullName
        {
            get
            {
                return string.Format("{0}, {1}", LName, FName);
            }
        }

        override public string ToString()
        {
            return string.Format("{0}, {1},{2},{3},{4},{5},{6}," +
                "{7},{8},{9},{10},{11},{12},{13},{14}",
                UserID, UserTypeID, Email, LName, FName,
                Password, PhoneNumber, StreetName,
                City, PostalCode, State, Pet, StartDate,Rating,NumOfRatings);
        }
    }
}
