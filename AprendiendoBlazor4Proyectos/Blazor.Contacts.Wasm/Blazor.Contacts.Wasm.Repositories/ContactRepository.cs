using Blazor.Contacts.Wasm.Shared;
using Blazor.Contacts.Wasm.Shared.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Contacts.Wasm.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly IDbConnection _DbConnection;

        // De esta forma se Injecta la conexion en las clases
        public ContactRepository(IDbConnection dbConnection)
        {
            _DbConnection = dbConnection;
        }

        public Task DeleteContact(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Contact>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Contact> GetDetails(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertContact(Contact contact)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateContact(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}
