using Lesconario.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LESCOnario.Services
{
    public class DataBaseStoreProfesor
    {
        readonly SQLiteAsyncConnection database;
        List<Profesor> all = new List<Profesor>();
        List<Profesor> aux = new List<Profesor>();

        public DataBaseStoreProfesor(string dbPath)
        {
            aux = new List<Profesor>();
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Profesor>().Wait();
        }

        public Task<Profesor> GetNoteAsync(string email, string password)
        {
            // Get a specific note.
            return database.Table<Profesor>()
                            .Where(i => i.email.Equals(email) || i.password.Equals(password))
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveNoteAsync(Profesor note)
        {
            if (aux.Count > 0)
            {
                // Update an existing note.
                return database.UpdateAsync(note);
            }
            else
            {
                // Save a new note.
                return database.InsertAsync(note);
            }
        }

        public Task<int> DeleteNoteAsync(Profesor note)
        {
            // Delete a note.
            return database.DeleteAsync(note);
        }

        private async void addList()
        {
            all = await database.QueryAsync<Profesor>("select * from Profesor");
        }

        public List<Profesor> getList()
        {
            addList();
            return all;
        }

        public async void findId(int id)
        {
            aux = await database.QueryAsync<Profesor>("select * from Profesor where id = " + id);
        }

    }
}
