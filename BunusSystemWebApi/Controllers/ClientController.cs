using BunusSystemWebApi.BonusCardData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BunusSystemWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private IBonusCardRepository _bonusCardRepository;

        public ClientController(IBonusCardRepository bonusCardRepository)
        {
            this._bonusCardRepository = bonusCardRepository;
        }

        [HttpGet]
        public IActionResult GetClients()
        {
            try
            {
                var clients = _bonusCardRepository.GetClients();
                if (clients == null)
                {
                    return NotFound();
                }

                return Ok(clients);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateNewClient(string firstName, string lastName, string phone)
        {
            try
            {
                var result = _bonusCardRepository.CreateNewClient(firstName, lastName, phone);
                if (!result.Equals("Success"))
                {
                    return ValidationProblem(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
