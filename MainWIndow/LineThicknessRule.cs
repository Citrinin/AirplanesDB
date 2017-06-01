using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MainWIndow
{
    public class LineThicknessRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            foreach (char c in value.ToString())
            {
                if (!char.IsDigit(c))
                {
                    return new ValidationResult(false, "Enter integer number");
                }
            }

            return new ValidationResult(true, null);
        }
    }
}
