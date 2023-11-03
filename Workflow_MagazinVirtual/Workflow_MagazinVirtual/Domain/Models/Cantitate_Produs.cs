using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow_MagazinVirtual.Domain.Models
{
    public record Cantitate_Produs
    {
        private static readonly Random random = new Random();
        public static int produse_in_stoc = 10;
        public int Value { get; set; }

        public Cantitate_Produs(int value)
        {
            if (IsValid(value))
            {
                Value = value;
            }
            else
            {
                throw new Exceptie_Cantitatea_Produsului_Invalida("");
            }
        }

        public int ReturnQuantity()
        {
            return Value;
        }

        private static bool IsValid(int nrCant) => nrCant < produse_in_stoc && nrCant > 0;

        public static bool TryParse(string valString, out Cantitate_Produs? cant_produs)
        {
            bool isValid = false;
            cant_produs = null;
            if (int.TryParse(valString, out int nrCant))
            {
                if (IsValid(nrCant))
                {
                    isValid = true;
                    cant_produs = new(nrCant);
                }
            }
            return isValid;
        }
    }
}
