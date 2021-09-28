using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Dto_Transaction : Dto
    {
        public int transactionID { get; set; }
        public int userID { get; set; }
        public int listingID { get; set; }
        public int bidID { get; set; }
        public double maidRating { get; set; }
        public double customerRating { get; set; }
    }
}
