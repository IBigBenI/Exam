using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Exam.Models;


namespace Exam.Data
{
    public class Database
    {
        readonly SQLiteAsyncConnection database;

        public Database(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Records>().Wait();
        }

        public Task<List<Records>> GetRecordsAsync()
        {
            return database.Table<Records>().ToListAsync();
        }

        public Task<Records> GetRecordsAsync(int id)
        {
            return database.Table<Records>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveRecordsAsync(Records records)
        {
            if (records.ID != 0)
            {
                return database.UpdateAsync(records);
            }
            else
            {
                return database.InsertAsync(records);
            }
        }

        public Task<int> DeleteRecordsAsync(Records records)
        {
            return database.DeleteAsync(records);
        }
    }
}
