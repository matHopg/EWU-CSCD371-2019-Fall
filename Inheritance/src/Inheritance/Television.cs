using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public class Television : Item
    {
        public string Size { get; set; }
        public string Manufacturer { get; set; }

        public override string PrintInfo()
        {
            if(Size is null || Size == "")
            {
                throw new ArgumentNullException("Size is invalid", new ArgumentNullException());
            }
            if(Manufacturer is null || Manufacturer == "")
            {
                throw new ArgumentNullException("Manufacturer is invalid", new ArgumentNullException());
            }
            return $"{Manufacturer} - {Size}";
        }
    }
}
