using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Net;
using Links_Clients.Models;
using Links_Clients.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Microsoft.AspNetCore.JsonPatch;

namespace Links_Clients.Controllers
{
    [ApiController]
    [Route("Clients")]
    public class InternalController : ControllerBase
    {
        
        private readonly ILogger<InternalController> _logger;
        private readonly IMapper mapper;
        private readonly ClientsDbContext db;

        public InternalController(ILogger<InternalController> logger, IMapper _mapper, ClientsDbContext _db)
        {
            _logger = logger;
            mapper = _mapper;
            db = _db;
        }

        [HttpGet]
        [Route("[controller]/all")]
        public async Task<IActionResult> GetAsyncClients()
        {
            try
            {
                var _clients = await db.Clients.ToListAsync();
                var clients = mapper.Map<IEnumerable<Client_Internal>>(_clients);
                return Ok(clients);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return Problem(ex.ToString());
            }
            
        }

        [HttpGet]
        [Route("[controller]/{id}")]
        public async Task<IActionResult> GetAsyncClient(int id)
        {
            try
            {
                var _client = await db.Clients.SingleOrDefaultAsync(i => i.Id == id);
                if(_client == null)
                    return NotFound();
                var client = mapper.Map<Client_Internal>(_client);
                return Ok(client);
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
        public async Task<IActionResult> PostAsyncNewClient(Client_Internal _client)
        {
            try
            {
                var newClient = mapper.Map<Client_Raw>(_client);
                db.Clients.Add(newClient);
                await db.SaveChangesAsync();
                _client.Id= newClient.Id;
                return Created($"/internal/new", _client);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());

                return Problem(ex.ToString());
            }
        }

        [HttpPut]
        [Route("[controller]/update/{id}")]
        public async Task<IActionResult> PutAsyncClient(int id, Client_Internal _client)
        {
            try
            {
                var client = await db.Clients.FirstOrDefaultAsync(c => c.Id == id);
                if (client == null) return BadRequest();
                mapper.Map(_client, client);
                await db.SaveChangesAsync();
                _client = mapper.Map<Client_Internal>(client);
                return Ok(_client);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());

                return Problem(ex.ToString());
            }
        }

        [HttpPatch]
        [Route("[controller]/edit/{id}")]
        public async Task<IActionResult> PatchAsyncClient([FromRoute]int id, [FromBody]JsonPatchDocument<Client_Internal> value)
        {
            try
            {
                var _client = await db.Clients.FirstOrDefaultAsync(c =>c.Id == id);
                if (_client == null) return BadRequest();
                var client = mapper.Map<Client_Internal>(_client);
                value.ApplyTo(client);
                mapper.Map(client, _client);
                await db.SaveChangesAsync();
                return Ok(client);


            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());

                return Problem(ex.ToString());
            }

        }

        [HttpDelete]
        [Route("[controller]/delete/{id}")]
        public async Task<IActionResult> DeleteAsyncClient(int id)
        {
            try
            {
                var _client = await db.Clients.FirstOrDefaultAsync(c => c.Id == id);
                if (_client == null) return BadRequest();
                db.Clients.Remove(_client);
                await db.SaveChangesAsync();
                return Ok(_client);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());

                return Problem(ex.ToString());
            }
        }

        [HttpPut]
        [Route("[controller]/activate/{id}")]
        public async Task<IActionResult> ActivateAsyncClient(int id)
        {
            // how can I include confirmation here, does it even make sense ??
            try
            {
                var _client = await db.Clients.FirstOrDefaultAsync(c => c.Id == id);
                if (_client == null) return BadRequest();
                else if (_client.Active) return Ok("Client already active");
                _client.Active = true;
                await db.SaveChangesAsync();
                return Ok(_client);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());

                return Problem(ex.ToString());
            }
        }

    }
}