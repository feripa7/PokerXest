using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace PokerXestWPF.Repositories
{
    public abstract class RepositoryBase
    {
        private readonly string _connectionString;
        public RepositoryBase()
        {
            _connectionString = "Data Source=pokerXestDbEntregas.db;";
        }

        protected SqliteConnection GetConnection() 
        {
            return new SqliteConnection(_connectionString);
        }
    }
}
