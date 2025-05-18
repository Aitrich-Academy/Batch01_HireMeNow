using Domain.Helpers;
using Domain.Models;
using Domain.Services.JobProvider.Dtos;
using Domain.Services.JobProvider.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.JobProvider.Interfaces
{
	public interface ICompanyService
	{
		Task<JobProviderCompany> AddCompany(CompanyRegistrationDtos data, Guid UserId);

        GetCompanyDetailsDto GetCompany(Guid companyId);
		Task<JobProviderCompany> UpdateAsync(CompanyUpdateDtos company);
		bool memberDeleteById(Guid id);

		Task<CompanyMemberDtos> addMember(CompanyMemberDtos companyMember, Guid companyId);

        Task<bool> DeleteCompanyAsync(Guid companyId);
        Task<List<GetCompanyDetailsDto>> GetAllCompaniesAsync();

    }
}
