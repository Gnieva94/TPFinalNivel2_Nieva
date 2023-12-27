using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataBase
{
    public class Conection
    {
        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _reader;
        public SqlDataReader Reader { get { return _reader; } }

        public Conection()
        {
            _connection = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_DB; integrated security=true");
            _command = new SqlCommand();
        }

        public void SetQuery(string query)
        {
            _command.CommandType = System.Data.CommandType.Text;
            _command.CommandText = query;
        }
        public void ExecuteQuery()
        {
            _command.Connection = _connection;
            try
            {
                _connection.Open();
                _reader = _command.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool ExecuteAction()
        {
            _command.Connection = _connection;
            try
            {
                _connection.Open();

                var state = _command.ExecuteNonQuery() > 0;
                return state;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void SetParameter(string parameter, object value)
        {
            _command.Parameters.AddWithValue(parameter, value);
        }
        public void CloseConnection()
        {
            try
            {
                if(Reader != null)
                {
                    _reader.Close();
                }
                _connection.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
