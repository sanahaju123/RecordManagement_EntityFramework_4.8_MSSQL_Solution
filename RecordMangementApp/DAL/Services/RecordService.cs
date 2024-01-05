using RecordManagementApp.DAL.Interrfaces;
using RecordManagementApp.DAL.Services.Repository;
using RecordManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace RecordManagementApp.DAL.Services
{
    public class RecordService : IRecordService
    {
        private readonly IRecordRepository _repository;

        public RecordService(IRecordRepository repository)
        {
            _repository = repository;
        }

        public Task<Record> CreateRecord(Record record)
        {
            return _repository.CreateRecord(record);
        }

        public Task<bool> DeleteRecordById(long id)
        {
            return _repository.DeleteRecordById(id);
        }

        public List<Record> GetAllRecords()
        {
            return _repository.GetAllRecords();
        }

        public Task<Record> GetRecordById(long id)
        {
            return _repository.GetRecordById(id); ;
        }

        public Task<Record> UpdateRecord(Record model)
        {
            return _repository.UpdateRecord(model);
        }
    }
}