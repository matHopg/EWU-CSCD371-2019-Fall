using System;
namespace Mailbox
{
    public class Mailbox
    {
        public Sizes MailSize { get; set; }
        public (int one, int two) Location { get; set; }
        public Person Owner { get; set; }

        public Mailbox(Sizes mailSize, (int, int) location, Person owner)
        {
            if (mailSize == Sizes.Premium)
            {
                throw new ArgumentException("Premium is not a valid size, must be size and premium");
            }
            MailSize = mailSize;
            Location = location;
            Owner = owner;
        }
        public override string ToString()
        {
            string mailSize = $"{MailSize}";
            if (MailSize == Sizes.Default)
            {
                mailSize = "";
            }
            return $"{Owner.ToString()} owns mailbox {Location.one}, {Location.two} with size '{mailSize}'";

        }

        public override bool Equals(object obj)
        {
            if (obj is Mailbox)
            {
                return this.Equals((Mailbox)obj);
            }
            return false;
        }

        public bool Equals(Mailbox box)
        {
            return MailSize == MailSize && Location == box.Location && Owner == Owner;
        }

       
    }

}
