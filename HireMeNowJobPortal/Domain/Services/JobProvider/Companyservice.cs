using AutoMapper;
//using Domain.Helpers;
using Domain.Models;
using Domain.Service.JobProvider.Dtos;
using Domain.Service.JobProvider.DTOs;
using Domain.Service.JobProvider.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.JobProvider
{
    public class Companyservice : ICompanyService
    {
        IMapper mapper;
        ICompanyRepository companyRepository;

        public Companyservice(IMapper _mapper, ICompanyRepository _companyRepository)
        {
            mapper = _mapper;
            companyRepository = _companyRepository;
        }


        public async Task<JobProviderCompany> AddCompany(CompanyRegistrationDtos data, Guid UserId)

        {
            var jobproviderCompany = mapper.Map<JobProviderCompany>(data);
            await companyRepository.AddCompany(jobproviderCompany, UserId);


            return jobproviderCompany;

        }



        public GetCompanyDetailsDto GetCompany(Guid companyId)
        {
            var company = companyRepository.GetCompany(companyId);
            var getCompanyDetailsDto = mapper.Map<GetCompanyDetailsDto>(company);
            return getCompanyDetailsDto;
        }
        public async Task<JobProviderCompany> UpdateAsync(CompanyUpdateDtos company)
        {
            JobProviderCompany jobProviderCompany = mapper.Map<JobProviderCompany>(company);
            var jobProviderUpdatedCompany = await companyRepository.updateCompanyAsync(jobProviderCompany);
            return jobProviderUpdatedCompany;
        }


        public bool memberDeleteById(Guid id)
        {
            return companyRepository.memberDeleteById(id);
        }

        public async Task<CompanyMemberDtos> addMember(CompanyMemberDtos companyMember, Guid companyId)
        {
            return await companyRepository.AddMemberAsync(companyMember, companyId);
        }

        public async Task<bool> DeleteCompanyAsync(Guid companyId)
        {
            return await companyRepository.DeleteCompanyAsync(companyId);
        }

        public async Task<List<GetCompanyDetailsDto>> GetAllCompaniesAsync()
        {
            var companies = await companyRepository.GetAllCompaniesAsync();
            return mapper.Map<List<GetCompanyDetailsDto>>(companies);
        }

    }
}
