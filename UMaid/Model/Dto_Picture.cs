using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Dto_Picture :Dto
    {
        public int PictureID { get; set; }
        public int UserID { get; set; }
        public Nullable<int> PropertyID { get; set; }
        public string PicturePath { get; set; }

        override public string ToString()
        {
            return string.Format("{0}, {1},{2},{3}",
                PictureID,UserID, PropertyID, PicturePath);
        }

    }
}
