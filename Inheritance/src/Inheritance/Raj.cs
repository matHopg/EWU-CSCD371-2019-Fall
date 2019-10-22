using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public class Raj : Actor
    {
        public bool WomenArePresent { get; set; }
        public string SpeakWithWomenPresent()
        {
            return "Raj: mumble";
        }

        public string SpeakWithoutWomenPresent()
        {
            return "Raj: Shouldn't we be inheriting from characters instead of actors since we are the characters not the actors.";
        }
    }
}
