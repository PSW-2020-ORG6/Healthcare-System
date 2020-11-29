using IntegrationAdapters.Models;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Services
{
    public class SftpService : ISftpService
    {
        public void GenerateFile(List<MedicineReport> medicineReports, string fileName)
        {
            string result = "";
            TextWriter tw = new StreamWriter(fileName);
            foreach (var s in medicineReports)
            {
                result += s.Id;
                foreach (var m in s.dosage)
                    result += " " + m.Amount + " ";
                tw.Flush();
                tw.WriteLine(result);

            }
            tw.Close();
        }

        public bool SendFile(string fileName)
        {
            SftpConfig config = new SftpConfig
            {
                Host = "192.168.100.4",
                Port = 22,
                Username = "tester",
                Password = "password"
            };

            using (var client = new SftpClient(config.Host, config.Port, config.Username, config.Password))
            {
                client.Connect();
                if (client.IsConnected)
                {
                    using (var fileStream = new FileStream(fileName, FileMode.Open))
                    {
                        client.BufferSize = 4 * 1024;
                        client.UploadFile(fileStream, Path.GetFileName(fileName));
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }


}

