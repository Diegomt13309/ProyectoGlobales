using Lesconario.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lesconario.Services
{
    public class DataBaseStoreUser
    {
        readonly SQLiteAsyncConnection database;

        public DataBaseStoreUser(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<User>().Wait();
        }

        public Task<List<User>> NotesAsync =>
            //Get all notes.
            database.Table<User>().ToListAsync();

        public Task<User> GetNoteAsync(string email, string password)
        {
            // Get a specific note.
            return database.Table<User>()
                            .Where(i => i.Email.Equals(email) || i.Password.Equals(password))
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveNoteAsync(User note)
        {
            if (note.ID != 0)
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

        public Task<int> DeleteNoteAsync(User note)
        {
            // Delete a note.
            return database.DeleteAsync(note);
        }

    }
}
