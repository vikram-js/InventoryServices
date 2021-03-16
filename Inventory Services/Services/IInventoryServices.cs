using Inventory_Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Services.Services
{
    public interface IInventoryServices
    {
        object AddInventoryItems(InventoryItems items);
        object GetInventoryItems();
    }
}
