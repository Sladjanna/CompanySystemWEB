using DAL;
using Model;
using Services.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class CompanyServices : ICompanyServices
    {
        public Company GetCompanyByID(int companyID)
        {
            using (var ctx = new CompanyDbContext())
            {
                var company = ctx.Companies.SingleOrDefault(s => s.Id == (int)companyID);
                return company;
            }
        }

        public List<Company> GetAllCompanies()
        {
            using (var ctx = new CompanyDbContext())
            {
                return ctx.Companies.ToList();
            }
        }
    }
}
