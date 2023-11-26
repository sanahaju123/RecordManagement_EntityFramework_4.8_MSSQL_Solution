using RecordManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace RecordManagementApp.DAL.Services.Repository
{
    public class RecordRepository : IRecordRepository
    {
        private readonly DatabaseContext _dbContext;
        public RecordRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<Record> CreateRecord(Record expense)
        {
            try
            {
                var result =  _dbContext.Records.Add(expense);
                await _dbContext.SaveChangesAsync();
                return expense;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<bool> DeleteRecordById(long id)
        {
            try
            {
                _dbContext.Records.Remove(_dbContext.Records.Single(a => a.RecordId == id));
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<Record> GetAllRecords()
        {
            try
            {
                var result = _dbContext.Records.ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Record> GetRecordById(long id)
        {
            try
            {
                return await _dbContext.Records.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

      
        

        public async Task<Record> UpdateRecord(Record model)
        {
            var ex = await _dbContext.Records.FindAsync(model.RecordId);
            try
            {
                await _dbContext.SaveChangesAsync();
                return ex;
            }
            catch (Exception exc)
            {
                throw (exc);
            }
        }
    }
}