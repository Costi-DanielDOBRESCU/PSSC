using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Workflow_MagazinVirtual.Domain.Models
{
    [Serializable]
    internal class Exceptie_Cantitatea_Produsului_Invalida: Exception
    {
        public Exceptie_Cantitatea_Produsului_Invalida()
        {
        }

        public Exceptie_Cantitatea_Produsului_Invalida(string? message) : base(message)
        {
        }

        public Exceptie_Cantitatea_Produsului_Invalida(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected Exceptie_Cantitatea_Produsului_Invalida(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
