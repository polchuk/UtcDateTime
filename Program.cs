/*
    This file is part of UtcDateTime.

    UtcDateTime is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    UtcDateTime is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with UtcDateTime.  If not, see <http://www.gnu.org/licenses/>.
*/
using System;

namespace UtcDateTime
{
    class Program
    {
        static void Main(string[] args)
        {
            var utc_now = UtcDateTime.Now;
            var now = DateTime.Now;

            //if (utc_now < now) <- Compiler error because local time and utc time are not compatible
            //{
            //    //blah blah
            //}

            var utc_now2 = TimeHelper.ToUtcTime(now);

            TimeSpan diff = utc_now2 - utc_now;
            Console.WriteLine("utc_now2 - utc_now = " + diff);

            Console.WriteLine("now.TimeOfDay = " + now.TimeOfDay);
            Console.WriteLine("utc_now.LocalTimeOfDay = " + utc_now.LocalTimeOfDay);
            Console.WriteLine("((IDateTime)utc_now).TimeOfDay = " + ((IDateTime)utc_now).TimeOfDay + " //local time in Greenwich(UTC)");

            Console.ReadKey();
        }
    }
}
