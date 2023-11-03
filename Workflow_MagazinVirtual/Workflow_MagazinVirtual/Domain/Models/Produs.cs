using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Workflow_MagazinVirtual.Domain.Models
{
    public record Produs
    {
        private static readonly Random random = new Random();
        private static readonly Regex ValidPatternCode = new("^[0-9]{6}$");
        public Cod_Produs Cod { get; set; }
        public Cantitate_Produs Cantitate { get; set; }
        public Pret_Produs Pret { get; set; }
        public Produs(Cod_Produs cod, Cantitate_Produs cant, Pret_Produs pret)
        {
            Cod = cod;
            Cantitate = cant;
            Pret = pret;
        }
        public override string ToString()
        {
            return "Code=" + Cod + " " + "Quantity=" + Cantitate + "Price=" + Pret;
        }

        public double CalculPretTotal()
        {
            double pret = random.Next(200) * random.NextDouble();
            double pret_total = System.Math.Round(Cantitate.ReturnQuantity() * Pret.ReturnPrice(), 2);
            return pret_total;
        }

        private static bool IsValidCode(string stringValue) => ValidPatternCode.IsMatch(stringValue);
        public static bool TryParseCode(string stringValue, out string? code)
        {
            bool isValid = false;
            code = null;
            if (IsValidCode(stringValue))
            {
                isValid = true;
                code = new(stringValue);
            }
            return isValid;
        }

        private static bool IsValidQuantity(int numericQuantity) => numericQuantity > 0;
        public static bool TryParseQuantity(string quantityString, out int quantity)
        {
            bool isValid = false;
            quantity = 0;
            if (int.TryParse(quantityString, out int numericQuantity))
            {
                if (IsValidQuantity(numericQuantity))
                {
                    isValid = true;
                    quantity = numericQuantity;
                }
            }
            return isValid;
        }

    }
}
