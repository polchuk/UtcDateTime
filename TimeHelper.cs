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
using System.Threading;

namespace Utils
{
    public class TimeHelper
    {
        #region Time Zone
        public static TimeZoneInfo CurrentTimeZone
        {
            get
            {
#if !SILVERLIGHT
                var tz = (TimeZoneInfo)Thread.GetData(CurrentTimeZoneSlot);
                if (tz != null)
                    return tz;
#endif
                return TimeZoneInfo.Local;
            }
        }

#if !SILVERLIGHT
        public static void SetThreadTimeZone(string time_zone_id)
        {
            TimeZoneInfo time_zone = null;
            if (!string.IsNullOrEmpty(time_zone_id))
                time_zone = TimeZoneInfo.FindSystemTimeZoneById(time_zone_id);
            SetThreadTimeZone(time_zone);
        }

        public static void SetThreadTimeZone(TimeZoneInfo time_zone)
        {
            Thread.SetData(CurrentTimeZoneSlot, time_zone);
        }

        public static void ResetThreadTimeZone()
        {
            Thread.SetData(CurrentTimeZoneSlot, null);
        }

        private static LocalDataStoreSlot CurrentTimeZoneSlot
        {
            get { return Thread.GetNamedDataSlot("TimeZone"); }
        }
#endif
        #endregion

        #region Local/Universal Time
        public static UtcDateTime ToUtcTime(DateTime local_dt)
        {
#if SILVERLIGHT
            return new UtcDateTime(TimeZoneInfo.ConvertTime(local_dt, TimeZoneInfo.Utc));
#else
            return new UtcDateTime(TimeZoneInfo.ConvertTimeToUtc(local_dt, CurrentTimeZone));
#endif
        }

        public static UtcDateTime? ToUtcTime(DateTime? local_dt)
        {
            if (local_dt == null)
                return null;
            return ToUtcTime((DateTime)local_dt);
        }

        public static DateTime ToLocalTime(UtcDateTime utc_dt)
        {
            return utc_dt.ToLocalTime();
        }

        public static DateTime? ToLocalTime(UtcDateTime? utc_dt)
        {
            if (utc_dt == null)
                return null;
            return ToLocalTime((UtcDateTime)utc_dt);
        }

        public static int GetUtcOffset(UtcDateTime dt)
        {
            return GetUtcOffset(dt.ToLocalTime());
        }

        public static int GetUtcOffset(DateTime dt)
        {
            return CurrentTimeZone.GetUtcOffset(dt).Minutes;
        }
        #endregion
    }
}
