using System.Text;

namespace ConDuck
{
    public class TimeOfDay
    {
        private int Hour;
        private int Minute;
        private int Second;

        public TimeOfDay(int hour, int minute)
        {
            if(
                (hour < 0 || hour > 23) || 
                (minute < 0 || minute > 59)
            ) throw new ArgumentException($"{hour}:{minute} is not a time of day");
            Hour = hour;
            Minute = minute;
            Second = 0;
        }

        public TimeOfDay(int hour, int minute, int second)
        {
            if(
                (hour < 0 || hour > 23) || 
                (minute < 0 || minute > 59) ||
                (second < 0 || second > 59)
            ) throw new ArgumentException($"{hour}:{minute}:{second} is not a time of day");
            Hour = hour;
            Minute = minute;
            Second = second;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            if (Hour < 10) sb.Append($"0{Hour}"); else sb.Append(Hour.ToString());
            sb.Append(":");
            if (Minute < 10) sb.Append($"0{Minute}"); else sb.Append(Minute.ToString());
            sb.Append(":");
            if (Second < 10) sb.Append($"0{Second}"); else sb.Append(Second.ToString());
            return sb.ToString();
        }

        public static TimeOfDay Now()
        {
            return new TimeOfDay(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
        }

        public static bool operator ==(TimeOfDay lhs, TimeOfDay rhs)
        {
            if (
                lhs.Hour == rhs.Hour && 
                lhs.Minute == rhs.Minute && 
                lhs.Second == rhs.Second
            ) return true;
            else return false;
        }

        public static bool operator !=(TimeOfDay lhs, TimeOfDay rhs)
        {
            if (
                lhs.Hour == rhs.Hour && 
                lhs.Minute == rhs.Minute && 
                lhs.Second == rhs.Second
            ) return false;
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
            DateTime thisTod = DateTime.Today.AddHours(Hour).AddMinutes(Minute).AddSeconds(Second);
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