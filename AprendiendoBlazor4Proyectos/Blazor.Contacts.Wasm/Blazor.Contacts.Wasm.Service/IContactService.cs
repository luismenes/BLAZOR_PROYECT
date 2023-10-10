using Blazor.Contacts.Wasm.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Contacts.Wasm.Service
{
    public interface IContactService
    {
        Task SaveContact(Contact contact);
        Task DeleteContact(long Id);
        Task<IEnumerable<Contact>> GetAll();
        Task<Contact> GetDetails(long Id);
    }
}
