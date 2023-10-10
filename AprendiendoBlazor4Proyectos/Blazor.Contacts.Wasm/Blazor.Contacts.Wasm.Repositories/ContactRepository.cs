using Blazor.Contacts.Wasm.Shared;
using Blazor.Contacts.Wasm.Shared.Models;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
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

        /// <summary>
        /// Todos estos metodos se Utilizan con Dapper
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task DeleteContact(long Id)
        {
            var sql = @"DELETE FROM [Proceso].[Contacts] WHERE Id= @Id";
            var affectedRows = await _DbConnection.ExecuteAsync(sql, new { Id = Id });
        }

        public async Task<IEnumerable<Contact>> GetAll()
        {
            var sql = @"SELECT [Id]
                 ,[FirsName]
                 ,[LastName]
                 ,[Phone]
                 ,[Address]
             FROM [Proceso].[Contacts]";

            return await _DbConnection.QueryAsync<Contact>(sql, new { });
        }

        public async Task<Contact> GetDetails(long Id)
        {
            var sql = @"SELECT [Id]
                 ,[FirsName]
                 ,[LastName]
                 ,[Phone]
                 ,[Address]
             FROM [Proceso].[Contacts]  WHERE Id= @Id";

            return await _DbConnection.QueryFirstOrDefaultAsync<Contact>(sql, new { Id = Id });
        }

        public async Task<bool> InsertContact(Contact contact)
        {
            try
            {
                // Consulta SQL para la inserción
                var sql = @"INSERT INTO [Proceso].[Contacts]
                                        ([FirsName]
                                        ,[LastName]
                                        ,[Phone]
                                        ,[Address])
                                  VALUES
                                        (@FirsName
                                        ,@LastName
                                        ,@Phone
                                        ,@Address)";
                                
                // Ejecuta la consulta utilizando Dapper
                var affectedRows = await _DbConnection.ExecuteAsync(sql, new
                {
                    contact.FirsName,
                    contact.LastName,
                    contact.Phone,
                    contact.Address,
                });

                // Si se insertaron filas, considera la operación como exitosa
                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                // Manejo de errores aquí
                return false;
            }
        }

        public async Task<bool> UpdateContact(Contact contact)
        {
            try
            {
                // Consulta SQL para la inserción
                var sql = @"UPDATE [Proceso].[Contacts]
                             SET [FirsName] = @FirsName
                                ,[LastName] = @LastName
                                ,[Phone] = @Phone
                                ,[Address] = @Address
                           WHERE Id= @Id";

                // Ejecuta la consulta utilizando Dapper
                var affectedRows = await _DbConnection.ExecuteAsync(sql, new
                {
                    contact.FirsName,
                    contact.LastName,
                    contact.Phone,
                    contact.Address,
                    contact.Id,
                });

                // Si se insertaron filas, considera la operación como exitosa
                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                // Manejo de errores aquí
                return false;
            }
        }
    }
}
