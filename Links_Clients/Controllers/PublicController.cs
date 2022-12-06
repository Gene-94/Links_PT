using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Net;
using Links_Clients.Models;
using Links_Clients.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Microsoft.AspNetCore.JsonPatch;
using System;

namespace Links_Clients.Controllers
{
    [ApiController]
    [Route("Clients")]
    public class PublicController : ControllerBase
    {
        
        private readonly ILogger<PublicController> _logger;
        private readonly IMapper mapper;
        private readonly ClientsDbContext db;

        public PublicController(ILogger<PublicController> logger, IMapper _mapper, ClientsDbContext _db)
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
                var _clients = await db.Clients.Where(i =>  i.Active == true).ToListAsync();
                var clients = mapper.Map<IEnumerable<Client_Public>>(_clients);
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
                var _client = await db.Clients.SingleOrDefaultAsync(i => i.Id == id && i.Active == true);
                if(_client == null)
                    return NotFound();
                var client = mapper.Map<Client_Public>(_client);
                return Ok(client);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return Problem(ex.ToString());
            }
        }

        [HttpPost]
        [Route("[controller]/new")]
        public async Task<IActionResult> PostAsyncNewClient(Client_Public _client)
        {
            try
            {
                var newClient = mapper.Map<Client_Raw>(_client);
                db.Clients.Add(newClient);
                await db.SaveChangesAsync();
                _client.Id= newClient.Id;
                return Ok(_client);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());

                return Problem(ex.ToString());
            }
        }

        [HttpPut]
        [Route("[controller]/update/{id}")]
        public async Task<IActionResult> PutAsyncClient(int id, Client_Public _client)
        {
            var client = await db.Clients.FirstOrDefaultAsync(c => c.Id == id && c.Active == true);
            if (client == null) return BadRequest();
            mapper.Map(_client, client);
            await db.SaveChangesAsync();
            _client = mapper.Map<Client_Public>(client);
            return Ok(_client);
        }

        [HttpPatch]
        [Route("[controller]/edit/{id}")]
        public async Task<IActionResult> PatchAsyncClient([FromRoute]int id, [FromBody]JsonPatchDocument<Client_Public> value)
        {
            try
            {
                var _client = await db.Clients.FirstOrDefaultAsync(c =>c.Id == id && c.Active == true);
                if (_client == null) return BadRequest();
                var client = mapper.Map<Client_Public>(_client);
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
            // how can I include confirmation here, does it even make sense ??
            try
            {
                var _client = await db.Clients.FirstOrDefaultAsync(c => c.Id == id && c.Active == true);
                if (_client == null) return BadRequest();
                _client.Active = false;
                await db.SaveChangesAsync();
                var simple = mapper.Map<Client_Simplified>(_client);
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