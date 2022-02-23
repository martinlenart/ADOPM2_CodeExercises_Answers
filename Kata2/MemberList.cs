using System;
using System.Collections.Generic;

namespace Kata2
{
    class MemberList : IMemberList
    {
        List<Member> _members = new List<Member>();

        public int Count() => _members.Count;

        public int Count(int year)
        {
            int c = 0;
            foreach (var item in _members)
            {
                if (item.Since.Year == year)
                    c++;
            }
            return c;
        }

        public void Sort() => _members.Sort();

        public override string ToString()
        {
            string sRet = "";
            for (int i = 0; i < _members.Count; i++)
            {
                sRet += $"{_members[i]}";
                if ((i + 1) % 5 == 0)
                {
                    sRet += "\n";
                }
            }
            return sRet;
        }

        public MemberList(int NrOfItems)
        {
            var rnd = new Random();
            for (int i = 0; i < NrOfItems; i++)
            {
                DateTime _memberSince;
                int year = rnd.Next(1900, DateTime.Today.Year + 1);
                int month = rnd.Next(1, 13);
                int day = rnd.Next(1, 32);
                try
                {
                    _memberSince = new DateTime(year, month, day);
                    MemberLevel _level = (MemberLevel)rnd.Next((int)MemberLevel.Platinum, (int)MemberLevel.Blue + 1);

                    string[] _names = "Fred John Mary Jane Oliver Marie".Split(' ');
                    string _name = _names[rnd.Next(0, _names.Length)];

                    _members.Add(new Member { Level = _level, Since = _memberSince, Name = _name });
                }
                catch 
                {
                    i--;
                }
            }
        }
    }
}
