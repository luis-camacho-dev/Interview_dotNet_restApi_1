using Application.Repositories;
using Domain.Entity;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SQLServer.Repositories
{
    public class RecordRepository : IRecordRepository
    {
        private DbContext _dbContext;
        public RecordRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Result<int> CreateRecord(Record newRecord)
        {
            try
            {
                int recordId;
                using (var sqlConnection = _dbContext.GetConnection())
                {
                    sqlConnection.Open();
                    using (var command = new SqlCommand("INSERT INTO dbo.records(name) values(@name);SELECT SCOPE_IDENTITY();", sqlConnection))
                    {
                        command.Parameters.Add(new SqlParameter("name", newRecord.Name));
                        recordId = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
                return Result.Ok<int>(recordId);
            }
            catch(Exception ex)
            {
                return Result.Fail<int>($"Unexpected error occurred while inserting Record with Name={newRecord.Name}");
            }
        }

        public Result DeleteRecord(int recordId)
        {
            try
            {
                using (var sqlConnection = _dbContext.GetConnection())
                {
                    sqlConnection.Open();
                    using (var command = new SqlCommand("delete from dbo.records where recordId=@recordId", sqlConnection))
                    {
                        command.Parameters.Add(new SqlParameter("recordId", recordId));
                        command.ExecuteNonQuery();
                    }
                }
                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail($"Unexpected error occurred while deleting a record with Id ={recordId}");
            }
        }

        public Result<List<Record>> GetAllRecords()
        {
            try
            {
                var records = new List<Record>();
                using (var sqlConnection = _dbContext.GetConnection())
                {
                    sqlConnection.Open();
                    using (var command = new SqlCommand("select * from dbo.records", sqlConnection))
                    {

                        using (var reader = command.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                records.Add(new Record()
                                {
                                    Id = reader.GetInt32(0),
                                    Name = reader.GetString(1),
                                });
                            }
                        }
                    }
                }
                return Result.Ok<List<Record>>(records);
            }
            catch (Exception ex)
            {
                return Result.Fail<List<Record>>($"Unexpected error occurred while getting all records");
            }
        }

        public Result<Record> GetRecord(int recordId)
        {
            try
            {
                Record record = null;
                using (var sqlConnection = _dbContext.GetConnection())
                {
                    sqlConnection.Open();
                    using (var command = new SqlCommand("select * from dbo.records where Id=@recordId", sqlConnection))
                    {
                        command.Parameters.Add(new SqlParameter("recordId", recordId));

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                record = new Record()
                                {
                                    Id = reader.GetInt32(0),
                                    Name = reader.GetString(1),
                                };
                            }
                        }
                    }
                }
                if (record == null)
                {
                    return Result.Ok<Record>(record);
                }
                return Result.Fail<Record>($"Record with Identifier={recordId} does not Exists");
            }
            catch (Exception ex)
            {
                return Result.Fail<Record>($"Unexpected error Occurred with Identifier={recordId}.");
            }
        }

        public Result UpdateRecord(Record newRecord)
        {
            try
            {
                using (var sqlConnection = _dbContext.GetConnection())
                {
                    sqlConnection.Open();
                    using (var command = new SqlCommand("update dbo.record set recordId=@recordId,Name=@name", sqlConnection))
                    {
                        command.Parameters.Add(new SqlParameter("recordId", newRecord.Id));
                        command.Parameters.Add(new SqlParameter("name", newRecord.Name));
                        command.ExecuteNonQuery();
                    }
                }
                return Result.Ok();
            }
            catch(Exception ex)
            {
                return Result.Fail($"Unexpected error occurred while updating the Record={newRecord.Id}");
            }
        }
    }
}
