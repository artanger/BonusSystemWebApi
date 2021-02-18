﻿using BunusSystemWebApi.BonusCardData;
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
                var messages = _bonusCardRepository.GetBonusCards();
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);
            }
            catch (Exception ex)
            {
                var ttt = ex.Message;

                return BadRequest();
            }
        }

        //[HttpGet("[action]")]
        //public IActionResult GetBonusCard()
        //{

        //}

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
                var ttt = ex.Message;

                return BadRequest();
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
                var ttt = ex.Message;

                return BadRequest();
            }
        }

        [HttpGet("[action]/{number}/{value}")]
        public IActionResult AddToCard(string number, int value)
        {
            try
            {
                var card = _bonusCardRepository.AddToCardByNumber(number, value);
                if (card == null)
                {
                    return NotFound();
                }

                return Ok(card);
            }
            catch (Exception ex)
            {
                var ttt = ex.Message;

                return BadRequest();
            }
        }

        [HttpGet("[action]/{number}/{value}")]
        public IActionResult RemoveFromCard(string number, int value)
        {
            try
            {
                var card = _bonusCardRepository.RemoveFromCardByNumber(number, value);
                if (card == null)
                {
                    return NotFound();
                }

                return Ok(card);
            }
            catch (Exception ex)
            {
                var ttt = ex.Message;

                return BadRequest();
            }
        }

        [HttpGet("[action]/{phone}/{expirationdate}")]
        public IActionResult CreateBonusCard(string phone, string expirationdate)
        {
            try
            {
                var result = _bonusCardRepository.CreateNewBonusCard(phone, expirationdate);
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
