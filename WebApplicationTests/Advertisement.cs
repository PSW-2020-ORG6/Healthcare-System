﻿using Moq;
using System;
using System.Collections.Generic;
using System.Text;
//using HealthClinicBackend.Backend.Model.PharmacySupport;
//using HealthClinicBackend.Backend.Repository.Generic;
using Xunit;
using MicroServiceAccount.Backend.Service;
using MicroServiceAccount.Backend.Model;
using MicroServiceAccount.Backend.Repository.Generic;

namespace WebApplicationTests
{
    public class Advertisement
    {
        List<ActionAndBenefitMessage> actionAndBenefitMessages = new List<ActionAndBenefitMessage>();

        [Fact]
        public void Advertisements()
        {
            var patientRepository = new Mock<IPatientRepository>();
            var actionsAndBenefitsRepository = new Mock<IActionAndBenefitMessageRepository>();
            var addressRepository = new Mock<IAddressRepository>();

            actionAndBenefitMessages.Add(new ActionAndBenefitMessage
            {
                DateFrom = new DateTime(2020, 12, 5), DateTo = new DateTime(2021, 12, 5), Text = "Health",
                PharmacyName = "Health"
            });
            actionsAndBenefitsRepository.Setup(m => m.GetAll()).Returns(actionAndBenefitMessages);

            PatientService service = new PatientService(patientRepository.Object, actionsAndBenefitsRepository.Object,addressRepository.Object);

            List<ActionAndBenefitMessage> list = service.GetAdvertisements();

            Assert.NotNull(list);
        }

        [Fact]
        public void No_advertisements()
        {
            var patientRepository = new Mock<IPatientRepository>();
            var actionsAndBenefitsRepository = new Mock<IActionAndBenefitMessageRepository>();
            var addressRepository = new Mock<IAddressRepository>();


            actionAndBenefitMessages.Add(new ActionAndBenefitMessage
            {
                DateFrom = new DateTime(2020, 12, 5), DateTo = new DateTime(2020, 12, 9), Text = "Health",
                PharmacyName = "Health"
            });
            actionsAndBenefitsRepository.Setup(m => m.GetAll())
                .Returns(actionAndBenefitMessages);

            PatientService service = new PatientService(patientRepository.Object, actionsAndBenefitsRepository.Object,addressRepository.Object);

            List<ActionAndBenefitMessage> list = service.GetAdvertisements();

            Assert.Empty(list);
        }
    }
}