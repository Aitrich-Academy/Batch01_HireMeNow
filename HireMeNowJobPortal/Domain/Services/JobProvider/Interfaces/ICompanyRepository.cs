using Domain.Helpers;
using Domain.Models;
using Domain.Services.JobProvider.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.JobProvider.Interfaces
{
    public interface ICompanyRepository
    {
        Task AddCompany(JobProviderCompany data, Guid UserId);
        JobProviderCompany GetCompany(Guid companyId);
        Task<JobProviderCompany> updateCompanyAsync(JobProviderCompany company);
        bool memberDeleteById(Guid id);

        Task<CompanyMemberDtos> AddMemberAsync(CompanyMemberDtos companyMember, Guid companyId);

        Task<bool> DeleteCompanyAsync(Guid companyId);
        Task<List<JobProviderCompany>> GetAllCompaniesAsync();

    }
}
