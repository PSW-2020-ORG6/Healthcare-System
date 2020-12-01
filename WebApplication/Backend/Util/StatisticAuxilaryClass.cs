using System;

namespace WebApplication.Backend.Util
{
    public class StatisticAuxilaryClass
    {
        private double averageRating;
        private int ones;
        private int twos;
        private int threes;
        private int fours;
        private int fives;
        private String onesPercent;
        private String twosPercent;
        private String threesPercent;
        private String foursPercent;
        private String fivesPercent;


        public StatisticAuxilaryClass()
        {
            this.AverageRating = 0;
            this.Ones = 0;
            this.Twos = 0;
            this.Threes = 0;
            this.Fours = 0;
            this.Fives = 0;
        }

        public double AverageRating { get => averageRating; set => averageRating = value; }
        public int Ones { get => ones; set => ones = value; }
        public int Threes { get => threes; set => threes = value; }
        public int Fours { get => fours; set => fours = value; }
        public int Fives { get => fives; set => fives = value; }
        public int Twos { get => twos; set => twos = value; }
        public string FivesPercent { get => fivesPercent; set => fivesPercent = value; }
        public string FoursPercent { get => foursPercent; set => foursPercent = value; }
        public string ThreesPercent { get => threesPercent; set => threesPercent = value; }
        public string TwosPercent { get => twosPercent; set => twosPercent = value; }
        public string OnesPercent { get => onesPercent; set => onesPercent = value; }

        public void increment(int i)
        {
            if (i == 1)
            {
                ones++;
            }
            else if (i == 2)
            {
                twos++;
            }
            else if (i == 3)
            {
                threes++;
            }
            else if (i == 4)
            {
                fours++;
            }
            else if (i == 5)
            {
                fives++;
            }
        }

        public void generatePercents()
        {
            if ((ones + twos + threes + fours + fives) == 0)
            {
                onesPercent = 0.ToString() + "%";
                twosPercent = 0.ToString() + "%";
                threesPercent = 0.ToString() + "%";
                foursPercent = 0.ToString() + "%";
                fivesPercent = 0.ToString() + "%";
            }
            else
            {
                onesPercent = (ones * 100 / (ones + twos + threes + fours + fives)).ToString() + "%";
                twosPercent = (twos * 100 / (ones + twos + threes + fours + fives)).ToString() + "%";
                threesPercent = (threes * 100 / (ones + twos + threes + fours + fives)).ToString() + "%";
                foursPercent = (fours * 100 / (ones + twos + threes + fours + fives)).ToString() + "%";
                fivesPercent = (fives * 100 / (ones + twos + threes + fours + fives)).ToString() + "%";
            }
        }

    }


}
