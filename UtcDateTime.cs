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
using System.Diagnostics;
using System.Globalization;

namespace UtcDateTime
{
    public interface IDateTime
    {
        DateTime Value { get; set; }
        long Ticks { get; }
        int Millisecond { get; }
        int Second { get; }
        int Minute { get; }
        int Hour { get; }
        int Day { get; }
        int Month { get; }
        int Year { get; }
        int DayOfYear { get; }
        DayOfWeek DayOfWeek { get; }
        DateTime Date { get; }
        TimeSpan TimeOfDay { get; }
    }

    [DebuggerDisplay("Utc: {date_time}, Local: {ToLocalTime()}")]
    public struct UtcDateTime : IDateTime, IComparable, IFormattable, IConvertible, IComparable<UtcDateTime>, IEquatable<UtcDateTime>
    {
        public static readonly UtcDateTime MinValue = new UtcDateTime(DateTime.MinValue);
        public static readonly UtcDateTime MaxValue = new UtcDateTime(DateTime.MaxValue);

        #region Privates
        private DateTime date_time;
        #endregion

        #region Properties
        public DateTime Value
        {
            get { return date_time; }
            set { date_time = value; }
        }

        public long LocalTicks
        {
            get { return ToLocalTime().Ticks; }
        }

        long IDateTime.Ticks
        {
            get { return date_time.Ticks; }
        }

        public int LocalMillisecond
        {
            get { return ToLocalTime().Millisecond; }
        }

        int IDateTime.Millisecond
        {
            get { return date_time.Millisecond; }
        }

        public int LocalSecond
        {
            get { return ToLocalTime().Second; }
        }

        int IDateTime.Second
        {
            get { return date_time.Second; }
        }

        public int LocalMinute
        {
            get { return ToLocalTime().Minute; }
        }

        int IDateTime.Minute
        {
            get { return date_time.Minute; }
        }

        public int LocalHour
        {
            get { return ToLocalTime().Hour; }
        }

        int IDateTime.Hour
        {
            get { return date_time.Hour; }
        }

        public int LocalDay
        {
            get { return ToLocalTime().Day; }
        }

        int IDateTime.Day
        {
            get { return date_time.Day; }
        }

        public int LocalMonth
        {
            get { return ToLocalTime().Month; }
        }

        int IDateTime.Month
        {
            get { return date_time.Month; }
        }

        public int LocalYear
        {
            get { return ToLocalTime().Year; }
        }

        int IDateTime.Year
        {
            get { return date_time.Year; }
        }

        public int LocalDayOfYear
        {
            get { return ToLocalTime().DayOfYear; }
        }

        int IDateTime.DayOfYear
        {
            get { return date_time.DayOfYear; }
        }

        public DayOfWeek LocalDayOfWeek
        {
            get { return ToLocalTime().DayOfWeek; }
        }

        DayOfWeek IDateTime.DayOfWeek
        {
            get { return date_time.DayOfWeek; }
        }

        public UtcDateTime LocalStartOfDay
        {
            get { return TimeHelper.ToUtcTime(ToLocalTime().Date); }
        }

        DateTime IDateTime.Date //StartOfDay
        {
            get { return date_time.Date; }
        }

        public TimeSpan LocalTimeOfDay
        {
            get { return ToLocalTime().TimeOfDay; }
        }

        TimeSpan IDateTime.TimeOfDay
        {
            get { return date_time.TimeOfDay; }
        }

        public DateTimeKind Kind
        {
            get { return DateTimeKind.Utc; }
        }
        #endregion

        #region Construction
        public UtcDateTime(DateTime date_time)
        {
            if (date_time.Kind == DateTimeKind.Utc)
                this.date_time = date_time;
            else
                this.date_time = new DateTime(date_time.Ticks, DateTimeKind.Utc);
        }

        public UtcDateTime(int year, int month, int day)
        {
            date_time = new DateTime(year, month, day, 0, 0, 0, DateTimeKind.Utc);
        }

        public UtcDateTime(int year, int month, int day, int hour, int minute, int second)
        {
            date_time = new DateTime(year, month, day, hour, minute, second, DateTimeKind.Utc);
        }

        public UtcDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond)
        {
            date_time = new DateTime(year, month, day, hour, minute, second, millisecond, DateTimeKind.Utc);
        }
        #endregion

