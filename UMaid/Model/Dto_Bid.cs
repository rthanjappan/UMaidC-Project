using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Dto_Bid : Dto
    {
        public int BidID { get; set; }
        public int ListingID { get; set; }
        public int UserID { get; set; }
        public double BidPrice { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime BidExpires { get; set; }
        public bool IsValid { get; set; }
        public int IsAccepted { get; set; }
        public string allBidValues
        {
            get
            {
                string status;

                if (IsAccepted == 1)
                {
                    status = "Accepted";
                }
                else
                {
                    status = "Pending property owner's response";
                }

                string s = "Bid Id: {0}\nListing Id: {1}\nBid price: {2}\nTime bid was placed: " +
                    "{3}\nTime bid expires: {4}\nStatus of bid: {5}\n\n";
                return string.Format(s, BidID, ListingID, BidPrice, StartTime.ToString(), BidExpires.ToString(), status);
            }
        }
    }
}  
