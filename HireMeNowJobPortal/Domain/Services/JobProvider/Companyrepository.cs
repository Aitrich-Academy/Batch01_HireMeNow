using AutoMapper;
using Domain.Models;
using Domain.Service.JobProvider.Dtos;
using Domain.Service.JobProvider.DTOs;
using Domain.Service.JobProvider.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.JobProvider
{

    public class Companyrepository : ICompanyRepository
    {
        protected DbHireMeNowWebApiContext _context;
        public IMapper mapper { get; set; }
        public Companyrepository(DbHireMeNowWebApiContext context, IMapper _mapper)
        {
            _context = context;
            mapper = _mapper;
        }

        public async Task AddCompany(JobProviderCompany data, Guid UserId)
        {
            try
            {
                _context.JobProviderCompanies.AddAsync(data);
                await _context.SaveChangesAsync();
                var CmpanyId = data.Id;
                AuthUser user = _context.AuthUsers.Where(e => e.Id == UserId).FirstOrDefault();
                CompanyUser companyUser = new CompanyUser();
                var cmp = _context.CompanyUsers.Where(e => e.Id == UserId).FirstOrDefault();

                cmp.Company = CmpanyId;
                _context.CompanyUsers.Update(cmp);
                await _context.SaveChangesAsync();

                if (cmp == null)
                {
                    companyUser.Id = UserId;
                    companyUser.UserName = user.UserName;
                    companyUser.Email = user.Email;
                    companyUser.FirstName = user.FirstName;
                    companyUser.LastName = user.LastName;
                    companyUser.Phone = user.Phone;
                    companyUser.Role = Enums.Role.COMPANY_USER;
                    companyUser.Company = CmpanyId;
                    _context.CompanyUsers.AddAsync(companyUser);
                    await _context.SaveChangesAsync();
                }



            }
            catch (Exception ex)
            {

            }

        }
        public JobProviderCompany GetCompany(Guid companyId)
        {
            JobProviderCompany company = _context.JobProviderCompanies.Where(e => e.Id == companyId).FirstOrDefault();
            return company;

        }
        



        public async Task<JobProviderCompany> updateCompanyAsync(JobProviderCompany company)
        {
            var companyToUpdate = await _context.JobProviderCompanies
                .FirstOrDefaultAsync(e => e.Id == company.Id);

            if (companyToUpdate == null)
            {
                throw new FileNotFoundException("Company Not Found");
            }

            companyToUpdate.LegalName = company.LegalName ?? companyToUpdate.LegalName;
            companyToUpdate.Address = company.Address ?? companyToUpdate.Address;
            companyToUpdate.Email = company.Email ?? companyToUpdate.Email;
            companyToUpdate.Phone = company.Phone == null ? companyToUpdate.Phone : company.Phone;
            companyToUpdate.Website = company.Website ?? companyToUpdate.Website;

            if (company.IndustryId != Guid.Empty)
            {
                companyToUpdate.IndustryId = company.IndustryId;
            }

            _context.JobProviderCompanies.Update(companyToUpdate);
            await _context.SaveChangesAsync();

            return companyToUpdate;
        }




        public bool memberDeleteById(Guid id)
        {
            CompanyUser user = _context.CompanyUsers.Where(e => e.Id == id).FirstOrDefault();
            if (user != null)
            {
                _context.CompanyUsers.Remove(user);
                _context.SaveChanges();
                return true;
            }

            else
            {
                return false;
            }
        }

        public async Task<CompanyMemberDtos> AddMemberAsync(CompanyMemberDtos companyMember, Guid companyId)
        {
            companyMember.Company = companyId;
            var companyMemberDtos = mapper.Map<CompanyUser>(companyMember);

            var authUserDtos = mapper.Map<AuthUser>(companyMember);
            _context.CompanyUsers.Add(companyMemberDtos);
            _context.AuthUsers.Add(authUserDtos);
            await _context.SaveChangesAsync();

            return companyMember;
        }

        public async Task<bool> DeleteCompanyAsync(Guid companyId)
        {
            var company = await _context.JobProviderCompanies.FindAsync(companyId);
            if (company != null)
            {
                _context.JobProviderCompanies.Remove(company);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<JobProviderCompany>> GetAllCompaniesAsync()
        {
            return await _context.JobProviderCompanies.ToListAsync();
        }

    }
}

