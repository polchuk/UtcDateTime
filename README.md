UtcDateTime
===========

This class helps to work with UTC time in .NET applications.

Use UtcDateTime for UTC time and DateTime for local time and they will never mix up.

The implementation of UtcDateTime is aware of timezones and summer/winter time changes.

            var utc_now = UtcDateTime.Now;
            var now = DateTime.Now;

            //utc_now = now;  <- Error: Cannot implicitly convert type 'System.DateTime' to 'Utils.UtcDateTime'
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

