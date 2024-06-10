using Domain.Entity;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IRecordRepository
    {
        public Result<int> CreateRecord(Record newRecord);

        public Result UpdateRecord(Record newRecord);

        public Result DeleteRecord(int recordId);

        public Result<Record> GetRecord(int recordId);

        public Result<List<Record>> GetAllRecords();

    }
}
