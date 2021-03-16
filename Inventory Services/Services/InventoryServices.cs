using Inventory_Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Services.Services
{
    public class InventoryServices : IInventoryServices
    {
        private readonly Dictionary<string, InventoryItems> _inventoryItems;

        public InventoryServices()
        {
            _inventoryItems = new Dictionary<string, InventoryItems>();
        }
        public object AddInventoryItems(InventoryItems items)
        {
            _inventoryItems.Add(items.ItemName,items);
            return items;
        }

        public object GetInventoryItems()
        {
            return _inventoryItems;
        }
    }
}
