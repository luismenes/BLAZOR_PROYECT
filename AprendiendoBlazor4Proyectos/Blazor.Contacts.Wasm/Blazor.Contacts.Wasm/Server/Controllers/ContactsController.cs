using Blazor.Contacts.Wasm.Repositories;
using Blazor.Contacts.Wasm.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.Contacts.Wasm.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactsController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        //Insert
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Contact contact)
        {
            if (contact == null)
            {
                return BadRequest();
            }

            if (string.IsNullOrEmpty(contact.FirsName))
            {
                ModelState.AddModelError("FirsName", "No puede ser vacio FirsName");
            }
            if (string.IsNullOrEmpty(contact.LastName))
            {
                ModelState.AddModelError("LastName", "No puede ser vacio LastName");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _contactRepository.InsertContact(contact);

            return NoContent();
        }

        //Update
        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(long Id, [FromBody] Contact contact)
        {
            if (contact == null)
            {
                return BadRequest();
            }

            if (string.IsNullOrEmpty(contact.FirsName))
            {
                ModelState.AddModelError("FirsName", "No puede ser vacio FirsName");
            }
            if (string.IsNullOrEmpty(contact.LastName))
            {
                ModelState.AddModelError("LastName", "No puede ser vacio LastName");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _contactRepository.UpdateContact(contact);

            return NoContent();
        }

        //Lista
        [HttpGet]
        public async Task<IEnumerable<Contact>> Get()
        {
            return await _contactRepository.GetAll();
        }

        [HttpGet("{Id}")]
        public async Task<Contact> Get(long Id)
        {
            return await _contactRepository.GetDetails(Id);
        }


        [HttpDelete("{Id}")]
        public async Task Delete(long Id)
        {
            await _contactRepository.DeleteContact(Id);
        }

    }
}
