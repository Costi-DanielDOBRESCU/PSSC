using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow_MagazinVirtual.Domain.Models
{
    public record PretCalculat(Cod_Produs Cod, Cantitate_Produs Cantitate, Pret_Produs Pret, double PretTotal);
}
