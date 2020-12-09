// File:    SecretaryRepository.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Interface SecretaryRepository

using HealthClinicBackend.Backend.Model.Accounts;

namespace HealthClinicBackend.Backend.Repository.Generic
{
    public interface ISecretaryRepository : IGenericRepository<Secretary>
    {
    }
}