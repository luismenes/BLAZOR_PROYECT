using Blazor.Contacts.Wasm.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Contacts.Wasm.Service
{
    public class ContactService : IContactService
    {
        private readonly HttpClient _httpClient;

        public ContactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task DeleteContact(long Id)
        {
            await _httpClient.DeleteAsync($"api/Contacts/{Id}");
        }

        public async Task<IEnumerable<Contact>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Contact>>($"api/Contacts");
        }

        public async Task<Contact> GetDetails(long Id)
        {
            return await _httpClient.GetFromJsonAsync<Contact>($"api/Contacts/{Id}");

        }

        public async Task SaveContact(Contact contact)
        {
            if (contact.Id == 0)
            {
                await _httpClient.PostAsJsonAsync<Contact>($"api/Contacts", contact);
            }
            else
            {
                await _httpClient.PutAsJsonAsync<Contact>($"api/Contacts/{contact.Id}", contact);
            }
        }
    }
}
