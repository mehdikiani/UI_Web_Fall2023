using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing.Core.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToPersianDateTime(this DateTime dateTime)
        {
            var pr = new PersianCalendar();

            return $"{pr.GetYear(dateTime)}/{pr.GetMonth(dateTime)}/{pr.GetDayOfMonth(dateTime)} {pr.GetHour(dateTime)}:{pr.GetMinute(dateTime)}:{pr.GetSecond(dateTime)}";
        }
    }
}
