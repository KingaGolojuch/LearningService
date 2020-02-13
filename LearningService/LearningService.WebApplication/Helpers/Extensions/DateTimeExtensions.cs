using System;

namespace LearningService.WebApplication.Helpers.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToFullDateWithoutSeconds(this DateTime datetime)
        {
            if (datetime == null)
                return string.Empty;

            return datetime.ToString("yyyy/MM/dd hh:mm");
        }
    }
}
