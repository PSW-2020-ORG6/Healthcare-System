using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace IntegrationAdapters.Services
{
    public class HttpFTService
    {
        public bool UploadFile(string fileName)
        {
            try
            {
                WebClient client = new WebClient();
                Uri uri = new Uri(@"http://localhost:8082/myapp/upload");
                client.Credentials = CredentialCache.DefaultCredentials;
                client.UploadFile(uri, "POST", fileName);
                client.Dispose();
                return true; 
            }
            catch (Exception err)
            {
                return false;
            }
        }
    }
}
