using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Net;
using Links_Cards.Models;
using Links_Cards.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Microsoft.AspNetCore.JsonPatch;
using System;

namespace Links_Cards.Controllers
{
    [ApiController]
    [Route("Cards")]
    public class PublicController : ControllerBase
    {
        
        private readonly ILogger<PublicController> _logger;
        private readonly IMapper mapper;
        private readonly CardsDbContext db;

        public PublicController(ILogger<PublicController> logger, IMapper _mapper, CardsDbContext _db)
        {
            _logger = logger;
            mapper = _mapper;
            db = _db;
        }

        [HttpGet]
        [Route("[controller]/{clientID}/all")]
        public async Task<IActionResult> GetAsyncCards([FromRoute] int clientID)
        {
            try
            {
                var _Cards = await db.Cards.Where(c => c.ClientId == clientID && c.Active == true).ToListAsync();
                if (_Cards == null) return NotFound();
                var Cards = mapper.Map<IEnumerable<Card_Internal>>(_Cards);
                return Ok(Cards);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return Problem(ex.ToString());
            }

        }

        [HttpGet]
        [Route("[controller]/{clientID}/{cardID}")]
        public async Task<IActionResult> GetAsyncCard([FromRoute]int clientID, [FromRoute]int cardID)
        {
            try
            {
                var _Cards = await db.Cards.SingleOrDefaultAsync(c => c.ClientId == clientID && c.Active == true && c.Id == cardID);
                if (_Cards == null) return NotFound();
                var Cards = mapper.Map<IEnumerable<Card_Internal>>(_Cards);
                return Ok(Cards);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return Problem(ex.ToString());
            }
        }

        [HttpPost]
        [Route("[controller]/{clientID}/new")]
        public async Task<IActionResult> PostAsyncNewCard([FromRoute] int clientID, Card_Public _Card)
        {
            try
            {
                if (_Card.Credit > 0) _Card.ValidUntil = DateTime.Now.AddDays(30);
                else if (_Card.Credit == 0 || _Card.Credit == null)
                    _Card.ValidUntil = DateTime.Now;
                else if (_Card.Credit < 0) return BadRequest("Cannot crete card with negative credit");
                var newCard = mapper.Map<Card_Raw>(_Card);
                newCard.ClientId = clientID;
                newCard.Active = true; // -> later delete this line and activate only upon payment confirmation
                db.Cards.Add(newCard);
                await db.SaveChangesAsync();
                mapper.Map(newCard, _Card);
                return Ok(_Card);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());

                return Problem(ex.ToString());
            }
        }

        [HttpPut]
        [Route("[controller]/{clientID}/{cardID}/ChangeAlias")]
        public async Task<IActionResult> PutAsyncCard([FromRoute] int clientID, [FromRoute] int cardID, [FromBody] string CardAlias)
        {
            try
            {
                var Card = await db.Cards.FirstOrDefaultAsync(c => c.ClientId == clientID && c.Active == true && c.Id == cardID);
                if (Card == null) return NotFound();
                Card.CardAlias = CardAlias;
                await db.SaveChangesAsync();
                var pCard = mapper.Map<Card_Public>(Card);
                return Ok(pCard);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());

                return Problem(ex.ToString());
            }
        }

        [HttpPut]
        [Route("[controller]/{clientID}/{cardID}/add_credit")]
        public async Task<IActionResult> CreditCardAsync([FromRoute] int clientID, [FromRoute] int cardID, [FromBody] float AddCredit)
        {
            try
            {
                if (AddCredit <= 0) return BadRequest("invalid amount");
                var Card = await db.Cards.FirstOrDefaultAsync(c => c.ClientId == clientID && c.Active == true && c.Id == cardID);
                if (Card == null) return NotFound();
                Card.Credit = (Card.Credit == null ? 0 : Card.Credit) + AddCredit;
                Card.ValidUntil = DateTime.Now.AddDays(30);
                await db.SaveChangesAsync();
                var pCard = mapper.Map<Card_Public>(Card);
                return Ok(pCard);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());

                return Problem(ex.ToString());
            }
        }
        [HttpPut]
        [Route("[controller]/{clientID}/{cardID}/debit")]
        public async Task<IActionResult> DebitCardAsync([FromRoute] int clientID, [FromRoute] int cardID, [FromBody] float Debit)
        {
            try
            {
                if (Debit <= 0) return BadRequest("invalid amount");
                var Card = await db.Cards.FirstOrDefaultAsync(c => c.ClientId == clientID && c.Active == true && c.Id == cardID);
                if (Card == null) return NotFound();
                if (Card.Credit < Debit) return StatusCode(402, "Insufitient funds");
                Card.Credit = (Card.Credit == null ? 0 : Card.Credit) - Debit;
                await db.SaveChangesAsync();
                var pCard = mapper.Map<Card_Public>(Card);
                return Ok(pCard);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());

                return Problem(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("[controller]/{clientID}/delete/{cardID}")]
        public async Task<IActionResult> DeleteAsyncCard([FromRoute] int clientID, [FromRoute] int cardID)
        {
            // how can I include confirmation here, does it even make sense ??
            try
            {
                var _Card = await db.Cards.FirstOrDefaultAsync(c => c.ClientId == clientID && c.Active == true && c.Id == cardID);
                if (_Card == null) return NotFound();
                _Card.Active = false;
                await db.SaveChangesAsync();
                var simple = mapper.Map<Card_Public>(_Card);
                return Ok(simple);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());

                return Problem(ex.ToString());
            }
        }

    }
}