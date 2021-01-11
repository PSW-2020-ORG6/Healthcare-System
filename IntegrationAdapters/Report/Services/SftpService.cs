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
        public SftpConfig config = new SftpConfig
        {
            Host = "192.168.0.116",
            Port = 22,
            Username = "tester",
            Password = "password"
        };
        public void GenerateFile(List<MedicineReport> medicineReports, string fileName)
        {
            string result = "";
            TextWriter tw = new StreamWriter(fileName);
            foreach (var s in medicineReports)
            {
                result += s.Date + "\n" + "----------------------" + "\n";
                foreach (var m in s.Dosage)
                    result += m.MedicineName + ": " + m.Amount + "\n";
                result += "\n\n";
            }
            tw.WriteLine(result);
            tw.Close();
        }

        public bool SendFile(string fileName)
        {

            using (var client = new SftpClient(config.Host, config.Port, config.Username, config.Password))
            {
                client.Connect();
                if (client.IsConnected)
                {
                    using (var fileStream = new FileStream(fileName, FileMode.Open))
                    {
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

        public bool DownloadFile(string fileName)
        {

            using (var client = new SftpClient(config.Host, config.Port, config.Username, config.Password))
            {
                client.Connect();
                if (client.IsConnected)
                {
                    using (var fileStream = new FileStream(fileName, FileMode.Create))
                    {
                        client.BufferSize = 4 * 1024;
                        client.DownloadFile(fileName, fileStream);
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

