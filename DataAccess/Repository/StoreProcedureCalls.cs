using BookShop.DataAccess.Data;
using Dapper;
using DataAccess.Repository.IRepository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repository
{
    public class StoreProcedureCalls : IStoreProcedure
    {
        private readonly ApplicationDbContext _dbcontext;
        private static string connectionString = String.Empty;

        public StoreProcedureCalls(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
            connectionString = dbcontext.Database.GetDbConnection().ConnectionString;
        }

        public void Dispose()
        {
            _dbcontext.Dispose();
        }

        //store procedure to update
        public void Execute(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                sqlConnection.Execute(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        //To retrieve all the categories
        public IEnumerable<T> List<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                return sqlConnection.Query<T>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        // To retrieve two Tables
        public Tuple<IEnumerable<T1>, IEnumerable<T2>> List<T1, T2>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                var result = SqlMapper.QueryMultiple(sqlConnection, procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
                var item1 = result.Read<T1>().ToList();
                var item2 = result.Read<T2>().ToList();

                if(item1!=null && item2!= null)
                {
                    return new Tuple<IEnumerable<T1>, IEnumerable<T2>>(item1, item2);

                }

                return new Tuple<IEnumerable<T1>, IEnumerable<T2>>(new List<T1>(), new List<T2>());
            }
        }

        // To retrieve one complete record or row
        public T OneRecord<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                var value = sqlConnection.Query<T>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);

                return (T)Convert.ChangeType(value.FirstOrDefault(), typeof(T));

            }
        }


        //to return first column from the first row
        public T Single<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                return (T)Convert.ChangeType(sqlConnection.ExecuteScalar<T>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure), typeof(T));
            }
        }
    }
}
