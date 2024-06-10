using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SQLServer
{
    public static class SeedData
    {

        public static void InitSeedData(string db)
        {
            try
            {
                string createTable = "create table dbo.records(\r\n[Id] int identity primary key, \r\n[name] nvarchar(255) not null\r\n)";

                using (var connection = new SqlConnection(db))
                {
                    connection.Open();
                    using (var command = new SqlCommand(createTable, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("erro:", ex.ToString());
            }
            
        }
    }
}
