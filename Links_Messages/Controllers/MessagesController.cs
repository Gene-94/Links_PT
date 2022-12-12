
using Links_Messages.Helpers;
using Links_Messages.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Links_Cards.Controllers
{
    public class MessagesController : Controller
    {
        private readonly ILogger<MessagesController> _logger;
        private readonly MessagesDbContext db;
        private int LINKS_PREFIX = 970000000;

        public MessagesController(ILogger<MessagesController> logger, MessagesDbContext _db)
        {
            _logger = logger;
            db = _db;
        }

        [HttpGet]
        [Route("[controller]/{CardID}/all_received")]
        public async Task<IActionResult> GetAllAsync([FromRoute] int CardID)
        {
            try
            {
                int _ReceiverNr = CardID + LINKS_PREFIX;
                var _Messages = await db.Messages.Where(m => m.ReceiverNr == _ReceiverNr).ToListAsync();
                return _Messages==null?NotFound("nothing to show"):Ok(_Messages);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return Problem(ex.ToString());
            }
        }

        [HttpGet]
        [Route("[controller]/{CardID}/received/{MessageID}")]
        public async Task<IActionResult> GetOneAsync([FromRoute] int CardID, [FromRoute] int MessageID)
        {
            try
            {
                int _ReceiverNr = CardID + LINKS_PREFIX;
                var _Message = await db.Messages.SingleOrDefaultAsync(m => m.Id == MessageID);
                return (_Message == null || _Message.ReceiverNr != _ReceiverNr) ? BadRequest() : Ok(_Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return Problem(ex.ToString());
            }
        }

        [HttpPost]
        [Route("[controller]/{CardID}/new")]
        public async Task<IActionResult> NewPostAsync([FromRoute] int CardID, [FromBody] Message msg)
        {
            try
            {
                int _nr = CardID + LINKS_PREFIX;
                msg.SenderNr = _nr;
                db.Messages.Add(msg);
                await db.SaveChangesAsync();
                return Ok(msg);


            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return Problem(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("[controller]/{CardID}/delete/{MessageID}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int CardID, [FromRoute] int MessageID)
        {
            try
            {
                int _nr = CardID + LINKS_PREFIX;
                var _Message = await db.Messages.SingleOrDefaultAsync(m => m.Id == MessageID);
                if (_Message == null || _Message.ReceiverNr != _nr) return BadRequest();
                db.Messages.Remove(_Message);
                await db.SaveChangesAsync();
                return NoContent();


            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return Problem(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("[controller]/{CardID}/delete_all")]
        public async Task<IActionResult> DeleteALLAsync([FromRoute] int CardID)
        {
            try
            {
                int _nr = CardID + LINKS_PREFIX;
                var _Messages = await db.Messages.Where(m => m.ReceiverNr == _nr).ToListAsync();
                if (_Messages == null) return BadRequest();
                db.Messages.RemoveRange(_Messages);
                await db.SaveChangesAsync();
                return NoContent();


            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return Problem(ex.ToString());
            }
        }
    }
}
