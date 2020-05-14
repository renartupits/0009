using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain;
using Webapp.Data;

namespace Webapp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactTypesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ContactTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ContactTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactType>>> GetContactTypes()
        {
            return await _context.ContactTypes.ToListAsync();
        }

        // GET: api/ContactTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactType>> GetContactType(string id)
        {
            var contactType = await _context.ContactTypes.FindAsync(id);

            if (contactType == null)
            {
                return NotFound();
            }

            return contactType;
        }

        // PUT: api/ContactTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactType(string id, ContactType contactType)
        {
            if (id != contactType.ContactTypeId)
            {
                return BadRequest();
            }

            _context.Entry(contactType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ContactTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ContactType>> PostContactType(ContactType contactType)
        {
            _context.ContactTypes.Add(contactType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ContactTypeExists(contactType.ContactTypeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetContactType", new { id = contactType.ContactTypeId }, contactType);
        }

        // DELETE: api/ContactTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ContactType>> DeleteContactType(string id)
        {
            var contactType = await _context.ContactTypes.FindAsync(id);
            if (contactType == null)
            {
                return NotFound();
            }

            _context.ContactTypes.Remove(contactType);
            await _context.SaveChangesAsync();

            return contactType;
        }

        private bool ContactTypeExists(string id)
        {
            return _context.ContactTypes.Any(e => e.ContactTypeId == id);
        }
    }
}
