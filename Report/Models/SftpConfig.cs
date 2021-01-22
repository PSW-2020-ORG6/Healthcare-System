using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Report.Models
{
    public class SftpConfig
    {
        private string host { get; set; }
        private int port { get; set; }
        private string username { get; set; }
        private string password { get; set; }

        public string Host
        {
            get { return host; }
            private set { host = value; }
        }

        public int Port
        {
            get { return port; }
            private set { port = value; }
        }

        public string Username
        {
            get { return username; }
            private set { username = value; }
        }

        public string Password
        {
            get { return password; }
            private set { password = value; }
        }
    }
}
