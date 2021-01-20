using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceAppointment.Backend.Dto
{
    public class StatisticsResulDto
    {
        public int SprecializationReturnOnce { get; set; }
        public int SprecializationReturnTwice { get; set; }
        public int SprecializationReturnMultipletimes { get; set; }
        public int DateReturnOnce { get; set; }
        public int DateReturnTwice { get; set; }
        public int DateReturnMultipletimes { get; set; }

        public StatisticsResulDto() { }
        public StatisticsResulDto(int sprecializationReturnOnce,int sprecializationReturnTwice, int sprecializationReturnMultipletimes, int dateReturnOnce, int dateReturnTwice, int dateReturnMultipletimes) 
        {
            SprecializationReturnOnce = sprecializationReturnOnce;
            SprecializationReturnTwice = sprecializationReturnTwice;
            SprecializationReturnMultipletimes = sprecializationReturnMultipletimes;
            DateReturnOnce = dateReturnOnce;
            DateReturnTwice = dateReturnTwice;
            DateReturnMultipletimes = DateReturnMultipletimes;
        }

    }
}
