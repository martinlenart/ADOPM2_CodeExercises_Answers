using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata2
{
    class Member : IMember, IComparable<Member>
    {
        public string Name { get; set; }
        public MemberLevel Level { get; set; }
        public DateTime Since { get; init; }

        public override string ToString() => $"{Name} is a {Level} member since {Since.Year}\n";

        public int CompareTo(Member other)
        {
            if (Level != other.Level)
                return Level.CompareTo(other.Level);
            if (Since != other.Since) 
                return Since.CompareTo(other.Since);

            return Name.CompareTo(other.Name);
        }

    }
}
