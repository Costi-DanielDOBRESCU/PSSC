using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workflow_MagazinVirtual.Domain.Models;

namespace Workflow_MagazinVirtual.Domain.Models
{
    [AsChoice]
    public static partial class StariCos
    {
        public interface IntCosCumparaturi { }
        public record _CosCumparaturiGol : IntCosCumparaturi
        {
            public CosCumparaturi CosGol { get; }
            public _CosCumparaturiGol(CosCumparaturi cosGol)
            {
                CosGol = cosGol;
            }
        }
        
        public record _CosCumparaturiNevalidate : IntCosCumparaturi
        {
            public IReadOnlyCollection<ProduseNevalidate> ListaProduse { get; }
            public _CosCumparaturiNevalidate(IReadOnlyCollection<ProduseNevalidate> listaProduse)
            {
                ListaProduse = listaProduse;
            }
        }

        public record _CosCumparaturiInvalid : IntCosCumparaturi
        {
            public IReadOnlyCollection<ProduseNevalidate> ListaProduse { get; }
            public string Motiv { get; }
            public _CosCumparaturiInvalid(IReadOnlyCollection<ProduseNevalidate> listaProduse, string motiv_invalidare)
            {
                ListaProduse = listaProduse;
                Motiv = motiv_invalidare;
            }
        }

        public record _CosCumparaturiValidate : IntCosCumparaturi
        {
            public IReadOnlyCollection<ProduseValidate> ListaProduse { get; }
            public _CosCumparaturiValidate(IReadOnlyCollection<ProduseValidate> listaProduse)
            {
                ListaProduse = listaProduse;
            }
        }

        public record _CosCalculatTotal : IntCosCumparaturi
        {
            public IReadOnlyCollection<PretCalculat> ListaProduse { get; }
            public _CosCalculatTotal(IReadOnlyCollection<PretCalculat> listaProduse)
            {
                ListaProduse = listaProduse;
            }
        }

        public record _CosPlatit : IntCosCumparaturi
        {
            public IReadOnlyCollection<PretCalculat> ListaProduse { get; }
            public string Csv { get; }
            public DateTime Data_Platii { get; }
            public _CosPlatit(IReadOnlyCollection<PretCalculat> listaProduse, string csv, DateTime data_Platii)
            {
                ListaProduse = listaProduse;
                Csv = csv;
                Data_Platii = data_Platii;
            }
        }
    }
}
