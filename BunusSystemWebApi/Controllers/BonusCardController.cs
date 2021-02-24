using BunusSystemWebApi.BonusCardData;
using BunusSystemWebApi.Models;
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
    public class BonusCardController : ControllerBase
    {
        private IBonusCardRepository _bonusCardRepository;

        public BonusCardController(IBonusCardRepository bonusCardRepository)
        {
            this._bonusCardRepository = bonusCardRepository;
        }

        [HttpGet("[action]")]
        public IActionResult GetBonusCard()
        {
            try
            {
                var cards = _bonusCardRepository.GetBonusCards();
                if (cards == null)
                {
                    return NotFound();
                }

                return Ok(cards);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[action]")]
        public IActionResult SayHello()
        {
            try
            {
                return Ok("Hello!");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("[action]/{phone}")]
        public IActionResult GetByPhone(string phone)
        {
            try
            {
                var card = _bonusCardRepository.GetCardByPhoneAdvanced(phone);
                if (card == null)
                {
                    return NotFound();
                }

                return Ok(card);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[action]/{number}")]
        public IActionResult GetByNumber(string number)
        {
            try
            {
                //var card = bonusCardData.GetCardByNumber(number);
                var card = _bonusCardRepository.GetCardByNumberAdvanced(number);
                if (card == null)
                {
                    return NotFound();
                }

                return Ok(card);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Update ballance for the credit card
        /// </summary>
        /// <param name="number"> Card Number</param>
        /// <param name="value"> Value to add to or remove from credit card</param>
        /// <param name="type"> 1 - add to card; 0 - remove from card</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public IActionResult Update(string number, int value, int type)
        {
            try
            {
                BonusCard card = null;

                if (type.Equals(1))
                {
                    card = _bonusCardRepository.AddToCardByNumber(number, value);
                }
                else if (type.Equals(0))
                {
                    card = _bonusCardRepository.RemoveFromCardByNumber(number, value);
                }
                else
                {
                    throw new Exception("Incorrect 'type' parameter's value");
                }

                if (card == null)
                {
                    return NotFound();
                }

                return Ok(card);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateBonusCard(string phone, string expdate)
        {
            try
            {
                var result = _bonusCardRepository.CreateNewBonusCard(phone, expdate);
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
