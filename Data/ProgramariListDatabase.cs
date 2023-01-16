using System;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProiectAEMobile.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectAEMobile.Data
{
    public class ProgramariListDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public ProgramariListDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<ProgramariList>().Wait();
        }
        public Task<List<ProgramariList>> GetProgramariListsAsync()
        {
            return _database.Table<ProgramariList>().ToListAsync();
        }
        public Task<ProgramariList> GetProgramariListAsync(int id)
        {
            return _database.Table<ProgramariList>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveProgramariListAsync(ProgramariList slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteProgramariListAsync(ProgramariList slist)
        {
            return _database.DeleteAsync(slist);
        }
    }
}