        #region IComparable Members
        public int CompareTo(object value)
        {
            if (value == null)
                return 1;

            if (!(value is UtcDateTime))
            {
                throw new ArgumentException("Argument must be UtcDateTime");
            }

            return CompareTo((UtcDateTime)value);
        }

        public int CompareTo(UtcDateTime value)
        {
            return date_time.CompareTo(value.date_time);
        }
        #endregion

        #region IFormattable Members
        public string ToString(string format, IFormatProvider format_provider)
        {
            return date_time.ToString(format, format_provider);
        }

        public string ToString(string format)
        {
            return date_time.ToString(format);
        }

        public string ToString(IFormatProvider format_provider)
        {
            return date_time.ToString(format_provider);
        }
        #endregion

        #region IConvertible Members
        public TypeCode GetTypeCode()
        {
            return date_time.GetTypeCode();
        }

        bool IConvertible.ToBoolean(IFormatProvider provider)
        {
            return ((IConvertible)date_time).ToBoolean(provider);
        }

        byte IConvertible.ToByte(IFormatProvider provider)
        {
            return ((IConvertible)date_time).ToByte(provider);
        }

        char IConvertible.ToChar(IFormatProvider provider)
        {
            return ((IConvertible)date_time).ToChar(provider);
        }

        DateTime IConvertible.ToDateTime(IFormatProvider provider)
        {
            return ((IConvertible)date_time).ToDateTime(provider);
        }

        Decimal IConvertible.ToDecimal(IFormatProvider provider)
        {
            return ((IConvertible)date_time).ToDecimal(provider);
        }

        double IConvertible.ToDouble(IFormatProvider provider)
        {
            return ((IConvertible)date_time).ToDouble(provider);
        }

        short IConvertible.ToInt16(IFormatProvider provider)
        {
            return ((IConvertible)date_time).ToInt16(provider);
        }

        int IConvertible.ToInt32(IFormatProvider provider)
        {
            return ((IConvertible)date_time).ToInt32(provider);
        }

        long IConvertible.ToInt64(IFormatProvider provider)
        {
            return ((IConvertible)date_time).ToInt64(provider);
        }

        sbyte IConvertible.ToSByte(IFormatProvider provider)
        {
            return ((IConvertible)date_time).ToSByte(provider);
        }

        float IConvertible.ToSingle(IFormatProvider provider)
        {
            return ((IConvertible)date_time).ToSingle(provider);
        }

        string IConvertible.ToString(IFormatProvider provider)
        {
            return ((IConvertible)date_time).ToString(provider);
        }

        object IConvertible.ToType(Type conversion_type, IFormatProvider provider)
        {
            return ((IConvertible)date_time).ToType(conversion_type, provider);
        }

        ushort IConvertible.ToUInt16(IFormatProvider provider)
        {
            return ((IConvertible)date_time).ToUInt16(provider);
        }

        uint IConvertible.ToUInt32(IFormatProvider provider)
        {
            return ((IConvertible)date_time).ToUInt32(provider);
        }

        ulong IConvertible.ToUInt64(IFormatProvider provider)
        {
            return ((IConvertible)date_time).ToUInt64(provider);
        }
        #endregion

        #region IEquatable Members
        public bool Equals(UtcDateTime other)
        {
            return date_time.Equals(other.date_time);
        }
        #endregion

        #region Operations
        public UtcDateTime LocalAdd(TimeSpan value)
        {
            return TimeHelper.ToUtcTime(ToLocalTime().Add(value));
        }

        public UtcDateTime LocalAddTicks(long value)
        {
            return TimeHelper.ToUtcTime(ToLocalTime().AddTicks(value));
        }

        public UtcDateTime LocalAddMilliseconds(double value)
        {
            return TimeHelper.ToUtcTime(ToLocalTime().AddMilliseconds(value));
        }

        public UtcDateTime LocalAddSeconds(double value)
        {
            return TimeHelper.ToUtcTime(ToLocalTime().AddSeconds(value));
        }

        public UtcDateTime LocalAddMinutes(double value)
        {
            return TimeHelper.ToUtcTime(ToLocalTime().AddMinutes(value));
        }

        public UtcDateTime LocalAddHours(double value)
        {
            return TimeHelper.ToUtcTime(ToLocalTime().AddHours(value));
        }

        public UtcDateTime LocalAddDays(double value)
        {
            return TimeHelper.ToUtcTime(ToLocalTime().AddDays(value));
        }

