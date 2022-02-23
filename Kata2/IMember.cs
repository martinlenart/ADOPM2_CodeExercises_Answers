using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata2
{
    public enum MemberLevel { Platinum, Gold, Silver, Blue}
    interface IMember
    {
        public string Name { get; set; }
        public MemberLevel Level {get; set;}
        public DateTime Since { get; init; }
    }
}
