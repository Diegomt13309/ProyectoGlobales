using Lesconario.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LESCOnario.Services
{
    public class DataBaseStoreCurso
    {
        readonly SQLiteAsyncConnection database;
        List<CursoxProfe> all = new List<CursoxProfe>();
        //List<Curso> aux = new List<Curso>();

        public DataBaseStoreCurso(string dbPath)
        {
            //aux = new List<Curso>();
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<CursoxProfe>().Wait();
        }

        public Task<int> SaveNoteAsync(CursoxProfe note)
        {
            //if (aux.Count > 0)
            //{
                // Save a new note.
                return database.InsertAsync(note);
            //}
            //else
            //{

                // Update an existing note.
                //return database.UpdateAsync(note);
            //}
        }

        public Task<int> DeleteNoteAsync(CursoxProfe note)
        {
            // Delete a note.
            return database.DeleteAsync(note);
        }

        private async void addList()
        {
            all = await database.QueryAsync<CursoxProfe>("select * from CursoxProfe");
        }

        public List<CursoxProfe> getList()
        {
            addList();
            return all;
        }

       /* public async void findId(int id)
        {
            aux = await database.QueryAsync<Curso>("select * from Curso where id = " + id);
        }*/

    }
}
