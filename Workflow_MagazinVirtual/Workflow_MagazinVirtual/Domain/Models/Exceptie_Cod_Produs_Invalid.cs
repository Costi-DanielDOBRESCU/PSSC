using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Workflow_MagazinVirtual.Domain.Models
{
    [Serializable]
    //atributul [Serializable] indică că instanțele clasei pot fi serializate,
    //adică pot fi convertite într-o formă serializată care poate fi stocată sau transmisă
    //și apoi deserializate pentru a fi reconstruite în obiectul original. 
    internal class Exceptie_Cod_Produs_Invalid : Exception
    {
        public Exceptie_Cod_Produs_Invalid()
        {
        }

        public Exceptie_Cod_Produs_Invalid(string? message) : base(message)
        {
        }

        public Exceptie_Cod_Produs_Invalid(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected Exceptie_Cod_Produs_Invalid(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
