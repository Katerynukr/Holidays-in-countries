using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryHolidaySolution.Domain.Helpers
{
    public class ParsingHelper
    {
        public static Dictionary<string, int> ParseStringToDateDictionary(string date)
        {
            var dateArrayString = date.Split("-");
            Dictionary<string, int> dateInteger = new();
            dateInteger.Add("day", int.Parse(dateArrayString[0]));
            dateInteger.Add("month", int.Parse(dateArrayString[1]));
            dateInteger.Add("year", int.Parse(dateArrayString[2]));
            return dateInteger;
        }
    }
}
