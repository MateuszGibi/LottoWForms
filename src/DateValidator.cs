using System;

namespace LottoWForms
{
    public class DateValidator
    {
        public static bool IsDateToday(DateTime dateToValidate)
        {
            return DateTime.Now.Date == dateToValidate.Date;
        }
    }
}