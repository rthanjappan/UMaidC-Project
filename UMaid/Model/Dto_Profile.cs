using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Add namespace??

namespace Model
{
    public class Dto_Profile : Dto
    { 
        public int ProfileID { get; set; }
        public int UserID { get; set; }
        public int PictureID { get; set; }
        public int AccountNumber { get; set; }
        public double AvgRating { get; set; }
        public string Bio { get; set; }

        public string PicturePath { get; set; }


        override public string ToString()
        {
            return string.Format("{0}, {1},{2},{3},{4},{5},{6}",
                ProfileID,UserID, PictureID,
                AccountNumber, AvgRating, Bio,
                PicturePath);
        }
    }
}