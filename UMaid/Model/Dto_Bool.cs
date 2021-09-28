using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Dto_Bool : Dto
    {
        public bool success { get; set; }

        public Dto_Bool()
        {
            success = false;
        }
    }
}
