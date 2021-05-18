namespace LESCOnario.Services
{
    using Lesconario.Models;
    using SQLite;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public class DataBaseStoreCourse
    {

        readonly SQLiteAsyncConnection database;

        public DataBaseStoreCourse(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Course>().Wait();
        }

        public Task<List<Course>> NotesAsync =>
            //Get all notes.
            database.Table<Course>().ToListAsync();

        public Task<Course> GetNoteAsync(string name, string code)
        {
            // Get a specific note.
            return database.Table<Course>()
                            .Where(i => i.Name.Equals(name) || i.Code.Equals(code))
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveNoteAsync(Course note)
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

        public Task<int> DeleteNoteAsync(Course note)
        {
            // Delete a note.
            return database.DeleteAsync(note);
        }
    }
}