using System;
namespace SmartSchool.API.Helpers
{
    public static class DateTimeExtension
    {
        public static int GetCurrentAge(this DateTime dateTime)
        {
            var CurrentDate = DateTime.UtcNow;
            int age = CurrentDate.Year - dateTime.Year;
            if(CurrentDate < dateTime.AddYears(age)) age--;
            return age;
        }
    } 
}