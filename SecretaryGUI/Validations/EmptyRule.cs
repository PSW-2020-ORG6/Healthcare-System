using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HCI_SIMS_PROJEKAT.Validations
{
    class EmptyRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string charString = value as string;

            if (charString.Equals(""))
                return new ValidationResult(false, $"This field is required!");

            return new ValidationResult(true, null);
        }
    }
}
