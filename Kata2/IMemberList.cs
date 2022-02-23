using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata2
{
    interface IMemberList
    {
        /// <summary>
        /// Return all dates created
        /// </summary>
        /// <returns>number of dates created</returns>
        int Count();

        /// <summary>
        /// Returns all members that joined in a specific year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        int Count(int year);

        /// <summary>
        /// Sorts the dates in year, month, day order
        /// </summary>
        void Sort();

    }
}
