using System.Text.RegularExpressions;

namespace HealthClinic.View.ErrorCheck
{
    public static class Checker
    {
        public static Regex nameRegex = new Regex(@"^[A-Z][a-z]+$");
        public static Regex jmbgRegex = new Regex(@"^[0-9]+$");


    }
}
