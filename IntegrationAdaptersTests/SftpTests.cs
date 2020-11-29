using IntegrationAdapters.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IntegrationAdaptersTests
{
    public class SftpTests
    {
        [Fact]
        public void sendFileSuccess()
        {  
            SftpService service = new SftpService();
            bool success = service.SendFile(@"C:\Users\dragana\Desktop\Projekat PSW\Healthcare-System\IntegrationAdaptersTests\bin\Debug\netcoreapp3.1\testFile.txt");
            Assert.True(success);   
        }
    }
}
