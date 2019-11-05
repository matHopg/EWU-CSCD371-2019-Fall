using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Mailbox
{
    [DataContract]
    public struct Person : IEquatable<Person>
    {
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]

        public string LastName { get; set; }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            return Equals(obj as Person?);
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
        public bool Equals([AllowNull] Person other)
        {
            return FirstName == other.FirstName && LastName == other.LastName;
        }

        public static bool operator ==(Person one, Person two)
        {
            if (ReferenceEquals(one, two))
            {
                return true;
            }
            if (ReferenceEquals(one, null))
            {
                return false;
            }
            return one.Equals(two);
        }
        public static bool operator !=(Person one, Person two) => (one == two);

        
    }
}