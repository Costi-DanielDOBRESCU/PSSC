using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow_MagazinVirtual.Domain.Models
{
    public record Client
    {
        public string Nume { get; set; }
        public string Adresa { get; set; }

        public Client(string nume, string adresa)
        {
            Nume = nume;
            Adresa = adresa;
        }
    }
}
