using Inventory_Services.Models;
using Inventory_Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Services.Controllers
{
    [Authorize]        
    [Produces("application/json")]
    [Route("v1/")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryServices _services;
        private readonly IJWTAuthenticationManager _jwtAuthenticationManager;

        public InventoryController(IInventoryServices services, IJWTAuthenticationManager jwtAuthenticationManager)
        {
            _services = services;
            _jwtAuthenticationManager = jwtAuthenticationManager;
        }

        private static Logger logger = LogManager.GetCurrentClassLogger();
        [HttpPost]
        [Route("AddInventoryItems")]
        public ActionResult<InventoryItems> AddInventoryItems(InventoryItems items)
        {
            var inventoryItems = _services.AddInventoryItems(items);

            if(inventoryItems==null)
            {
                logger.Info("No access!");
                return NotFound();
            }

            logger.Info($"item {items.ItemName} added successfully!");
            return Ok(inventoryItems);
        }
            
        [HttpGet]
        [Route("GetInventoryItems")]
        public ActionResult<Dictionary<string,InventoryItems>> GetInventoryItems()
        {
            var inventoryItems = _services.GetInventoryItems();

            if (inventoryItems==null)
            {
                logger.Info("No access!");
                return NotFound();
            }
            logger.Info("items retrieved successfully");
            return Ok(inventoryItems);
        }


        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public ActionResult Authenticate(UserCred userCred)
        {
            var token = _jwtAuthenticationManager.Authenticate(userCred.Username, userCred.Password);

            if (token == null)
            {
                logger.Info("Unauthorised attempt!");
                return Unauthorized();
            }

            logger.Info("sign in successful");
            return Ok(token);
        }


    }
}
