using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Workflow_MagazinVirtual.Domain.Models
{
    public record Cod_Produs
    {
        private static readonly Regex ValidPattern = new("^[0-9]{3}P$");

        public string Value { get; set; }

        public Cod_Produs(string value)
        {
            if (IsValid(value))
            {
                Value = value;
            }
            else
            {
                throw new Exceptie_Cod_Produs_Invalid("");
            }
        }

        private static bool IsValid(string stringValue) => ValidPattern.IsMatch(stringValue);

        public override string ToString()
        {
            return Value;
        }

        public static bool TryParse(string stringValue, out Cod_Produs? productCode)
        {
            bool isValid = false;
            productCode = null;

            if (IsValid(stringValue))
            {
                isValid = true;
                productCode = new(stringValue);
            }

            return isValid;
        }
    }
}

