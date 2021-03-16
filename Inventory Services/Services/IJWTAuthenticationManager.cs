using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Services.Services
{
    public interface IJWTAuthenticationManager
    {
        string Authenticate(string username, string password);
    }
}
