using System;
using System.Collections.Generic;
using System.Configuration;
using IntegrationAdapters;
using IntegrationAdapters.Models;
using IntegrationAdapters.Repositories;
using IntegrationAdapters.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace IntegrationAdaptersTests
{
    public class RegisterHospitalTests
    {
        public Mock<IApiRepository> mock;

        [Fact]
        public void Is_pharmacy_already_existing_on_hospital()
        {          
            ApiService service = new ApiService();

            Api registerFailed = new Api("k", "k", "k");
            bool alreadyExists = service.RegisterHospitalOnPharmacy(registerFailed);

            Assert.False(alreadyExists);
        }

        [Fact]
        public void Is_pharmacy_not_existing_on_hospital()
        {
            ApiService service = new ApiService();

            Api registerSuccessful = new Api("l", "l", "l");
            bool notExists = service.RegisterHospitalOnPharmacy(registerSuccessful);

            Assert.True(notExists);
        }   

        [Fact]
        public void Find_existing_api()
        {
            mock = new Mock<IApiRepository>();
            mock.Setup(expression: t => t.GetAllApis()).Returns(new List<Api> { new Api("12345678","pharmacyName","pharmacyUrl")});
            
            ApiService service = new ApiService();
            Api api = service.getApiByKey(mock.Object.GetAllApis(), "12345678");

            Assert.NotNull(api);
        }

        [Fact]
        public void Find_not_existing_api()
        {
            mock = new Mock<IApiRepository>();
            mock.Setup(expression: t => t.GetAllApis()).Returns(new List<Api> { new Api { Key = "1234567", PharmacyName = "pharmacyName1", Url = "pharmacyUrl1" } });
            
            ApiService service = new ApiService();
            Api api = service.getApiByKey(mock.Object.GetAllApis(),"23478");
           
            Assert.Null(api);
        }
    }
}
