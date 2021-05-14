using Blagajna.DataAccess;
using Blagajna.Domain.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blagajna.Services.Interfaces
{
    public interface IVraboten
    {
        List<Vraboten> GetAllVraboteni();
    }
}
