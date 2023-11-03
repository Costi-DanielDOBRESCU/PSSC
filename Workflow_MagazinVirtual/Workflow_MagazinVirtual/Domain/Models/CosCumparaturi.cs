using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow_MagazinVirtual.Domain.Models
{
    public record CosCumparaturi
    {
        public Client Client { get; set; }
        public List<Produs>? Produse { get; set; }
    }
}
