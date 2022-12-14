using LoanApply.Data;
using LoanApply.Models.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanApply.Repositories
{
    public class ApplyLoanRepositry : IApplyLoanRepositry
    {
        private readonly BankManagementDbContext bankManagementDbContext;

        public ApplyLoanRepositry(BankManagementDbContext bankManagementDbContext)
        {
            this.bankManagementDbContext = bankManagementDbContext;
        }
        public async Task<List<LoanDetail>> GetAllLoanAsync(string userName)
        {
            return await bankManagementDbContext.LoanDetails?.Where(x => x.UserName == userName).ToListAsync();
        }

        public async Task<LoanDetail> GetLoanAsync(int loanId)
        {
            return await bankManagementDbContext.LoanDetails?.FirstOrDefaultAsync(x => x.LoanId == loanId);
        }

        public async Task<bool> SaveLoanDeatilAsync(LoanDetail loanDetail)
        {
            try
            {
                await bankManagementDbContext.LoanDetails.AddAsync(loanDetail);
                await bankManagementDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
