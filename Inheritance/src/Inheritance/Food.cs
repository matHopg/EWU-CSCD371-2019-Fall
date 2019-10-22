using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public class Food : Item
    {
        public string Upc { get; set; }
        public string Brand { get; set; }

        public override string PrintInfo()
        {
            if(Upc is null || Upc == "")
            {
                throw new ArgumentNullException("Upc is not valid", new ArgumentNullException());
            }
            if(Brand is null || Brand == "")
            {
                throw new ArgumentNullException("Brand is not valid", new ArgumentNullException());
            }
            return $"{Upc} - {Brand}";
        }
    }
}
