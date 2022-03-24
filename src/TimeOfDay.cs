using System;

namespace Chroniker
{
    public class TimeOfDay
    {
        private int Hour;
        private int Minute;

        public TimeOfDay(int hour, int minute)
        {
            if((hour < 0 || hour > 23) || (minute < 0 || minute > 59)) throw new ArgumentException($"{hour}:{minute} is not a time of day");
            Hour = hour;
            Minute = minute;
        }

        public override string ToString()
        {
            return $"{Hour}:{Minute}";
        }

        public static TimeOfDay Now()
        {
            return new TimeOfDay(DateTime.Now.Hour, DateTime.Now.Minute);
        }

        public static bool operator ==(TimeOfDay lhs, TimeOfDay rhs)
        {
            if (lhs.Hour == rhs.Hour && lhs.Minute == rhs.Minute) return true;
            else return false;
        }

        public static bool operator !=(TimeOfDay lhs, TimeOfDay rhs)
        {
            if (lhs.Hour == rhs.Hour && lhs.Minute == rhs.Minute) return false;
            else return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public int TimeUntil()
        {
            DateTime thisTod = DateTime.Today.AddHours(Hour).AddMinutes(Minute);
            var diff = thisTod - DateTime.Now;
            if (diff.TotalMilliseconds < 0) 
            {
                return (int) ((thisTod.AddDays(1)) - DateTime.Now).TotalMilliseconds;
            }
            else 
            {
                return (int) diff.TotalMilliseconds;
            }
        }
    }
}