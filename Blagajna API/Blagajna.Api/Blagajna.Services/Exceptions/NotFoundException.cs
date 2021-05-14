using System;
using System.Collections.Generic;
using System.Text;

namespace Blagajna.Services.Exceptions
{
    public class NotFoundException: Exception
    {
        public NotFoundException(string mesage) : base(mesage)
        {

        }    
    }
}
