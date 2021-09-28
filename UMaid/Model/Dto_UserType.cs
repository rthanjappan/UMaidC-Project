using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Dto_UserType: Dto
    {
        public int UserTypeID { get; set; }
        public string UserTypeDescription { get; set; }

        override public string ToString()
        {
            return string.Format("{0}, {1}",
                UserTypeID, UserTypeDescription);
        }
    }
}
