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

namespace Utils
{
    class Program
    {
        static void Main(string[] args)
        {
            var utc_now = UtcDateTime.Now;
            var now = DateTime.Now;

            //utc_now = now;  <- Error: Cannot implicitly convert type 'System.DateTime' to 'UtcDateTime.UtcDateTime'
            //                   UTC time and local time will be never mixed up!

            var utc_now2 = TimeHelper.ToUtcTime(now);

            TimeSpan diff = utc_now2 - utc_now;
            Console.WriteLine("utc_now2 - utc_now = " + diff);

            Console.WriteLine("now.TimeOfDay = " + now.TimeOfDay);
            Console.WriteLine("utc_now.LocalTimeOfDay = " + utc_now.LocalTimeOfDay);
            Console.WriteLine("((IDateTime)utc_now).TimeOfDay = " + ((IDateTime)utc_now).TimeOfDay + " //(UTC) Coordinated Universal Time");

            Console.WriteLine();

            TimeHelper.SetThreadTimeZone("Tokyo Standard Time");
            Console.WriteLine("Time in Tokyo = " + utc_now.LocalTimeOfDay);

            TimeHelper.SetThreadTimeZone("GMT Standard Time");
            Console.WriteLine("Time in London = " + utc_now.LocalTimeOfDay);

            TimeHelper.SetThreadTimeZone("Eastern Standard Time");
            Console.WriteLine("Time in New York = " + utc_now.LocalTimeOfDay);

            Console.ReadKey();
        }
    }
}
