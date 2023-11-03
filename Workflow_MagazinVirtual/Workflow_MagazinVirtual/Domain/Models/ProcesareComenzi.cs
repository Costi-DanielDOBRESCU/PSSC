using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow_MagazinVirtual.Domain.Models
{
    public record ProcesareComenzi
    {
        public IReadOnlyCollection<ProduseNevalidate> InputCosCumparaturi { get; }

        public ProcesareComenzi(IReadOnlyCollection<ProduseNevalidate> inputCosCumparaturi)
        {
            InputCosCumparaturi = inputCosCumparaturi;
        }
    }
}
