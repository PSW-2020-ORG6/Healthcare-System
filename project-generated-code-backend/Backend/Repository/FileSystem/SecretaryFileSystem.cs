// File:    SecretaryFileSystem.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class SecretaryFileSystem

using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Repository.Generic;
using Newtonsoft.Json;

namespace HealthClinicBackend.Backend.Repository.FileSystem
{
    public class SecretaryFileSystem : GenericFileSystem<Secretary>, ISecretaryRepository
    {
        public SecretaryFileSystem()
        {
            path = @"./../../../../project-generated-code-backend/data/secretaries.txt";
            path = @"./../../data/secretaries.txt";

        }
        public override Secretary Instantiate(string objectStringFormat)
        {
            return JsonConvert.DeserializeObject<Secretary>(objectStringFormat);
        }
    }
}