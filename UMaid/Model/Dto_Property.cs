using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Dto_Property : Dto
    {
        public int PropertyID { get; set; }
        public int UserID { get; set; }
        public bool isVacant { get; set; }
        public bool hasPets { get; set; }
        public int size { get; set; }
        public int numBeds { get; set; }
        public int numBaths { get; set; }
        public string desc { get; set; }
        public List<string> photos { get; set; }
        public double priceLight { get; set; }
        public double priceMedium { get; set; }
        public double priceHeavy { get; set; }
        public Dto_Address Address { get; set; }

        public static double getAverage(List<double> priceList)
        {
            if (priceList.Count == 0)
            {
                return 0;
            }
            else
            {
                double avg = 0;
                foreach (int p in priceList)
                {
                    avg += p;
                }
                return avg / priceList.Count;
            }
        }
    }
}
