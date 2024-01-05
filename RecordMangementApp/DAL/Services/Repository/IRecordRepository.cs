using RecordManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordManagementApp.DAL.Services.Repository
{
    public interface IRecordRepository
    {
        List<Record> GetAllRecords();
        Task<Record> CreateRecord(Record record);
        Task<Record> GetRecordById(long id);
        Task<bool> DeleteRecordById(long id);
        Task<Record> UpdateRecord(Record model);
    }
}

