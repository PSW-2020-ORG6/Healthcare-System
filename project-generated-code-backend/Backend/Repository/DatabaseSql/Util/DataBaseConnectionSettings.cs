namespace HealthClinicBackend.Backend.Repository.DatabaseSql.Util
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
        }

        public string ConnectionString =>
            $"userid={User};password={Password};server={Host};port={Port};database={Database}";
    }
}