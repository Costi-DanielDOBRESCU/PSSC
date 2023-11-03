using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow_MagazinVirtual.Domain.Models
{
    public record Pret_Produs
    {
        private static readonly Random random = new Random();
        public double Value;
        public Pret_Produs()
        {
            Value = System.Math.Round(random.Next(300) * random.NextDouble(), 2);
            //aici am dat valoare un numar random din int [0,299] cu doua zecimale dupa virgula
        }
        public double ReturnPrice()
        {
            return Value;
        }
    }
}
