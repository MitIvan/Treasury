using System;
using System.Collections.Generic;
using System.Text;

namespace Blagajna.Services.Exceptions
{
    public class DenDocumentExeption : Exception
    {
        public DenDocumentExeption(string masage) : base(masage)
        {

        }
    }
}
