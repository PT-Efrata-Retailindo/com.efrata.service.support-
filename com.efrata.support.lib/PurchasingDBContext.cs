﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace com.efrata.support.lib
{
    public class PurchasingDBContext : IPurchasingDBContext
    {
        private readonly SqlConnection _connection;

        public PurchasingDBContext(string connectionString)
        {
            _connection = CreateConnection(connectionString);
            _connection.Open();
        }

        private SqlConnection CreateConnection(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException("connectionString Empty");
            }

            return new SqlConnection(connectionString);
        }

        public IDataReader ExecuteReader(string query, ICollection<SqlParameter> parameters)
        {


            SqlCommand command = new SqlCommand(query, _connection);
            foreach (var parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }

            return command.ExecuteReader();

        }
        public IDataReader ExecuteReader2(string query)
        {


            SqlCommand command = new SqlCommand(query, _connection);

            return command.ExecuteReader();
        }

    }
    public interface IPurchasingDBContext
    {
        IDataReader ExecuteReader(string query, ICollection<SqlParameter> parameters);
        IDataReader ExecuteReader2(string query);
    }
}
