using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Net;
using Links_Cards.Models;
using Links_Cards.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Microsoft.AspNetCore.JsonPatch;

namespace Links_Cards.Controllers
{
    [ApiController]
    [Route("Cards")]
    public class InternalController : ControllerBase
    {
        
        private readonly ILogger<InternalController> _logger;
        private readonly IMapper mapper;
        private readonly CardsDbContext db;

        public InternalController(ILogger<InternalController> logger, IMapper _mapper, CardsDbContext _db)
        {
            _logger = logger;
            mapper = _mapper;
            db = _db;
        }

        [HttpGet]
        [Route("[controller]/all")]
        public async Task<IActionResult> GetAsyncCards()
        {
            try
            {
                var _Cards = await db.Cards.ToListAsync();
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
        [Route("[controller]/{id}")]
        public async Task<IActionResult> GetAsyncCard(int id)
        {
            try
            {
                var _Card = await db.Cards.SingleOrDefaultAsync(i => i.Id == id);
                if(_Card == null)
                    return NotFound();
                var Card = mapper.Map<Card_Internal>(_Card);
                return Ok(Card);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return Problem(ex.ToString());
            }
        }
        [HttpGet]
        [Route("[controller]/client/{id}")]
        public async Task<IActionResult> GetAsyncCards(int id)
        {
            try
            {
                var _Cards = await db.Cards.Where(c => c.ClientId == id).ToListAsync();
                if(_Cards == null ) return NotFound();
                var Cards = mapper.Map<IEnumerable<Card_Internal>>(_Cards);
                return Ok(Cards);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return Problem(ex.ToString());
            }

        }
        // Refactor method to allow batch adding
        [HttpPost]
        [Route("[controller]/new")]
        public async Task<IActionResult> PostAsyncNewCard(Card_Internal _Card)
        {
            try
            {
                if(_Card.Credit > 0) _Card.ValidUntil= DateTime.Now.AddDays(30);
                else if(_Card.Credit==0 || _Card.Credit == null)
                    _Card.ValidUntil = DateTime.Now;
                else if(_Card.Credit<0) return BadRequest("Cannot crete card with negative credit");
                var newCard = mapper.Map<Card_Raw>(_Card);
                db.Cards.Add(newCard);
                await db.SaveChangesAsync();
                mapper.Map(newCard, _Card);
                return Created($"/internal/new", _Card);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());

                return Problem(ex.ToString());
            }
        }

        [HttpPut]
        [Route("[controller]/{id}/ChangeAlias")]
        public async Task<IActionResult> PutAsyncCard([FromRoute]int id, [FromBody]string CardAlias)
        {
            try
            {
                var Card = await db.Cards.FirstOrDefaultAsync(c => c.Id == id);
                if (Card == null) return BadRequest();
                Card.CardAlias = CardAlias;
                await db.SaveChangesAsync();
                return Ok(Card.CardAlias);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());

                return Problem(ex.ToString());
            }
        }

        [HttpPut]
        [Route("[controller]/{id}/add_credit")]
        public async Task<IActionResult> CreditCardAsync([FromRoute] int id, [FromBody] float AddCredit)
        {
            try
            {
                var Card = await db.Cards.FirstOrDefaultAsync(c => c.Id == id);
                if (Card == null) return NotFound();
                Card.Credit = Card.Credit + Math.Abs(AddCredit);
                Card.ValidUntil = DateTime.Now.AddDays(30);
                await db.SaveChangesAsync();
                return Ok(Card.Credit);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());

                return Problem(ex.ToString());
            }
        }
        [HttpPut]
        [Route("[controller]/{id}/debit")]
        public async Task<IActionResult> DebitCardAsync([FromRoute] int id, [FromBody] float Debit)
        {
            try
            {
                var Card = await db.Cards.FirstOrDefaultAsync(c => c.Id == id);
                if (Card == null) return NotFound();
                if (Card.Credit < Debit) return StatusCode(402,"Insufitient funds");
                Card.Credit = Card.Credit - Math.Abs(Debit);
                await db.SaveChangesAsync();
                return Ok(Card.Credit);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());

                return Problem(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("[controller]/delete/{id}")]
        public async Task<IActionResult> DeleteAsyncCard(int id)
        {
            try
            {
                var _Card = await db.Cards.FirstOrDefaultAsync(c => c.Id == id);
                if (_Card == null) return BadRequest();
                db.Cards.Remove(_Card);
                await db.SaveChangesAsync();
                return Ok(_Card);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());

                return Problem(ex.ToString());
            }
        }

        [HttpPut]
        [Route("[controller]/activate/{id}")]
        public async Task<IActionResult> ActivateAsyncCard(int id)
        {
            // how can I include confirmation here, does it even make sense ??
            try
            {
                var _Card = await db.Cards.FirstOrDefaultAsync(c => c.Id == id);
                if (_Card == null) return BadRequest();
                else if (_Card.Active) return Ok("Card already active");
                _Card.Active = true;
                await db.SaveChangesAsync();
                return Ok(_Card);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());

                return Problem(ex.ToString());
            }
        }

    }
}