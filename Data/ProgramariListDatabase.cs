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
            _database.CreateTableAsync<Serviciu>().Wait();
            _database.CreateTableAsync<ListServiciu>().Wait();
        }
        public Task<int> SaveProductAsync(Serviciu serviciu)
        {
            if (serviciu.ID != 0) 
            {
                return _database.UpdateAsync(serviciu);
            }
            else
            {
                return _database.InsertAsync(serviciu);
            }
        }
        public Task<int> DeleteProductAsync(Serviciu serviciu)
        {
            return _database.DeleteAsync(serviciu);
        }
        public Task<List<Serviciu>> GetProductsAsync()
        {
            return _database.Table<Serviciu>().ToListAsync();
        }
        public Task<int> DeleteListProductAsync(ListServiciu listp)
        {
            return _database.DeleteAsync(listp);
        }
        public Task<List<ListServiciu>> GetListProducts()
        {
            return _database.QueryAsync<ListServiciu>("select * from ListServiciu");
        }

        public Task<List<ProgramariList>> GetShopListsAsync()
        {
            return _database.Table<ProgramariList>().ToListAsync();
        }
        public Task<ProgramariList> GetShopListAsync(int id)
        {
            return _database.Table<ProgramariList>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveShopListAsync(ProgramariList slist)
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
        public Task<int> DeleteShopListAsync(ProgramariList slist)
        {
            return _database.DeleteAsync(slist);
        }
        public Task<int> SaveListProductAsync(ListServiciu listp)
        {
            if (listp.ID != 0)
            {
                return _database.UpdateAsync(listp);
            }
            else
            {
                return _database.InsertAsync(listp);
            }
        }
        public Task<List<Serviciu>> GetListProductsAsync(int shoplistid)
        {
            return _database.QueryAsync<Serviciu>(
            "select P.ID, P.Descriere from Serviciu P"
            + " inner join ListServiciu LP"
            + " on P.ID = LP.ServiciuID where LP.ServiciuListID = ?",
            shoplistid);
        }

    }

}
