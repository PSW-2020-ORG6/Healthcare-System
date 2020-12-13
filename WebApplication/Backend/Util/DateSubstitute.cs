using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Backend.Util
{
    public class DateSubstitute
    {
        int year;
        int month;
        int day;

        public DateSubstitute(string year, string month, string day)
        {
            this.year = int.Parse(year);
            this.month = int.Parse(month);
            this.day = int.Parse(day);
        }

        public DateSubstitute()
        {

        }

        public int Day { get => day; set => day = value; }
        public int Month { get => month; set => month = value; }
        public int Year { get => year; set => year = value; }

        public List<DateSubstitute> SortDateSubstitutes(List<DateSubstitute> datesToSort)
        {
            DateSubstitute temp;
            for (int j = 0; j <= datesToSort.Count - 2; j++)
            {
                for (int i = 0; i <= datesToSort.Count - 2; i++)
                {
                    if (datesToSort[i].Year > datesToSort[i + 1].Year)
                    {
                        temp = datesToSort[i + 1];
                        datesToSort[i + 1] = datesToSort[i];
                        datesToSort[i] = temp;
                    }
                    else if (datesToSort[i].Year == datesToSort[i + 1].Year && datesToSort[i].Month > datesToSort[i + 1].Month)
                    {
                        temp = datesToSort[i + 1];
                        datesToSort[i + 1] = datesToSort[i];
                        datesToSort[i] = temp;
                    }
                    else if (datesToSort[i].Year == datesToSort[i + 1].Year && datesToSort[i].Month == datesToSort[i + 1].Month && datesToSort[i].Day > datesToSort[i + 1].Day)
                    {
                        temp = datesToSort[i + 1];
                        datesToSort[i + 1] = datesToSort[i];
                        datesToSort[i] = temp;
                    }
                }
            }

            return datesToSort;
        }

        public void MonthsToDays()
        {
            if (month == 2)
            {
                Day += 31;
            }
            else if (month == 3)
            {
                Day += 60;
            }
            else if (month == 4)
            {
                Day += 91;
            }
            else if (month == 5)
            {
                Day += 121;
            }
            else if (month == 6)
            {
                Day += 152;
            }
            else if (month == 7)
            {
                Day += 182;
            }
            else if (month == 8)
            {
                Day += 213;
            }
            else if (month == 9)
            {
                Day += 243;
            }
            else if (month == 10)
            {
                Day += 273;
            }
            else if (month == 11)
            {
                Day += 304;
            }
            else if (month == 12)
            {
                Day += 334;
            }
        }

        public int CalculateDiference(DateSubstitute one, DateSubstitute two)
        {
            if (one.Year == two.Year)
            {
                one.MonthsToDays();
                two.MonthsToDays();
                if (Math.Abs(one.Month - two.Month) < 2)
                    return Math.Abs(one.Day - two.Day);

                else return 1000;
            }
            else if (one.Year - two.Year == 1)
            {
                if (one.Month == 1 && two.Month == 12 && one.Year > two.Year)
                {
                    return Math.Abs(one.Day - two.Day + 365);
                }
                else if (one.Month == 12 && two.Month == 1 && one.Year < two.Year)
                {
                    return Math.Abs(one.Day - two.Day - 365);
                }
                else return 1000;
            }

            else return 1000;
        }
    }
}

