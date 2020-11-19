using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HCI_SIMS_PROJEKAT.Validations
{
    public class EmailRegexRule : ValidationRule
    {
        public Regex rgx = new Regex(@"^[a-zA-Z0-9]+@[a-zA-Z0-9]+\.com$");

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string charString = value as string;
            if (rgx.IsMatch(charString))
                return new ValidationResult(true, null);

            return new ValidationResult(false, $"Format xxxxx@xxxx.com");
        }
    }
}
