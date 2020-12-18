using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinicBackend.Backend.Repository
{
    public class DataBaseConnectionSettings
    {
        public string Host { get; set; }
        public string Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }
        public int RetryCount { get; set; }
        public int RetryWaitInSeconds { get; set; }

        public DataBaseConnectionSettings()
        {
            Host = "localhost";
            User = "postgres";
            Password = "super";
            Port = "5432";
            Database = "healthcare-system-db";
        }

        public string ConnectionString =>
            $"server={Host} ;userid={User}; pwd={Password};"
            + $"port={Port}; database={Database}";
    }
}