        public UtcDateTime LocalAddMonths(int value)
        {
            return TimeHelper.ToUtcTime(ToLocalTime().AddMonths(value));
        }

        public UtcDateTime LocalAddYears(int value)
        {
            return TimeHelper.ToUtcTime(ToLocalTime().AddYears(value));
        }

        public TimeSpan LocalSubtract(UtcDateTime value)
        {
            return ToLocalTime().Subtract(value.ToLocalTime());
        }

        public UtcDateTime LocalSubtract(TimeSpan value)
        {
            return TimeHelper.ToUtcTime(ToLocalTime().Subtract(value));
        }

        public static int Compare(UtcDateTime t1, UtcDateTime t2)
        {
            return DateTime.Compare(t1.date_time, t2.date_time);
        }

        public DateTime ToLocalTime()
        {
#if SILVERLIGHT
            return TimeZoneInfo.ConvertTime(date_time, TimeZoneInfo.Local);
#else
            return TimeZoneInfo.ConvertTimeFromUtc(date_time, TimeHelper.CurrentTimeZone);
#endif
        }

        public override string ToString()
        {
            return string.Format("Utc: {0}, Local: {1}", date_time, ToLocalTime());
        }

        public override int GetHashCode()
        {
            return date_time.GetHashCode();
        }

        public override bool Equals(object value)
        {
            if (value is UtcDateTime)
            {
                return Equals((UtcDateTime)value);
            }
            return false;
        }
        #endregion

        #region Operators
        public static UtcDateTime operator +(UtcDateTime d, TimeSpan t)
        {
            return new UtcDateTime(d.date_time + t);
        }

        public static UtcDateTime operator -(UtcDateTime d, TimeSpan t)
        {
            return new UtcDateTime(d.date_time - t);
        }

        public static TimeSpan operator -(UtcDateTime d1, UtcDateTime d2)
        {
            return d1.date_time - d2.date_time;
        }

        public static bool operator ==(UtcDateTime d1, UtcDateTime d2)
        {
            return d1.date_time == d2.date_time;
        }

        public static bool operator !=(UtcDateTime d1, UtcDateTime d2)
        {
            return d1.date_time != d2.date_time;
        }

        public static bool operator <(UtcDateTime t1, UtcDateTime t2)
        {
            return t1.date_time < t2.date_time;
        }

        public static bool operator <=(UtcDateTime t1, UtcDateTime t2)
        {
            return t1.date_time <= t2.date_time;
        }

        public static bool operator >(UtcDateTime t1, UtcDateTime t2)
        {
            return t1.date_time > t2.date_time;
        }

        public static bool operator >=(UtcDateTime t1, UtcDateTime t2)
        {
            return t1.date_time >= t2.date_time;
        }
        #endregion

        #region Statics
        public static UtcDateTime Now
        {
            get { return new UtcDateTime(DateTime.UtcNow); }
        }

        public static UtcDateTime Parse(string s)
        {
            return Parse(s, DateTimeFormatInfo.CurrentInfo, DateTimeStyles.AssumeUniversal);
        }

        public static UtcDateTime Parse(string s, IFormatProvider provider)
        {
            return Parse(s, DateTimeFormatInfo.GetInstance(provider), DateTimeStyles.AssumeUniversal);
        }

        public static UtcDateTime Parse(string s, IFormatProvider provider, DateTimeStyles styles)
        {
            return new UtcDateTime(DateTime.Parse(s, DateTimeFormatInfo.GetInstance(provider), styles).ToUniversalTime());
        }

        public static UtcDateTime ParseExact(string s, string format, IFormatProvider provider)
        {
            return new UtcDateTime(DateTime.ParseExact(s, format, provider));
        }

        public static bool TryParse(string s, out UtcDateTime result)
        {
            DateTime dt_result;
            var parsed = DateTime.TryParse(s, DateTimeFormatInfo.CurrentInfo, DateTimeStyles.AssumeUniversal, out dt_result);
            result = new UtcDateTime(dt_result);
            return parsed;
        }

        public static bool TryParse(string s, IFormatProvider provider, DateTimeStyles styles, out UtcDateTime result)
        {
            DateTime dt_result;
            var parsed = DateTime.TryParse(s, provider, styles, out dt_result);
            result = new UtcDateTime(dt_result);
            return parsed;
        }
        #endregion
    }
}
