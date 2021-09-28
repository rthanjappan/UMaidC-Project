using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Model
{
    public class Dto_Person : Dto
    {
        public int PersonID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string EmailID { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public int UserType { get; set; }
        public string Pic { get; set; }


        //public int UserID {get;set;}
        //public int UserTypeID { get; set; }
        //public string Email { get; set; }
        //public string FName { get; set; }
        //public string LName { get; set; }
        //public string Password { get; set; }
        //public string PhoneNumber { get; set; }
        //public string StreetName { get; set; }
        //public string City { get; set; }
        //public string PostalCode { get; set; }
        //public string State { get; set; }
        //public int  Pet { get; set; }//[bit] NULL
        //public string StartDate { get; set; }


        public string FullName
        {
            get
            {
                return string.Format("{0}, {1}", LName, FName);
            }
        }

        //override public string ToString()
        //{
        //    return string.Format("{0}, {1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}", 
        //       UserID,UserTypeID,Email, LName, FName,Password,PhoneNumber,StreetName,
        //       City,PostalCode,State,Pet,StartDate);
        //}
    }
}